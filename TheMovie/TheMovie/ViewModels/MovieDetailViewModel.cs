using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Models;
using TheMovie.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheMovie.ViewModels
{
	public class MovieDetailViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        IApiService _rest = DependencyService.Get<IApiService>();

        public ICommand OpenWebCommand { get; }

        private int _currentPage { get; set; } = 1;
        private bool _isLoading = false;
        private int _idMovie { get; set; }


        public MovieDetailViewModel(int id)
        {
            AllReviews = new AllReview();
            _idMovie = id;
            getMovieDetail(id);
            getMovieReview(id, 1);
            OpenWebCommand = new Command(async () => await Browser.OpenAsync($"https://www.youtube.com/watch?v={MovieDetails.videos.results[0].key}"));
        }

        public async void getMovieDetail(int id)
        {
            var result = await _rest.GetMovieDetail(id);

            if (result != null)
            {
                MovieDetails = result;
            }
        }

        public async void getMovieReview(int idMovie, int page)
        {
            var result = await _rest.GetMovieReview(_idMovie, page);

            if (result != null)
            {
                AllReviews = result;
            }
        }

        public async Task LoadMoreReview()
        {
            if (!_isLoading)
            {
                _isLoading = true;

                var Reviews = await _rest.GetMovieReview(_idMovie, _currentPage);
                System.Diagnostics.Debug.WriteLine(_idMovie);

                if (Reviews != null && Reviews.results.Any())
                {
                    _currentPage++;
                    foreach (var review in Reviews.results)
                    {
                        AllReviews.results.Add(review);
                    }
                }

                _isLoading = false;
            }
        }


        private MovieDetail _movieDetails;

        public MovieDetail MovieDetails
        {
            get { return _movieDetails; }
            set
            {
                _movieDetails = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MovieDetails"));
            }
        }

        private AllReview _allReviews;

        public AllReview AllReviews
        {
            get { return _allReviews; }
            set
            {
                _allReviews = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllReviews"));
            }
        }
    }
}

