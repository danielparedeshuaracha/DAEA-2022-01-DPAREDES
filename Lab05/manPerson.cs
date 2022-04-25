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

namespace Lab05
{
    public partial class manPerson : Form
    {
        SqlConnection con;
        public manPerson()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void manPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-NF47T9P\\LOCAL;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPersonID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el codigo: " + codigo);
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("EnrollmentDate", txtEnrollmentDate.Value);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
            {
                MessageBox.Show("Se ha modificado el registro correctamente");
            }
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            try
            {
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                }


            }catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }       
            
            con.Close();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();              
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                if (dgvListado.SelectedRows[0].Cells[3].Value.ToString()=="")
                {
                    txtHireDate.Format = DateTimePickerFormat.Custom;
                    txtHireDate.CustomFormat = " ";
                }
                else
                {
                    txtHireDate.Format = DateTimePickerFormat.Short;
                }
                if (dgvListado.SelectedRows[0].Cells[4].Value.ToString() == "")
                {
                    txtEnrollmentDate.Format = DateTimePickerFormat.Custom;
                    txtEnrollmentDate.CustomFormat = " ";
                }
                else
                {
                    txtEnrollmentDate.Format = DateTimePickerFormat.Short;
                }
                txtHireDate.Text = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dgvListado.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            con.Open();
            String Busqueda = "";
            if(txtFirstName.Text == "")
            {
                Busqueda = txtPersonID.Text;
            }
            else
            {
                Busqueda = txtFirstName.Text;
            }


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Busqueda";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = Busqueda;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }
    
    }
}
