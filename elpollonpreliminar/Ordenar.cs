using elpollonpreliminar.Orden;
using elpollonpreliminar.Orden.Combos;
using elpollonpreliminar.Orden.Complementos;
using elpollonpreliminar.Pollos.Complementos;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elpollonpreliminar
{
    public partial class Ordenar : MetroForm
    {       
        public Ordenar()
        {
            
            InitializeComponent();
            s.dgrid(bunifuCustomDataGrid1, "select nombre,precio from almacen2 where complemento = 1");
            auto();
        }
        List<string> _items = new List<string>();
        List<int> _precio = new List<int>();
        List<int> _cantidad = new List<int>();
        List<string> _descripcion = new List<string>();  
        SQL sql = new SQL();

       
        private void Ordenar_Load(object sender, EventArgs e)
        {
            
          
        }    

        public string query(string n2, string n3)
        {
            string query = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre = '{1}'",n2,n3);
            return query;
        }
        SQL s = new SQL();
        private void btnchico_Click(object sender, EventArgs e)
        {
            pollos("Pollo chico");
        }

        private void btnmed_Click(object sender, EventArgs e)
        {
            pollos("Pollo mediano");
        }

        private void btngran_Click(object sender, EventArgs e)
        {
            pollos("Pollo grande");
        }
        public void pollos(string size)
        {
            SQL p = new SQL();
            string query = string.Format("select * from almacen2 where nombre = '{0}'", size);
            string nombre = p.getdata(query, "nombre");
            int price = int.Parse(s.getdata(query, "precio"));
            _ticket.DataSource = null;
            _items.Add(nombre + "\t" + txtcantidad.Text + "  x\t " +"$"+(double.Parse(txtcantidad.Text) * price));
            _precio.Add(int.Parse(txtcantidad.Text) * price);
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(nombre);
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
        }
       


        private void btnagregar_Click(object sender, EventArgs e)
        {
            string polloc = "update almacen2 set almacenado = almacenado - cantidad";           
            sql.Exe(polloc);         
            restar();
        }
        public void restar()
        {
            string polloc = "update almacen2 set cantidad = 0";          
            sql.Exe(polloc);
          
        }
        public string remove(string n2, string n3)
        {           
            string query = string.Format("update almacen2 set cantidad =   cantidad - '{0}' where nombre = '{1}'", n2, n3);
            return query;
        }
        public void des() {
            _cantidad.RemoveAt(_ticket.SelectedIndex);
            _descripcion.RemoveAt(_ticket.SelectedIndex);
            _precio.RemoveAt(_ticket.SelectedIndex);
            _items.RemoveAt(_ticket.SelectedIndex);
            _ticket.DataSource = null;
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();

        }
        public void limpiar()
        {
            _cantidad.Clear();
            _descripcion.Clear();
            _precio.Clear();
            _items.Clear();
            _ticket.DataSource = null;
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
        }



        private void btnquitar_Click(object sender, EventArgs e)
        {         
        }

  
        private void cbcombo_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void btnagregarcombo_Click(object sender, EventArgs e)
        {          
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            string query = string.Format("select * from almacen2 where nombre = '{0}'");
            int precio = int.Parse(s.getdata(query, "precio"));
            string des = s.getdata(query, "nombre");
            _ticket.DataSource = null;
            _precio.Add(int.Parse(txtcantidad.Text) * precio);
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(des);
            _items.Add(des + "\t \t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * precio));
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
        }

      
     

        private void _ticket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    
        private void _ticket_DoubleClick_1(object sender, EventArgs e)
        {
            des();
        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            sql.ExportDataTableToPdf("prueba", _descripcion, _cantidad, _precio, lblprecio);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void Ordenar_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar la ventana de bienvenida?",
                   "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

                e.Cancel = false;

                FormProvider.MainMenu.BringToFront();
                FormProvider.MainMenu.Show();

            }
        }
        public void auto()
        {
            txtsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtsearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            string cons = "Server=pruebastec.database.windows.net,1433;Initial Catalog=elpollon;Persist Security Info=False;" +
                "User ID = alexis; Password=Azure1234567;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
            string query = "select * from clientes";
            SqlConnection con = new SqlConnection(cons);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sName = reader.GetString(1);
                     Int64 stelefono = reader.GetInt64(0);
                    coll.Add(stelefono +" "+ sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ahhhh" + ex);
            }
            txtsearch.AutoCompleteCustomSource = coll;
        }
      

       
        private void btnhome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProvider.MainMenu.Show();
        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            com();
        }
        public void com()
        {
            string des = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
           int precio = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString());
            _ticket.DataSource = null;
            _precio.Add(int.Parse(txtcantidad.Text) * precio);
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(des);
            _items.Add(des + "\t \t" + txtcantidad.Text + "  x\t " +"$"+ (double.Parse(txtcantidad.Text) * precio));
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
        }
    }
}
