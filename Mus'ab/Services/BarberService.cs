using Mus_ab.Helpers;
using Mus_ab.Helpers.Barbers;
using Mus_ab.Interfaces;
using Mus_ab.Models.barbers;
using Mus_ab.Models.users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Services;

public class BarberService : IBarberService
{
    BarberReader barberReader=new BarberReader();
    BarberWriter barberWriter=new BarberWriter();

    private List<Barber> barbers=new List<Barber>();
    public async ValueTask<List<BarberView>> OrderByRatingAsync()
    {
        barbers=barberReader.ReadBarbers();
        var list=barbers.OrderBy(x=>x.Rating).ToList().Select(b=> Mapper.MapTo<BarberView>(b)).ToList();
        return list;
    }

    public async ValueTask<BarberView> UpdateBarberAsync(int id, Barber barber)
    {
        barbers = barberReader.ReadBarbers();
        var exist=barbers.FirstOrDefault(b => b.Id == id);
        exist.Rating = barber.Rating;
        exist.FirstName = barber.FirstName;
        exist.LastName = barber.LastName;
        exist.Email = barber.Email;
        exist.Id = id;

        barberWriter.WriteBarbers(barbers);

        return Mapper.MapTo<BarberView>(exist);
    }
}
