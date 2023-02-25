using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheMovie.Models;

namespace TheMovie.Services
{
    public interface IApiService
    {
        Task<AllGenre> getAllGenre();
        Task<ResultDiscoverMovie> getDiscoverByGenre(int id, int page);
        Task<MovieDetail> GetMovieDetail(int movieId);
        Task<AllReview> GetMovieReview(int movieId, int page);
    }
}

