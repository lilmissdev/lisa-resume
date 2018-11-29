using System;
using System.IO;
using System.Text;
using LisaResume.Back_End_Code.Classes;
using LisaResume.Back_End_Code.Interfaces;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using LisaResume.Back_End_Code.Classes.Serializable_Classes;
using Formatting = System.Xml.Formatting;

namespace LisaResume.Back_End_Code
{
    class JsonTranslator : Translator, ITranslatable
    {

        public JsonTranslator(CurrentDocType current, FutureDocType future, string path)
        {
            CurrentDocumentType = current;
            FutureDocumentType = future;
            FilePath = path;
        }

        private Rootobject JsonObject { get; set; }
        public bool isSaved
        {
            get { return mIsSaved; }
            set { mIsSaved = value; }
        }

        private bool mIsSaved = false;
        public string FilePath { get; set; }


        private void ToXml()
        {
            Load(FilePath, CurrentDocumentType);
            var rootLevelJson = new RootLevel();
            XmlDocument xml;
            string xmlString;

            rootLevelJson.root.Add(JsonObject);

            xml = (XmlDocument)JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(rootLevelJson));
            xmlString = JsonConvert.SerializeXmlNode(xml);


            XmlElement root = xml.DocumentElement;
            XmlComment comment = xml.CreateComment("Comment");
            root.AppendChild(comment);

            using (MemoryStream mStream = new MemoryStream())
            using (XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                xml.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();
                mStream.Position = 0;
                StreamReader sReader = new StreamReader(mStream);
                string formattedXml = sReader.ReadToEnd();
                xmlString = formattedXml;
            }

            FilePath = Path.Combine(Path.GetDirectoryName(FilePath),
                                       Path.GetFileNameWithoutExtension(FilePath) + "." + GetFutureDocType(FutureDocumentType));

            Save(xmlString, FilePath);

            Publish(FilePath);
        }

        private void ToHtml()
        {
            FilePath = Path.Combine(Path.GetDirectoryName(FilePath),
                                    Path.GetFileNameWithoutExtension(FilePath) + "." + GetFutureDocType(FutureDocumentType));
            throw new NotImplementedException();
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
                case FutureDocType.Xml:
                    {
                        ToXml();
                        singleton.CurrentDocumentType = CurrentDocType.Xml;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
                case FutureDocType.Html:
                    {
                        ToHtml();
                        singleton.CurrentDocumentType = CurrentDocType.Html;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
                case FutureDocType.Json:
                    {
                        Load(FilePath, FutureDocumentType);
                        Publish(FilePath);
                        singleton.CurrentDocumentType = CurrentDocType.Json;
                        singleton.DocumentClass = newClass;
                        FilePath = Path.ChangeExtension(FilePath, GetFutureDocType(FutureDocumentType));
                        break;
                    }
            }
        }


        public void Publish(string path)
        {
            //Process notepad = Process.Start("notepad.exe", path);
        }

        public void Save(string text, string path)
        {
            File.WriteAllText(path, text);
        }

        public void Load(string path, Enum @enum)
        {
            if (!File.Exists(path))
                return;
            JsonObject = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(path));

            if (JsonObject.rootOfJson == null)
            {
                JsonObject =
                    JsonConvert
                       .DeserializeObject<Rootobject
                        >(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                        @"Components\LisaResume.json")));
            }
        }

        public Enum CheckDocType(string path)
        {
            var suffix = Path.GetExtension(path);
            return (CurrentDocType)Enum.Parse(typeof(CurrentDocType), suffix, true);
        }
    }
}
