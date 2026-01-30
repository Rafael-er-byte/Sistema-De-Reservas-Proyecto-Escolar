namespace SistemaDeReservas
{
    partial class MenuView
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
            this.agregarItemBtn = new System.Windows.Forms.Button();
            this.buscarItemBtn = new System.Windows.Forms.Button();
            this.itemParametroDeBusquedaTxt = new System.Windows.Forms.MaskedTextBox();
            this.itemContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // agregarItemBtn
            // 
            this.agregarItemBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.agregarItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarItemBtn.ForeColor = System.Drawing.Color.White;
            this.agregarItemBtn.Location = new System.Drawing.Point(672, 36);
            this.agregarItemBtn.Name = "agregarItemBtn";
            this.agregarItemBtn.Size = new System.Drawing.Size(160, 54);
            this.agregarItemBtn.TabIndex = 10;
            this.agregarItemBtn.Text = "Agregar Item";
            this.agregarItemBtn.UseVisualStyleBackColor = false;
            this.agregarItemBtn.Click += new System.EventHandler(this.agregarItemBtn_Click);
            // 
            // buscarItemBtn
            // 
            this.buscarItemBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buscarItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarItemBtn.ForeColor = System.Drawing.Color.White;
            this.buscarItemBtn.Location = new System.Drawing.Point(347, 60);
            this.buscarItemBtn.Name = "buscarItemBtn";
            this.buscarItemBtn.Size = new System.Drawing.Size(92, 34);
            this.buscarItemBtn.TabIndex = 11;
            this.buscarItemBtn.Text = "Buscar";
            this.buscarItemBtn.UseVisualStyleBackColor = false;
            this.buscarItemBtn.Click += new System.EventHandler(this.buscarItemBtn_Click);
            // 
            // itemParametroDeBusquedaTxt
            // 
            this.itemParametroDeBusquedaTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemParametroDeBusquedaTxt.Location = new System.Drawing.Point(28, 60);
            this.itemParametroDeBusquedaTxt.Name = "itemParametroDeBusquedaTxt";
            this.itemParametroDeBusquedaTxt.Size = new System.Drawing.Size(301, 30);
            this.itemParametroDeBusquedaTxt.TabIndex = 12;
            // 
            // itemContainer
            // 
            this.itemContainer.AutoScroll = true;
            this.itemContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.itemContainer.Location = new System.Drawing.Point(28, 140);
            this.itemContainer.Name = "itemContainer";
            this.itemContainer.Size = new System.Drawing.Size(818, 469);
            this.itemContainer.TabIndex = 13;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 647);
            this.Controls.Add(this.itemContainer);
            this.Controls.Add(this.itemParametroDeBusquedaTxt);
            this.Controls.Add(this.buscarItemBtn);
            this.Controls.Add(this.agregarItemBtn);
            this.Name = "MenuView";
            this.Text = "MenuView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agregarItemBtn;
        private System.Windows.Forms.Button buscarItemBtn;
        private System.Windows.Forms.MaskedTextBox itemParametroDeBusquedaTxt;
        private System.Windows.Forms.FlowLayoutPanel itemContainer;
    }
}