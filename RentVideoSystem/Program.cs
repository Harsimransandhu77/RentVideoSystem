using System;
using System.Windows.Forms;

namespace RentVideoSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RentalForm());
        }
    }
}