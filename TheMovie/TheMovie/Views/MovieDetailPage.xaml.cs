using System;
using System.Collections.Generic;
using TheMovie.ViewModels;
using Xamarin.Forms;

namespace TheMovie.Views
{	
	public partial class MovieDetailPage : ContentPage
	{
        private readonly MovieDetailViewModel _viewModel;

        public MovieDetailPage (int id)
		{
			InitializeComponent ();
            _viewModel = new MovieDetailViewModel(id);
            BindingContext = _viewModel;
		}

        private async void OnScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = (ScrollView)sender;
            var scrollingSpace = scrollView.ContentSize.Height - scrollView.Height;
            var currentScroll = scrollView.ScrollY;

            if (scrollingSpace < currentScroll + 50)
            {
                await (_viewModel.LoadMoreReview());
            }
        }
    }
}