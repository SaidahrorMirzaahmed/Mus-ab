using Mus_ab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Interfaces;

public interface IRatingService
{
    ValueTask<Rating> RateAsync(Rating rating);
}
