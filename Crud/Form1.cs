using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conetar();
            MessageBox.Show("Conexion exitosa ");

            dataGridView1.DataSource = Llenar_grid();
        }

        public DataTable Llenar_grid()
        {
            Conexion.Conetar();
            DataTable dt = new DataTable();
            String consulta = "select * from Alumno";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conetar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if( (txtCodigo.Text.Length > 1) | (txtNombre.Text.Length > 1) | (txtApellidos.Text.Length > 1) | (txtDireccion.Text.Length > 1))
            {
                Conexion.Conetar();
                String insertar = "insert into Alumno (codigo, nombres, apellidos, direccion) values(@codigo, @nombres, @apellidos, @direccion)";
                SqlCommand cmdAg = new SqlCommand(insertar, Conexion.Conetar());
                cmdAg.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                cmdAg.Parameters.AddWithValue("@nombres", txtNombre.Text);
                cmdAg.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                cmdAg.Parameters.AddWithValue("@direccion", txtDireccion.Text);

                cmdAg.ExecuteNonQuery();

                MessageBox.Show("Registro agregado exitosamente");

                dataGridView1.DataSource = Llenar_grid();
            }
            else
            {
                MessageBox.Show("Campos vacios");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if ((txtCodigo.Text.Length > 1) | (txtNombre.Text.Length > 1) | (txtApellidos.Text.Length > 1) | (txtDireccion.Text.Length > 1))
            {
                Conexion.Conetar();
                String actualizar = "update Alumno set codigo = @codigo, nombres = @nombres, apellidos= @apellidos, direccion = @direccion where codigo = @codigo";
                SqlCommand comMo = new SqlCommand(actualizar, Conexion.Conetar());

                comMo.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                comMo.Parameters.AddWithValue("@nombres", txtNombre.Text);
                comMo.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                comMo.Parameters.AddWithValue("@direccion", txtDireccion.Text);

                comMo.ExecuteNonQuery();

                MessageBox.Show("Registro Modificado exitosamente");

                dataGridView1.DataSource = Llenar_grid();
            }
            else
            {
                MessageBox.Show("Campos vacios");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conetar();
            String eliminar = "delete Alumno where codigo = @codigo";
            SqlCommand comEl = new SqlCommand(eliminar, Conexion.Conetar());
            comEl.Parameters.AddWithValue("@codigo", txtCodigo.Text);

            comEl.ExecuteNonQuery();

            MessageBox.Show("Registro Eliminado exitosamente");

            dataGridView1.DataSource = Llenar_grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
        }
    }
}
