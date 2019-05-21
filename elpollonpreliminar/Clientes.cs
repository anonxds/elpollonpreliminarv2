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
    public partial class Clientes : MetroForm
    {
        public Clientes()
        {
            InitializeComponent();
        }
        Form1 agarrar = new Form1();

        private void Clientes_Load(object sender, EventArgs e)
        {
            lblopcion.Text = Form1.opcion;
            string id = Form1.id;
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "pruebastec.database.windows.net";
            builder1.UserID = "alexis";
            builder1.Password = "Azure1234567";
            builder1.InitialCatalog = "elpollon";



            if (Form1.opcion == "Eliminar")
            {
                txtnomc.Enabled = false;
                txtdirec.Enabled = false;

                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from clientes where Id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");
                    DataRow DR;
                    DR = dt.Tables["clientes"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string numero = DR["numero"].ToString();
                    string direccion = DR["direccion"].ToString();
                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnomc.Text = nombre;
                    txtnum.Text = numero;
                    txtdirec.Text = direccion;
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
                    sb.Append("select * from clientes where Id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");
                    DataRow DR;
                    DR = dt.Tables["clientes"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string numero = DR["numero"].ToString();
                    string direccion = DR["direccion"].ToString();
                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnomc.Text = nombre;
                    txtnum.Text = numero;
                    txtdirec.Text = direccion;
                    //txtDescripcionI.Text = descripcion;
                    // cbcomplement.SelectedItem = complemento;
                    connection.Close();
                }
            }
        }

        private void btnopcion_Click(object sender, EventArgs e)
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
                    if (txtdirec.Text != "" && txtnomc.Text != "" && txtnum.Text != "")
                    {


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
                        FormProvider.MainMenu.Show();
                        agarrar.actualizar();
                    }
                    

                }
                if (Form1.opcion == "Editar")
                {
                    if (txtdirec.Text != "" && txtnomc.Text != "" && txtnum.Text != "")
                    {


                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            StringBuilder sb = new StringBuilder();
                            sb.Append("update clientes set nombre=" + "'" + txtnomc.Text + "',direccion='" + txtdirec.Text + "' where Id=" + id);
                            String sql = sb.ToString();
                            SqlCommand cmd = new SqlCommand(sql, connection);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet dt = new DataSet();
                            da.Fill(dt, "clientes");

                        }
                        FormProvider.MainMenu.Show();

                        agarrar.actualizar();
                    }
                    

                }
                if (Form1.opcion == "Eliminar")
                {
                    if (txtnum.Text!="")
                    {


                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            connection.Open();
                            StringBuilder sb = new StringBuilder();
                            sb.Append("delete clientes where Id=" + "'" + id + "' ALTER TABLE clientes DROP CONSTRAINT [pk1];" +
                                "ALTER table clientes drop column Id;ALTER table clientes add Id int identity(1,1);" +
                                "ALTER TABLE clientes ADD  CONSTRAINT[pk1] PRIMARY KEY CLUSTERED([Id] ASC); ");
                            String sql = sb.ToString();
                            SqlCommand cmd = new SqlCommand(sql, connection);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet dt = new DataSet();
                            da.Fill(dt, "clientes");

                        }
                        FormProvider.MainMenu.Show();

                        agarrar.actualizar();

                    }

                }


            }
            catch (Exception)
            {

                MessageBox.Show("Intente de nuevo");
            }
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProvider.MainMenu.Show();

        }
    }
}
