-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Waktu pembuatan: 01 Feb 2025 pada 07.13
-- Versi server: 8.0.30
-- Versi PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apotek`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `kasir`
--

CREATE TABLE `kasir` (
  `id_kasir` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `nama_lengkap` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `alamat` text COLLATE utf8mb4_general_ci NOT NULL,
  `nomor_telepon` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `tanggal_lahir` date NOT NULL,
  `tanggal_bergabung` date NOT NULL,
  `shift_kerja` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `gaji` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `kasir`
--

INSERT INTO `kasir` (`id_kasir`, `nama_lengkap`, `alamat`, `nomor_telepon`, `email`, `tanggal_lahir`, `tanggal_bergabung`, `shift_kerja`, `gaji`) VALUES
('DK001', 'Fawitio', 'Jl Malaka Baru', '082212345', 'tio@gmail.com', '2001-06-06', '2024-01-16', 'Pagi', 3000000.00),
('DK002', 'Hazbie', 'Jl Cpinang Raya', '082210987', 'Hazbie@gmail.com', '2003-08-19', '2024-05-08', 'Siang', 3000000.00),
('DK003', 'Ivo', 'Jl Jatinegara Baru', '0822356797', 'Ivo@gmail.com', '2002-10-15', '2024-03-13', 'Malam', 3000000.00),
('DK004', 'Tristan', 'Jl Malaka 1', '08214436457', 'tristan@gmail.com', '2001-06-12', '2024-05-07', 'Siang', 3000000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `obat`
--

CREATE TABLE `obat` (
  `kode_obat` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `nama_obat` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `kategori_obat` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `tanggal_kadaluwarsa` date NOT NULL,
  `stok_awal` int NOT NULL,
  `harga_satuan` decimal(10,2) NOT NULL,
  `brand` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `dosis` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `penyimpanan` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `bentuk_obat` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `indikasi_obat` text COLLATE utf8mb4_general_ci NOT NULL,
  `efek_samping` text COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `obat`
--

INSERT INTO `obat` (`kode_obat`, `nama_obat`, `kategori_obat`, `tanggal_kadaluwarsa`, `stok_awal`, `harga_satuan`, `brand`, `dosis`, `penyimpanan`, `bentuk_obat`, `indikasi_obat`, `efek_samping`) VALUES
('OB001', 'Paracetamol', 'Analgesik', '2025-12-01', 100, 2000.00, 'Kimia Farma', '500 mg setiap 6-8 jam', 'Sejuk', 'Tablet', 'Digunakan untuk meredakan nyeri ringan hingga sedang dan demam', 'Mual, reaksi alergi'),
('OB002', 'Amoxicillin', 'Antibiotik', '2026-03-15', 45, 5000.00, 'Meiji', '500 mg setiap 8 jam', 'Kering', 'Tablet', 'Mengobati berbagai infeksi bakteri', 'Diare, mual, ruam kulit'),
('OB003', 'Vitamin C', 'Vitamin', '2025-01-01', 200, 1000.00, 'Holisticare', '500 mg sekali sehari', 'Sejuk', 'Sirup', 'Meningkatkan sistem kekebalan tubuh', 'Gangguan pencernaan, sakit perut'),
('OB004', 'Ibuprofen', 'Antiinflamasi', '2024-12-10', 75, 3500.00, 'Sanbe', '400 mg setiap 6-8 jam', 'Kering', 'Sirup', 'Mengurangi rasa sakit, pembengkakan, dan demam', 'Sakit perut, gangguan pencernaan'),
('OB005', 'Loratadine', 'Antihistamin', '2024-11-20', 60, 4000.00, 'Bayer', '10 mg sekali sehari', 'Sejuk', 'Tablet', 'Mengobati gejala alergi', 'Sakit kepala, kantuk'),
('OB006', 'Metformin', 'Antidiabetik', '2027-09-30', 120, 3000.00, 'Kimia Farma', '500 mg dua kali sehari', 'Kering', 'Tablet', 'Mengontrol kadar gula darah pada pasien diabetes tipe 2', 'Mual, diare'),
('OB007', 'Amlodipine', 'Antihipertensi', '2026-05-15', 74, 6000.00, 'Pfizer', '5 mg sekali sehari', 'Sejuk', 'Sirup', 'Menurunkan tekanan darah tinggi', 'Sakit kepala, pembengkakan pergelangan kaki'),
('OB008', 'Omeprazole', 'Antivirus', '2024-12-22', 90, 4500.00, 'Hexpharm Jaya', '20 mg sekali sehari', 'Kering', 'Sirup', 'Mengobati refluks asam dan tukak lambung', 'Sakit kepala, gangguan pencernaan'),
('OB009', 'Cetirizine', 'Antihistamin', '2025-08-08', 100, 2.50, 'Kalbe', '10 mg sekali sehari', 'Sejuk', 'Tablet', 'Mengobati gejala alergi', 'Kantuk, mulut kering'),
('OB010', 'Simvastatin', 'Vitamin', '2026-06-10', 14, 7000.00, 'Sanofi', '20 mg sekali sehari', 'Kering', 'Tablet', 'Menurunkan kadar kolesterol dalam darah', 'Sakit perut, gangguan pencernaan'),
('OB011', 'Tolak Angin', 'Vitamin', '2024-07-16', 2, 5000.00, 'sindomuncul', '1 Sachet', 'Kering', 'Sirup', 'Untuk Meredakan Gejala pusing', 'mengalami ngantuk');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembeli`
--

CREATE TABLE `pembeli` (
  `kode_pembeli` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `nama_pembeli` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `alamat_pembeli` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `no_telepon` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `email_pembeli` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `jenis_kelamin` varchar(10) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pembeli`
--

INSERT INTO `pembeli` (`kode_pembeli`, `nama_pembeli`, `alamat_pembeli`, `no_telepon`, `email_pembeli`, `jenis_kelamin`) VALUES
('DP001', 'Tegar Pratama Gultom', '082125298946', 'tegar@gmail.com', 'Jl Bintara XI RT 001 RW 013', 'Laki-Laki'),
('DP002', 'Ryski Maulana', '082234986543', 'ryski@gmail.com', 'Jl Bintara IX RT 003 RW 004', 'Laki-Laki'),
('DP003', 'Salfa Aryanda Agustino', '08213554743', 'salfa@gmail.com', 'Jl Perumnas 3', 'Laki-Laki'),
('DP004', 'Wahid Narenda Saputra', '08214554753', 'salfa@gmail.com', 'Jl Pondok Cipta', 'Laki-Laki'),
('DP005', 'Ladi Setiawan', '08214546346', 'ladi@gmail.com', 'Jl Pegangsaan', 'Laki-Laki');

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `ID` int NOT NULL,
  `first_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `last_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`ID`, `first_name`, `last_name`, `username`, `password`) VALUES
(2, 'tegar', 'gultom', 'tama', '123'),
(7, 'tegar', 'pratama', 'tegarpra', '123');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `kasir`
--
ALTER TABLE `kasir`
  ADD PRIMARY KEY (`id_kasir`);

--
-- Indeks untuk tabel `obat`
--
ALTER TABLE `obat`
  ADD PRIMARY KEY (`kode_obat`);

--
-- Indeks untuk tabel `pembeli`
--
ALTER TABLE `pembeli`
  ADD PRIMARY KEY (`kode_pembeli`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
