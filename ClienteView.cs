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
        private readonly ClientController controller;
        private Font cardFont = new Font("Segoe UI", 11);

        public ClienteView(ClientController controller)
        {
            InitializeComponent();
            this.controller = controller;
            Update();
        }

        private void buscarClienteBtn_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al buscar clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void agregarClienteBtn_Click(object sender, EventArgs e)
        {
            CreateClientView view = new CreateClientView(controller, this);
            view.ShowDialog();
        }

        public void Update()
        {
            try
            {
                var clients = controller.Search(0, null);
                RenderClients(clients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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

            Font labelFont = new Font("Segoe UI", 10);

            Label nameLbl = new Label
            {
                Text = "Nombre",
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

            // ✏️ Editar cliente
            editBtn.Click += (s, e) =>
            {
                try
                {
                    controller.Update(
                        client.Id,
                        nameTxt.Text,
                        telTxt.Text,
                        mailTxt.Text
                    );

                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error al actualizar cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            };

            // 🗑 Eliminar cliente
            deleteBtn.Click += (s, e) =>
            {
                try
                {
                    controller.Delete(client.Id);
                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "No se pudo eliminar el cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            };

            card.Controls.AddRange(new Control[]
            {
                nameLbl, nameTxt,
                telLbl, telTxt,
                mailLbl, mailTxt,
                editBtn, deleteBtn
            });

            return card;
        }
    }
}
