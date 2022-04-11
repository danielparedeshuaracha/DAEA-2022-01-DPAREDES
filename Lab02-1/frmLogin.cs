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

namespace Lab02_1
{
    public partial class frmLogin : Form
    {
        SqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String user = txtUsuario.Text;
            String password = txtPassword.Text;
            String str = "Server=DESKTOP-NF47T9P\\LOCAL;Database=School;Integrated Security = true";
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                Console.WriteLine("Conectado con exito");
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@usuario_nombre";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Value = user;
                    cmd.Parameters.Add(param);

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@usuario_password";
                    param1.SqlDbType = SqlDbType.NVarChar;
                    param1.Value = password;
                    cmd.Parameters.Add(param1);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        PrincipalMDI principal = new PrincipalMDI();
                        reader.Close();
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Datos ingresados incorrectos");
                    }
                }
                else
                {
                    Console.WriteLine("La conexion esta cerrada.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }
    }
}
