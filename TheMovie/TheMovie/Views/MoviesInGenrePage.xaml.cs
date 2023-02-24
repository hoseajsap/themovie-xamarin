using System;
using System.Collections.Generic;
using TheMovie.Models;
using TheMovie.ViewModels;
using Xamarin.Forms;

namespace TheMovie.Views
{	
	public partial class MoviesInGenrePage : ContentPage
	{	
		public MoviesInGenrePage (Genre selectedItem)
		{
			InitializeComponent ();
			BindingContext = new MoviesInGenreViewModel(selectedItem.id, 1, selectedItem.name);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedItem = e.SelectedItem as DiscoverMovie;

            var MovieListPage = new MovieDetailPage(selectedItem.id);

            await Navigation.PushAsync(MovieListPage);

            ((ListView)sender).SelectedItem = null;
        }
    }
}

