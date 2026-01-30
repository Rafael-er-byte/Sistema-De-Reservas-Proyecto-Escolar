using System;
using System.Collections.Generic;
using System.Diagnostics;
using SistemaDeReservas.Model;
using SistemaDeReservas.Repository;

namespace SistemaDeReservas.Controller
{
    public class ReservationController
    {
        private readonly ReservationRepository repository;
        private readonly ScheduleRepository scheduleRepository;
        private readonly ClientRepository clientRepository;

        public ReservationController(ReservationRepository repo, ScheduleRepository scheduleRepo, ClientRepository clientRepository)
        {
            repository = repo;
            this.scheduleRepository = scheduleRepo;
            this.clientRepository = clientRepository;
        }

        public void Update(
        int reservationId,
        int clientId,
        DateTime day,
        int scheduleId,
        int persons,
        string status)
        {
            if (reservationId <= 0)
                throw new ArgumentException("Id de reservación inválido.");

            if (clientId <= 0)
                throw new ArgumentException("Cliente inválido.");

            if (scheduleId <= 0)
                throw new ArgumentException("Horario inválido.");

            if (persons <= 0)
                throw new ArgumentException("El número de personas no es válido.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El estado no es válido.");

            Client client = clientRepository.GetById(clientId);
            Schedule schedule = scheduleRepository.GetById(scheduleId);

            DateTime fullDateTime = day.Date + schedule.StartTime;

            Reservation reservation =
                Reservation.CreateExisting(
                    reservationId,
                    client,
                    schedule,
                    fullDateTime,
                    persons,
                    status
                );

            repository.Update(reservation);
        }

        public void Delete(int reservationId)
        {
            repository.Delete(reservationId);
        }

        public void ChangeStatus(int reservationId, string status)
        {
            repository.UpdateStatus(reservationId, status);
        }

        public List<Reservation> GetByCriteria(
        string clientNameLikeOrId,
        string status,
        DateTime dateDay,
        DateTime dateHour)
        {
            ReservationCriteria criteria = new ReservationCriteria
            {
                clientNameLikeOrId = clientNameLikeOrId,
                status = status,
                dateDay = dateDay,
                dateHour = dateHour
            };

            return repository.GetByCriteria(criteria);
        }

        public Reservation CreateNew(
        int clientId,
        DateTime day,
        int scheduleId,
        int persons)
        {
            if (clientId <= 0)
                throw new ArgumentException("Cliente inválido.");

            if (scheduleId <= 0)
                throw new ArgumentException("Horario inválido.");

            if (persons <= 0)
                throw new ArgumentException("El número de personas no es válido.");

            if (day == DateTime.MinValue)
                throw new ArgumentException("La fecha no es válida.");
            
            Client client = clientRepository.GetById(clientId);
            Schedule schedule = scheduleRepository.GetById(scheduleId);

            DateTime fullDateTime = day.Date + schedule.StartTime;

            Reservation reservation =
                Reservation.CreateNew(
                    client,
                    fullDateTime,
                    schedule,
                    persons
                );

            repository.Create(reservation);
            return reservation;
        }

    }
}
