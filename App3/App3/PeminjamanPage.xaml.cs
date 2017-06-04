using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeminjamanPage : ContentPage
	{

        private PeminjamanManager _peminjamanManager = new PeminjamanManager();
        public PeminjamanPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshItems(true);
        }


        private async Task RefreshItems(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                listViewPeminjaman.ItemsSource = await _peminjamanManager.GetPeminjamanAsync();
            }
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            TambahPeminjamanPage tambahPage = new TambahPeminjamanPage();

            Peminjaman item = (Peminjaman)e.Item;
            tambahPage.BindingContext = item;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(tambahPage);
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            TambahPeminjamanPage tambahPage = new TambahPeminjamanPage(true);
            await Navigation.PushAsync(tambahPage);
        }


        private async void ListViewPeminjaman_OnRefreshing(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error !", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }


    }
}