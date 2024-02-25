using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Models;

public class Review
{
    public int Id { get; set; }
    public int BarberId {  get; set; }
    public int CustomerId {  get; set; }
    public string Message { get; set; }
}
