namespace SistemaDeReservas
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.horariosLbl = new System.Windows.Forms.Label();
            this.menuLbl = new System.Windows.Forms.Label();
            this.pedidosLbl = new System.Windows.Forms.Label();
            this.reservasLbl = new System.Windows.Forms.Label();
            this.clientesLbl = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Controls.Add(this.horariosLbl);
            this.groupBox1.Controls.Add(this.menuLbl);
            this.groupBox1.Controls.Add(this.pedidosLbl);
            this.groupBox1.Controls.Add(this.reservasLbl);
            this.groupBox1.Controls.Add(this.clientesLbl);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 630);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // horariosLbl
            // 
            this.horariosLbl.AutoSize = true;
            this.horariosLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horariosLbl.ForeColor = System.Drawing.Color.White;
            this.horariosLbl.Location = new System.Drawing.Point(41, 359);
            this.horariosLbl.Name = "horariosLbl";
            this.horariosLbl.Size = new System.Drawing.Size(117, 31);
            this.horariosLbl.TabIndex = 5;
            this.horariosLbl.Text = "Horarios";
            this.horariosLbl.Click += new System.EventHandler(this.horariosLbl_Click);
            // 
            // menuLbl
            // 
            this.menuLbl.AutoSize = true;
            this.menuLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLbl.ForeColor = System.Drawing.Color.White;
            this.menuLbl.Location = new System.Drawing.Point(41, 120);
            this.menuLbl.Name = "menuLbl";
            this.menuLbl.Size = new System.Drawing.Size(81, 31);
            this.menuLbl.TabIndex = 4;
            this.menuLbl.Text = "Menu";
            this.menuLbl.Click += new System.EventHandler(this.menuLbl_Click);
            // 
            // pedidosLbl
            // 
            this.pedidosLbl.AutoSize = true;
            this.pedidosLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidosLbl.ForeColor = System.Drawing.Color.White;
            this.pedidosLbl.Location = new System.Drawing.Point(41, 199);
            this.pedidosLbl.Name = "pedidosLbl";
            this.pedidosLbl.Size = new System.Drawing.Size(112, 31);
            this.pedidosLbl.TabIndex = 3;
            this.pedidosLbl.Text = "Pedidos";
            this.pedidosLbl.Click += new System.EventHandler(this.pedidosLbl_Click);
            // 
            // reservasLbl
            // 
            this.reservasLbl.AutoSize = true;
            this.reservasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservasLbl.ForeColor = System.Drawing.Color.White;
            this.reservasLbl.Location = new System.Drawing.Point(41, 276);
            this.reservasLbl.Name = "reservasLbl";
            this.reservasLbl.Size = new System.Drawing.Size(130, 31);
            this.reservasLbl.TabIndex = 2;
            this.reservasLbl.Text = "Reservas";
            this.reservasLbl.Click += new System.EventHandler(this.reservasLbl_Click);
            // 
            // clientesLbl
            // 
            this.clientesLbl.AutoSize = true;
            this.clientesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.clientesLbl.Location = new System.Drawing.Point(41, 44);
            this.clientesLbl.Name = "clientesLbl";
            this.clientesLbl.Size = new System.Drawing.Size(113, 31);
            this.clientesLbl.TabIndex = 1;
            this.clientesLbl.Text = "Clientes";
            this.clientesLbl.Click += new System.EventHandler(this.clientesLbl_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainPanel.Location = new System.Drawing.Point(221, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(850, 621);
            this.mainPanel.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 657);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label horariosLbl;
        private System.Windows.Forms.Label menuLbl;
        private System.Windows.Forms.Label pedidosLbl;
        private System.Windows.Forms.Label reservasLbl;
        private System.Windows.Forms.Label clientesLbl;
        private System.Windows.Forms.Panel mainPanel;
    }
}

