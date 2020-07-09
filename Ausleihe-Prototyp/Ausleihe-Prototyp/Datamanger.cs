using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ausleihe_Prototyp
{
   public static class Datamanger
    {
      

        public static List<Ausleihe> Ausleihen = new List<Ausleihe>();
        public static List<Student> Studenten = new List<Student>();
        public static List<Transponder> Transponders = new List<Transponder>();
        public static void init()
        {
            Transponder t1 = new Transponder(1, new List<string>{ "1.001", "1.002", "1.003" });
            Transponder t2 = new Transponder(2, new List<string>{ "1.004", "1.005", "1.006" });
            Transponder t3 = new Transponder(3, new List<string>{ "1.007", "1.008", "1.009" });
            Transponder t4 = new Transponder(4, new List<string>{ "2.001", "2.002", "2.003" });
            Transponder t5 = new Transponder(5, new List<string>{ "3.001", "3.002", "3.003" });
            Transponder t6 = new Transponder(6, new List<string> { "1.001", "1.002", "1.003" });
            Transponder t7 = new Transponder(7, new List<string> { "1.004", "1.005", "1.006" });
            Transponder t8 = new Transponder(8, new List<string> { "1.007", "1.008", "1.009" });
            Transponder t9 = new Transponder(9, new List<string> { "2.001", "2.002", "2.003" });
            Transponder t10 = new Transponder(10, new List<string> { "3.001", "3.002", "3.003" });

            Transponders = new List<Transponder> { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };

            Student student1 = new Student("11100001", "Albino", "Apfelbaum", new List<Transponder>{ t1,t2,t3 });
            Student student2 = new Student("11100002", "Bärbel", "Baumchrist", new List<Transponder> { t2, t3, t4 });
            Student student3 = new Student("11100003", "Carolin", "Christdamm", new List<Transponder> { t3, t4, t5 });
            Student student4 = new Student("11100004", "Damian", "Dammenkel", new List<Transponder> { t4, t5, t6 });
            Student student5 = new Student("11100005", "Erik", "Enkelfüger", new List<Transponder> { t5, t6, t7 });
            Student student6 = new Student("11100006", "Frank", "Fügergang", new List<Transponder> { t6, t7, t8 });
            Student student7 = new Student("11100007", "Günther", "Ganghalter", new List<Transponder> { t7, t8, t9 });
            Student student8 = new Student("11100008", "Hans", "Halter", new List<Transponder> { t8, t9, t10 });

            Studenten = new List<Student> { student1,student2,student3,student4,student5,student6,student7,student8};

            Ausleihe a1 = new Ausleihe(t1, student1, "12:33");
            Ausleihe a2 = new Ausleihe(t2, student2, "12:44");
            Ausleihe a3 = new Ausleihe(t3, student3, "13:03");
            Ausleihe a4 = new Ausleihe(t4, student4, "14:06");
            Ausleihe a5 = new Ausleihe(t5, student5, "14:40");
            Ausleihe a6 = new Ausleihe(t6, student5, "15:00");
            Ausleihe a7 = new Ausleihe(t7, student5, "15:10");
            Ausleihe a8 = new Ausleihe(t8, student6, "15:20");
            Ausleihe a9 = new Ausleihe(t9, student7, "11:11");
            Ausleihe a10 = new Ausleihe(t10, student8, "12:22");

            Ausleihen = new List<Ausleihe> { a9, a10 , a2,a3,a5,a6,a7,a8};
            
        }

        public static void addAusleihe(Transponder _tr, Student student, string datum)
        {
            Ausleihen.Add(new Ausleihe(_tr, student, datum)) ;
        }

   
    }
}
