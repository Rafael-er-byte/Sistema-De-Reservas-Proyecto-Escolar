namespace SistemaDeReservas
{
    partial class CreateScheduleView
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
            this.horarioTxt = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crearHorarioBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // horarioTxt
            // 
            this.horarioTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horarioTxt.Location = new System.Drawing.Point(63, 101);
            this.horarioTxt.Name = "horarioTxt";
            this.horarioTxt.Size = new System.Drawing.Size(339, 30);
            this.horarioTxt.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Horario";
            // 
            // crearHorarioBtn
            // 
            this.crearHorarioBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.crearHorarioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearHorarioBtn.ForeColor = System.Drawing.Color.White;
            this.crearHorarioBtn.Location = new System.Drawing.Point(310, 199);
            this.crearHorarioBtn.Name = "crearHorarioBtn";
            this.crearHorarioBtn.Size = new System.Drawing.Size(92, 34);
            this.crearHorarioBtn.TabIndex = 19;
            this.crearHorarioBtn.Text = "Crear";
            this.crearHorarioBtn.UseVisualStyleBackColor = false;
            this.crearHorarioBtn.Click += new System.EventHandler(this.crearHorarioBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.BackColor = System.Drawing.Color.Gray;
            this.cancelarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarBtn.ForeColor = System.Drawing.Color.White;
            this.cancelarBtn.Location = new System.Drawing.Point(183, 199);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(101, 34);
            this.cancelarBtn.TabIndex = 20;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // CreateScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 268);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.crearHorarioBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.horarioTxt);
            this.Name = "CreateScheduleView";
            this.Text = "CreateScheduleView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox horarioTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crearHorarioBtn;
        private System.Windows.Forms.Button cancelarBtn;
    }
}