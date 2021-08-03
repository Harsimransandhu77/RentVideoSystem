using System;
using System.Windows.Forms;

namespace RentVideoSystem
{
    public partial class Booking : Form
    {
        int id, cost;

        // update database
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (customerCB.SelectedIndex != -1)
            {
                if (saveBtn.Text == "Return")
                {
                    int a = cost * Convert.ToInt32((endDate.Value - startDate.Value).TotalDays);
                    if (a == 0)
                        a = cost;
                    SqlQuery.UpdateData(customerCB, videoCB, startDate, endDate, id.ToString(), a);
                }
                else
                {
                    if (customerCB.SelectedIndex != -1)
                    {
                        SqlQuery.AddData(customerCB, videoCB, startDate, endDate);
                        customerCB.SelectedIndex = -1;
                        videoCB.SelectedIndex = -1;
                        startDate.Value = DateTime.Now;
                        endDate.Value = DateTime.Now;
                    }
                }
            }
        }

        private void customerCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerCB.SelectedIndex != -1)
            {
                        customerCB.Tag = SqlQuery.custID[customerCB.SelectedIndex];
            }
        }

        private void videoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoCB.SelectedIndex != -1)
            {
                videoCB.Tag = SqlQuery.videoID[videoCB.SelectedIndex];
            }
        }

        public Booking(String actionVal, int idVal, int cidVal, int vidVal, int costVal, String customerVal, String videoVal, String startVal, String dueVal)
        {
            SqlQuery.GetBooking();
            InitializeComponent();
            foreach (var a in SqlQuery.custName)
            {
                customerCB.Items.Add(a);
            }
            foreach (var a in SqlQuery.videoName)
            {
                videoCB.Items.Add(a);
            }
             id = idVal;
             cost = costVal;
             saveBtn.Text = actionVal;
             customerCB.Tag = cidVal;
             videoCB.Tag = vidVal;
             startDate.Text = startVal;
             endDate.Text = dueVal;
             if (id == 0)
             {
                 customerCB.SelectedIndex = -1;
                 videoCB.SelectedIndex = -1;
             }
             else
             {
                 customerCB.SelectedItem = customerVal;
                 videoCB.SelectedItem = videoVal;
             }
        }
    }
}