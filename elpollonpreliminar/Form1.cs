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
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Forms;

namespace elpollonpreliminar
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        int cantidadventas = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabPage2.Parent = null;
            metroTabPage4.Parent = null;
            metroTabPage5.Parent = null;
            actualizar();
            pictureBox3.SendToBack();
            mtxtusu.Focus();
            ventas.Parent = null;
        }
        SQL s = new SQL();

        public void actualizar()
        {
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "pruebastec.database.windows.net";
            builder1.UserID = "alexis";
            builder1.Password = "Azure1234567";
            builder1.InitialCatalog = "elpollon";

            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from usuarios");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid4.DataSource = dt;
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from clientes");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                s.dgrid(gridalmacen, "select id,nombre,cantidad,precio from almacen2");
            }

        }

        private void btncsesion_Click(object sender, EventArgs e)
        {
            mlabelrol.Text = "Tu Rol Es: ";
            if (mlabelrol.Text == "Tu Rol Es: ")
            {
                metroTabPage1.Parent = metroTabControl1;
                metroTabPage2.Parent = null;
                metroTabPage4.Parent = null;
                metroTabPage5.Parent = null;

            }


            mtxtcontra.Text = "";
            mtxtusu.Text = "";
            btncsesion.Visible = false;
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                if (txtusu.Text != "")
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("delete usuarios where usuario=" + "'" + txtusu.Text + "'");
                        String sql = sb.ToString();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dt = new DataSet();
                        da.Fill(dt, "usuarios");

                    }
                    actualizar();

                    int texto = metroGrid4.RowCount;
                    Console.WriteLine(texto);
                    if (texto == 1)
                    {
                        advertencia.Text = "RECUERDA AGREGAR UN ADMINISTRADOR ANTES DE IRTE";
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese id");

            }


        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into usuarios values('" + txtusu.Text + "','" + txtcontra.Text + "','" + cmrol.SelectedItem + "'," + "'" + txtnombre.Text + "',"
                        + "'" + txtrfc.Text + "'" + ")");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "usuarios");

                }
                actualizar();


            }
            catch (Exception)
            {

                MessageBox.Show("Intente de nuevo");
            }


        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select usuario, contraseña,rol from usuarios where usuario = '" + mtxtusu.Text +
                        "'And contraseña = '" + mtxtcontra.Text + "' ");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "usuarios");

                    DataRow DR;
                    DR = dt.Tables["usuarios"].Rows[0];
                    if ((mtxtusu.Text == DR["usuario"].ToString()) || (mtxtcontra.Text == DR["contraseña"].ToString()))
                    {
                        btncsesion.Visible = true;

                        mlabelrol.Text = mlabelrol.Text + DR["rol"].ToString();
                        if (mlabelrol.Text == "Tu Rol Es: administrador")
                        {
                            metroTabPage1.Parent = null;
                            metroTabPage2.Parent = metroTabControl1;
                            metroTabPage4.Parent = metroTabControl1;
                            metroTabPage5.Parent = metroTabControl1;
                            ventas.Parent = metroTabControl1;
                            metroTabControl1.SelectedTab = metroTabPage4;

                        }

                        if (mlabelrol.Text == "Tu Rol Es: vendedor")
                        {
                            metroTabPage1.Parent = null;
                            metroTabPage2.Parent = null;
                            metroTabPage4.Parent = metroTabControl1;
                            metroTabPage5.Parent = null;
                            ventas.Parent = metroTabControl1;

                            metroTabControl1.SelectedTab = metroTabPage4;

                        }

                    }


                    connection.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Credenciales Incorrectas");
            }
        }

        private void btnbusc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select numero,nombre,direccion from clientes where numero=" + "'" + txtnum.Text + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    DR = dt.Tables["clientes"].Rows[0];
                    string nombre = DR["nombre"].ToString();
                    string direccion = DR["direccion"].ToString();


                    txtnomc.Text = nombre;
                    txtdirec.Text = direccion;

                    actualizar();
                }

            }

            catch (Exception)
            {

                MessageBox.Show("No existe ID");
            }
        }

        private void btnaddc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into clientes values(" + txtnum.Text + ",'" + txtnomc.Text + "','" + txtdirec.Text + "')");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                }
                actualizar();


            }
            catch (Exception)
            {

                MessageBox.Show("Error intente de nuevo");
            }
        }

        private void btnelimc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete clientes where numero=" + "'" + txtnum.Text + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                }
                actualizar();

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese número");

            }
        }

        private void btnmodc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("update clientes set nombre=" + "'" + txtnomc.Text + "',direccion='" + txtdirec.Text + "' where numero=" + txtnum.Text);
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                }
                actualizar();

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese número");

            }
        }

        private void btnmode_Click(object sender, EventArgs e)
        {
            //  try
            // {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pruebastec.database.windows.net";
            builder.UserID = "alexis";
            builder.Password = "Azure1234567";
            builder.InitialCatalog = "elpollon";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("update usuarios set usuario=" + "'" + txtusu.Text + "'" + ",contraseña='" + txtcontra.Text + "'"
                    + ",rol='" + cmrol.SelectedItem + "'" + ",nombre='" + txtnombre.Text + "'" + ",rfc='" + txtrfc.Text + "'" + " where usuario='" + txtusu.Text + "'");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                da.Fill(dt, "usuarios");

            }
            actualizar();

            /*   }
               catch (Exception)
               {

                   MessageBox.Show("No existe ese numero");

               }*/
        }

        private void metroTabControl1_Click(object sender, EventArgs e)
        {
           Ordenar nuevo = new Ordenar();
            nuevo.Show();
            FormProvider.MainMenu.Hide();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?",
                   "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
 
                e.Cancel = false;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {

        }

        private void txtprecioI_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnagregarI_Click(object sender, EventArgs e)
        {
            string ins = string.Format("insert into almacen2 values('{0}','{1}','{2}','{3}')",txtnombreI.Text,txtcantidadI.Text,txtprecioI.Text,cbcomplement.SelectedIndex);
            s.Exe(ins);
        }

        private void gridalmacen_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
     
            lblid.Text = gridalmacen.CurrentRow.Cells[0].Value.ToString();
            txtnombreI.Text = gridalmacen.CurrentRow.Cells[1].Value.ToString();
            txtcantidadI.Text = gridalmacen.CurrentRow.Cells[2].Value.ToString();
            txtprecioI.Text = gridalmacen.CurrentRow.Cells[3].Value.ToString();
            string p = string.Format("select * from almacen2 where id = '{0}'", lblid.Text);
            cbcomplement.SelectedIndex = int.Parse(s.getdata(p, "complemento"));
            // .Text = dgvinfo.CurrentRow.Cells[4].Value.ToString();
            //   cbrol.Text = dgvinfo.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnphoto_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            string upd = string.Format("update almacen2 set nombre = '{0}',cantidad='{1}',precio='{2}',complemento='{3}' where id = '{4}'",txtnombreI.Text,txtcantidadI.Text,txtprecioI.Text,cbcomplement.SelectedIndex,lblid.Text);
            s.Exe(upd);
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            string del = string.Format("delete from almacen2 where id = '{0}'",lblid.Text);
            s.Exe(del);
        }
        //
       
    }
}
