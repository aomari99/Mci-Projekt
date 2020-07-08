using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace Ausleihe_Prototyp
{
    public class Student
    {
        public string Matrikelnummer;
        public string Vorname;
        public string Nachname;

        public List<Transponder> Berechtingungsliste;

        public Student(string _matr,string _vorname, string _nachname , List<Transponder> _bere)
        {
            Matrikelnummer = _matr;
            Vorname = _vorname;
            Nachname = _nachname;
            Berechtingungsliste = _bere;
        }
    }
    public class Transponder
    {
        public int Transpondernummer;
        public List<string> Raum ;

        public Transponder(int _tnr , List<string> raume)
        {
            Transpondernummer = _tnr;
            Raum = raume;
        }
    }
    

    public class Ausleihe
    {
        public Transponder Transponder;
        public Student Student;
        public string Ausgeliehenam;
        public bool abegegeben = false;

        public Ausleihe(Transponder _tr ,Student student , string datum)
        {
            Transponder = _tr;
            Student = student;
            Ausgeliehenam = datum;


        }
    }

}
