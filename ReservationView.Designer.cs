namespace SistemaDeReservas
{
    partial class ReservationView
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
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.agregarReservaBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reservaParametroDeBusquedaTxt = new System.Windows.Forms.MaskedTextBox();
            this.buscarReservaBtn = new System.Windows.Forms.Button();
            this.reservasContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.horarioCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // statusCombo
            // 
            this.statusCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCombo.FormattingEnabled = true;
            this.statusCombo.Location = new System.Drawing.Point(115, 124);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(171, 30);
            this.statusCombo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Estado";
            // 
            // agregarReservaBtn
            // 
            this.agregarReservaBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarReservaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarReservaBtn.ForeColor = System.Drawing.Color.White;
            this.agregarReservaBtn.Location = new System.Drawing.Point(677, 37);
            this.agregarReservaBtn.Name = "agregarReservaBtn";
            this.agregarReservaBtn.Size = new System.Drawing.Size(160, 54);
            this.agregarReservaBtn.TabIndex = 19;
            this.agregarReservaBtn.Text = "Agregar Reserva";
            this.agregarReservaBtn.UseVisualStyleBackColor = false;
            this.agregarReservaBtn.Click += new System.EventHandler(this.agregarReservaBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ingrese id o nombre de cliente";
            // 
            // reservaParametroDeBusquedaTxt
            // 
            this.reservaParametroDeBusquedaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservaParametroDeBusquedaTxt.Location = new System.Drawing.Point(41, 61);
            this.reservaParametroDeBusquedaTxt.Name = "reservaParametroDeBusquedaTxt";
            this.reservaParametroDeBusquedaTxt.Size = new System.Drawing.Size(301, 30);
            this.reservaParametroDeBusquedaTxt.TabIndex = 21;
            // 
            // buscarReservaBtn
            // 
            this.buscarReservaBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buscarReservaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarReservaBtn.ForeColor = System.Drawing.Color.White;
            this.buscarReservaBtn.Location = new System.Drawing.Point(357, 61);
            this.buscarReservaBtn.Name = "buscarReservaBtn";
            this.buscarReservaBtn.Size = new System.Drawing.Size(92, 34);
            this.buscarReservaBtn.TabIndex = 22;
            this.buscarReservaBtn.Text = "Buscar";
            this.buscarReservaBtn.UseVisualStyleBackColor = false;
            this.buscarReservaBtn.Click += new System.EventHandler(this.buscarReservaBtn_Click);
            // 
            // reservasContainer
            // 
            this.reservasContainer.AutoScroll = true;
            this.reservasContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.reservasContainer.Location = new System.Drawing.Point(30, 278);
            this.reservasContainer.Name = "reservasContainer";
            this.reservasContainer.Size = new System.Drawing.Size(862, 386);
            this.reservasContainer.TabIndex = 23;
            // 
            // horarioCombo
            // 
            this.horarioCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horarioCombo.FormattingEnabled = true;
            this.horarioCombo.Location = new System.Drawing.Point(411, 129);
            this.horarioCombo.Name = "horarioCombo";
            this.horarioCombo.Size = new System.Drawing.Size(171, 30);
            this.horarioCombo.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Horario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Fecha";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // fechaPicker
            // 
            this.fechaPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaPicker.Location = new System.Drawing.Point(115, 201);
            this.fechaPicker.Name = "fechaPicker";
            this.fechaPicker.Size = new System.Drawing.Size(273, 30);
            this.fechaPicker.TabIndex = 29;
            this.fechaPicker.ValueChanged += new System.EventHandler(this.fechaPicker_ValueChanged);
            // 
            // ReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 676);
            this.Controls.Add(this.fechaPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.horarioCombo);
            this.Controls.Add(this.reservasContainer);
            this.Controls.Add(this.buscarReservaBtn);
            this.Controls.Add(this.reservaParametroDeBusquedaTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.agregarReservaBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusCombo);
            this.Name = "ReservationView";
            this.Text = "ReservasView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox statusCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button agregarReservaBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox reservaParametroDeBusquedaTxt;
        private System.Windows.Forms.Button buscarReservaBtn;
        private System.Windows.Forms.FlowLayoutPanel reservasContainer;
        private System.Windows.Forms.ComboBox horarioCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaPicker;
    }
}