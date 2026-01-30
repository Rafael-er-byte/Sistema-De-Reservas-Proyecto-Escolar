using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class MenuView : Form
    {
        private readonly ItemController controller;
        private Font cardFont = new Font("Segoe UI", 11);

        public MenuView(ItemController controller)
        {
            InitializeComponent();
            this.controller = controller;
            Update();
        }

        private void buscarItemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string param = itemParametroDeBusquedaTxt.Text.Trim();

                int id = 0;
                string nameLike = null;

                if (int.TryParse(param, out int parsedId))
                    id = parsedId;
                else if (!string.IsNullOrWhiteSpace(param))
                    nameLike = param;

                var items = controller.Search(id, nameLike);
                RenderItems(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al buscar ítems",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void agregarItemBtn_Click(object sender, EventArgs e)
        {
            CreateItemView view = new CreateItemView(controller, this);
            view.ShowDialog();
        }

        public void Update()
        {
            try
            {
                var items = controller.Search(0, null);
                RenderItems(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar el menú",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void RenderItems(List<Item> items)
        {
            itemContainer.Controls.Clear();

            foreach (var item in items)
            {
                itemContainer.Controls.Add(CreateItemCard(item));
            }
        }

        private Panel CreateItemCard(Item item)
        {
            Panel card = new Panel
            {
                Width = 520,
                Height = 220,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(12)
            };

            Font labelFont = new Font("Segoe UI", 10);

            Label nameLbl = new Label
            {
                Text = "Nombre",
                Location = new Point(15, 18),
                Width = 90
            };

            TextBox nameTxt = new TextBox
            {
                Text = item.Name,
                Font = cardFont,
                Location = new Point(110, 15),
                Width = 380
            };

            Label descLbl = new Label
            {
                Text = "Descripción",
                Location = new Point(15, 58),
                Width = 90
            };

            TextBox descTxt = new TextBox
            {
                Text = item.Description,
                Font = cardFont,
                Location = new Point(110, 55),
                Width = 380
            };

            Label priceLbl = new Label
            {
                Text = "Precio",
                Location = new Point(15, 98),
                Width = 90
            };

            TextBox priceTxt = new TextBox
            {
                Text = item.Price.ToString("0.00"),
                Font = cardFont,
                Location = new Point(110, 95),
                Width = 380
            };

            Button editBtn = new Button
            {
                Text = "Editar",
                BackColor = Color.LightGray,
                Font = cardFont,
                Location = new Point(110, 150),
                Width = 120,
                Height = 36
            };

            Button deleteBtn = new Button
            {
                Text = "Eliminar",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(245, 150),
                Width = 120,
                Height = 36
            };

            // ✏️ Editar ítem
            editBtn.Click += (s, e) =>
            {
                try
                {
                    controller.Update(
                        item.Id,
                        nameTxt.Text,
                        descTxt.Text,
                        decimal.Parse(priceTxt.Text)
                    );

                    Update();
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "El precio debe ser un número válido.",
                        "Dato inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error al actualizar ítem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            };

            // 🗑 Eliminar ítem
            deleteBtn.Click += (s, e) =>
            {
                try
                {
                    controller.Delete(item.Id);
                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "No se pudo eliminar el ítem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            };

            card.Controls.AddRange(new Control[]
            {
                nameLbl, nameTxt,
                descLbl, descTxt,
                priceLbl, priceTxt,
                editBtn, deleteBtn
            });

            return card;
        }
    }
}
