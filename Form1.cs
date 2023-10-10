using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Reflection.Emit;

namespace Livestock_Tracking
{
    public partial class Login : Form
    {
        private Dictionary<string, string> userCredentials;
        public Login()
        {
            InitializeComponent();
            userCredentials = new Dictionary<string, string>
            {
                { "Thia", "Thia272" },
                { "user2", "password2" },
                {"admin", "pass" }
                // Add more user credentials as needed
            };
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
    }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            if (userCredentials.ContainsKey(username))
            {
                panel5.Visible = false;

                if (userCredentials.ContainsValue(password))
                {
                    this.Hide();

                    TrackingData dataForm = new TrackingData();
                    dataForm.Show();
                }

                else
                {
                    panel6.Visible = true;
                    return;
                }
            }

            else
            {
                panel5.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                panel6.Visible = true;
                panel5.Visible = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try {
                txtUsername.ForeColor = Color.Black;
            }
            catch (Exception ) {
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPassword.ForeColor = Color.Black;
            }
            catch (Exception)
            {
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }


