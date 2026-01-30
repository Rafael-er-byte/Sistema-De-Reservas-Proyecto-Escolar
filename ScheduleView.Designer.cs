namespace SistemaDeReservas
{
    partial class ScheduleView
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
            this.agregarHorarioBtn = new System.Windows.Forms.Button();
            this.horariosContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // agregarHorarioBtn
            // 
            this.agregarHorarioBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarHorarioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarHorarioBtn.ForeColor = System.Drawing.Color.White;
            this.agregarHorarioBtn.Location = new System.Drawing.Point(670, 25);
            this.agregarHorarioBtn.Name = "agregarHorarioBtn";
            this.agregarHorarioBtn.Size = new System.Drawing.Size(160, 54);
            this.agregarHorarioBtn.TabIndex = 11;
            this.agregarHorarioBtn.Text = "Agregar Horario";
            this.agregarHorarioBtn.UseVisualStyleBackColor = false;
            this.agregarHorarioBtn.Click += new System.EventHandler(this.agregarHorarioBtn_Click);
            // 
            // horariosContainer
            // 
            this.horariosContainer.AutoScroll = true;
            this.horariosContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.horariosContainer.Location = new System.Drawing.Point(28, 128);
            this.horariosContainer.Name = "horariosContainer";
            this.horariosContainer.Size = new System.Drawing.Size(818, 502);
            this.horariosContainer.TabIndex = 12;
            // 
            // ScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 647);
            this.Controls.Add(this.horariosContainer);
            this.Controls.Add(this.agregarHorarioBtn);
            this.Name = "ScheduleView";
            this.Text = "ScheduleView";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button agregarHorarioBtn;
        private System.Windows.Forms.FlowLayoutPanel horariosContainer;
    }
}