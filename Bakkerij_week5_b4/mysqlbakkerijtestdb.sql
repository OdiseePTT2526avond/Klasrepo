-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 03, 2026 at 03:29 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bakkerijtestdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `Klanten`
--

CREATE TABLE `Klanten` (
  `KlantId` int(11) NOT NULL,
  `Naam` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Klantenkaarten`
--

CREATE TABLE `Klantenkaarten` (
  `KlantenkaartNummer` int(11) NOT NULL,
  `KlantId` int(11) DEFAULT NULL,
  `AantalBroden` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Klanten`
--
ALTER TABLE `Klanten`
  ADD PRIMARY KEY (`KlantId`),
  ADD UNIQUE KEY `Naam` (`Naam`);

--
-- Indexes for table `Klantenkaarten`
--
ALTER TABLE `Klantenkaarten`
  ADD PRIMARY KEY (`KlantenkaartNummer`),
  ADD KEY `FK_Klantenkaarten_Klanten` (`KlantId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Klanten`
--
ALTER TABLE `Klanten`
  MODIFY `KlantId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `Klantenkaarten`
--
ALTER TABLE `Klantenkaarten`
  MODIFY `KlantenkaartNummer` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Klantenkaarten`
--
ALTER TABLE `Klantenkaarten`
  ADD CONSTRAINT `FK_Klantenkaarten_Klanten` FOREIGN KEY (`KlantId`) REFERENCES `Klanten` (`KlantId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
