namespace elpollonpreliminar
{
    partial class Inventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.cbcomplement = new MetroFramework.Controls.MetroComboBox();
            this.txtDescripcionI = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtprecioI = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtcantidadI = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtnombreI = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnopcion = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblopcion = new MetroFramework.Controls.MetroLabel();
            this.lblid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnopcion)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(24, 312);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(96, 19);
            this.metroLabel12.TabIndex = 115;
            this.metroLabel12.Text = "Complemento";
            // 
            // cbcomplement
            // 
            this.cbcomplement.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbcomplement.FormattingEnabled = true;
            this.cbcomplement.ItemHeight = 19;
            this.cbcomplement.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbcomplement.Location = new System.Drawing.Point(125, 306);
            this.cbcomplement.Margin = new System.Windows.Forms.Padding(2);
            this.cbcomplement.Name = "cbcomplement";
            this.cbcomplement.Size = new System.Drawing.Size(146, 25);
            this.cbcomplement.TabIndex = 114;
            this.cbcomplement.UseSelectable = true;
            // 
            // txtDescripcionI
            // 
            this.txtDescripcionI.BackColor = System.Drawing.Color.White;
            this.txtDescripcionI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcionI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic);
            this.txtDescripcionI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescripcionI.HintForeColor = System.Drawing.Color.Empty;
            this.txtDescripcionI.HintText = "Descripcion";
            this.txtDescripcionI.isPassword = false;
            this.txtDescripcionI.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.txtDescripcionI.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(18)))), ((int)(((byte)(1)))));
            this.txtDescripcionI.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(100)))), ((int)(((byte)(15)))));
            this.txtDescripcionI.LineThickness = 3;
            this.txtDescripcionI.Location = new System.Drawing.Point(24, 253);
            this.txtDescripcionI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcionI.Name = "txtDescripcionI";
            this.txtDescripcionI.Size = new System.Drawing.Size(247, 38);
            this.txtDescripcionI.TabIndex = 113;
            this.txtDescripcionI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtprecioI
            // 
            this.txtprecioI.BackColor = System.Drawing.Color.White;
            this.txtprecioI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtprecioI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic);
            this.txtprecioI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtprecioI.HintForeColor = System.Drawing.Color.Empty;
            this.txtprecioI.HintText = "Precio";
            this.txtprecioI.isPassword = false;
            this.txtprecioI.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.txtprecioI.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(18)))), ((int)(((byte)(1)))));
            this.txtprecioI.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(100)))), ((int)(((byte)(15)))));
            this.txtprecioI.LineThickness = 3;
            this.txtprecioI.Location = new System.Drawing.Point(24, 161);
            this.txtprecioI.Margin = new System.Windows.Forms.Padding(4);
            this.txtprecioI.Name = "txtprecioI";
            this.txtprecioI.Size = new System.Drawing.Size(247, 38);
            this.txtprecioI.TabIndex = 112;
            this.txtprecioI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtcantidadI
            // 
            this.txtcantidadI.BackColor = System.Drawing.Color.White;
            this.txtcantidadI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcantidadI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic);
            this.txtcantidadI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcantidadI.HintForeColor = System.Drawing.Color.Empty;
            this.txtcantidadI.HintText = "Cantidad";
            this.txtcantidadI.isPassword = false;
            this.txtcantidadI.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.txtcantidadI.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(18)))), ((int)(((byte)(1)))));
            this.txtcantidadI.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(100)))), ((int)(((byte)(15)))));
            this.txtcantidadI.LineThickness = 3;
            this.txtcantidadI.Location = new System.Drawing.Point(24, 207);
            this.txtcantidadI.Margin = new System.Windows.Forms.Padding(4);
            this.txtcantidadI.Name = "txtcantidadI";
            this.txtcantidadI.Size = new System.Drawing.Size(247, 38);
            this.txtcantidadI.TabIndex = 111;
            this.txtcantidadI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtnombreI
            // 
            this.txtnombreI.BackColor = System.Drawing.Color.White;
            this.txtnombreI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnombreI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic);
            this.txtnombreI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtnombreI.HintForeColor = System.Drawing.Color.Empty;
            this.txtnombreI.HintText = "Nombre";
            this.txtnombreI.isPassword = false;
            this.txtnombreI.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.txtnombreI.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(18)))), ((int)(((byte)(1)))));
            this.txtnombreI.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(100)))), ((int)(((byte)(15)))));
            this.txtnombreI.LineThickness = 3;
            this.txtnombreI.Location = new System.Drawing.Point(24, 114);
            this.txtnombreI.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombreI.Name = "txtnombreI";
            this.txtnombreI.Size = new System.Drawing.Size(247, 39);
            this.txtnombreI.TabIndex = 110;
            this.txtnombreI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnopcion
            // 
            this.btnopcion.BackColor = System.Drawing.Color.OrangeRed;
            this.btnopcion.Image = ((System.Drawing.Image)(resources.GetObject("btnopcion.Image")));
            this.btnopcion.ImageActive = null;
            this.btnopcion.Location = new System.Drawing.Point(99, 356);
            this.btnopcion.Name = "btnopcion";
            this.btnopcion.Size = new System.Drawing.Size(71, 71);
            this.btnopcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnopcion.TabIndex = 118;
            this.btnopcion.TabStop = false;
            this.btnopcion.Zoom = 10;
            this.btnopcion.Click += new System.EventHandler(this.btnopcion_Click);
            // 
            // lblopcion
            // 
            this.lblopcion.AutoSize = true;
            this.lblopcion.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblopcion.Location = new System.Drawing.Point(23, 60);
            this.lblopcion.Name = "lblopcion";
            this.lblopcion.Size = new System.Drawing.Size(72, 19);
            this.lblopcion.TabIndex = 119;
            this.lblopcion.Text = "aaaaaaaaa";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.BackColor = System.Drawing.Color.Transparent;
            this.lblid.Location = new System.Drawing.Point(22, 97);
            this.lblid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(0, 13);
            this.lblid.TabIndex = 120;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 450);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblopcion);
            this.Controls.Add(this.btnopcion);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.cbcomplement);
            this.Controls.Add(this.txtDescripcionI);
            this.Controls.Add(this.txtprecioI);
            this.Controls.Add(this.txtcantidadI);
            this.Controls.Add(this.txtnombreI);
            this.MaximizeBox = false;
            this.Name = "Inventario";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventario_FormClosing);
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnopcion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroComboBox cbcomplement;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDescripcionI;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtprecioI;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtcantidadI;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtnombreI;
        private Bunifu.Framework.UI.BunifuImageButton btnopcion;
        private MetroFramework.Controls.MetroLabel lblopcion;
        private System.Windows.Forms.Label lblid;
    }
}