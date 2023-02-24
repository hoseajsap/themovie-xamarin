using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TheMovie.Models;
using TheMovie.Services;
using Xamarin.Forms;

namespace TheMovie.ViewModels
{
    public class MoviesInGenreViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IApiService _rest = DependencyService.Get<IApiService>();

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public MoviesInGenreViewModel(int id, int page, string genre)
        {
            getMovies(id, page);
            Title = $"Genre {genre}";
        }

        public async void getMovies(int id, int page)
        {
            MoviesByGenre = new ObservableCollection<DiscoverMovie>();
            var result = await _rest.getDiscoverByGenre(id, page);

            if (result != null)
            {
                MoviesByGenre = result.results;
            }
        }

        private ObservableCollection<DiscoverMovie> _MoviesByGenre;

        public ObservableCollection<DiscoverMovie> MoviesByGenre
        {
            get { return _MoviesByGenre; }
            set
            {
                _MoviesByGenre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MoviesByGenre"));
            }
        }
    }
}

