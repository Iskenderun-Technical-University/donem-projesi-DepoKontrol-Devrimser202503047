using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WarehouseControl
{
    public partial class sellinscr : Form
    {
        public sellinscr()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection("Data Source=WINZLOW;Initial Catalog=products;Integrated Security=True");
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        private void refresh()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select*from products", con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
        
        private void sellinscr_Load(object sender, EventArgs e)
        {
            
            this.productsTableAdapter.Fill(this.productsDataSet.products);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            textBox1.Text = selectedRow.Cells[3].Value.ToString();
            prodprice.Text = selectedRow.Cells[4].Value.ToString();
            id_holder.Text = selectedRow.Cells[0].Value.ToString();
            q_holder.Text = selectedRow.Cells[2].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string del = "Update products set prod_quantity=@kalan where prod_id=@prod_id";
               
            
            SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("@prod_id", Convert.ToInt32(id_holder.Text));
            int a = Convert.ToInt32(howmany.Text);
            int b = Convert.ToInt32(q_holder.Text);
            int c = b - a;

            cmd.Parameters.AddWithValue("@kalan", c );
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ürün başarıyla satıldı!");
            con.Close();
        }
    }
}
