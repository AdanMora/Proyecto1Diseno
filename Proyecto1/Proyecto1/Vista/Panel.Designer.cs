namespace Proyecto1.Vista
{
    partial class Panel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CargaXls = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.generaAgenda = new System.Windows.Forms.Button();
            this.notificacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.generaActa = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.CargaXls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CargaXls);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 454);
            this.tabControl1.TabIndex = 0;
            // 
            // CargaXls
            // 
            this.CargaXls.Controls.Add(this.tableLayoutPanel1);
            this.CargaXls.Controls.Add(this.textBox1);
            this.CargaXls.Location = new System.Drawing.Point(4, 22);
            this.CargaXls.Name = "CargaXls";
            this.CargaXls.Padding = new System.Windows.Forms.Padding(3);
            this.CargaXls.Size = new System.Drawing.Size(758, 428);
            this.CargaXls.TabIndex = 0;
            this.CargaXls.Text = "Previo";
            this.CargaXls.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.generaAgenda, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.notificacion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.generaActa, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(567, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(119, 179);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // generaAgenda
            // 
            this.generaAgenda.Location = new System.Drawing.Point(3, 95);
            this.generaAgenda.Name = "generaAgenda";
            this.generaAgenda.Size = new System.Drawing.Size(113, 34);
            this.generaAgenda.TabIndex = 4;
            this.generaAgenda.Text = "Generar Agenda";
            this.generaAgenda.UseVisualStyleBackColor = true;
            this.generaAgenda.Click += new System.EventHandler(this.generaAgenda_Click);
            // 
            // notificacion
            // 
            this.notificacion.Location = new System.Drawing.Point(3, 49);
            this.notificacion.Name = "notificacion";
            this.notificacion.Size = new System.Drawing.Size(113, 39);
            this.notificacion.TabIndex = 2;
            this.notificacion.Text = "Enviar notificaciones";
            this.notificacion.UseVisualStyleBackColor = true;
            this.notificacion.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar lista miembros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // generaActa
            // 
            this.generaActa.Location = new System.Drawing.Point(3, 135);
            this.generaActa.Name = "generaActa";
            this.generaActa.Size = new System.Drawing.Size(113, 39);
            this.generaActa.TabIndex = 3;
            this.generaActa.Text = "Generar Acta";
            this.generaActa.UseVisualStyleBackColor = true;
            this.generaActa.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(459, 179);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(758, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "consejo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 479);
            this.Controls.Add(this.tabControl1);
            this.Name = "Panel";
            this.Text = "Administración consejo";
            this.tabControl1.ResumeLayout(false);
            this.CargaXls.ResumeLayout(false);
            this.CargaXls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CargaXls;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button notificacion;
        private System.Windows.Forms.Button generaActa;
        private System.Windows.Forms.Button generaAgenda;
    }
}