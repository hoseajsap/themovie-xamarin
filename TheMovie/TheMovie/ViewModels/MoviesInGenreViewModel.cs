using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
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

        private int _currentPage { get; set; }
        private int _genreId { get; set; }

        public MoviesInGenreViewModel(int id, int page, string genre)
        {
            MoviesByGenre = new ObservableCollection<DiscoverMovie>();
            _currentPage = page;
            _genreId = id;
            getMovies(_genreId, _currentPage);
            Title = $"Genre {genre}";
        }

        public async void getMovies(int id, int page)
        {
            var result = await _rest.getDiscoverByGenre(_genreId, page);

            if (result != null)
            {
                _currentPage++;
                MoviesByGenre = result.results;
            }
        }

        public async Task LoadMoreMoviesAsync()
        {
            var resultAdd = await _rest.getDiscoverByGenre(_genreId, _currentPage);
            if (resultAdd != null)
            {
                foreach (DiscoverMovie eachData in resultAdd.results)
                {
                    MoviesByGenre.Add(eachData);
                }
                _currentPage++;
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

