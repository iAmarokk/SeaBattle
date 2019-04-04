using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public enum Status
    {
        indefinitely,
        miss,
        slash,
        kill,
        win
    }

    public struct Dot
    {
        public int x;
        public int y;
        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

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
            Application.Run(new FormGame());
        }
    }
}
