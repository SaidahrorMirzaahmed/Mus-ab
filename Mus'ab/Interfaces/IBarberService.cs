using Mus_ab.Models.barbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Interfaces;

public interface IBarberService
{
    ValueTask<BarberView> UpdateBarberAsync(int id, Barber barber);
    ValueTask<List<BarberView>> OrderByRatingAsync();
}
