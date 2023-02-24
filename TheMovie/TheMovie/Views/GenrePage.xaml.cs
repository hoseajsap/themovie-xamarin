using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovie.Models;
using TheMovie.ViewModels;
using Xamarin.Forms;

namespace TheMovie.Views
{	
	public partial class GenrePage : ContentPage
	{
		ObservableCollection<Genre> AllGenre = new ObservableCollection<Genre>();

		public GenrePage()
		{
			InitializeComponent ();
            BindingContext = new GenreViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedItem = e.SelectedItem as Genre;

            var MovieListPage = new MoviesInGenrePage(selectedItem);

            await Navigation.PushAsync(MovieListPage);

            ((ListView)sender).SelectedItem = null;
        }
    }
}

