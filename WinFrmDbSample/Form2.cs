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

namespace WinFrmDbSample
{
    public partial class Form2 : Form
    {
        string strcon = "Data Source=.;Initial Catalog=sample;Integrated Security=True";
        SqlConnection cn;
        bool flag;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("Select * from person_tbl", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show("Error!" + ex.Message);
            }
            finally
            {
                cn.Close();
              
            }
        }
    }
}
