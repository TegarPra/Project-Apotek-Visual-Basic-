# Project Apotek - Visual Basic

## Deskripsi
Project Apotek adalah aplikasi manajemen apotek berbasis desktop yang dikembangkan menggunakan Visual Basic .NET. Aplikasi ini bertujuan untuk membantu pemilik dan pegawai apotek dalam mengelola persediaan obat, transaksi penjualan, serta pencatatan data pelanggan dan pemasok dengan lebih efisien dan akurat.

## Fitur Utama
- **Manajemen Obat**
  - Menambahkan data obat baru.
  - Mengedit informasi obat seperti nama, harga, stok, dan tanggal kedaluwarsa.
  - Menghapus obat yang sudah tidak tersedia.
  
- **Transaksi Penjualan**
  - Mencatat transaksi pembelian obat oleh pelanggan.
  - Menghitung total biaya otomatis.
  - Mencetak struk pembelian.
  
- **Manajemen Pelanggan**
  - Menyimpan data pelanggan yang melakukan pembelian.
  - Melacak riwayat pembelian pelanggan.

- **Manajemen Pemasok**
  - Menyimpan data pemasok obat.
  - Melakukan pencatatan barang masuk dari pemasok.

- **Laporan Penjualan**
  - Menampilkan laporan transaksi dalam periode tertentu.
  - Mengekspor laporan ke format PDF atau Excel.

## Persyaratan Sistem
- **Sistem Operasi**: Windows 10/11
- **IDE**: Visual Studio (dengan dukungan Visual Basic .NET)
- **Database**: SQL Server (jika menggunakan database lokal)
- **Framework**: .NET Framework 4.5 atau lebih baru

## Cara Instalasi
1. **Clone atau Download Repository**
   ```sh
   git clone <repository-url>
   ```
2. **Buka di Visual Studio**
   - Buka file solusi (`.sln`) menggunakan Visual Studio.
3. **Konfigurasi Database**
   - Jalankan SQL Server dan buat database baru.
   - Import skrip database yang disediakan dalam folder `Database/`.
   - Sesuaikan string koneksi di aplikasi agar sesuai dengan konfigurasi database Anda.
4. **Jalankan Aplikasi**
   - Tekan `F5` di Visual Studio untuk menjalankan aplikasi.

## Struktur Proyek
```
/Project Apotek
├── My Project/           # Pengaturan proyek dan konfigurasi utama
├── References/           # Referensi pustaka eksternal
├── apotek.vb            # Modul utama aplikasi
├── App.config           # File konfigurasi aplikasi
├── bill.vb              # Modul untuk pengelolaan tagihan
├── datakasir.vb         # Modul data kasir
├── dataobat.vb          # Modul untuk manajemen data obat
├── datapembeli.vb       # Modul untuk menyimpan data pembeli
├── FormLoading.vb       # Form untuk tampilan loading aplikasi
├── laporan.vb           # Modul untuk pembuatan laporan
├── login.vb             # Modul untuk autentikasi pengguna
├── Module1.vb           # Modul pendukung dengan fungsi tambahan
├── pembayaran.vb        # Modul untuk proses pembayaran
├── pembelian.vb         # Modul untuk pencatatan pembelian obat
├── Register.vb          # Modul untuk pendaftaran pengguna

└── README.md            # Dokumentasi proyek
```

## Kontak
- **Email**: [tegarp2608@gmail.com](mailto:tegarp2608@gmail.com)
- **GitHub**: [github.com/TegarPra](https://github.com/TegarPra)

## Lisensi
Proyek ini bersifat open-source dan dapat digunakan sesuai dengan ketentuan lisensi yang berlaku.

## Catatan Tambahan
- Pastikan sistem Anda memiliki SQL Server yang sudah dikonfigurasi dengan benar.
- Jika terjadi error saat menjalankan aplikasi, periksa string koneksi database dan pastikan dependensi sudah terinstal.
- Anda dapat menyesuaikan laporan atau fitur lain sesuai dengan kebutuhan apotek Anda.

