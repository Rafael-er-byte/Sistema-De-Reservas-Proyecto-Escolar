using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class ReservationView : Form
    {
        private readonly ReservationController reservationController;
        private readonly ClientController clientController;
        private readonly ScheduleController scheduleController;

        private Font cardFont = new Font("Segoe UI", 10);

        public ReservationView(
            ReservationController reservationController,
            ClientController clientController,
            ScheduleController scheduleController)
        {
            InitializeComponent();

            this.reservationController = reservationController;
            this.clientController = clientController;
            this.scheduleController = scheduleController;

            InitStatusCombo();
            InitScheduleCombo();
            UpdateView();
        }

        private void InitStatusCombo()
        {
            statusCombo.Items.Clear();

            statusCombo.Items.Add("PENDIENTE");
            statusCombo.Items.Add("CONFIRMADA");
            statusCombo.Items.Add("CANCELADA");

            if (statusCombo.Items.Count > 0)
                statusCombo.SelectedIndex = 0;
        }

        private void InitScheduleCombo()
        {
            horarioCombo.Items.Clear();

            List<Schedule> schedules =
                scheduleController.GetAll();

            foreach (var s in schedules)
                horarioCombo.Items.Add(s);

            horarioCombo.DisplayMember = "StartTime";

            if (horarioCombo.Items.Count > 0)
                horarioCombo.SelectedIndex = 0;
        }


        private void buscarReservaBtn_Click(object sender, EventArgs e)
        {
            string search = reservaParametroDeBusquedaTxt.Text.Trim();
            string status = statusCombo.SelectedItem?.ToString();
            DateTime day = fechaPicker.Value.Date;

            DateTime hour =
                horarioCombo.SelectedItem != null
                ? fechaPicker.Value.Date +
                  ((Schedule)horarioCombo.SelectedItem).StartTime
                : DateTime.MinValue;

            var reservations =
                reservationController.GetByCriteria(
                    search,
                    status,
                    day,
                    hour
                );

            RenderReservations(reservations);
        }

        private void agregarReservaBtn_Click(object sender, EventArgs e)
        {
            CreateReservationView view =
                new CreateReservationView(
                    reservationController,
                    clientController,
                    scheduleController,
                    this
                );

            view.ShowDialog();
        }

        public void UpdateView()
        {

            var reservations =
                reservationController.GetByCriteria(
                    null,
                    statusCombo.SelectedItem.ToString(),
                    fechaPicker.Value.Date,
                    DateTime.MinValue
                );

            foreach (var reservation in reservations) { 
                    Debug.WriteLine( reservation.Id);
               }

            RenderReservations(reservations);
        }

        private void RenderReservations(List<Reservation> reservations)
        {
            reservasContainer.Controls.Clear();

            foreach (var r in reservations)
                reservasContainer.Controls.Add(CreateCard(r));
        }

        private Panel CreateCard(Reservation reservation)
        {
            Panel card = new Panel
            {
                Width = 580,
                Height = 230,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(12)
            };

            Label title = new Label
            {
                Text = $"Reserva #{reservation.Id}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, 15),
                Width = 300
            };

            Label clientLbl = new Label
            {
                Text = $"Cliente: {reservation.Client.Name}",
                Location = new Point(15, 45),
                Width = 350
            };

            Label statusLbl = new Label
            {
                Text = $"Estado: {reservation.Status}",
                Location = new Point(15, 70),
                Width = 200
            };

            Label personsLbl = new Label
            {
                Text = "Personas:",
                Location = new Point(15, 105),
                Width = 80
            };

            NumericUpDown personsInput = new NumericUpDown
            {
                Value = reservation.Persons,
                Minimum = 1,
                Location = new Point(95, 100),
                Width = 60
            };

            Label scheduleLbl = new Label
            {
                Text = "Horario:",
                Location = new Point(170, 105),
                Width = 70
            };

            ComboBox scheduleInput = new ComboBox
            {
                Location = new Point(240, 100),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "StartTime"
            };

            foreach (Schedule s in horarioCombo.Items)
            {
                scheduleInput.Items.Add(s);

                // Seleccionar el horario actual de la reserva
                if (s.Id == reservation.Schedule.Id)
                    scheduleInput.SelectedItem = s;
            }

            Button saveBtn = new Button
            {
                Text = "Guardar",
                BackColor = Color.LightSteelBlue,
                Font = cardFont,
                Location = new Point(15, 150),
                Width = 100,
                Height = 40
            };

            Button confirmBtn = new Button
            {
                Text = "Confirmar",
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Location = new Point(125, 150),
                Width = 100,
                Height = 40
            };

            Button cancelBtn = new Button
            {
                Text = "Cancelar",
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                Location = new Point(235, 150),
                Width = 100,
                Height = 40
            };

            Button deleteBtn = new Button
            {
                Text = "Eliminar",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Location = new Point(345, 150),
                Width = 100,
                Height = 40
            };

            saveBtn.Click += (s, e) =>
            {
                reservationController.Update(
                    reservation.Id,
                    reservation.Client.Id,
                    fechaPicker.Value.Date,
                    ((Schedule)scheduleInput.SelectedItem).Id,
                    (int)personsInput.Value,
                    reservation.Status
                );

                UpdateView();
            };

            confirmBtn.Click += (s, e) =>
            {
                reservationController.ChangeStatus(
                    reservation.Id,
                    "CONFIRMADA"
                );
                UpdateView();
            };

            cancelBtn.Click += (s, e) =>
            {
                reservationController.ChangeStatus(
                    reservation.Id,
                    "CANCELADA"
                );
                UpdateView();
            };

            deleteBtn.Click += (s, e) =>
            {
                reservationController.Delete(reservation.Id);
                UpdateView();
            };

            card.Controls.AddRange(new Control[]
            {
        title, clientLbl, statusLbl,
        personsLbl, personsInput,
        scheduleLbl, scheduleInput,
        saveBtn, confirmBtn, cancelBtn, deleteBtn
            });

            return card;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fechaPicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
