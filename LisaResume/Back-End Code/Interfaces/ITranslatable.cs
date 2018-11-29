using System;

namespace LisaResume.Back_End_Code.Interfaces
{
    interface ITranslatable
    {
        Boolean isSaved { get; set; }
        string FilePath { get; set; }
        void Translate(Enum @enum);
        void Publish(string Path);
        void Save(String Text, String Path);
        void Load(String path, Enum @enum);
        Enum CheckDocType(String Path);
    }
}
