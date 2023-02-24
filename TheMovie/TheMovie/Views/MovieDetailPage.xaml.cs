using System;
using System.Collections.Generic;
using TheMovie.ViewModels;
using Xamarin.Forms;

namespace TheMovie.Views
{	
	public partial class MovieDetailPage : ContentPage
	{	
		public MovieDetailPage (int id)
		{
			InitializeComponent ();
			BindingContext = new MovieDetailViewModel(id);
		}
	}
}