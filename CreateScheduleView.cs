using System;
using System.Windows.Forms;
using SistemaDeReservas.Controller;

namespace SistemaDeReservas
{
    public partial class CreateScheduleView : Form
    {
        private ScheduleController controller;
        private ScheduleView scheduleView;

        public CreateScheduleView(ScheduleController controller, ScheduleView scheduleView)
        {
            InitializeComponent();
            this.controller = controller;
            this.scheduleView = scheduleView;
        }

        private void crearHorarioBtn_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Create(horarioTxt.Text);

                scheduleView.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
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
