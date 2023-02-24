using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheMovie.Models;
using TheMovie.Services;
using Xamarin.Forms;

namespace TheMovie.ViewModels
{
    public class GenreViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IApiService _rest = DependencyService.Get<IApiService>();

        public GenreViewModel()
        {
            getGenre();
        }

        public async void getGenre()
        {
            AllGenres = new ObservableCollection<Genre>();
            var result = await _rest.getAllGenre();

            if (result != null)
            {
                AllGenres = result.genres;
            }
        }

        private ObservableCollection<Genre> _AllGenres;

        public ObservableCollection<Genre> AllGenres
        {
            get { return _AllGenres; }
            set
            {
                _AllGenres = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllGenres"));
            }
        }
    }
}

