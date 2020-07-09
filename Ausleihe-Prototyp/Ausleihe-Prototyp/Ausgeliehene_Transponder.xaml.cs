using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public sealed partial class Ausgeliehene_Transponder : Page
    {



       

        public ObservableCollection<string> suggestion = new ObservableCollection<string>();

        public ObservableCollection<string> filtersuggestion = new ObservableCollection<string>();

        public ObservableCollection<data> collection = new ObservableCollection<data>();
        public Ausgeliehene_Transponder()
        {



            this.DataContext = this;
            this.InitializeComponent();

           

            // DataTable dt = GetDataTable();

            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false)
                {



                    collection.Add(new data(x.Student.Vorname, x.Student.Nachname, x.Student.Matrikelnummer, x.Transponder.Transpondernummer, x.Ausgeliehenam));
                }
            }
            suchebox.ItemsSource = filtersuggestion;
            //  MyDataGrid.ItemsSource = collection;
            // FillDataGrid(dt, MyDataGrid);
        }




        public class data {
          public  string Vorname { get; set; }
            public string Nachname { get; set; }
            public string Matrikelnummer { get; set; }
            public int Transpondernummer { get; set; }
            public string Ausgeliehenam { get; set; }

            public data(string a, string b , string c , int d , string e)
            {
                Vorname = a; Nachname = b; Matrikelnummer = c; Transpondernummer = d; Ausgeliehenam = e;

            }
            }

   
        
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int trnummer = Int32.Parse(((Button)sender).Tag.ToString());
            Debug.WriteLine(trnummer);
            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false && x.Transponder.Transpondernummer == trnummer)
                {
                    x.abegegeben = true;
                }
            }
            collection.Clear();
            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false)
                {

                  

                    collection.Add(new data(x.Student.Vorname, x.Student.Nachname, x.Student.Matrikelnummer, x.Transponder.Transpondernummer, x.Ausgeliehenam));
                }
            }
             
            MyDataGrid.SelectedItem = null;
        }
        public string lasttag = "";
        private void MyDataGrid_Sorting(object sender, DataGridColumnEventArgs e)
        {


            // Remove sorting indicators from other columns
            try
            {
                foreach (var dgColumn in MyDataGrid.Columns)
                {
                    if (dgColumn.Tag != e.Column.Tag)
                    {
                        dgColumn.SortDirection = null;
                    }
                }
            }
            catch (Exception ex)
            {

            }


            //Use the Tag property to pass the bound column name for the sorting implementation 
            if (e.Column.Tag.ToString() == "Nachname")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                        orderby item.Nachname ascending
                                                                        select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                        orderby item.Nachname descending
                                                                        select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }else if (e.Column.Tag.ToString() == "Vorname")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Vorname ascending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Vorname descending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            else if (e.Column.Tag.ToString() == "Matrikelnummer")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Matrikelnummer ascending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Matrikelnummer descending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            else if (e.Column.Tag.ToString() == "Transpondernummer")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Transpondernummer ascending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Transpondernummer descending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            else if (e.Column.Tag.ToString() == "Ausgeliehenum")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Ausgeliehenam ascending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    MyDataGrid.ItemsSource = new ObservableCollection<data>(from item in collection
                                                                            orderby item.Ausgeliehenam descending
                                                                            select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }

        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (combo.SelectedIndex != -1)
            {
                suggestion.Clear();
                suchebox.IsEnabled = true;
                switch (combo.SelectedValue.ToString())
                {
                    case "Nachname":
                        foreach (var x in collection)
                        {
                            suggestion.Add(x.Nachname);
                        }
                        break;

                    case "Vorname":
                        foreach (var x in collection)
                        {
                            suggestion.Add(x.Vorname);
                        }
                        break;

                    case "Matrikelnummer":
                        foreach (var x in collection)
                        {
                            suggestion.Add(x.Matrikelnummer);
                        }
                        break;


                    case "Transpondernummer":
                        foreach (var x in collection)
                        {
                            suggestion.Add(x.Transpondernummer.ToString());
                        }
                        break;

                    case "Ausgeliehen um":
                        foreach (var x in collection)
                        {
                            suggestion.Add(x.Ausgeliehenam);
                        }
                        break;
                }
                filtersuggestion.Clear();
                foreach (var x in suggestion)
                {
                    filtersuggestion.Add(x);
                }
            }
        }

        private void suchebox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                filtersuggestion.Clear();
                foreach (var x in suggestion)
                {
                    if(x.ToUpper().Contains(suchebox.Text.ToUpper()))
                     filtersuggestion.Add(x);
                }
            }
        }

        private void suchebox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                suchebox.Text = args.ChosenSuggestion.ToString();
            }
            else
            {
                collection.Clear();
                foreach (var y in Datamanger.Ausleihen)
                {
                    if (y.abegegeben == false )
                    {

                        switch (combo.SelectedValue.ToString())
                        {
                            case "Nachname":
                                if (y.Student.Nachname == suchebox.Text)
                                {
                                    collection.Add(new data(y.Student.Vorname, y.Student.Nachname, y.Student.Matrikelnummer, y.Transponder.Transpondernummer, y.Ausgeliehenam));
                                }
                                break;

                            case "Vorname":
                                if (y.Student.Vorname == suchebox.Text)
                                {
                                    collection.Add(new data(y.Student.Vorname, y.Student.Nachname, y.Student.Matrikelnummer, y.Transponder.Transpondernummer, y.Ausgeliehenam));
                                }
                                break;

                            case "Matrikelnummer":
                                if (y.Student.Matrikelnummer == suchebox.Text)
                                {
                                    collection.Add(new data(y.Student.Vorname, y.Student.Nachname, y.Student.Matrikelnummer, y.Transponder.Transpondernummer, y.Ausgeliehenam));
                                }
                                break;


                            case "Transpondernummer":
                                if (y.Transponder.Transpondernummer.ToString() == suchebox.Text)
                                {
                                    collection.Add(new data(y.Student.Vorname, y.Student.Nachname, y.Student.Matrikelnummer, y.Transponder.Transpondernummer, y.Ausgeliehenam));
                                }
                                break;

                            case "Ausgeliehen um":
                                if (y.Ausgeliehenam == suchebox.Text)
                                {
                                    collection.Add(new data(y.Student.Vorname, y.Student.Nachname, y.Student.Matrikelnummer, y.Transponder.Transpondernummer, y.Ausgeliehenam));
                                }
                                break;
                        }

                      
                    }
                }

                MyDataGrid.SelectedItem = null;
            }
           
        }

        private void suchebox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
          //  Debug.WriteLine("Hello world");
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            suchebox.Text = "";
            
            collection.Clear();
            combo.SelectedIndex = -1;
            suchebox.IsEnabled = false;
            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false)
                {



                    collection.Add(new data(x.Student.Vorname, x.Student.Nachname, x.Student.Matrikelnummer, x.Transponder.Transpondernummer, x.Ausgeliehenam));
                }
            }

            MyDataGrid.SelectedItem = null;
        }
    }
}
