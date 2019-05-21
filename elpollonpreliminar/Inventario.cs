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
    public partial class Inventario : MetroForm
    {
        public Inventario()
        {
            InitializeComponent();
        }
        Form1 agarrar = new Form1();
        SQL s = new SQL();

        private void Inventario_Load(object sender, EventArgs e)
        {
            lblopcion.Text = Form1.opcion;
            string id = Form1.id;

            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "pruebastec.database.windows.net";
            builder1.UserID = "alexis";
            builder1.Password = "Azure1234567";
            builder1.InitialCatalog = "elpollon";

            

            if (Form1.opcion == "Eliminar" )
            {
                txtprecioI.Enabled = false;
                txtDescripcionI.Enabled = false;
                txtcantidadI.Enabled = false;
                cbcomplement.Enabled = false;

                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from almacen2 where id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "almacen2");
                    DataRow DR;
                    DR = dt.Tables["almacen2"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string cantidad = DR["cantidad"].ToString();
                    string precio = DR["precio"].ToString();
                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnombreI.Text = nombre;
                    txtprecioI.Text = cantidad;
                    txtcantidadI.Text = precio;
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
                    sb.Append("select * from almacen2 where id='" + id + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "almacen2");
                    DataRow DR;
                    DR = dt.Tables["almacen2"].Rows[0];

                    string nombre = DR["nombre"].ToString();
                    string cantidad = DR["cantidad"].ToString();
                    string precio = DR["precio"].ToString();
                    //string descripcion = DR["Observaciones"].ToString();
                    //string complemento = DR["Observaciones"].ToString();

                    txtnombreI.Text = nombre;
                    txtprecioI.Text = cantidad;
                    txtcantidadI.Text = precio;
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
                    if (txtcantidadI.Text != "" && txtDescripcionI.Text != "" && txtnombreI.Text != "" && txtprecioI.Text != "")
                    {


                        string ins = string.Format("insert into almacen2 values('{0}','{1}','{2}','{3}')", txtnombreI.Text, txtcantidadI.Text, txtprecioI.Text, cbcomplement.SelectedIndex);
                        s.Exe(ins);
                        FormProvider.MainMenu.Show();
                        agarrar.actualizar();
                    }
                }
                if (Form1.opcion == "Editar")
                {
                    if (txtcantidadI.Text != "" && txtDescripcionI.Text != "" && txtnombreI.Text != "" && txtprecioI.Text != "")
                    {

                        string upd = string.Format("update almacen2 set nombre = '{0}',cantidad='{1}',precio='{2}',complemento='{3}' where id = '{4}'", txtnombreI.Text, txtcantidadI.Text, txtprecioI.Text, cbcomplement.SelectedIndex, id);
                        s.Exe(upd);
                        FormProvider.MainMenu.Show();
                        agarrar.actualizar();
                    }
                }
                if (Form1.opcion == "Eliminar")
                {
                    if (txtnombreI.Text!="")
                    {

                        string del = string.Format("delete from almacen2 where id = '{0}' ALTER TABLE almacen2 DROP CONSTRAINT [pk2];" +
                            "ALTER table almacen2 drop column id;" +
                            "ALTER table almacen2 add id int identity(1,1);" +
                            "ALTER TABLE almacen2 ADD  CONSTRAINT[pk2] PRIMARY KEY CLUSTERED" +
                            "([id] ASC); ", id);
                        s.Exe(del);
                        FormProvider.MainMenu.Show();
                        agarrar.actualizar();
                    }
                }

                agarrar.actualizar();


            }
            catch (Exception)
            {

                MessageBox.Show("Intente de nuevo");
            }
        }

        private void Inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProvider.MainMenu.Show();

        }
    }
}
