using Mus_ab.Models;
using Mus_ab.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Interfaces;

public interface IAppointmentService
{
    ValueTask<Appointment> CreateAsync(Appointment appointment);
    ValueTask<Appointment> UpdateAsync(int id, Appointment appointment);
    ValueTask<List<Appointment>> GetAllAsync();
    ValueTask<Appointment> GetByIdAsync(int id);
    ValueTask<bool> DeleteAsync(int id);
}
