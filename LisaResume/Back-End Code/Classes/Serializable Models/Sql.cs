//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Linq;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LisaResume.Back_End_Code.Classes.Serializable_Classes
//{
//    [System.Serializable]
//    public class Root
//    {
//        public Basics basics { get; set; } = new Basics();
//        public Location locations { get; set; } = new Location();
//        public Profiles[] profiles { get; set; } = ClassBuilder.CreateArray<Profiles>(10);
//        public Work[] work { get; set; } = ClassBuilder.CreateArray<Work>(10);
//        public Education[] education { get; set; } = ClassBuilder.CreateArray<Education>(10);
//        //public Awards[] awards { get; set; }
//        public Skills[] skill { get; set; } = ClassBuilder.CreateArray<Skills>(10);
//        public Volunteer[] volunteer { get; set; } = ClassBuilder.CreateArray<Volunteer>(10);
//        public Interests[] Interests { get; set; } = ClassBuilder.CreateArray<Interests>(10);
//        public Languages[] languages { get; set; } = ClassBuilder.CreateArray<Languages>(10);
//        public References[] references { get; set; } = ClassBuilder.CreateArray<References>(10);
//    }
//    [System.Serializable]
//    public class Basics
//    {
//        public int PID { get; set; }
//        public string name { get; set; }
//        public string label { get; set; }
//        public string email { get; set; }
//        public string phone { get; set; }
//        public string website { get; set; }
//        public string summary { get; set; }
//        public Location locations { get; set; } = new Location();
//        public Profiles[] profiles { get; set; } = ClassBuilder.CreateArray<Profiles>(10);
//        public string picture { get; set; }

//    }
//    [System.Serializable]
//    public class Volunteer
//    {
//        public int PID { get; set; }
//        public string organization { get; set; }
//        public string position     { get; set; }
//        public string website      { get; set; }
//        public string startDate    { get; set; }
//        public string endDate      { get; set; }
//        public string summary      { get; set; }
//        public Highlights[] highlights { get; set; } = ClassBuilder.CreateArray<Highlights>(10);
//    }
//    [System.Serializable]
//    public class Location
//    {
//        public int PID { get; set; }
//        public string address { get; set; }
//        public string postalCode { get; set; }
//        public string city { get; set; }
//        public string countryCode { get; set; }
//        public string region { get; set; }
//    }
//    [System.Serializable]
//    public class Profiles
//    {
//        public int PID { get; set; }
//        public string network { get; set; }
//        public string username { get; set; }
//        public string url { get; set; }
//    }
//    [System.Serializable]
//    public class Work
//    {
//        public int PID { get; set; }
//        public string company { get; set; }
//        public string position { get; set; }
//        public string website { get; set; }
//        public string startDate { get; set; }
//        public string endDate { get; set; }
//        public string summary { get; set; }
//        public Highlights[] highlights { get; set; } = ClassBuilder.CreateArray<Highlights>(10);
//    }
//    [System.Serializable]
//    public class Highlights
//    {
//        public int PID { get; set; }
//        public string highlights { get; set; }
//    }
//    [System.Serializable]
//    public class Education
//    {
//        public int PID { get; set; }
//        public string institution { get; set; }
//        public string area { get; set; }
//        public string studyType { get; set; }
//        public string startDate { get; set; }
//        public string endDate { get; set; }
//        public string gpa { get; set; }
//        public Courses[] courses { get; set; } = ClassBuilder.CreateArray<Courses>(10);
//    }
//    [System.Serializable]
//    public class Courses
//    {
//        public int PID { get; set; }
//        public string course { get; set; }
//    }
//    [System.Serializable]
//    public class Awards
//    {
//        [Column(IsPrimaryKey = true)]
//        public int PID { get; set; }
//        public string title { get; set; }
//        public string date { get; set; }
//        public string awarder { get; set; }
//        public string summary { get; set; }
//    }
//    [System.Serializable]
//    public class Skills
//    {
//        public int PID { get; set; }
//        public string name { get; set; }
//        public string level { get; set; }
//        public Keywords[] keywords { get; set; } = ClassBuilder.CreateArray<Keywords>(10);
//    }
//    [System.Serializable]
//    public class Keywords
//    {
//        public int PID { get; set; }
//        public string keywords { get; set; }
//    }
//    [System.Serializable]
//    public class Languages
//    {
//        public int PID { get; set; }
//        public string language { get; set; }
//        public string fluency { get; set; }
//    }
//    [System.Serializable]
//    public class Interests
//    {
//        public int PID { get; set; }
//        public string name { get; set; }
//        public Keywords[] keywords { get; set; } = ClassBuilder.CreateArray<Keywords>(10);
//    }
//    [System.Serializable]
//    public class References
//    {
//        public int PID { get; set; }
//        public string name { get; set; }
//        public string reference { get; set; }
//    }

//}
