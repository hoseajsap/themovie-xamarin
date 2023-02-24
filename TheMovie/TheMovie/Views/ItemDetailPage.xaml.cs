using System.ComponentModel;
using Xamarin.Forms;
using TheMovie.ViewModels;

namespace TheMovie.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
