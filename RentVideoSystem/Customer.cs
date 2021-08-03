using System;
using System.Windows.Forms;

namespace RentVideoSystem
{
    public partial class Customer : Form
    {
        int id;
        public Customer(String typeVal,int idVal,String nameVal, String cnctVal, String addVal, String dateVal)
        {
            InitializeComponent();
            nameTxt.Text =nameVal;
            phoneTxt.Text =cnctVal;
            addressTxt.Text =addVal;
            jDateTxt.Text =dateVal;
            saveBtn.Text = typeVal;
            id = idVal;
        }

        // save to database

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "" && phoneTxt.Text != "" && addressTxt.Text != "")
            {
                if (saveBtn.Text == "Add")
                {
                    SqlQuery.AddData(nameTxt, phoneTxt, addressTxt, jDateTxt);
                }
                else
                {
                    SqlQuery.UpdateData(nameTxt, phoneTxt, addressTxt, jDateTxt, id.ToString());
                }
            }
        }
    }
}