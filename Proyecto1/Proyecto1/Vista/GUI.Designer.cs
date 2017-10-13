namespace Proyecto1.Vista
{
    partial class GUI
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
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabPrevio = new System.Windows.Forms.TabPage();
            this.tabSolicitudes = new System.Windows.Forms.TabPage();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.btn_Solicitudes = new System.Windows.Forms.Button();
            this.btn_CrearSesion = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_FechaHora = new System.Windows.Forms.DateTimePicker();
            this.tb_lugarSesion = new System.Windows.Forms.TextBox();
            this.s_numeroSesion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Notificar = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_RechazarSolicitud = new System.Windows.Forms.Button();
            this.btn_AgregarAgenda = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.Tab.SuspendLayout();
            this.tabPrevio.SuspendLayout();
            this.tabSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_numeroSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.tabPrevio);
            this.Tab.Controls.Add(this.tabSolicitudes);
            this.Tab.Controls.Add(this.tabPage1);
            this.Tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab.Location = new System.Drawing.Point(12, 12);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(950, 520);
            this.Tab.TabIndex = 0;
            // 
            // tabPrevio
            // 
            this.tabPrevio.Controls.Add(this.btn_Notificar);
            this.tabPrevio.Controls.Add(this.label4);
            this.tabPrevio.Controls.Add(this.label3);
            this.tabPrevio.Controls.Add(this.label2);
            this.tabPrevio.Controls.Add(this.s_numeroSesion);
            this.tabPrevio.Controls.Add(this.tb_lugarSesion);
            this.tabPrevio.Controls.Add(this.dt_FechaHora);
            this.tabPrevio.Controls.Add(this.label1);
            this.tabPrevio.Controls.Add(this.dataGridView1);
            this.tabPrevio.Controls.Add(this.btn_CrearSesion);
            this.tabPrevio.Controls.Add(this.btn_Solicitudes);
            this.tabPrevio.Controls.Add(this.btn_Actualizar);
            this.tabPrevio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPrevio.Location = new System.Drawing.Point(4, 29);
            this.tabPrevio.Name = "tabPrevio";
            this.tabPrevio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrevio.Size = new System.Drawing.Size(942, 487);
            this.tabPrevio.TabIndex = 0;
            this.tabPrevio.Text = "Previo Secretaria";
            this.tabPrevio.UseVisualStyleBackColor = true;
            // 
            // tabSolicitudes
            // 
            this.tabSolicitudes.Controls.Add(this.button3);
            this.tabSolicitudes.Controls.Add(this.label6);
            this.tabSolicitudes.Controls.Add(this.btn_AgregarAgenda);
            this.tabSolicitudes.Controls.Add(this.btn_RechazarSolicitud);
            this.tabSolicitudes.Controls.Add(this.label5);
            this.tabSolicitudes.Controls.Add(this.dataGridView2);
            this.tabSolicitudes.Location = new System.Drawing.Point(4, 29);
            this.tabSolicitudes.Name = "tabSolicitudes";
            this.tabSolicitudes.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolicitudes.Size = new System.Drawing.Size(942, 487);
            this.tabSolicitudes.TabIndex = 1;
            this.tabSolicitudes.Text = "Gestion de solicitudes";
            this.tabSolicitudes.UseVisualStyleBackColor = true;
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Location = new System.Drawing.Point(31, 384);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(203, 69);
            this.btn_Actualizar.TabIndex = 0;
            this.btn_Actualizar.Text = "Actualizar Miembros";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Solicitudes
            // 
            this.btn_Solicitudes.Location = new System.Drawing.Point(265, 384);
            this.btn_Solicitudes.Name = "btn_Solicitudes";
            this.btn_Solicitudes.Size = new System.Drawing.Size(203, 69);
            this.btn_Solicitudes.TabIndex = 1;
            this.btn_Solicitudes.Text = "Simulación de Solicitudes";
            this.btn_Solicitudes.UseVisualStyleBackColor = true;
            this.btn_Solicitudes.Click += new System.EventHandler(this.btn__Click);
            // 
            // btn_CrearSesion
            // 
            this.btn_CrearSesion.Location = new System.Drawing.Point(183, 179);
            this.btn_CrearSesion.Name = "btn_CrearSesion";
            this.btn_CrearSesion.Size = new System.Drawing.Size(137, 47);
            this.btn_CrearSesion.TabIndex = 2;
            this.btn_CrearSesion.Text = "Crear sesion";
            this.btn_CrearSesion.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(529, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(373, 372);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista de Miembros actuales";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dt_FechaHora
            // 
            this.dt_FechaHora.Location = new System.Drawing.Point(183, 127);
            this.dt_FechaHora.Name = "dt_FechaHora";
            this.dt_FechaHora.Size = new System.Drawing.Size(200, 27);
            this.dt_FechaHora.TabIndex = 5;
            // 
            // tb_lugarSesion
            // 
            this.tb_lugarSesion.Location = new System.Drawing.Point(183, 88);
            this.tb_lugarSesion.Name = "tb_lugarSesion";
            this.tb_lugarSesion.Size = new System.Drawing.Size(200, 27);
            this.tb_lugarSesion.TabIndex = 6;
            // 
            // s_numeroSesion
            // 
            this.s_numeroSesion.Location = new System.Drawing.Point(183, 48);
            this.s_numeroSesion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.s_numeroSesion.Name = "s_numeroSesion";
            this.s_numeroSesion.Size = new System.Drawing.Size(60, 27);
            this.s_numeroSesion.TabIndex = 7;
            this.s_numeroSesion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de sesión:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lugar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha y Hora:";
            // 
            // btn_Notificar
            // 
            this.btn_Notificar.Location = new System.Drawing.Point(183, 260);
            this.btn_Notificar.Name = "btn_Notificar";
            this.btn_Notificar.Size = new System.Drawing.Size(183, 47);
            this.btn_Notificar.TabIndex = 11;
            this.btn_Notificar.Text = "Notificar Miembros";
            this.btn_Notificar.UseVisualStyleBackColor = true;
            this.btn_Notificar.Click += new System.EventHandler(this.btn_Notificar_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(312, 48);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(606, 408);
            this.dataGridView2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Lista de Solicitudes";
            // 
            // btn_RechazarSolicitud
            // 
            this.btn_RechazarSolicitud.Location = new System.Drawing.Point(56, 51);
            this.btn_RechazarSolicitud.Name = "btn_RechazarSolicitud";
            this.btn_RechazarSolicitud.Size = new System.Drawing.Size(203, 69);
            this.btn_RechazarSolicitud.TabIndex = 2;
            this.btn_RechazarSolicitud.Text = "Rechazar Solicitud";
            this.btn_RechazarSolicitud.UseVisualStyleBackColor = true;
            // 
            // btn_AgregarAgenda
            // 
            this.btn_AgregarAgenda.Location = new System.Drawing.Point(56, 171);
            this.btn_AgregarAgenda.Name = "btn_AgregarAgenda";
            this.btn_AgregarAgenda.Size = new System.Drawing.Size(203, 69);
            this.btn_AgregarAgenda.TabIndex = 3;
            this.btn_AgregarAgenda.Text = "Agregar a la Agenda";
            this.btn_AgregarAgenda.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(514, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "* Seleccione la solicitud que quiere rechazar o agrega a la agenda...";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 487);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Gestión de la Agenda (Previo)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 69);
            this.button1.TabIndex = 7;
            this.button1.Text = "Agregar a la Agenda";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 69);
            this.button2.TabIndex = 6;
            this.button2.Text = "Rechazar Solicitud";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(521, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Agenda de la Sesión";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(296, 56);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(606, 408);
            this.dataGridView3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(56, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 69);
            this.button3.TabIndex = 5;
            this.button3.Text = "Visualizar Solicitud";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 544);
            this.Controls.Add(this.Tab);
            this.Name = "GUI";
            this.Text = "Form2";
            this.Tab.ResumeLayout(false);
            this.tabPrevio.ResumeLayout(false);
            this.tabPrevio.PerformLayout();
            this.tabSolicitudes.ResumeLayout(false);
            this.tabSolicitudes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_numeroSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage tabPrevio;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.TabPage tabSolicitudes;
        private System.Windows.Forms.Button btn_Solicitudes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_CrearSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown s_numeroSesion;
        private System.Windows.Forms.TextBox tb_lugarSesion;
        private System.Windows.Forms.DateTimePicker dt_FechaHora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Notificar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_AgregarAgenda;
        private System.Windows.Forms.Button btn_RechazarSolicitud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button3;
    }
}