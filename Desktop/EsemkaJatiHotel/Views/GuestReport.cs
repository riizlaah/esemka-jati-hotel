using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EsemkaJatiHotel.Views
{
    public partial class GuestReport : Form
    {
        EJHDBC DBC;
        public GuestReport(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            Debug.WriteLine(DateTime.Now.Year);
            years.DataSource = Enumerable.Range(2016, (DateTime.Now.Year + 1) - 2016).ToList();
            RefreshChart();
        }
        public void RefreshChart()
        {
            var currYear = years.SelectedValue == null ? DateTime.Now.Year : (int)years.SelectedValue;
            guestsNumber.ChartAreas.Clear();
            guestsNumber.Series.Clear();
            guestsNumber.Titles.Clear();
            guestsNumber.Titles.Add($"Guests Year {currYear}");
            var chartArea = new ChartArea();
            chartArea.AxisX.Title = "Month";
            chartArea.AxisY.Title = "Guests Number";
            guestsNumber.ChartAreas.Add(chartArea);
            var series = guestsNumber.Series.Add("Guests");
            series.ChartType = SeriesChartType.Column;
            var datas = DBC.Reservations.Where(r => r.DateTime.Year == currYear)
                .GroupBy(r => r.DateTime.Month).Select(g => new {Month = g.Key, Count = g.Count()}
                );
            foreach (var item in datas)
            {
                var date = new DateTime(currYear, item.Month, 1);
                series.Points.AddY(date.ToString("MMM"), item.Count);
            }
        }

        private void onYearChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void onPreviewClicked(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}
