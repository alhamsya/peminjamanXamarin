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
    public partial class TambahPeminjamanPage : ContentPage
    {

        private PeminjamanManager _peminjamanManager = new PeminjamanManager();
        private bool _isNew = false;

        public TambahPeminjamanPage()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            foreach (var ctr in gvPeminjaman.Children)
            {
                if (ctr is Entry)
                {
                    var item = ctr as Entry;
                    item.Text = string.Empty;
                }
            }
        }

        public TambahPeminjamanPage(bool isNew)
        {
            InitializeComponent();
            _isNew = isNew;
            if (_isNew)
            {
                txtNamaPeminjaman.Focus();
            }
        }

        private async void BtnSave_OnClicked(object sender, EventArgs e)
        {
            if (_isNew)
            {
                var peminjaman = new Peminjaman()
                {
                    NamaPeminjaman = txtNamaPeminjaman.Text,
                    NimPeminjaman = txtNimPeminjaman.Text,
                    RuangPeminjaman = txtRuangPeminjaman.Text,
                    WaktuPeminjaman = txtWaktuPeminjaman.Text,
                    WaktuSelesai = txtWaktuSelesai.Text,
                    TanggalPeminjaman = txtTanggalPeminjaman.Text
                };
                await _peminjamanManager.SaveTaskAsync(peminjaman);
                ClearAll();
                await DisplayAlert("Keterangan", "Data Peminjaman berhasil ditambah !", "OK");
                await Navigation.PopAsync(true);
            }
            else
            {
                var peminjaman = (Peminjaman)this.BindingContext;
                await _peminjamanManager.SaveTaskAsync(peminjaman);

                await DisplayAlert("Keterangan", "Data Peminjaman berhasil diupdate !", "OK");
                await Navigation.PopAsync(true);
            }
        }

        private async void BtnDelete_OnClicked(object sender, EventArgs e)
        {

            if (_isNew)
            {
                await DisplayAlert("Keterangan", "Silahkan Isi data dankemudian simpan !", "OK");
            }
            else
            {
                var peminjaman = (Peminjaman)this.BindingContext;
                await _peminjamanManager.DeleteTaskAsync(peminjaman);

                await DisplayAlert("Keterangan", "Data Peminjaman berhasil dihapus !", "OK");
                await Navigation.PopAsync(true);
            }
        }
    }
}