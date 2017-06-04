using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace App3
{
    public class PeminjamanManager
    {

        private IMobileServiceTable<Peminjaman> _peminjamanTable;

        public PeminjamanManager()
        {
            var client = new MobileServiceClient(Constants.ApplicationURL);
            _peminjamanTable = client.GetTable<Peminjaman>();
        }

        public async Task<ObservableCollection<Peminjaman>> GetPeminjamanAsync()
        {
            try
            {
                IEnumerable<Peminjaman> peminjamans = await _peminjamanTable.ToEnumerableAsync();
                return new ObservableCollection<Peminjaman>(peminjamans);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("@Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(Peminjaman peminjaman)
        {
            if (peminjaman.Id == null)
            {
                await _peminjamanTable.InsertAsync(peminjaman);
            }
            else
            {
                await _peminjamanTable.UpdateAsync(peminjaman);
            }
        }

        public async Task DeleteTaskAsync(Peminjaman peminjaman)
        {
            
                await _peminjamanTable.DeleteAsync(peminjaman);
            

        }

    }
}
