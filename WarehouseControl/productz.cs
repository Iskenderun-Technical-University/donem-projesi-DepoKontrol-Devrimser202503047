using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WarehouseControl
{
    public partial class productz : Form
    {
        public productz()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=WINZLOW;Initial Catalog=products;Integrated Security=True");
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        private void refresh() {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select*from products", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void refreshwstring(string sw)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sw, con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void productz_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                try { con.Open();
                    string del = "Delete from products where prod_name=@prod_name";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.AddWithValue("@prod_name", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla silindi!");
                    con.Close();


                } 
                
                catch {
                    MessageBox.Show("Herhangi bir ürün seçmediniz.");
                } 
            }
            else
                MessageBox.Show("Lütfen silmek istediğinizden emin olup, kutucuğu işaretleyiniz.");
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (cat_1.Checked == true){
                a= 1;
            }else if (cat_2.Checked == true)
            {
                a=2;
            }else if(cat_3.Checked==true){ a=3; };


            con.Open();
            string addin = "insert  into products(prod_categoryid,prod_name,prod_price,prod_quantity)values(@prod_categoryid,@prod_name,@prod_price,@prod_quantity)";
            cmd = new SqlCommand(addin, con);
            cmd.Parameters.AddWithValue("@prod_name", textBox_name.Text);
            cmd.Parameters.AddWithValue("@prod_price", Convert.ToInt32(textBox_price.Text));
            cmd.Parameters.AddWithValue("@prod_quantity", Convert.ToInt32(textBox_quantity.Text));
            cmd.Parameters.AddWithValue("@prod_categoryid", a) ;
            
            
            if (textBox_name ==  null || textBox_price == null || textBox_quantity == null )
            { MessageBox.Show("Lütfen içeriği doğru girdiğinizden ve boş bırakmadığnızdan emin olun."); }

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Ürün başarıyla depoya eklendi!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (searchtb.Text != "")
            {
                string sw = "select prod_name,prod_price,prod_quantity from products where prod_name like '" + searchtb.Text + "'";
                string qd = "select *from products where prod_name='" + searchtb.Text + "'";
                refreshwstring(sw);
            }
            else
            {
                refresh();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox2.Text = selectedRow.Cells[3].Value.ToString();
            
        }
    }
}
