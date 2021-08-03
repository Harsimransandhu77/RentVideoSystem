using System.Data.SqlClient;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RentVideoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConnectionTest()
        {
            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-3P69FP5\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
            try
            {
                myCon.Open();
                Assert.IsTrue(true);
                myCon.Close();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }
        [TestMethod]
        public void CheckDate()
        {
            bool c=true;
            string query = "select Start,Due FROM BookingDetails;";
            SqlDataReader dr;
            try
            {
                SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-3P69FP5\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
                SqlCommand myCmd = new SqlCommand(query,myCon);
                myCon.Open();
                dr = myCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        c = true;
                        if(DateTime.Compare(Convert.ToDateTime(dr.GetValue(0).ToString()), Convert.ToDateTime(dr.GetValue(1).ToString())) >0 )
                        {
                            c = false;
                            break;
                        }
                    }
                    if(c)
                        Assert.IsTrue(false, "Invalid Booking Date");
                    else
                        Assert.IsTrue(true);
                    dr.Close();
                }
                myCon.Close();
            }
            catch (Exception exp)
            {
                Assert.IsTrue(false, exp.Message);
            }
        }
    }
}
/*

    public bool CheckDate(DateTime BookingDate, DateTime ReturnDate)
    {
        return (ReturnDate > BookingDate);
    }
    [TestMethod]
    public void BookingDateTest1()
    {
        bool a = CheckDate(new DateTime(2021, 7, 1), new DateTime(2021, 7, 5));
        Assert.IsTrue(a, "Invaid Booking Date");
    }

    [TestMethod]
    public void BookingDateTest2()
    {
        bool a = CheckDate(new DateTime(2021, 7, 10), new DateTime(2021, 7, 5));
        Assert.IsTrue(a, "Invaid Booking Date");
    }
}
}
 */
