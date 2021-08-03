using System;
using System.Windows.Forms;

namespace RentVideoSystem
{
    public partial class Video : Form
    {
        int id;
        public Video(String typeVal,int idVal, String titleVal,String costVal,String copiesVal,String genre,String languageVal, DateTime yearVal)
        {
            InitializeComponent();
            id = idVal;
            saveBtn.Text = typeVal;
            titleTxt.Text = titleVal;
            priceTxt.Text = costVal;
            copyTxt.Text = copiesVal;
            genreTxt.Text = genre;
            langTxt.Text = languageVal;
            yearPK.Value = yearVal;
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (titleTxt.Text != "" && genreTxt.Text != "" && langTxt.Text != "" && priceTxt.Text != "")
            {
                if (saveBtn.Text == "Add")
                {
                    SqlQuery.AddData(titleTxt, genreTxt, priceTxt, langTxt, copyTxt, yearPK);
                }
                else
                {
                    SqlQuery.UpdateData(titleTxt, genreTxt, priceTxt, langTxt, copyTxt, yearPK, id.ToString());
                }
            }
        }
    }
}
