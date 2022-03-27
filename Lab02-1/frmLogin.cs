using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> userCredentials = new Dictionary<string, string>
            {
                {"usuario1", "123"},
                {"usuario2", "1234"},
                {"usuario3", "12345"},

            };
            String username = txtUsuario.Text;
            String password = txtPassword.Text;

            string foundPassword;

            if (userCredentials.TryGetValue(username, out foundPassword) && (foundPassword == password))
            {

                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
