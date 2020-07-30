using System;
using System.Collections.Generic;
using System.Diagnostics;
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
           this.InitializeComponent();  
 
            
        }

        Transponder transkorrekt;
        Student studkorrekt;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 
        }


        private void matrikelnummer_eingetragen(object sender, RoutedEventArgs e)
        {

            if (box_matrikelnummer.Text != "")
            {
                List<Student> studi1 = Datamanger.Studenten;
                string mnummer = box_matrikelnummer.Text;
                string mnummerkorrekt = "";
                foreach (Student s in studi1)
                {
                    if (s.Matrikelnummer == mnummer)
                    {
                        block_matrikelnummer.Text = "";
                        mnummerkorrekt = mnummer;
                        box_vorname.Text = s.Vorname;
                        box_name.Text = s.Nachname;
                        break;
                    }
                }
                if (box_matrikelnummer.Text != mnummerkorrekt)
                {
                    box_vorname.Text = "";
                    box_name.Text = "";
                    block_matrikelnummer.Text = "Dieser Nutzer ist nicht im System vorhanden!";
                }
            }
            else {
                box_vorname.Text = "";
                box_name.Text = "";
                block_matrikelnummer.Text = "";
            }

        }

        private void raum_eingetragen(UIElement sender, LosingFocusEventArgs args)
        {

            if (box_raum.Text != "")
            {


                List<String> raumi = new List<string>();
                List<Ausleihe> ausli = Datamanger.Ausleihen;
                string mnummer = box_matrikelnummer.Text;
                string raumkorrekt = "";
                List<Student> studi1 = Datamanger.Studenten;
                List<Transponder> studitransis = new List<Transponder>();
                foreach (Student s in studi1)
                {
                    if (s.Matrikelnummer == mnummer)
                    {
                        studitransis = s.Berechtingungsliste;
                        studkorrekt = s;
                        break;
                    }
                }

                int i = 0;
                int istausgeliehen = 0;
                string raumnmmer = box_raum.Text;
                List<Transponder> alleTrans = Datamanger.Transponders;
                List<Transponder> studTrans = studkorrekt.Berechtingungsliste;
                List<Ausleihe> alleAusl = Datamanger.Ausleihen;
                foreach (Transponder aT in alleTrans) {
                    i = 0;
                    if (aT.Raumliste.Contains(raumnmmer)) {
                        foreach (Transponder sT in studTrans) {
                            if (sT == aT) {
                                foreach (Ausleihe aA in alleAusl) {
                                    if (aA.Transponder == sT && aA.abegegeben ==false) {
                                        i = 1;
                                        istausgeliehen = 1;
                                        break;
                                    }
                                }
                                if (i == 1)
                                {
                                    break;
                                }
                                block_raum.Text = "";
                                box_transponder.Text = sT.Transpondernummer.ToString();
                                transkorrekt = sT;
                                i = 2;
                                break;
                            }
                            

                        }
                        if (i != 1)
                        {
                            break;
                        }

                    }
                    if (i != 1) {
                        i = 3;
                    }
                    
                    
                    

                }
                if (istausgeliehen == 1)
                {
                    box_transponder.Text = "";
                    block_raum.Text = "Es gibt keinen freien Transponder für diesen Raum!";
                }
                else if (i == 0)
                {
                    box_transponder.Text = "";
                    block_raum.Text = "Der Nutzer besitzt keine Berechtigung für diesen Raum!";
                }
                else if (i == 3) {
                    box_transponder.Text = "";
                    block_raum.Text = "Diesen Raum gibt es im System nicht!";
                }


                /*
                foreach (Transponder t in studitransis)
                {
                    raumi = t.Raumliste;
                    i = 0;
                    if (raumi.Contains(box_raum.Text))
                    {
                        foreach (Ausleihe a in ausli)
                        {
                            if (a.Transponder == t)
                            {
                                i = 1;
                                break;
                            }
                        }
                        if (i == 1) { break; }
                        else
                        {


                            foreach (String r in raumi)
                            {
                                if (box_raum.Text == r)
                                {
                                    box_transponder.Text = t.Transpondernummer.ToString();
                                    raumkorrekt = box_raum.Text;
                                    transkorrekt = t;
                                    block_raum.Text = "";
                                    break;
                                }
                            }
                            // Wenn Raum gefunden wurde, breche ab

                            if (box_raum.Text == raumkorrekt)
                            {
                                break;
                            }

                        }

                    }
                }


                if (box_raum.Text != raumkorrekt && i == 1)
                {
                    block_raum.Text = "Es gibt keine freien Transponder für diesen Raum!";
                    box_transponder.Text = "";
                } 
                else
                {
                    box_transponder.Text = "";
                    block_raum.Text = "Dieser Nutzer besitzt keine Berechtigung auf diesen Raum!";
                }
                    
                        */
             
                


            }
            else {
                box_transponder.Text = "";
                block_raum.Text = "";
            }
            
            
        }

       

        private async void DisplayLocationPromptDialog()
        {
            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = "Sind Sie sich sicher?",
                Content = "Kontrollieren Sie bitte, ob die Person auf dem Ausweis auch die Person ist, die den Transponder ausleiht!",
                CloseButtonText = "Nein, das ist nicht die Person",
                PrimaryButtonText = "Ja, das ist die Person",
                Background = GetSolidColorBrush("#FF39428C")
              



            };

            ContentDialog erfolg = new ContentDialog
            {
                Title = "Info",
                Content = "Ausleihe erfolgreich hinzugefügt!",
                
                PrimaryButtonText = "OK",
                Background = GetSolidColorBrush("#FF39428C")




            };
            ContentDialog abbruch = new ContentDialog
            {
                Title = "Info",
                Content = "Ausleihe abgebrochen!",

                PrimaryButtonText = "OK",
                Background = GetSolidColorBrush("#FF39428C")




            };

            var result = await locationPromptDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {

                Datamanger.Ausleihen.Add(new Ausleihe(transkorrekt, studkorrekt, DateTime.Now.ToString("HH:mm") , box_raum.Text));
                erfolg.ShowAsync();
                Frame.Navigate(typeof(NeueAusleihe));
            }
            else 
            {
                abbruch.ShowAsync();
                Frame.Navigate(typeof(NeueAusleihe));
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
            if (box_matrikelnummer.Text == "") { 
                box_matrikelnummer.PlaceholderForeground = GetSolidColorBrush("FF960909");
                box_matrikelnummer.PlaceholderText = "Bitte geben Sie eine Matrikelnummer ein";
            }

            
            if (box_raum.Text == "")
            {
                box_raum.PlaceholderForeground = GetSolidColorBrush("FF960909");
                box_raum.PlaceholderText = "Bitte geben Sie eine Raumnummer ein";
            }

            if (box_unterschrift.Text == "")
            {
                box_unterschrift.PlaceholderForeground = GetSolidColorBrush("FF960909");
                box_unterschrift.PlaceholderText = "Bitte hinterlegen Sie eine Unterschrift";
            }

            if (box_raum.Text != "" && box_matrikelnummer.Text != "" && box_unterschrift.Text != "" && box_transponder.Text != "" && box_name.Text != "") {
                DisplayLocationPromptDialog();
            }
        }

        private void box_matrikelnummer_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Debug.WriteLine("enter mtr");
                box_raum.Focus(FocusState.Keyboard);
            }
        }
    }
}
