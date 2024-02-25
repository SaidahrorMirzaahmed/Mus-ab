using Mus_ab.Helpers.Ratings;
using Mus_ab.Interfaces;
using Mus_ab.Models;
using Mus_ab.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Services;

public class RatingService : IRatingService
{
    RatingReader RatingReader=new RatingReader();
    RatingWriter RatingWriter=new RatingWriter();

    private List<Rating> ratings = new List<Rating>();
    public async ValueTask<Rating> RateAsync(Rating rating)
    {
        ratings = RatingReader.ReadRatings();
        rating.Id = ratings.Count == 0 ? 1 : ratings.Last().Id + 1;
        ratings.Add(rating);
        RatingWriter.WriteRatings(ratings);
        return rating;
    }
}
