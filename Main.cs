using SistemaDeReservas.Controller;
using SistemaDeReservas.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaDeReservas
{
    public partial class Main : Form
    {
        private ClientController clientController;
        private ItemController itemController;
        private ScheduleController scheduleController;
        private OrderController orderController;
        private ReservationController reservationController;

        public Main()
        {
            InitializeComponent();
            BuildDependencies();
            ClienteView view = new ClienteView(clientController);
            ShowFormInPanel(view);
        }

        private void BuildDependencies()
        {
            var clientRepository = new ClientRepository();
            var itemRepository = new ItemRepository();
            var scheduleRepository = new ScheduleRepository();
            var orderRepository = new OrderRepository();
            var reservationRepository = new ReservationRepository();

            clientController = new ClientController(clientRepository);
            itemController = new ItemController(itemRepository);
            scheduleController = new ScheduleController(scheduleRepository);

            orderController = new OrderController(orderRepository);

            reservationController = new ReservationController(reservationRepository, scheduleRepository, clientRepository);
        }

        private void clientesLbl_Click(object sender, EventArgs e)
        {
            HighlightMenuLabel(clientesLbl);
            ClienteView view = new ClienteView(clientController);
            ShowFormInPanel(view);
        }

        private void ShowFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(form);
            form.Show();
        }

    private void HighlightMenuLabel(Label selectedLabel)
        {
            clientesLbl.ForeColor = Color.White;
            menuLbl.ForeColor = Color.White;
            pedidosLbl.ForeColor = Color.White;
            reservasLbl.ForeColor = Color.White;
            horariosLbl.ForeColor = Color.White;

            selectedLabel.ForeColor = Color.DarkSlateGray;
        }

        private void menuLbl_Click(object sender, EventArgs e)
        {
            HighlightMenuLabel(menuLbl);
            MenuView view = new MenuView(itemController);
            ShowFormInPanel(view);
        }

        private void horariosLbl_Click(object sender, EventArgs e)
        {
            HighlightMenuLabel(horariosLbl);
            ScheduleView view = new ScheduleView(scheduleController);
            ShowFormInPanel(view);
        }

        private void pedidosLbl_Click(object sender, EventArgs e)
        {
            HighlightMenuLabel(pedidosLbl);
            OrderView view = new OrderView(orderController, clientController, itemController);
            ShowFormInPanel(view);
        }

        private void reservasLbl_Click(object sender, EventArgs e)
        {
            HighlightMenuLabel(reservasLbl);
            ReservationView view = new ReservationView(reservationController, clientController, scheduleController);
            ShowFormInPanel(view);
        }
    }
}
