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
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
        }
        public void LoadCheckInReport(DateTime? Start = null, DateTime? End = null)
        {
            try
            {
                var repData = GetCheckInReports(Start, End);
                reportViewer.LocalReport.ReportEmbeddedResource = "EsemkaJatiHotel.Reports.CheckInReport.rdlc";
                ReportDataSource ds = new ReportDataSource
                {
                    Name = "CheckInDataset",
                    Value = repData
                };
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(ds);
                if(Start.HasValue && End.HasValue)
                {
                    ReportParameter[] repParams = new ReportParameter[]
                    {
                        new ReportParameter("StartDate", Start.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("EndDate", End.Value.ToString("dd/MM/yyyy")),
                        new ReportParameter("ReportTitle", "LAPORAN CHECK-IN HOTEL"),
                        new ReportParameter("PrintedDare", DateTime.Now.ToString("dd/MM/yyyy")),
                    };
                    reportViewer.LocalReport.SetParameters(repParams);
                }
                reportViewer.RefreshReport();
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
            var reportData = query.Select(r => new ReservationReport 
            {
                ReservationDate = r.Reservation.DateTime,
                GuessName = r.Reservation.Customer.Name,
                RoomNumber = r.RoomNumber,
                RoomPrice = r.RoomPrice,
                RoomType = r.RoomType,
                BookingCode = r.Reservation.BookingCode,
                CheckInDate = r.CheckInDateTime.Value,
                CheckOutDate = r.CheckOutDateTime.Value,
                DaysLong = (int)(r.CheckOutDateTime.Value - r.CheckInDateTime.Value).TotalDays,
            }).ToList();
            return reportData;
        }
    }
}
