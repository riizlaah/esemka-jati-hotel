using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsemkaJatiHotel.Models;

namespace EsemkaJatiHotel.Views
{
    public partial class ReqAdditionalItem : Form
    {

        EJHDBC DBC;
        BindingList<ReservationRequestItem> resvReqItems = new BindingList<ReservationRequestItem>();

        public ReqAdditionalItem()
        {
            InitializeComponent();
        }

        private void onAddReqItemClicked(object sender, EventArgs e)
        {

        }

        private void onQtyChanged(object sender, EventArgs e)
        {

        }
    }
}
