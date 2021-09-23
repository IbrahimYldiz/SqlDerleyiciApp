using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlDerleyiciApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sorgu,list;
        SqlConnection SqlConnection = new SqlConnection();

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://nasilbasarirsin.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sorgu = richTextBox1.Text.ToLower().Trim();


            if (sorgu.StartsWith("use"))
            {
                SqlConnection.ConnectionString = @"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=" + sorgu.Remove(0, 4) + "; Integrated Security = True";
                MessageBox.Show(sorgu + " database seçildi");
                //list = richTextBox2.Text.ToLower().Trim();

                
            }list = sorgu;

            if (sorgu.StartsWith("select")) { 
            try
            {
                SqlConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(list, SqlConnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
            SqlConnection.Close();
            //list = sorgu;

             }
                catch
                {
                    MessageBox.Show("Hatalı Giriş ");
                }
            }
            else { 

            try
            {
                if (SqlConnection.State == ConnectionState.Closed)
                {
                    SqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand(sorgu, SqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlConnection.Close();

                SqlDataAdapter da1 = new SqlDataAdapter(sorgu, SqlConnection);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş ");
            }
            }

        }
    }

        

        
}

