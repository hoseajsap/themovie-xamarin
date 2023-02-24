using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public MovieDetailViewModel(int id)
        {
            getMovieDetail(id);
            OpenWebCommand = new Command(async () => await Browser.OpenAsync($"https://www.youtube.com/watch?v={MovieDetails.videos.results[0].key}"));
        }

        public async void getMovieDetail(int id)
        {
            MovieDetails = new MovieDetail();
            var result = await _rest.GetMovieDetail(id);

            if (result != null)
            {
                MovieDetails = result;
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
    }
}

