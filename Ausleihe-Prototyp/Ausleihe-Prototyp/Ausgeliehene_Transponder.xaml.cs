using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Ausleihe_Prototyp
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Ausgeliehene_Transponder : Page
    {
        public Ausgeliehene_Transponder()
        {
            this.InitializeComponent();
            ausleihe_info testausleihe = new ausleihe_info();

            testausleihe.matrikelnr = 12345;
            testausleihe.name = "Testname";
            testausleihe.transpondernr = 987654321;
            testausleihe.raumnr = 31;
            testausleihe.ausgeliehenam = "01.01.2020";

            DataGridTransponder.Items.Add(testausleihe);
        }




        public class ausleihe_info
        {
            public int matrikelnr { get; set; }
            public string name { get; set; }
            public int transpondernr { get; set; }
            public int raumnr { get; set; }
            public string ausgeliehenam { get; set; }
        }
    }
}
