using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        List<Ausleihe> nochda = new List<Ausleihe>();

        List<Ausleihe> datamangerlocal  = Datamanger.Ausleihen;


        private ObservableCollection<Ausleihe> Items;
        public Ausgeliehene_Transponder()
        {

           
        

            this.InitializeComponent();



            DataTable dt = GetDataTable();
           
            FillDataGrid(dt, MyDataGrid);
        }

        private static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Vorname", typeof(string));
            dt.Columns.Add("Nachname", typeof(string));
            dt.Columns.Add("Matrikelnummer", typeof(string));
            dt.Columns.Add("Transpondernummer", typeof(int));
            dt.Columns.Add("Ausgeliehen am", typeof(string));

            foreach (var x in Datamanger.Ausleihen)
            {
                if (x.abegegeben == false)
                    dt.Rows.Add(x.Student.Vorname ,x.Student.Nachname , x.Student.Matrikelnummer , x.Transponder.Transpondernummer , x.Ausgeliehenam);
            }
            return dt;
        }




        public static void FillDataGrid(DataTable table, DataGrid grid)
        {
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                grid.Columns.Add(new DataGridTextColumn()
                {
                    Header = table.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }

            var collection = new ObservableCollection<object>();
            foreach (DataRow row in table.Rows)
            {
                collection.Add(row.ItemArray);
            }

            grid.ItemsSource = collection;
        }
    }
}
