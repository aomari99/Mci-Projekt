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
    public sealed partial class NeueAusleihe : Page
    {
        public NeueAusleihe()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 
        }

        
        /*
        private void button_hinzu_click(object sender, RoutedEventArgs e)
        {
            if (!PopUp1.IsOpen) { PopUp1.IsOpen = true; }
            
            // Pop-Up anzeigen lassen
            // Hinzufuegen von Neuer Ausleihe in Aktuell-Ausgeliehene-Transponder
            // Sperren des Transponders von 
        }
        */

        private void matrikelnummer_eingetragen(object sender, RoutedEventArgs e)
        {
            // Wenn Matrikelnummer im System
            // Anzeigen von vorname und name in box_varname und box_name
            // Ansonsten gib Text in Rot aus und rotes ausrufezeichen daneben
        }

        private void raum_eingetragen(UIElement sender, LosingFocusEventArgs args)
        {
            // Wenn keine Berechtigung auf Raum ist, gib Text in Rot aus und rotes ausrufezeichen daneben
            // Anzeigen von passendem Transponder in box_transponder
        }

        private void Button_Click_Ja(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Nein(object sender, RoutedEventArgs e)
        {

        }
    }
}
