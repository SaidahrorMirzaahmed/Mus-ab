using Mus_ab.Helpers.Appointments;
using Mus_ab.Interfaces;
using Mus_ab.Models;

namespace Mus_ab.Services;

public class AppointmentService : IAppointmentService
{
    AppointmentReader appointmentReader = new AppointmentReader();
    AppointmentWriter appointmentWriter = new AppointmentWriter();

    private List<Appointment> appointments = new List<Appointment>();
    public async ValueTask<Appointment> CreateAsync(Appointment appointment)
    {
        appointments = appointmentReader.ReadAppointments();
        appointment.Id = appointments.Count == 0 ? 1 : appointments.Last().Id + 1;
        appointments.Add(appointment);
        appointmentWriter.WriteOrders(appointments);
        return appointment;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        appointments = appointmentReader.ReadAppointments();
        var exist = appointments.FirstOrDefault(a => a.Id == id);
        if (exist is null)
        {
            throw new Exception("Appointment is not found");
        }
        appointments.Remove(exist);
        appointmentWriter.WriteOrders(appointments);
        return true;
    }

    public async ValueTask<List<Appointment>> GetAllAsync()
    {
        appointments = appointmentReader.ReadAppointments();
        return appointments;
    }

    public async ValueTask<Appointment> GetByIdAsync(int id)
    {
        appointments = appointmentReader.ReadAppointments();
        var exist = appointments.FirstOrDefault(a => a.Id == id);
        if (exist is null)
        {
            throw new Exception("Appointment is not found");
        }
        return exist;
    }

    public async ValueTask<Appointment> UpdateAsync(int id, Appointment appointment)
    {
        appointments = appointmentReader.ReadAppointments();
        var exist = appointments.FirstOrDefault(a => a.Id == id);
        if (exist is null)
        {
            throw new Exception("Appointment is not found");
        }
       
        exist.AdditionalPrice = appointment.AdditionalPrice;
        exist.OrderTime = appointment.OrderTime;
        exist.BarberId = appointment.BarberId;
        exist.UserId = appointment.UserId;
        appointment.AdditionalFeatures = appointment.AdditionalFeatures;
        exist.Id = id;

        appointmentWriter.WriteOrders(appointments);
        return exist;
    }
}
