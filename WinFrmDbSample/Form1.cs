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
    public partial class Form1 : Form
    {
        string strcon = "Data Source=.;Initial Catalog=sample;Integrated Security=True";
        SqlConnection cn;
        bool flag;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.ResetText();
            textBox4.Clear();
            textBox5.Text = null;
            textBox1.Focus();
            btnSave.Enabled = true;
            btnNew.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            flag = true;
            try
            {
                cn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into person_tbl (pid,pname,pfamily,tel,age,gender)" +
                    "values (@i,@n,@f,@t,@a,@g)";
                cmd.Parameters.AddWithValue("@i", textBox1.Text);
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.Parameters.AddWithValue("@f", textBox3.Text);
                cmd.Parameters.AddWithValue("@t", textBox4.Text);
                cmd.Parameters.AddWithValue("@a", textBox5.Text);
                if (rdMale.Checked)
                    cmd.Parameters.AddWithValue("@g", true);
                else
                    cmd.Parameters.AddWithValue("@g", false);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                flag = false;
                MessageBox.Show("Error!" + ex.Message);
            }
            finally
            {
                cn.Close();
                if (flag)
                    MessageBox.Show("record was saved in DataBase");
            }
            btnSave.Enabled = false; ;
            btnNew.Enabled = true;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            flag = true;
            try
            {
                cn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from person_tbl where pid=@i";
                cmd.Parameters.AddWithValue("@i", textBox1.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception exx)
            {
                flag = false;
                MessageBox.Show("Error!" + exx.Message);
            }
            finally
            {
                cn.Close();
                if (flag)
                    MessageBox.Show("record deleted in database");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flag = true;
            bool g=true;
            try
            {
                cn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update person_tbl set pname=@n , pfamily=@f ,tel=@t , age=@a , gender=@g where pid=@i";
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.Parameters.AddWithValue("@f", textBox3.Text);
                cmd.Parameters.AddWithValue("@t", textBox4.Text);
                cmd.Parameters.AddWithValue("@a", textBox5.Text);
                if (rdMale.Checked)
                    cmd.Parameters.AddWithValue("@g", true);
                else
                    cmd.Parameters.AddWithValue("@g", false);
                cmd.Parameters.AddWithValue("@i", textBox1.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception exx)
            {
                flag = false;
                MessageBox.Show("Error!" + exx.Message);
            }
            finally
            {
                cn.Close();
                if (flag)
                    MessageBox.Show("record Edited in database");
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

      
    }
}
