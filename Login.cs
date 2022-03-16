using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golden_Village
{
    public partial class Login : Form
    {
        SqlConnection sqlcn;
        public Login()
        {
            InitializeComponent();
            sqlcn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahajalal\Desktop\Golden Village\Golden Village\mysql.mdf;Integrated Security=True");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string pass;
        private void loginbtn_Click(object sender, EventArgs e)
        {

            sqlcn.Open();

            SqlCommand cmd = new SqlCommand("select password from users where username = '" + username.Text + "';", sqlcn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                pass = read["password"].ToString();
            }
            if (pass == password.Text)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("Plese Enter the Correct User Name And Password");
            }

            sqlcn.Close();

        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {
            password.isPassword = true;
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                password.Focus();
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginbtn.PerformClick();
            }
        }
    }
}
