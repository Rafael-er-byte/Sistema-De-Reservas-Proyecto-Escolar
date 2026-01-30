using System;
using System.Windows.Forms;
using SistemaDeReservas.Controller;

namespace SistemaDeReservas
{
    public partial class CreateItemView : Form
    {
        private ItemController controller;
        private MenuView menuView;

        public CreateItemView(ItemController controller, MenuView menuView)
        {
            InitializeComponent();
            this.controller = controller;
            this.menuView = menuView;
        }

        private void crearItemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Create(
                    nombreTxt.Text,
                    descripcionTxt.Text,
                    decimal.Parse(precioTxt.Text)
                );

                menuView.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
