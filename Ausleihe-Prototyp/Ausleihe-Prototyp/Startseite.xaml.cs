using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Perception.Spatial;
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
    public sealed partial class Info : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public Info()
        {
            this.InitializeComponent();

            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            navigation.SelectedItem = navigation.MenuItems[0];
        }

        private void Timer_Tick(object sender, object e)
        {
            uhrzeit.Text = DateTime.Now.ToString("HH:mm");
        }

        private void navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            string page = args.SelectedItemContainer.Tag.ToString();
            anwendung.Text = page;
            switch (page)
            {
                case "info":
                    //contentFrame.Navigate(typeof(Impressum));
                    break;
                case "ausleihe":
                    contentFrame.Navigate(typeof(NeueAusleihe));
                    break;
            }
        }
    }
}
