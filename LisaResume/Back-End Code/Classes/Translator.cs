using System;

namespace LisaResume.Back_End_Code.Classes
{
    public class Translator
    {
        public enum CurrentDocType
        {
            Json,
            Xml,
            Html,
            Sql,
            None,
            Error
        }

        public enum FutureDocType
        {
            Json,
            Xml,
            Html,
            Sql,
            None,
            Error
        }

        public FutureDocType FutureDocumentType { get; set; }

        public CurrentDocType CurrentDocumentType { get; set; }
        public string ResumeFormat { get; set; }

        public string GetDocType(Enum CurrentDocType)
        {
            switch ( CurrentDocType )
            {
                case Translator.CurrentDocType.Json:
                {
                    return "Json";
                }

                case Translator.CurrentDocType.Xml:
                {
                    return "Xml";
                }

                case Translator.CurrentDocType.Html:
                {
                    return "Html";
                }

                case Translator.CurrentDocType.Sql:
                {
                    return "Sql";
                }

                case Translator.CurrentDocType.None:
                {
                    return "None";
                }

                case Translator.CurrentDocType.Error:
                {
                    return "Error";
                }

                default:
                {
                    return "";
                }
            }
        }

        public string GetFutureDocType(Enum FutureDocType)
        {
            switch (FutureDocType)
            {
                case Translator.FutureDocType.Json:
                {
                    return "Json";
                }

                case Translator.FutureDocType.Xml:
                {
                    return "Xml";
                }

                case Translator.FutureDocType.Html:
                {
                    return "Html";
                }

                case Translator.FutureDocType.Sql:
                {
                    return "Sql";
                }

                case Translator.FutureDocType.None:
                {
                    return "None";
                }

                case Translator.FutureDocType.Error:
                {
                    return "Error";
                }

                default:
                {
                    return "";
                }
            }
        }
    }
}
