using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPDraw
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form f1 = new Form1();
            Application.Run(f1);
        }



        public static void WaitASecond()
        {
            Thread.Sleep(1000);
        }

        public static void RefreshDisplay()
        {
            Form1.ActiveForm.Refresh();
        }
    }
}
