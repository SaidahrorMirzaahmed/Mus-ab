using Mus_ab.Models;
using Mus_ab.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Interfaces;

public interface IReviewService
{
    ValueTask<Review> CreateAsync(Review review);
    ValueTask<Review> UpdateAsync(int id, Review review);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<List<Review>> GetAllReviews();
    ValueTask<List<Review>> GetReviewByBarberId(int barberId);
}
