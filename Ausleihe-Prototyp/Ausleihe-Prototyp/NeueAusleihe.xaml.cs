using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
            try { this.InitializeComponent(); }
            catch { // 
                
            }

            
            
        }

        // string unterschrift;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 
        }


        private void matrikelnummer_eingetragen(object sender, RoutedEventArgs e)
        {
            // Wenn Matrikelnummer im System
            box_vorname.Text = "Max";
            box_name.Text = "Moschi";
            // Anzeigen von vorname und name in box_varname und box_name
            // Ansonsten gib Text in Rot aus und rotes ausrufezeichen daneben
        }

        private void raum_eingetragen(UIElement sender, LosingFocusEventArgs args)
        {
            /*
             student studi1 = where student.matrikelnummer = matrikelnummer
             
            Wenn keine Berechtigung auf Raum ist, gib Text in Rot aus und rotes ausrufezeichen daneben
            
            get Transponder where Raum=raumnummer
            // Anzeigen von passendem Transponder in box_transponder



             */
            
        }

       

        private async void DisplayLocationPromptDialog()
        {
            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = "Sind Sie sich Sicher?",
                Content = "Kontrolieren Sie das die Person auf dem Ausweiß gleich der Person vor Ihnen ist ?",
                CloseButtonText = "Nein",
                PrimaryButtonText = "Ja",
                Background = GetSolidColorBrush("#FF39428C")
              



            };

           
            var result = await locationPromptDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
               
            }
            else 
            {
             
            }
  
        }
        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }
        private void unterschrift_einfügen(object sender, RoutedEventArgs e)
        {
            // unterschrift = "dummy";
            // ändere Text in unterschrift zu [Unterschrift eingefügt]
            box_unterschrift.Text = "[Unterschrift eingefügt]";
        }

        private void button_hinzu_Click(object sender, RoutedEventArgs e)
        {
            DisplayLocationPromptDialog();
        }
    }
}
