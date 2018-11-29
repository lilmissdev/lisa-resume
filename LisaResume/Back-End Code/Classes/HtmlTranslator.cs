using System;

using LisaResume.Back_End_Code.Interfaces;

namespace LisaResume.Back_End_Code.Classes
{
    class HtmlTranslator : Translator, ITranslatable
    {
        public HtmlTranslator(CurrentDocType current, FutureDocType future, string path)
        {
            CurrentDocumentType = current;
            FutureDocumentType = future;
        }
        public bool isSaved { get; set; }
        public string FilePath { get; set; }
        public void Translate(Enum @enum)
        {
            throw new NotImplementedException();
        }

        public void Publish(string Path)
        {
            throw new NotImplementedException();
        }


        public void Save(string text, string Path)
        {
            throw new NotImplementedException();
        }

        public void Load(string path, Enum @enum)
        {
            throw new NotImplementedException();
        }

        public Enum CheckDocType(string Path)
        {
            throw new NotImplementedException();
        }
    }
}
