using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseControl
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sellinscr sellinscr = new sellinscr(); 
            sellinscr.Show();
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productz productz = new productz();
            productz.Show();
            
        }
    }
}
