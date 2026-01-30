namespace SistemaDeReservas
{
    partial class ClienteView
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
            this.clienteParametroDeBusquedaTxt = new System.Windows.Forms.MaskedTextBox();
            this.buscarClienteBtn = new System.Windows.Forms.Button();
            this.agregarClienteBtn = new System.Windows.Forms.Button();
            this.clientesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // clienteParametroDeBusquedaTxt
            // 
            this.clienteParametroDeBusquedaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteParametroDeBusquedaTxt.Location = new System.Drawing.Point(29, 45);
            this.clienteParametroDeBusquedaTxt.Name = "clienteParametroDeBusquedaTxt";
            this.clienteParametroDeBusquedaTxt.Size = new System.Drawing.Size(301, 30);
            this.clienteParametroDeBusquedaTxt.TabIndex = 5;
            // 
            // buscarClienteBtn
            // 
            this.buscarClienteBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buscarClienteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarClienteBtn.ForeColor = System.Drawing.Color.White;
            this.buscarClienteBtn.Location = new System.Drawing.Point(336, 45);
            this.buscarClienteBtn.Name = "buscarClienteBtn";
            this.buscarClienteBtn.Size = new System.Drawing.Size(92, 34);
            this.buscarClienteBtn.TabIndex = 8;
            this.buscarClienteBtn.Text = "Buscar";
            this.buscarClienteBtn.UseVisualStyleBackColor = false;
            this.buscarClienteBtn.Click += new System.EventHandler(this.buscarClienteBtn_Click);
            // 
            // agregarClienteBtn
            // 
            this.agregarClienteBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarClienteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarClienteBtn.ForeColor = System.Drawing.Color.White;
            this.agregarClienteBtn.Location = new System.Drawing.Point(687, 21);
            this.agregarClienteBtn.Name = "agregarClienteBtn";
            this.agregarClienteBtn.Size = new System.Drawing.Size(160, 54);
            this.agregarClienteBtn.TabIndex = 9;
            this.agregarClienteBtn.Text = "Agregar cliente";
            this.agregarClienteBtn.UseVisualStyleBackColor = false;
            this.agregarClienteBtn.Click += new System.EventHandler(this.agregarClienteBtn_Click);
            // 
            // clientesContainer
            // 
            this.clientesContainer.AutoScroll = true;
            this.clientesContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clientesContainer.Location = new System.Drawing.Point(29, 111);
            this.clientesContainer.Name = "clientesContainer";
            this.clientesContainer.Size = new System.Drawing.Size(818, 502);
            this.clientesContainer.TabIndex = 10;
            // 
            // ClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 647);
            this.Controls.Add(this.clientesContainer);
            this.Controls.Add(this.agregarClienteBtn);
            this.Controls.Add(this.buscarClienteBtn);
            this.Controls.Add(this.clienteParametroDeBusquedaTxt);
            this.Name = "ClienteView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox clienteParametroDeBusquedaTxt;
        private System.Windows.Forms.Button buscarClienteBtn;
        private System.Windows.Forms.Button agregarClienteBtn;
        private System.Windows.Forms.FlowLayoutPanel clientesContainer;
    }
}