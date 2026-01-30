using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class ClienteView : Form
    {
        private ClientController controller;
        private Font cardFont = new Font("Segoe UI", 11);

        public ClienteView(ClientController controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.Update();
        }

        private void buscarClienteBtn_Click(object sender, EventArgs e)
        {
            string param = clienteParametroDeBusquedaTxt.Text.Trim();

            int id = 0;
            string nameLike = null;

            if (int.TryParse(param, out int parsedId))
                id = parsedId;
            else if (!string.IsNullOrWhiteSpace(param))
                nameLike = param;

            var clients = controller.Search(id, nameLike);
            RenderClients(clients);
        }

        private void agregarClienteBtn_Click(object sender, EventArgs e)
        {
            CreateClientView view = new CreateClientView(controller, this);
            view.ShowDialog();
        }

        public void Update()
        {
            var clients = controller.Search(0, null);
            RenderClients(clients);
        }

        private void RenderClients(List<Client> clients)
        {
            clientesContainer.Controls.Clear();

            foreach (var client in clients)
            {
                clientesContainer.Controls.Add(CreateClientCard(client));
            }
        }

        private Panel CreateClientCard(Client client)
        {
            Panel card = new Panel
            {
                Width = 520,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(12)
            };

            Font labelFont = new Font("Segoe UI", 10, FontStyle.Regular);

            Label nameLbl = new Label
            {
                Text = "Nombre",
                Font = labelFont,
                Location = new Point(15, 18),
                Width = 80
            };

            TextBox nameTxt = new TextBox
            {
                Text = client.Name,
                Font = cardFont,
                Location = new Point(100, 15),
                Width = 395
            };

            Label telLbl = new Label
            {
                Text = "Teléfono",
                Font = labelFont,
                Location = new Point(15, 58),
                Width = 80
            };

            TextBox telTxt = new TextBox
            {
                Text = client.Tel,
                Font = cardFont,
                Location = new Point(100, 55),
                Width = 395
            };

            Label mailLbl = new Label
            {
                Text = "Correo",
                Font = labelFont,
                Location = new Point(15, 98),
                Width = 80
            };

            TextBox mailTxt = new TextBox
            {
                Text = client.Mail,
                Font = cardFont,
                Location = new Point(100, 95),
                Width = 395
            };

            Button editBtn = new Button
            {
                Text = "Editar",
                BackColor = Color.LightGray,
                Font = cardFont,
                Location = new Point(100, 145),
                Width = 120,
                Height = 36
            };

            Button deleteBtn = new Button
            {
                Text = "Eliminar",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(235, 145),
                Width = 120,
                Height = 36
            };

            editBtn.Click += (s, e) =>
            {
                controller.Update(
                    client.Id,
                    nameTxt.Text,
                    telTxt.Text,
                    mailTxt.Text
                );

                Update();
            };

            deleteBtn.Click += (s, e) =>
            {
                controller.Delete(client.Id);
                Update();
            };

            card.Controls.Add(nameLbl);
            card.Controls.Add(nameTxt);
            card.Controls.Add(telLbl);
            card.Controls.Add(telTxt);
            card.Controls.Add(mailLbl);
            card.Controls.Add(mailTxt);
            card.Controls.Add(editBtn);
            card.Controls.Add(deleteBtn);

            return card;
        }
    }
}
