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

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection con;

        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public string username;

        public Form2()
        {
            InitializeComponent();
        }

        private void aaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hesap boş");
        }

        private void bbbToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "Hoşgeldin"+ " " + username;
            giris();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void giris()
        {
            try
            {
                //sql bağlantısını kurdum.
                con = new SqlConnection("server=localhost; Database=okul; Integrated Security=true;");
                // tablomu seçtim.
                da = new SqlDataAdapter("Select * From ogrenci", con);
                ds = new DataSet();
                con.Open();

                da.Fill(ds, "ogrenci");
                //datagridview adı neyse onu yazdım.

                dataGridView1.DataSource = ds.Tables["ogrenci"];
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı kurulamadı.");
                throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            MessageBox.Show("Başarıyla eklendi.");
            cmd.Connection = con;
            cmd.CommandText = "insert into ogrenci(ogrenci_no,ogrenci_ad,ogrenci_soyad,ogrenci_sehir) values (" + textBox3.Text + ",'" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            giris();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from ogrenci where ogrenci_no=" + textBox3.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            giris();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "update ogrenci set ogrenci_ad='" + textBox1.Text + "',ogrenci_soyad='" + textBox4.Text + "',ogrenci_sehir='" + textBox2.Text + "' where ogrenci_no=" + textBox3.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            giris();
        }
    }
}
