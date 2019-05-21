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
        public static string opcion;
        public static string id;


        int cantidadventas = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabPage2.Parent = null;
            metroTabPage4.Parent = null;
            metroTabPage5.Parent = null;
            actualizar();
            pictureBox3.SendToBack();
            mtxtusu.Focus();
            metroRadioButton1.Checked = true;
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
                btnventas.Visible = false;
            }


            mtxtcontra.Text = "";
            mtxtusu.Text = "";
            btncsesion.Visible = false;
        }

 

        private void metroButton9_Click(object sender, EventArgs e)
        {
            try
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
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((metroGrid4.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        empleados nuevo = new empleados();
                        opcion = "Eliminar";
                        id = (metroGrid4.SelectedCells[0].RowIndex + 1).ToString();

                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();
                    }

                    connection.Close();
                }
 
            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese id");

            }


        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

            empleados nuevo = new empleados();
            opcion = "Agregar";
            nuevo.Show();
            FormProvider.MainMenu.Hide();
            actualizar();

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
                            metroTabControl1.SelectedTab = metroTabPage4;
                            btnventas.Visible = true;
                        }

                        if (mlabelrol.Text == "Tu Rol Es: vendedor")
                        {
                            Ordenar nuevo = new Ordenar();
                            nuevo.Show();
                            FormProvider.MainMenu.Hide();

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
                /*
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
                */
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
                Clientes nuevo = new Clientes();
                opcion = "Agregar";
                nuevo.Show();
                FormProvider.MainMenu.Hide();
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
                SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
                builder1.DataSource = "pruebastec.database.windows.net";
                builder1.UserID = "alexis";
                builder1.Password = "Azure1234567";
                builder1.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from clientes");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((metroGrid1.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        Clientes nuevo = new Clientes();
                        opcion = "Eliminar";
                        id = (metroGrid1.SelectedCells[0].RowIndex + 1).ToString();
                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();

                    }

                    connection.Close();
                }
                
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
                SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
                builder1.DataSource = "pruebastec.database.windows.net";
                builder1.UserID = "alexis";
                builder1.Password = "Azure1234567";
                builder1.InitialCatalog = "elpollon";

                using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from clientes");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((metroGrid1.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        Clientes nuevo = new Clientes();
                        opcion = "Editar";
                        id = (metroGrid1.SelectedCells[0].RowIndex + 1).ToString();
                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();

                    }

                    connection.Close();
                }

                

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese número");

            }
        }

        private void btnmode_Click(object sender, EventArgs e)
        {
            try
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
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((metroGrid4.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        empleados nuevo = new empleados();
                        opcion = "Editar";
                        id = (metroGrid4.SelectedCells[0].RowIndex + 1).ToString();

                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();

                    }

                    connection.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese id");

            }
            
        }

        private void metroTabControl1_Click(object sender, EventArgs e)
        {
             
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
            Inventario nuevo = new Inventario();
            opcion = "Agregar";
            nuevo.Show();
            FormProvider.MainMenu.Hide();
            actualizar();
        }

        private void gridalmacen_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            lblid.Text = gridalmacen.CurrentRow.Cells[0].Value.ToString();
            txtnombreI.Text = gridalmacen.CurrentRow.Cells[1].Value.ToString();
            txtcantidadI.Text = gridalmacen.CurrentRow.Cells[2].Value.ToString();
            txtprecioI.Text = gridalmacen.CurrentRow.Cells[3].Value.ToString();
            string p = string.Format("select * from almacen2 where id = '{0}'", lblid.Text);
            cbcomplement.SelectedIndex = int.Parse(s.getdata(p, "complemento"));
            */
            // .Text = dgvinfo.CurrentRow.Cells[4].Value.ToString();
            //   cbrol.Text = dgvinfo.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnphoto_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            try
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
                    sb.Append("select * from clientes");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((gridalmacen.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        Inventario nuevo = new Inventario();
                        opcion = "Editar";
                        id = (gridalmacen.SelectedCells[0].RowIndex + 1).ToString();
                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();

                    }

                    connection.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese número");

            }
            
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            try
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
                    sb.Append("select * from clientes");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "clientes");

                    DataRow DR;

                    Console.WriteLine(dt.Tables[0].Select("Id is not null").Length);

                    if ((gridalmacen.SelectedCells[0].RowIndex + 1) > dt.Tables[0].Select("Id is not null").Length)
                    {
                        MessageBox.Show("Selecciona un campo valido");
                    }
                    else
                    {
                        Inventario nuevo = new Inventario();
                        opcion = "Eliminar";
                        Console.WriteLine(gridalmacen.SelectedCells[0].RowIndex + 1);
                        id = (gridalmacen.SelectedCells[0].RowIndex + 1).ToString();
                        nuevo.Show();
                        FormProvider.MainMenu.Hide();
                        actualizar();

                    }

                    connection.Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese número");

            }
            

        }



        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }


        private void bunifuTextbox1_Leave(object sender, EventArgs e)
        {
            txtusuario.text = "Ingresa algún usuario";
            actualizar();
        }

        private void bunifuTextbox1_KeyPress(object sender, EventArgs e)
        {
            

        }


        private void bunifuTextbox1_Enter_1(object sender, EventArgs e)
        {
            txtcliente.Text = "";

        }

        private void bunifuTextbox1_Leave_1(object sender, EventArgs e)
        {
            txtcliente.Text = "Ingresa algún número";
            actualizar();
        }




        private void Form1_Enter(object sender, EventArgs e)
        {
            actualizar();

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            actualizar();
            
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            Ordenar nuevo = new Ordenar();
            nuevo.Show();
            mlabelrol.Text = "Tu Rol Es: ";
            if (mlabelrol.Text == "Tu Rol Es: ")
            {
                metroTabPage1.Parent = metroTabControl1;
                metroTabPage2.Parent = null;
                metroTabPage4.Parent = null;
                metroTabPage5.Parent = null;
                btnventas.Visible = false;
            }


            mtxtcontra.Text = "";
            mtxtusu.Text = "";
            btncsesion.Visible = false;
            
            actualizar();
            pictureBox3.SendToBack();
            mtxtusu.Focus();
            FormProvider.MainMenu.Hide();
        }

        private void txtbuscinv_Enter(object sender, EventArgs e)
        {
            txtbuscinv.Text = "";

        }

        private void txtbuscinv_Leave(object sender, EventArgs e)
        {
            txtbuscinv.Text = "Ingresa algún nombre";
            actualizar();
        }

        private void txtbuscinv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
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
                    sb.Append("select * from almacen2 where nombre=" + "'" + txtbuscinv.Text + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridalmacen.DataSource = dt;
                    connection.Close();

                }
            }
            

        }

        private void bunifuTextbox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)Keys.Enter)
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
                        sb.Append("select * from clientes where numero=" + "'" + txtcliente.Text + "'");
                        String sql = sb.ToString();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        metroGrid1.DataSource = dt;
                        connection.Close();

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Solo numeros");
                txtcliente.Text = "";
            }
        }

        private void bunifuImageButton7_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void btnagregarI_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void bunifuImageButton8_MouseMove(object sender, MouseEventArgs e)
        {

        }


        private void btnaddc_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnmodc_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnelimc_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(btnelimc, "Borrar");

        }

        private void btnaddc_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(btnaddc, "Agregar");

        }

        private void btnmodc_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(btnmodc, "Editar");

        }

        private void bunifuImageButton7_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(bunifuImageButton7, "Borrar");

        }

        private void btnagregarI_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(btnagregarI, "Agregar");

        }

        private void bunifuImageButton8_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(bunifuImageButton8, "Editar");

        }

        private void bunifuImageButton3_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(bunifuImageButton3, "Borrar");

        }

        private void bunifuImageButton2_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(bunifuImageButton2, "Agregar");

        }

        private void btnmode_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(btnmode, "Editar");

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
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
                    sb.Append("select * from usuarios where usuario=" + "'" + txtusuario.text + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    metroGrid4.DataSource = dt;
                    connection.Close();

                }
            }
            if (metroRadioButton2.Checked)
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
                    sb.Append("select * from usuarios where nombre=" + "'" + txtnombre.text + "'");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    metroGrid4.DataSource = dt;
                    connection.Close();

                }
            }
            
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
            {
                txtusuario.Enabled = true;
                txtnombre.Enabled = false;
            }

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (metroRadioButton2.Checked)
            {
                txtusuario.Enabled = false;
                txtnombre.Enabled = true;

            }
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            txtusuario.text = "";
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            txtnombre.text = "";

        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            txtnombre.text = "Ingresa algún nombre";
            actualizar();

        }
    }
    }

