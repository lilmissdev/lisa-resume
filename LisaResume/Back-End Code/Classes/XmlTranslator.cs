using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

using LisaResume.Back_End_Code;
using LisaResume.Back_End_Code.Classes;
using LisaResume.Back_End_Code.Classes.Serializable_Classes;
using LisaResume.Back_End_Code.Interfaces;

using Newtonsoft.Json;

using Formatting = Newtonsoft.Json.Formatting;

namespace LisaResume
{
    class XmlTranslator : Translator, ITranslatable
    {
        public root XmlRoot { get; set; }
        public XmlTranslator(CurrentDocType current, FutureDocType future, string path)
        {
            CurrentDocumentType = current;
            FutureDocumentType = future;
            FilePath = path;
        }
        public bool isSaved { get; set; }
        public string FilePath { get; set; }

        public void ToJson()
        {
            XmlDocument doc = new XmlDocument();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Components\LisaResume.xml");
            var xmlString = File.ReadAllText(path);
            doc.LoadXml(xmlString);
            doc.RemoveChild(doc.FirstChild);
            doc.RemoveChild(doc.FirstChild);
            path = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                 @"Components\DefaultLisaResume.json"));
            var json = JsonConvert.DeserializeObject<Rootobject>(path);
            var jsonText = JsonConvert.SerializeObject(json, Formatting.Indented);

            FilePath = Path.Combine(Path.GetDirectoryName(FilePath),
                                    Path.GetFileNameWithoutExtension(FilePath) + "." + GetFutureDocType(FutureDocumentType));

            Save(jsonText, FilePath);

            Publish(FilePath);
        }

        public void ToHtml()
        {
            FilePath = Path.Combine(Path.GetDirectoryName(FilePath),
                                    Path.GetFileNameWithoutExtension(FilePath) + "." + GetFutureDocType(FutureDocumentType));
        }
        public void Translate(Enum @enum)
        {
            var myEnum = @enum.ToFutureDocType();
            FutureDocumentType = myEnum;
            var singleton = Singleton.GetSingleton();
            singleton.CurrentDocumentType = CurrentDocumentType;
            singleton.FutureDocumentType = FutureDocumentType;
            var newClass = ClassBuilder.ChooseClass(FutureDocumentType, CurrentDocumentType, FilePath);

            switch (FutureDocumentType)
            {
                case FutureDocType.Json:
                    {
                        ToJson();
                        singleton.CurrentDocumentType = CurrentDocType.Xml;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
                case FutureDocType.Html:
                    {
                        ToHtml();
                        singleton.CurrentDocumentType = CurrentDocType.Xml;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
                case FutureDocType.Xml:
                    {
                        Load(FilePath, FutureDocumentType);
                        Publish(FilePath);
                        singleton.CurrentDocumentType = CurrentDocType.Xml;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
            }
        }

        public void Publish(string Path)
        {
            //Process notepad = Process.Start("notepad.exe", path);
        }

        public void Save(string text, string Path)
        {
            System.IO.File.WriteAllText(Path, text);
        }

        public void Load(string path, Enum @enum)
        {
            switch (@enum)
            {
                case CurrentDocType.Json:
                    {
                        var json = new JsonTranslator(CurrentDocumentType, FutureDocumentType, FilePath);
                        json.Translate(FutureDocumentType);
                        break;
                    }
                case CurrentDocType.Xml:
                    {
                        var serializer = new XmlSerializer(typeof(root));
                        StreamReader reader = new StreamReader(FilePath);
                        XmlRoot = (root)serializer.Deserialize(reader);
                        reader.Close();
                        break;
                    }
                case CurrentDocType.Html:
                    {
                        var html = new HtmlTranslator(CurrentDocumentType, FutureDocumentType, FilePath);
                        html.Translate(FutureDocumentType);
                        break;
                    }
            }
        }

        public Enum CheckDocType(string Path)
        {
            throw new NotImplementedException();
        }
    }
}
