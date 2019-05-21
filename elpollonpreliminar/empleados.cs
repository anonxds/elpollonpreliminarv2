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
using MetroFramework.Forms;

namespace elpollonpreliminar
{
    public partial class empleados : MetroForm
    {
        public empleados()
        {
            InitializeComponent();
        }
        Form1 agarrar = new Form1();

        private void empleados_Load(object sender, EventArgs e)
        {
            lblopcion.Text =Form1.opcion;
            string id = Form1.id;
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "pruebastec.database.windows.net";
            builder1.UserID = "alexis";
            builder1.Password = "Azure1234567";
            builder1.InitialCatalog = "elpollon";



            if (Form1.opcion == "Eliminar")
            {
                txtnombre.Enabled = false;
                txtcontra.Enabled = false;
                txtrfc.Enabled = false;
                cmrol.Enabled = false;

                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from usuarios where Id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "usuarios");
                    DataRow DR;
                    DR = dt.Tables["usuarios"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string rfc = DR["rfc"].ToString();
                    string usuario = DR["usuario"].ToString();
                    string contraseña = DR["contraseña"].ToString();
                    string rol = DR["rol"].ToString();

                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnombre.Text = nombre;
                    txtrfc.Text = rfc;
                    txtusu.Text = usuario;
                    txtcontra.Text = contraseña;
                    cmrol.SelectedItem = rol;

                    //txtDescripcionI.Text = descripcion;
                    // cbcomplement.SelectedItem = complemento;
                    connection.Close();
                }

            }
            if (Form1.opcion == "Editar")
            {
                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from usuarios where Id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "usuarios");
                    DataRow DR;
                    DR = dt.Tables["usuarios"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string rfc = DR["rfc"].ToString();
                    string usuario = DR["usuario"].ToString();
                    string contraseña = DR["contraseña"].ToString();
                    string rol = DR["rol"].ToString();

                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnombre.Text = nombre;
                    txtrfc.Text = rfc;
                    txtusu.Text = usuario;
                    txtcontra.Text = contraseña;
                    cmrol.SelectedItem = rol;
                    //txtDescripcionI.Text = descripcion;
                    // cbcomplement.SelectedItem = complemento;
                    connection.Close();
                }
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Form1.id;

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";

                if (Form1.opcion == "Agregar")
                {
                    if (txtnombre.Text!=""&&txtcontra.Text!=""&&txtrfc.Text!=""&&cmrol.Text!="")
                    {
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
                        agarrar.actualizar();
                        FormProvider.MainMenu.Show();
                    }
                    

                }
                if (Form1.opcion=="Editar")
                {
                    if (txtnombre.Text != "" && txtcontra.Text != "" && txtrfc.Text != "" && cmrol.Text != "")
                    {


                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            StringBuilder sb = new StringBuilder();
                            sb.Append("update usuarios set usuario=" + "'" + txtusu.Text + "'" + ",contraseña='" + txtcontra.Text + "'"
                                + ",rol='" + cmrol.SelectedItem + "'" + ",nombre='" + txtnombre.Text + "'" + ",rfc='" + txtrfc.Text + "'" + " where Id='" + id + "'");
                            String sql = sb.ToString();
                            SqlCommand cmd = new SqlCommand(sql, connection);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet dt = new DataSet();
                            da.Fill(dt, "usuarios");

                        }
                        agarrar.actualizar();
                        FormProvider.MainMenu.Show();

                    }

                }
                if (Form1.opcion=="Eliminar")
                {
                    

                    if (txtusu.Text != "")
                    {
                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            StringBuilder sb = new StringBuilder();
                            sb.Append("delete usuarios where Id=" + "'" + id + "' ALTER TABLE usuarios DROP CONSTRAINT [pk];" +
                                " ALTER table usuarios drop column Id;ALTER table usuarios add Id int identity(1,1);" +
                                "ALTER TABLE usuarios ADD  CONSTRAINT[pk] PRIMARY KEY CLUSTERED([Id] ASC); ");
                            String sql = sb.ToString();
                            SqlCommand cmd = new SqlCommand(sql, connection);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet dt = new DataSet();
                            da.Fill(dt, "usuarios");

                        }
                        agarrar.actualizar();
                        FormProvider.MainMenu.Show();


                    }
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Intente de nuevo");
            }
        }

        private void empleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProvider.MainMenu.Show();

        }
    }
}
