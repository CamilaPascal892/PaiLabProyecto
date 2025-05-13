namespace PaiLab.WinApp
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Button btnRevendedores;
        private System.Windows.Forms.Button btnBeneficios;
        private System.Windows.Forms.Button btnLugaresDeReventa;
        private System.Windows.Forms.Button btnFiltrarLugares;
        private System.Windows.Forms.Button btnMisiones;
        private System.Windows.Forms.Button btnAdministradores;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();

            this.btnRevendedores = new System.Windows.Forms.Button();
            this.btnBeneficios = new System.Windows.Forms.Button();
            this.btnLugaresDeReventa = new System.Windows.Forms.Button();
            this.btnFiltrarLugares = new System.Windows.Forms.Button();
            this.btnMisiones = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnAdministradores = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // panelLateral
            // 
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Width = 250;
            this.panelLateral.BackColor = System.Drawing.Color.MistyRose;
            this.panelLateral.AutoScroll = true;

            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.BackColor = System.Drawing.Color.PaleVioletRed;

            // 
            // panelContenido
            // 
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.BackColor = System.Drawing.Color.White;

            // 
            // Botones
            // 
            EstiloBoton(this.btnRevendedores, "Revendedores");
            EstiloBoton(this.btnBeneficios, "Beneficios");
            EstiloBoton(this.btnLugaresDeReventa, "Lugares de Reventa");
            EstiloBoton(this.btnFiltrarLugares, "Filtrar Lugares");
            EstiloBoton(this.btnMisiones, "Misiones");
            EstiloBoton(this.btnConfiguracion, "Configuración");
            EstiloBoton(this.btnAdministradores, "Administradores");
            EstiloBoton(this.btnCerrarSesion, "Cerrar Sesión");

            // 
            // Agregar botones al panel lateral (orden inverso para que aparezcan arriba)
            // 
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Controls.Add(this.btnAdministradores);
            this.panelLateral.Controls.Add(this.btnConfiguracion);
            this.panelLateral.Controls.Add(this.btnMisiones);
            this.panelLateral.Controls.Add(this.btnFiltrarLugares);
            this.panelLateral.Controls.Add(this.btnLugaresDeReventa);
            this.panelLateral.Controls.Add(this.btnBeneficios);
            this.panelLateral.Controls.Add(this.btnRevendedores);

            // 
            // Agregar paneles al formulario
            // 
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLateral);

            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmPrincipal";
            this.Text = "PaiLab principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private void EstiloBoton(System.Windows.Forms.Button boton, string texto)
        {
            boton.Dock = System.Windows.Forms.DockStyle.Top;
            boton.Height = 60;
            boton.Text = texto;
            boton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            boton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            boton.BackColor = System.Drawing.Color.LightPink;
            boton.ForeColor = System.Drawing.Color.Maroon;
            boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            boton.MouseEnter += (s, e) => boton.BackColor = System.Drawing.Color.LightCoral;
            boton.MouseLeave += (s, e) => boton.BackColor = System.Drawing.Color.LightPink;
        }
    }
}
