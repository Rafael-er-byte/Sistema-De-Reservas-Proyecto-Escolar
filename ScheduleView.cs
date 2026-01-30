using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaDeReservas.Controller;
using SistemaDeReservas.Model;

namespace SistemaDeReservas
{
    public partial class ScheduleView : Form
    {
        private ScheduleController controller;
        private Font cardFont = new Font("Segoe UI", 11);

        public ScheduleView(ScheduleController controller)
        {
            InitializeComponent();
            this.controller = controller;
            Update();
        }

        private void agregarHorarioBtn_Click(object sender, EventArgs e)
        {
            CreateScheduleView view = new CreateScheduleView(controller, this);
            view.ShowDialog();
        }

        public void Update()
        {
            var schedules = controller.GetAll();
            RenderSchedules(schedules);
        }

        private void RenderSchedules(List<Schedule> schedules)
        {
            horariosContainer.Controls.Clear();

            foreach (var schedule in schedules)
            {
                horariosContainer.Controls.Add(CreateScheduleCard(schedule));
            }
        }

        private Panel CreateScheduleCard(Schedule schedule)
        {
            Panel card = new Panel
            {
                Width = 420,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(12)
            };

            Label timeLbl = new Label
            {
                Text = $"{schedule.StartTime}",
                Font = cardFont,
                Location = new Point(15, 20),
                AutoSize = true
            };

            Button deleteBtn = new Button
            {
                Text = "Eliminar",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = cardFont,
                Location = new Point(15, 60),
                Width = 120,
                Height = 36
            };

            deleteBtn.Click += (s, e) =>
            {
                controller.Delete(schedule.Id);
                Update();
            };

            card.Controls.Add(timeLbl);
            card.Controls.Add(deleteBtn);

            return card;
        }
    }
}
