namespace LisaResume.Back_End_Code.Classes
{
    public class Singleton : Translator
    {
        private Singleton()
        {
            // Prevent outside instantiation
        }

        public object DocumentClass { get; set; }

        private static readonly Singleton _singleton = new Singleton();

        public static Singleton GetSingleton()
        {
            return _singleton;
        }
    }
}
