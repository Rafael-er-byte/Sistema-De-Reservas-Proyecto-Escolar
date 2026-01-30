namespace SistemaDeReservas
{
    partial class OrderView
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
            this.agregarOrdenBtn = new System.Windows.Forms.Button();
            this.buscarOrdenBtn = new System.Windows.Forms.Button();
            this.orderParametroDeBusquedaTxt = new System.Windows.Forms.MaskedTextBox();
            this.ordersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // agregarOrdenBtn
            // 
            this.agregarOrdenBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarOrdenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarOrdenBtn.ForeColor = System.Drawing.Color.White;
            this.agregarOrdenBtn.Location = new System.Drawing.Point(658, 24);
            this.agregarOrdenBtn.Name = "agregarOrdenBtn";
            this.agregarOrdenBtn.Size = new System.Drawing.Size(160, 54);
            this.agregarOrdenBtn.TabIndex = 10;
            this.agregarOrdenBtn.Text = "Agregar Orden";
            this.agregarOrdenBtn.UseVisualStyleBackColor = false;
            this.agregarOrdenBtn.Click += new System.EventHandler(this.agregarOrdenBtn_Click);
            // 
            // buscarOrdenBtn
            // 
            this.buscarOrdenBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buscarOrdenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarOrdenBtn.ForeColor = System.Drawing.Color.White;
            this.buscarOrdenBtn.Location = new System.Drawing.Point(337, 74);
            this.buscarOrdenBtn.Name = "buscarOrdenBtn";
            this.buscarOrdenBtn.Size = new System.Drawing.Size(92, 34);
            this.buscarOrdenBtn.TabIndex = 11;
            this.buscarOrdenBtn.Text = "Buscar";
            this.buscarOrdenBtn.UseVisualStyleBackColor = false;
            this.buscarOrdenBtn.Click += new System.EventHandler(this.buscarOrdenBtn_Click);
            // 
            // orderParametroDeBusquedaTxt
            // 
            this.orderParametroDeBusquedaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderParametroDeBusquedaTxt.Location = new System.Drawing.Point(30, 74);
            this.orderParametroDeBusquedaTxt.Name = "orderParametroDeBusquedaTxt";
            this.orderParametroDeBusquedaTxt.Size = new System.Drawing.Size(301, 30);
            this.orderParametroDeBusquedaTxt.TabIndex = 12;
            // 
            // ordersContainer
            // 
            this.ordersContainer.AutoScroll = true;
            this.ordersContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ordersContainer.Location = new System.Drawing.Point(28, 196);
            this.ordersContainer.Name = "ordersContainer";
            this.ordersContainer.Size = new System.Drawing.Size(818, 439);
            this.ordersContainer.TabIndex = 13;
            // 
            // statusCombo
            // 
            this.statusCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCombo.FormattingEnabled = true;
            this.statusCombo.Location = new System.Drawing.Point(122, 136);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(171, 30);
            this.statusCombo.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ingrese id o nombre de cliente";
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 647);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusCombo);
            this.Controls.Add(this.ordersContainer);
            this.Controls.Add(this.orderParametroDeBusquedaTxt);
            this.Controls.Add(this.buscarOrdenBtn);
            this.Controls.Add(this.agregarOrdenBtn);
            this.Name = "OrderView";
            this.Text = "OrderView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agregarOrdenBtn;
        private System.Windows.Forms.Button buscarOrdenBtn;
        private System.Windows.Forms.MaskedTextBox orderParametroDeBusquedaTxt;
        private System.Windows.Forms.FlowLayoutPanel ordersContainer;
        private System.Windows.Forms.ComboBox statusCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}