namespace PaiLab
{
    partial class UCBeneficios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipoBeneficio;
        private System.Windows.Forms.Label lblLugaresDeReventaId;
        private System.Windows.Forms.Label lblRevendedores;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbTipoBeneficioId;
        private System.Windows.Forms.ComboBox cmbLugaresDeReventaId;
        private System.Windows.Forms.ComboBox cmbRevendedores;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvBeneficios;
        private System.Windows.Forms.BindingSource beneficiosBindingSource;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBeneficios));
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipoBeneficio = new System.Windows.Forms.Label();
            this.lblLugaresDeReventaId = new System.Windows.Forms.Label();
            this.lblRevendedores = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTipoBeneficioId = new System.Windows.Forms.ComboBox();
            this.cmbLugaresDeReventaId = new System.Windows.Forms.ComboBox();
            this.cmbRevendedores = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvBeneficios = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTipoBeneficio
            // 
            this.lblTipoBeneficio.Location = new System.Drawing.Point(30, 60);
            this.lblTipoBeneficio.Name = "lblTipoBeneficio";
            this.lblTipoBeneficio.Size = new System.Drawing.Size(84, 20);
            this.lblTipoBeneficio.TabIndex = 2;
            this.lblTipoBeneficio.Text = "Tipo Beneficio:";
            // 
            // lblLugaresDeReventa
            // 
            this.lblLugaresDeReventaId.Location = new System.Drawing.Point(30, 100);
            this.lblLugaresDeReventaId.Name = "lblLugaresDeReventa";
            this.lblLugaresDeReventaId.Size = new System.Drawing.Size(120, 20);
            this.lblLugaresDeReventaId.TabIndex = 6;
            this.lblLugaresDeReventaId.Text = "Lugar de Reventa:";
            // 
            // lblRevendedores
            // 
            this.lblRevendedores.Location = new System.Drawing.Point(30, 140);
            this.lblRevendedores.Name = "lblRevendedores";
            this.lblRevendedores.Size = new System.Drawing.Size(120, 20);
            this.lblRevendedores.TabIndex = 8;
            this.lblRevendedores.Text = "Revendedores:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(222)))), ((int)(((byte)(179)))));
            this.txtNombre.Location = new System.Drawing.Point(120, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // cmbTipoBeneficioId
            // 
            this.cmbTipoBeneficioId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(222)))), ((int)(((byte)(179)))));
            this.cmbTipoBeneficioId.Location = new System.Drawing.Point(120, 60);
            this.cmbTipoBeneficioId.Name = "cmbTipoBeneficioId";
            this.cmbTipoBeneficioId.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoBeneficioId.TabIndex = 3;
            // 
            // cmbLugaresDeReventa
            // 
            this.cmbLugaresDeReventaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(222)))), ((int)(((byte)(179)))));
            this.cmbLugaresDeReventaId.Location = new System.Drawing.Point(150, 100);
            this.cmbLugaresDeReventaId.Name = "cmbLugaresDeReventa";
            this.cmbLugaresDeReventaId.Size = new System.Drawing.Size(170, 21);
            this.cmbLugaresDeReventaId.TabIndex = 7;
            // 
            // cmbRevendedores
            // 
            this.cmbRevendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(222)))), ((int)(((byte)(179)))));
            this.cmbRevendedores.Location = new System.Drawing.Point(150, 140);
            this.cmbRevendedores.Name = "cmbRevendedores";
            this.cmbRevendedores.Size = new System.Drawing.Size(170, 21);
            this.cmbRevendedores.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(193)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(350, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(193)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Location = new System.Drawing.Point(350, 60);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvBeneficios
            // 
            this.dgvBeneficios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBeneficios.BackgroundColor = System.Drawing.Color.White;
            this.dgvBeneficios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBeneficios.Location = new System.Drawing.Point(30, 220);
            this.dgvBeneficios.MultiSelect = false;
            this.dgvBeneficios.Name = "dgvBeneficios";
            this.dgvBeneficios.ReadOnly = true;
            this.dgvBeneficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeneficios.Size = new System.Drawing.Size(540, 250);
            this.dgvBeneficios.TabIndex = 13;
            this.dgvBeneficios.SelectionChanged += new System.EventHandler(this.dgvBeneficios_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(376, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(30, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Gestion de Beneficios";
            // 
            // UCBeneficios
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipoBeneficio);
            this.Controls.Add(this.cmbTipoBeneficioId);
            this.Controls.Add(this.lblLugaresDeReventaId);
            this.Controls.Add(this.cmbLugaresDeReventaId);
            this.Controls.Add(this.lblRevendedores);
            this.Controls.Add(this.cmbRevendedores);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgvBeneficios);
            this.Name = "UCBeneficios";
            this.Size = new System.Drawing.Size(600, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}