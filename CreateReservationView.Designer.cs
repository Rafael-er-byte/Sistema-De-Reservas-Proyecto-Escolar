namespace SistemaDeReservas
{
    partial class CreateReservationView
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
            this.clienteCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.horarioCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaPicker = new System.Windows.Forms.DateTimePicker();
            this.fecha = new System.Windows.Forms.Label();
            this.crearReservaBtn = new System.Windows.Forms.Button();
            this.personsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.personsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteCombo
            // 
            this.clienteCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteCombo.FormattingEnabled = true;
            this.clienteCombo.Location = new System.Drawing.Point(42, 120);
            this.clienteCombo.Name = "clienteCombo";
            this.clienteCombo.Size = new System.Drawing.Size(198, 33);
            this.clienteCombo.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Cliente";
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.BackColor = System.Drawing.Color.Gray;
            this.cancelarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarBtn.ForeColor = System.Drawing.Color.White;
            this.cancelarBtn.Location = new System.Drawing.Point(382, 371);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(101, 34);
            this.cancelarBtn.TabIndex = 29;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // horarioCombo
            // 
            this.horarioCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horarioCombo.FormattingEnabled = true;
            this.horarioCombo.Location = new System.Drawing.Point(42, 253);
            this.horarioCombo.Name = "horarioCombo";
            this.horarioCombo.Size = new System.Drawing.Size(198, 33);
            this.horarioCombo.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Horario";
            // 
            // fechaPicker
            // 
            this.fechaPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaPicker.Location = new System.Drawing.Point(337, 123);
            this.fechaPicker.Name = "fechaPicker";
            this.fechaPicker.Size = new System.Drawing.Size(252, 30);
            this.fechaPicker.TabIndex = 32;
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(332, 70);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(67, 25);
            this.fecha.TabIndex = 33;
            this.fecha.Text = "Fecha";
            // 
            // crearReservaBtn
            // 
            this.crearReservaBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.crearReservaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearReservaBtn.ForeColor = System.Drawing.Color.White;
            this.crearReservaBtn.Location = new System.Drawing.Point(497, 371);
            this.crearReservaBtn.Name = "crearReservaBtn";
            this.crearReservaBtn.Size = new System.Drawing.Size(92, 34);
            this.crearReservaBtn.TabIndex = 34;
            this.crearReservaBtn.Text = "Crear";
            this.crearReservaBtn.UseVisualStyleBackColor = false;
            this.crearReservaBtn.Click += new System.EventHandler(this.crearReservaBtn_Click);
            // 
            // personsUpDown
            // 
            this.personsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personsUpDown.Location = new System.Drawing.Point(337, 253);
            this.personsUpDown.Name = "personsUpDown";
            this.personsUpDown.Size = new System.Drawing.Size(199, 30);
            this.personsUpDown.TabIndex = 35;
            this.personsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Cantidad de personas";
            // 
            // CreateReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.personsUpDown);
            this.Controls.Add(this.crearReservaBtn);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.fechaPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.horarioCombo);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clienteCombo);
            this.Name = "CreateReservationView";
            this.Text = "CreateReservationView";
            ((System.ComponentModel.ISupportInitialize)(this.personsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox clienteCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.ComboBox horarioCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaPicker;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Button crearReservaBtn;
        private System.Windows.Forms.NumericUpDown personsUpDown;
        private System.Windows.Forms.Label label3;
    }
}