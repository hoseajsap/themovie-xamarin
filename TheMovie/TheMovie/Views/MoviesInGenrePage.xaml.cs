using System;
using System.Collections.Generic;
using System.Linq;
using TheMovie.Models;
using TheMovie.ViewModels;
using Xamarin.Forms;

namespace TheMovie.Views
{	
	public partial class MoviesInGenrePage : ContentPage
	{
        private readonly MoviesInGenreViewModel _viewModel;

        public MoviesInGenrePage (Genre selectedItem)
		{
			InitializeComponent ();
            _viewModel = new MoviesInGenreViewModel(selectedItem.id, 1, selectedItem.name);
            BindingContext = _viewModel;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadMoreMoviesAsync();
        }

        private async void OnListViewItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var lastItem = _viewModel.MoviesByGenre.Last();
            if (e.Item == lastItem)
            {
                await _viewModel.LoadMoreMoviesAsync();
            }
        }
    }
}

