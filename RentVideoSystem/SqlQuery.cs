using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RentVideoSystem
{
    public class SqlQuery
    {

        // connection created
        private static SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-3P69FP5\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
        static SqlCommand myCmd;
        public static List<String> custName = new List<String>();
        public static List<String> custID = new List<String>();
        public static List<String> videoName = new List<String>();
        public static List<String> videoID = new List<String>();
        public static void GetCustomer(DataGridView gv)
        {
            SqlDataAdapter da = new SqlDataAdapter("getCustomer", myCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gv.DataSource = dataTable;
        }
        public static void GetVideo(DataGridView gv)
        {
            SqlDataAdapter da = new SqlDataAdapter("getVideo", myCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gv.DataSource = dataTable;
        }
        public static void GetBooking(DataGridView gv)
        {
            SqlDataAdapter da = new SqlDataAdapter("getBooking", myCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gv.DataSource = dataTable;
            gv.Columns["CID"].Visible = false;
            gv.Columns["VID"].Visible = false;
            gv.Columns["Cost"].Visible = false;
        }
        public static void GetBooking()
        {
            custID.Clear();
            videoID.Clear();
            custName.Clear();
            videoName.Clear();
            string query1 = "select ID,Title FROM VideoDetails;";
            string query2 = "select ID,Name FROM CustomerDetails;";
            SqlDataReader dr1, dr2;
            try
            {
                myCmd = new SqlCommand(query1, myCon);
                myCon.Open();
                dr1 = myCmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        videoID.Add(dr1.GetValue(0).ToString());
                        videoName.Add(dr1.GetString(1));
                    }
                    dr1.Close();
                }
                myCon.Close();

                myCmd = new SqlCommand(query2, myCon);
                myCon.Open();
                dr2 = myCmd.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        custID.Add(dr2.GetValue(0).ToString());
                        custName.Add(dr2.GetString(1));
                    }
                    dr2.Close();
                }
                myCon.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

            public static void DeleteCustomer(int id)
        {
            string query = "delete from CustomerDetails where ID=" + id + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show("Customer Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void DeleteVideo(int id)
        {
            string query = "delete from VideoDetails where ID=" + id + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show("Video Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                myCon.Close();
                MessageBox.Show(exp.Message);
            }
        }

        public static void DeleteBooking(int id)
        {
            string query = "delete from BookingDetails where ID=" + id + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void AddData(TextBox a, TextBox b, TextBox c,DateTimePicker d)
        {
            string query = "insert into CustomerDetails(Name,Phone,Address,JoinDate) values('" + a.Text + "','" + b.Text + "','" + c.Text + "','"+d.Text+"');";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show(a.Text + " Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a.Text = "";
                b.Text = "";
                c.Text = "";
                d.Value = DateTime.Now;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                myCon.Close();
            }
        }
        public static void AddData(ComboBox a, ComboBox b, DateTimePicker c, DateTimePicker d)
        {
            int count = 0;
            string q = "select Copies from VideoDetails where ID=" + Convert.ToInt32(b.Tag) + ";";
            SqlDataReader dataReader;
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(q, myCon);
                dataReader = myCmd.ExecuteReader();
                dataReader.Read();
                count = dataReader.GetInt32(0);
                dataReader.Close();
                myCon.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                myCon.Close();
            }
            if (count != 0)
            {
                string query = "insert into BookingDetails(CID,VID,Start,Due,Status,Cost) values(" + Convert.ToInt32(a.Tag) + "," + Convert.ToInt32(b.Tag) + ",'" + c.Value.ToString("dd MMMM yy") + "','" + d.Value.ToString("dd MMMM yy") + "','Issue',0); update VideoDetails set Copies=Copies-1 where ID=" + Convert.ToInt32(b.Tag) + "; ";
                try
                {
                    myCon.Open();
                    myCmd = new SqlCommand(query, myCon);
                    myCmd.ExecuteReader();
                    myCon.Close();
                    MessageBox.Show("Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    myCon.Close();
                }
            }
            else
            {
                MessageBox.Show("Video Copies Not Available...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void AddData(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e, DateTimePicker f)
        {
            string query = "insert into VideoDetails(Title,Genre,Cost,Language,Copies,PublishYear) values('" + a.Text + "','" + b.Text + "','" + Convert.ToInt32(c.Text) + "','" + d.Text + "'," + Convert.ToInt32(e.Text) + ",'" + f.Text + "');";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show(a.Text + " Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a.Text = "";
                b.Text = "";
                c.Text = "";
                d.Text = "";
                e.Text = "";
                f.Value = DateTime.Now;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void UpdateData(TextBox a, TextBox b, TextBox c,DateTimePicker d, string id)
        {
            string query = "update CustomerDetails set Name='" + a.Text + "',Phone='" + b.Text + "', Address='" + c.Text + "',JoinDate='"+d.Text+"' where ID=" + Convert.ToInt32(id) + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show(a.Text + " Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void UpdateData(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e, DateTimePicker f, String id)
        {
            string query = "update VideoDetails set Title='" + a.Text + "', Genre='" + b.Text + "', Cost='" + Convert.ToInt32(c.Text) + "', Language='" + d.Text + "', Copies=" + Convert.ToInt32(e.Text) + ",PublishYear='" + f.Text + "'  where ID=" + Convert.ToInt32(id) + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show(a.Text + " Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void UpdateData(ComboBox a, ComboBox b, DateTimePicker c, DateTimePicker d, String id, int i)
        {
            string query = "update BookingDetails set CID=" + Convert.ToInt32(a.Tag) + ", VID=" + Convert.ToInt32(b.Tag) + ", Start='" + c.Value.ToString("dd MMMM yy") + "',Due='" + d.Value.ToString("dd MMMM yy") + "',Status='Return',Cost="+i+" where ID=" + Convert.ToInt32(id) + "; update VideoDetails set Copies=Copies+1 where ID=" + b.Tag + "; ";
            try
            {
                myCon.Open();
                myCmd = new SqlCommand(query, myCon);
                myCmd.ExecuteReader();
                myCon.Close();
                MessageBox.Show("Total Rent Cost is " + i.ToString() + "$", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public static void LoadLabel(Label a, Label b, Label c, Label d,Label e)
        {
            string query1 = "select Top 1 v.Title FROM BookingDetails b,VideoDetails v where b.VID=v.ID group by b.VID,v.Title;";
            string query2 = "select Top 1 c.Name FROM BookingDetails b,CustomerDetails c where b.CID=c.ID group by b.CID,c.Name;";
            string query3 = "select count(ID) FROM CustomerDetails;";
            string query4 = "select sum(Cost) from BookingDetails;";
            string query5 = "select count(ID) FROM VideoDetails;";
            SqlDataReader dr1, dr2, dr3, dr4 ,dr5;
            try
            {
                myCmd = new SqlCommand(query1, myCon);
                myCon.Open();
                dr1 = myCmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    dr1.Read();
                    a.Text = dr1.GetString(0);
                    dr1.Close();
                }
                myCon.Close();

                myCmd = new SqlCommand(query2, myCon);
                myCon.Open();
                dr2 = myCmd.ExecuteReader();
                if (dr2.HasRows)
                {
                    dr2.Read();
                    b.Text = dr2.GetString(0);
                    dr2.Close();
                }
                myCon.Close();
             
                myCmd = new SqlCommand(query3, myCon);
                myCon.Open();
                dr3 = myCmd.ExecuteReader();
                if (dr3.HasRows)
                {
                    dr3.Read();
                    c.Text = dr3.GetValue(0).ToString();
                    dr3.Close();
                }
                myCon.Close();
                
             myCmd = new SqlCommand(query4, myCon);
             myCon.Open();
             dr4 = myCmd.ExecuteReader();
             if (dr4.HasRows)
             {
                    int i=0;
                    dr4.Read();
                 d.Text ="$"+ Convert.ToInt32(dr4.GetValue(0).ToString());
                    dr4.Close();
             }
             myCon.Close();

             myCmd = new SqlCommand(query5, myCon);
             myCon.Open();
             dr5 = myCmd.ExecuteReader();
             if (dr5.HasRows)
             {
                 dr5.Read();
                 e.Text = dr5.GetValue(0).ToString();
                    dr5.Close();
             }
             myCon.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
