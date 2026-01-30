using System;
using System.Windows.Forms;
using SistemaDeReservas.Controller;

namespace SistemaDeReservas
{
    public partial class CreateClientView : Form
    {
        private readonly ClientController controller;
        private readonly ClienteView clienteView;

        public CreateClientView(ClientController controller, ClienteView clienteView)
        {
            InitializeComponent();
            this.controller = controller;
            this.clienteView = clienteView;
        }

        private void crearClienteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Create(
                    nombreTxt.Text,
                    telefonoTxt.Text,
                    correoTxt.Text
                );

                clienteView.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al crear cliente",
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
