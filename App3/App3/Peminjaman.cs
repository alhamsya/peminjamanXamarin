using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace App3
{
    public class Peminjaman
    {

        private string _id;
        [JsonProperty(PropertyName = "ID")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _namaPeminjaman;
        [JsonProperty(PropertyName = "NamaPeminjaman")]
        public string NamaPeminjaman
        {
            get { return _namaPeminjaman; }
            set { _namaPeminjaman = value; }
        }

        private string _nimPeminjaman;
        [JsonProperty(PropertyName = "NimPeminjaman")]
        public string NimPeminjaman
        {
            get { return _nimPeminjaman; }
            set { _nimPeminjaman = value; }
        }

        private string _ruangPeminjaman;
        [JsonProperty(PropertyName = "RuangPeminjaman")]
        public string RuangPeminjaman
        {
            get { return _ruangPeminjaman; }
            set { _ruangPeminjaman = value; }
        }

        private string _waktuPeminjaman;
        [JsonProperty(PropertyName = "WaktuPeminjaman")]
        public string WaktuPeminjaman
        {
            get { return _waktuPeminjaman; }
            set { _waktuPeminjaman = value; }
        }


        private string _waktuSelesai;
        [JsonProperty(PropertyName = "WaktuSelesai")]
        public string WaktuSelesai
        {
            get { return _waktuSelesai; }
            set { _waktuSelesai = value; }
        }

        private string _tanggalPeminjaman;
        [JsonProperty(PropertyName = "TanggalPeminjaman")]
        public string TanggalPeminjaman
        {
            get { return _tanggalPeminjaman; }
            set { _tanggalPeminjaman = value; }
        }



        [Version]
        public string Version { get; set; }
    }
}
