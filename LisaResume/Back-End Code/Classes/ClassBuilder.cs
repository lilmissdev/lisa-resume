using System;
using System.Runtime.InteropServices;

namespace LisaResume.Back_End_Code.Classes
{
    static class ClassBuilder
    {
        public static T[] CreateArray<T>(int count) where T : new()
        {
            var array = new T[count];
            for ( var i = 0; i < count; i++ )
            {
                array[i] = new T();
            }

            return array;
        }

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
                                                 string lpszWindow);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        public static object ChooseClass(Translator.FutureDocType future, Translator.CurrentDocType current,
                                         string                   path)
        {
            switch ( future )
            {
                case Translator.FutureDocType.Json:
                {
                    return new JsonTranslator(current, future, path);
                }

                case Translator.FutureDocType.Xml:
                {
                    return new XmlTranslator(current, future, path);
                }

                case Translator.FutureDocType.Html:
                {
                    return new HtmlTranslator(current, future, path);
                }

                case Translator.FutureDocType.None:
                {
                    return null;
                }

                case Translator.FutureDocType.Error:
                {
                    return null;
                }

                default:
                {
                    return null;
                }
            }
        }
    }

    public static class DocTypeExtensions
    {
        public static Translator.FutureDocType ToFutureDocType(this Enum value)
        {
            switch ( value )
            {
                case Translator.FutureDocType.Json:
                {
                    return Translator.FutureDocType.Json;
                }

                case Translator.FutureDocType.Xml:
                {
                    return Translator.FutureDocType.Xml;
                }

                case Translator.FutureDocType.Html:
                {
                    return Translator.FutureDocType.Html;
                }

                case Translator.FutureDocType.Sql:
                {
                    return Translator.FutureDocType.Sql;
                }

                case Translator.FutureDocType.None:
                {
                    return Translator.FutureDocType.None;
                }

                case Translator.FutureDocType.Error:
                {
                    return Translator.FutureDocType.Error;
                }

                default:
                {
                    return Translator.FutureDocType.Error;
                }
            }
        }
    }
}