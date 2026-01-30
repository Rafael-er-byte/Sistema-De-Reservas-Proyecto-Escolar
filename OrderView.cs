using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class OrderView : Form
    {
        private readonly OrderController orderController;
        private readonly ClientController clientController;
        private readonly ItemController itemController;

        private Font cardFont = new Font("Segoe UI", 11);

        public OrderView(
            OrderController orderController,
            ClientController clientController,
            ItemController itemController)
        {
            InitializeComponent();

            this.orderController = orderController;
            this.clientController = clientController;
            this.itemController = itemController;

            InitStatusCombo();
            Update();
        }

        private void InitStatusCombo()
        {
            statusCombo.Items.Clear();
            statusCombo.Items.Add("Pendiente");
            statusCombo.Items.Add("Confirmada");
            statusCombo.Items.Add("Cancelada");
            statusCombo.SelectedIndex = 0;
        }

        private void buscarOrdenBtn_Click(object sender, EventArgs e)
        {
            string nameLikeOrId = orderParametroDeBusquedaTxt.Text.Trim();
            string status = statusCombo.SelectedItem?.ToString();

            var orders = orderController.GetByCriteria(
                0,
                status,
                nameLikeOrId
            );

            RenderOrders(orders);
        }

        private void agregarOrdenBtn_Click(object sender, EventArgs e)
        {
            CreateOrderView view = new CreateOrderView(
                clientController,
                itemController,
                orderController,
                this
            );

            view.ShowDialog();
        }

        public void Update()
        {
            string status = statusCombo.SelectedItem?.ToString() ?? "Pendiente";
            var orders = orderController.GetByCriteria(0, status, null);
            RenderOrders(orders);
        }

        private void RenderOrders(List<Order> orders)
        {
            ordersContainer.Controls.Clear();

            foreach (var order in orders)
            {
                ordersContainer.Controls.Add(CreateOrderCard(order));
            }
        }

        private Panel CreateOrderCard(Order order)
        {
            Panel card = new Panel
            {
                Width = 560,
                Height = 180,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(12)
            };

            Font labelFont = new Font("Segoe UI", 10);

            Label idLbl = new Label
            {
                Text = $"Orden #{order.Id}",
                Font = labelFont,
                Location = new Point(15, 15),
                Width = 200
            };

            Label clientLbl = new Label
            {
                Text = $"Cliente ID: {order.IdClient}",
                Font = labelFont,
                Location = new Point(15, 40),
                Width = 200
            };

            Label totalLbl = new Label
            {
                Text = $"Total: ${order.Total:N2}",
                Font = labelFont,
                Location = new Point(15, 65),
                Width = 200
            };

            Label statusLbl = new Label
            {
                Text = $"Estado: {order.Status}",
                Font = labelFont,
                Location = new Point(15, 90),
                Width = 200
            };

            Button deleteBtn = new Button
            {
                Text = "Eliminar",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(125, 120),
                Width = 100,
                Height = 36
            };

            Button completeBtn = new Button
            {
                Text = "Completar",
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(235, 120),
                Width = 110,
                Height = 36
            };

            Button cancelBtn = new Button
            {
                Text = "Cancelar",
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(355, 120),
                Width = 110,
                Height = 36
            };

            deleteBtn.Click += (s, e) =>
            {
                orderController.Delete(order.Id);
                Update();
            };

            completeBtn.Click += (s, e) =>
            {
                orderController.ChangeStatus(order.Id, "Confirmada");
                Update();
            };

            cancelBtn.Click += (s, e) =>
            {
                orderController.ChangeStatus(order.Id, "Cancelada");
                Update();
            };

            card.Controls.Add(idLbl);
            card.Controls.Add(clientLbl);
            card.Controls.Add(totalLbl);
            card.Controls.Add(statusLbl);
            card.Controls.Add(deleteBtn);
            card.Controls.Add(completeBtn);
            card.Controls.Add(cancelBtn);

            return card;
        }

    }
}
