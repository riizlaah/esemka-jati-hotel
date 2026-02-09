using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EsemkaJatiHotel.Models;
using System.Diagnostics;

namespace EsemkaJatiHotel.Views
{
    public partial class CheckInReportViewer : Form
    {
        private ReportViewer reportViewer;
        EJHDBC DBC;
        public CheckInReportViewer(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            reportViewer = new ReportViewer { ProcessingMode = ProcessingMode.Local};
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
        }
        public void LoadCheckInReport(DateTime? Start = null, DateTime? End = null)
        {
            try
            {
                var repData = GetCheckInReports(Start, End);
                reportViewer.LocalReport.ReportEmbeddedResource = "EsemkaJatiHotel.CheckInReport.rdlc";
                ReportDataSource ds = new ReportDataSource
                {
                    Name = "CheckInDataSet",
                    Value = repData
                };
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(ds);
                ReportParameter[] repParams = new ReportParameter[]
                {
                    new ReportParameter("StartDate", Start.HasValue ? Start.Value.ToString("dd/MM/yyyy") : "First"),
                    new ReportParameter("EndDate", End.HasValue ? End.Value.ToString("dd/MM/yyyy") : "Last"),
                    new ReportParameter("PrintedDate", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("RecordCount", repData.Count.ToString())
                };
                reportViewer.LocalReport.SetParameters(repParams);
                reportViewer.RefreshReport();
                Debug.WriteLine("refreshed!");
            } catch(Exception e)
            {
                MessageBox.Show($"Error loading report: {e.Message}", "Error");
            }
        }
        private List<ReservationReport> GetCheckInReports(DateTime? Start = null, DateTime? End = null)
        {
            var query = DBC.ReservationRooms.Include("Room.RoomType").Include("Reservation.Employee")
                .Include("Reservation.Customer").AsQueryable();
            if (Start.HasValue) query = query.Where(r => r.CheckInDateTime >= Start.Value);
            if (End.HasValue) query = query.Where(r => r.CheckInDateTime <= End.Value);
            var reportData = query.AsEnumerable().Select(r => new ReservationReport 
            {
                ReservationDate = r.Reservation.DateTime,
                GuessName = r.Reservation.Customer.Name,
                RoomNumber = r.Room.RoomNumber,
                RoomPrice = r.Room.RoomType.Price,
                RoomType = r.Room.RoomType.Name,
                BookingCode = r.Reservation.BookingCode,
                CheckInDate = r.CheckInDateTime.Value,
                CheckOutDate = r.CheckOutDateTime.Value,
                DaysLong = (int)(r.CheckOutDateTime.Value - r.CheckInDateTime.Value).TotalDays,
            }).ToList();
            Debug.WriteLine(reportData.Count);
            return reportData;
        }
    }
}
