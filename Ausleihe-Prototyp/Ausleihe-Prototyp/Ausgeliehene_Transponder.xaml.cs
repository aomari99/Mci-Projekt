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
            string mtrnummer = ((Button)sender).Tag.ToString();
            Debug.WriteLine(mtrnummer);
            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false && x.Student.Matrikelnummer == mtrnummer)
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
    }
}
