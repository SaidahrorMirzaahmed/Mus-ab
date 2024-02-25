using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Models;

public class Rating
{
    public int Id { get; set; }
    public int UserId {  get; set; }
    public int BarberId { get; set; }
    public decimal Ratingg {  get; set; }
}
