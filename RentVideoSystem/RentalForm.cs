using System;
using System.Windows.Forms;

namespace RentVideoSystem
{
    public partial class RentalForm : Form
    {
        public RentalForm()
        {
            InitializeComponent();
        }
        int cRow, vRow, bRow;
        int cID, vID, bID;
        private void videoGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (videoGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewRow row = videoGV.Rows[e.RowIndex];
                vRow = e.RowIndex;
                vID = Convert.ToInt32(videoGV.Rows[bRow].Cells["ID"].Value.ToString());
                String a = videoGV.Rows[vRow].Cells["Cost"].Value.ToString();
                Video v = new Video("Add", Convert.ToInt32(videoGV.Rows[vRow].Cells["ID"].Value.ToString()), videoGV.Rows[vRow].Cells["Title"].Value.ToString(), videoGV.Rows[vRow].Cells["Cost"].Value.ToString().Remove(a.Length - 2, 2), videoGV.Rows[vRow].Cells["Copies"].Value.ToString(), videoGV.Rows[vRow].Cells["Genre"].Value.ToString(), videoGV.Rows[vRow].Cells["Language"].Value.ToString(), new DateTime(Convert.ToInt32(videoGV.Rows[vRow].Cells["PublishYear"].Value.ToString()), 1, 1));
                v.Show();
                vID = -1;
            }
        }
        private void videoGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (videoGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewRow row = videoGV.Rows[e.RowIndex];
                vRow = e.RowIndex;
                vID = Convert.ToInt32(videoGV.Rows[bRow].Cells["ID"].Value.ToString());
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (vID != -1)
            {
                SqlQuery.DeleteVideo(vID);
                vID = -1;
                loadData();
            }
        }
        public void loadData()
        {
            SqlQuery.GetBooking(bookGV);
            SqlQuery.GetCustomer(custGV);
            SqlQuery.GetVideo(videoGV);
            SqlQuery.LoadLabel(movieLbl, customerLbl, custLbl, incomeLbl, videoLbl);
            custGV.Columns["ID"].Visible = false;
            bookGV.Columns["ID"].Visible = false;
            videoGV.Columns["ID"].Visible = false;
            videoGV.Columns["PublishYear"].Visible = false;
            videoGV.Columns["Language"].Visible = false;
            custGV.Columns["JoinDate"].Visible = false;
            custGV.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            custGV.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            videoGV.Columns["Cost"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            videoGV.Columns["Copies"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            videoGV.Columns["Genre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            bookGV.Columns["Booking Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            bookGV.Columns["Return Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            bookGV.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            custGV.ClearSelection();
            bookGV.ClearSelection();
            videoGV.ClearSelection();
        }
           private void Booking_Load(object sender, EventArgs e)
           {
               cID = -1;
               vID = -1;
               bID = -1;
               loadData();
           }
           private void issueBtn_Click(object sender, EventArgs e)
           {
               Booking b = new Booking("Issue",0,0,0,0,"","",DateTime.Now.ToString(), DateTime.Now.ToString());
               b.Show();
           }
           private void addCustBtn_Click(object sender, EventArgs e)
           {
               cID = -1;
               Customer c = new Customer("Add",0, "", "", "", DateTime.Now.ToString());
               c.Show();
           }
           private void RentalForm_Activated(object sender, EventArgs e)
           {
               loadData();
           }
           private void bookGV_CellClick(object sender, DataGridViewCellEventArgs e)
           {
               if (bookGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
               {
                   DataGridViewRow row = bookGV.Rows[e.RowIndex];
                   bRow = e.RowIndex;
                   bID = Convert.ToInt32(bookGV.Rows[bRow].Cells["ID"].Value.ToString());
               }
           }
           private void returnBtn_Click(object sender, EventArgs e)
           {
               if (bID != -1)
               {
                   Booking b = new Booking("Return", Convert.ToInt32(bookGV.Rows[bRow].Cells["ID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["CID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["VID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["Cost"].Value.ToString()), bookGV.Rows[bRow].Cells["Customer"].Value.ToString(), bookGV.Rows[bRow].Cells["Video"].Value.ToString(), bookGV.Rows[bRow].Cells["Booking Date"].Value.ToString(), bookGV.Rows[bRow].Cells["Return Date"].Value.ToString());
                   b.Show();
                   bID = -1;
               }
           }
           private void removeBtn_Click(object sender, EventArgs e)
           {
               if(bID!=-1)
               {
                   SqlQuery.DeleteBooking(bID);
                   bID = -1;
               }
               loadData();
           }
           private void editBtn_Click(object sender, EventArgs e)
           {
               if (vID != -1)
               {
                   String a = videoGV.Rows[vRow].Cells["Cost"].Value.ToString();
                   Video v = new Video("Edit", Convert.ToInt32(videoGV.Rows[vRow].Cells["ID"].Value.ToString()), videoGV.Rows[vRow].Cells["Title"].Value.ToString(), videoGV.Rows[vRow].Cells["Cost"].Value.ToString().Remove(a.Length - 2, 2), videoGV.Rows[vRow].Cells["Copies"].Value.ToString(), videoGV.Rows[vRow].Cells["Genre"].Value.ToString(), videoGV.Rows[vRow].Cells["Language"].Value.ToString(), new DateTime(Convert.ToInt32(videoGV.Rows[vRow].Cells["PublishYear"].Value.ToString()), 1, 1));
                   v.Show();
                   vID = -1;
               }
           }
           private void custGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               if (custGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
               {
                   DataGridViewRow row = custGV.Rows[e.RowIndex];
                   cRow = e.RowIndex;
                   cID = Convert.ToInt32(custGV.Rows[cRow].Cells["ID"].Value.ToString());
                   Customer c = new Customer("Return", Convert.ToInt32(custGV.Rows[cRow].Cells["ID"].Value.ToString()), custGV.Rows[cRow].Cells["Name"].Value.ToString(), custGV.Rows[cRow].Cells["Phone"].Value.ToString(), custGV.Rows[cRow].Cells["Address"].Value.ToString(), custGV.Rows[cRow].Cells["JoiningDate"].Value.ToString());
                   c.Show();
                   cID = -1;
               }
           }
           private void bookGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               if (bookGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
               {
                   DataGridViewRow row = bookGV.Rows[e.RowIndex];
                   bRow = e.RowIndex;
                   bID = Convert.ToInt32(bookGV.Rows[bRow].Cells["ID"].Value.ToString());
                   Booking b = new Booking("Return", Convert.ToInt32(bookGV.Rows[bRow].Cells["ID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["CID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["VID"].Value.ToString()), Convert.ToInt32(bookGV.Rows[bRow].Cells["Cost"].Value.ToString()), bookGV.Rows[bRow].Cells["Customer"].Value.ToString(), bookGV.Rows[bRow].Cells["Video"].Value.ToString(), bookGV.Rows[bRow].Cells["Booking Date"].Value.ToString(), bookGV.Rows[bRow].Cells["Return Date"].Value.ToString());
                   b.Show();
                   bID = -1;
               }
           }
           private void editCustBtn_Click(object sender, EventArgs e)
           {
               if (cID != -1)
               {
                   Customer c = new Customer("Edit", Convert.ToInt32(custGV.Rows[cRow].Cells["ID"].Value.ToString()), custGV.Rows[cRow].Cells["Name"].Value.ToString(), custGV.Rows[cRow].Cells["Phone"].Value.ToString(), custGV.Rows[cRow].Cells["Address"].Value.ToString(), custGV.Rows[cRow].Cells["JoinDate"].Value.ToString());
                   c.Show();
                   cID = -1;
               }
           }
           private void deleteCustBtn_Click(object sender, EventArgs e)
           {
               if (cID != -1)
               {
                   SqlQuery.DeleteCustomer(Convert.ToInt32(custGV.Rows[cRow].Cells["ID"].Value.ToString()));
                   cID = -1;
                   loadData();
               }
           }
           private void addBtn_Click(object sender, EventArgs e)
           {
               Video v = new Video("Add",0,"","","","","",DateTime.Now);
               v.Show();
           }
           private void custGV_CellClick(object sender, DataGridViewCellEventArgs e)
           {
               if (custGV.Columns.Count != 0 && e.RowIndex != -1 && e.ColumnIndex != -1)
               {
                   DataGridViewRow row = custGV.Rows[e.RowIndex];
                   cRow = e.RowIndex;
                   cID = Convert.ToInt32(custGV.Rows[cRow].Cells["ID"].Value.ToString());
               }
           }
       }
   }
    