using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class CreateOrderView : Form
    {
        private readonly ClientController clientController;
        private readonly ItemController itemController;
        private readonly OrderController orderController;
        private readonly OrderView parentView;

        private Dictionary<Item, int> itemsMap = new Dictionary<Item, int>();
        private Font cardFont = new Font("Segoe UI", 10);

        public CreateOrderView(
            ClientController clientController,
            ItemController itemController,
            OrderController orderController,
            OrderView parentView)
        {
            InitializeComponent();

            this.clientController = clientController;
            this.itemController = itemController;
            this.orderController = orderController;
            this.parentView = parentView;

            LoadCombos();
            UpdateTotal();
        }

        // Cargar combos
        private void LoadCombos()
        {
            clienteCombo.DataSource = clientController.GetAll();
            clienteCombo.DisplayMember = "Name";
            clienteCombo.ValueMember = "Id";

            itemCombo.DataSource = itemController.GetAll();
            itemCombo.DisplayMember = "Name";
            itemCombo.ValueMember = "Id";
        }

        // Agregar item
        private void agregarItem_Click(object sender, EventArgs e)
        {
            Item item = itemCombo.SelectedItem as Item;
            if (item == null) return;

            if (itemsMap.ContainsKey(item))
                itemsMap[item]++;
            else
                itemsMap[item] = 1;

            RenderItems();
            UpdateTotal();
        }

        // Renderizar items
        private void RenderItems()
        {
            itemsPanel.Controls.Clear();

            foreach (var pair in itemsMap)
            {
                itemsPanel.Controls.Add(CreateItemCard(pair.Key, pair.Value));
            }
        }

        private Panel CreateItemCard(Item item, int quantity)
        {
            Panel card = new Panel
            {
                Width = 460,
                Height = 70,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(6)
            };

            Label nameLbl = new Label
            {
                Text = item.Name,
                Font = cardFont,
                Location = new Point(10, 10),
                Width = 200
            };

            TextBox qtyTxt = new TextBox
            {
                Text = quantity.ToString(),
                Font = cardFont,
                Location = new Point(220, 8),
                Width = 50,
                TextAlign = HorizontalAlignment.Center
            };

            Button plusBtn = new Button
            {
                Text = "+",
                Location = new Point(280, 6),
                Width = 35,
                Height = 28
            };

            Button minusBtn = new Button
            {
                Text = "-",
                Location = new Point(320, 6),
                Width = 35,
                Height = 28
            };

            Button deleteBtn = new Button
            {
                Text = "X",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Location = new Point(365, 6),
                Width = 35,
                Height = 28
            };

            plusBtn.Click += (s, e) =>
            {
                itemsMap[item]++;
                RenderItems();
                UpdateTotal();
            };

            minusBtn.Click += (s, e) =>
            {
                itemsMap[item]--;
                if (itemsMap[item] <= 0)
                    itemsMap.Remove(item);

                RenderItems();
                UpdateTotal();
            };

            deleteBtn.Click += (s, e) =>
            {
                itemsMap.Remove(item);
                RenderItems();
                UpdateTotal();
            };

            qtyTxt.TextChanged += (s, e) =>
            {
                if (int.TryParse(qtyTxt.Text, out int newQty))
                {
                    if (newQty <= 0)
                        itemsMap.Remove(item);
                    else
                        itemsMap[item] = newQty;

                    RenderItems();
                    UpdateTotal();
                }
            };

            card.Controls.Add(nameLbl);
            card.Controls.Add(qtyTxt);
            card.Controls.Add(plusBtn);
            card.Controls.Add(minusBtn);
            card.Controls.Add(deleteBtn);

            return card;
        }

        // Actualizar total
        private void UpdateTotal()
        {
            decimal total = itemsMap.Sum(i => i.Key.Price * i.Value);
            if (total < 0) total = 0;

            mostrarTotalLbl.Text = $"Total: ${total:N2}";
        }

        // Crear orden
        private void crearOrdenBtn_Click(object sender, EventArgs e)
        {
            if (clienteCombo.SelectedItem == null || itemsMap.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente y al menos un ítem.");
                return;
            }

            try
            {
                int clientId = (int)clienteCombo.SelectedValue;

                orderController.CreateNew(clientId, itemsMap);

                parentView.Update();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
