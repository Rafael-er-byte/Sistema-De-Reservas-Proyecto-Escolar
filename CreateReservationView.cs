using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class CreateReservationView : Form
    {
        private readonly ReservationController reservationController;
        private readonly ClientController clientController;
        private readonly ScheduleController scheduleController;
        private readonly ReservationView parentView;

        public CreateReservationView(
            ReservationController reservationController,
            ClientController clientController,
            ScheduleController scheduleController,
            ReservationView parentView)
        {
            InitializeComponent();

            this.reservationController = reservationController;
            this.clientController = clientController;
            this.scheduleController = scheduleController;
            this.parentView = parentView;

            InitClientCombo();
            InitScheduleCombo();
        }

        private void InitClientCombo()
        {
            clienteCombo.Items.Clear();

            List<Client> clients =
                clientController.Search(null, null);

            foreach (var c in clients)
                clienteCombo.Items.Add(c);

            clienteCombo.DisplayMember = "Name";
            clienteCombo.SelectedIndex = clients.Count > 0 ? 0 : -1;
        }

        private void InitScheduleCombo()
        {
            horarioCombo.Items.Clear();

            List<Schedule> schedules =
                scheduleController.GetAll();

            foreach (var s in schedules)
                horarioCombo.Items.Add(s);

            horarioCombo.DisplayMember = "StartTime";
            horarioCombo.SelectedIndex = schedules.Count > 0 ? 0 : -1;
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void crearReservaBtn_Click(object sender, EventArgs e)
        {
            if (clienteCombo.SelectedItem == null ||
                horarioCombo.SelectedItem == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente y un horario.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                int clientId = ((dynamic)clienteCombo.SelectedItem).Id;
                int scheduleId = ((dynamic)horarioCombo.SelectedItem).Id;
                DateTime day = fechaPicker.Value.Date;

                int persons = int.Parse(personsUpDown.Value.ToString()); 

                reservationController.CreateNew(
                    clientId,
                    day,
                    scheduleId,
                    persons
                );

                parentView.UpdateView();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo crear la reservación.\n\n" +
                    "Posibles causas:\n" +
                    "- El horario ya está ocupado\n" +
                    "- Datos inválidos\n" +
                    "- Problemas de conexión a la base de datos\n\n" +
                    $"Detalle técnico:\n{ex.Message}",
                    "Error al crear reservación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
