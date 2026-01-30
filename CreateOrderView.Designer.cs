namespace SistemaDeReservas
{
    partial class CreateOrderView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.crearOrdenBtn = new System.Windows.Forms.Button();
            this.itemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.mostrarTotalLbl = new System.Windows.Forms.Label();
            this.clienteCombo = new System.Windows.Forms.ComboBox();
            this.itemCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.agregarItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cliente";
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.BackColor = System.Drawing.Color.Gray;
            this.cancelarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarBtn.ForeColor = System.Drawing.Color.White;
            this.cancelarBtn.Location = new System.Drawing.Point(504, 469);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(101, 34);
            this.cancelarBtn.TabIndex = 20;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // crearOrdenBtn
            // 
            this.crearOrdenBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.crearOrdenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearOrdenBtn.ForeColor = System.Drawing.Color.White;
            this.crearOrdenBtn.Location = new System.Drawing.Point(612, 469);
            this.crearOrdenBtn.Name = "crearOrdenBtn";
            this.crearOrdenBtn.Size = new System.Drawing.Size(92, 34);
            this.crearOrdenBtn.TabIndex = 21;
            this.crearOrdenBtn.Text = "Crear";
            this.crearOrdenBtn.UseVisualStyleBackColor = false;
            this.crearOrdenBtn.Click += new System.EventHandler(this.crearOrdenBtn_Click);
            // 
            // itemsPanel
            // 
            this.itemsPanel.Location = new System.Drawing.Point(63, 163);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(641, 216);
            this.itemsPanel.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(508, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Total: ";
            // 
            // mostrarTotalLbl
            // 
            this.mostrarTotalLbl.AutoSize = true;
            this.mostrarTotalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostrarTotalLbl.Location = new System.Drawing.Point(582, 401);
            this.mostrarTotalLbl.Name = "mostrarTotalLbl";
            this.mostrarTotalLbl.Size = new System.Drawing.Size(23, 25);
            this.mostrarTotalLbl.TabIndex = 24;
            this.mostrarTotalLbl.Text = "0";
            // 
            // clienteCombo
            // 
            this.clienteCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteCombo.FormattingEnabled = true;
            this.clienteCombo.Location = new System.Drawing.Point(63, 87);
            this.clienteCombo.Name = "clienteCombo";
            this.clienteCombo.Size = new System.Drawing.Size(155, 33);
            this.clienteCombo.TabIndex = 25;
            // 
            // itemCombo
            // 
            this.itemCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCombo.FormattingEnabled = true;
            this.itemCombo.Location = new System.Drawing.Point(355, 87);
            this.itemCombo.Name = "itemCombo";
            this.itemCombo.Size = new System.Drawing.Size(155, 33);
            this.itemCombo.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Item";
            // 
            // agregarItem
            // 
            this.agregarItem.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarItem.ForeColor = System.Drawing.Color.White;
            this.agregarItem.Location = new System.Drawing.Point(528, 87);
            this.agregarItem.Name = "agregarItem";
            this.agregarItem.Size = new System.Drawing.Size(92, 34);
            this.agregarItem.TabIndex = 28;
            this.agregarItem.Text = "Agregar";
            this.agregarItem.UseVisualStyleBackColor = false;
            this.agregarItem.Click += new System.EventHandler(this.agregarItem_Click);
            // 
            // CreateOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 515);
            this.Controls.Add(this.agregarItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemCombo);
            this.Controls.Add(this.clienteCombo);
            this.Controls.Add(this.mostrarTotalLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemsPanel);
            this.Controls.Add(this.crearOrdenBtn);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.label1);
            this.Name = "CreateOrderView";
            this.Text = "CreateOrderView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button crearOrdenBtn;
        private System.Windows.Forms.FlowLayoutPanel itemsPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label mostrarTotalLbl;
        private System.Windows.Forms.ComboBox clienteCombo;
        private System.Windows.Forms.ComboBox itemCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button agregarItem;
    }
}