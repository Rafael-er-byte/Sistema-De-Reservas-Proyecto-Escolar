using System;
using System.Collections.Generic;
using SistemaDeReservas.Model;
using SistemaDeReservas.Repository;

namespace SistemaDeReservas.Controller
{
    public class ScheduleController
    {
        private readonly ScheduleRepository repository;

        public ScheduleController(ScheduleRepository repo)
        {
            repository = repo;
        }

        public void Create(string startTime)
        {
              TimeSpan time = TimeSpan.Parse(startTime);

            if (repository.ExistsByStartTime(time))
                throw new InvalidOperationException("El horario ya existe.");

            Schedule schedule = Schedule.CreateNew(time);
            repository.Create(schedule);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<Schedule> GetAll()
        {
            return repository.GetAll();
        }

        public Schedule GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
