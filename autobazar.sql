-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Pon 16. pro 2019, 09:04
-- Verze serveru: 10.4.10-MariaDB
-- Verze PHP: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `autobazar`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `address`
--

CREATE TABLE `address` (
  `ID` int(11) NOT NULL,
  `Street` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `PSC` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `address`
--

INSERT INTO `address` (`ID`, `Street`, `City`, `PSC`) VALUES
(1, 'Petra Bezruče', 'Štěpánkovice', 74728);

-- --------------------------------------------------------

--
-- Struktura tabulky `admin`
--

CREATE TABLE `admin` (
  `ID` int(11) NOT NULL,
  `ID_Employee` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `admin`
--

INSERT INTO `admin` (`ID`, `ID_Employee`) VALUES
(1, 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `auction`
--

CREATE TABLE `auction` (
  `ID` int(11) NOT NULL,
  `ID_car` int(11) NOT NULL,
  `CurrentBid` int(11) NOT NULL,
  `StartBid` int(11) NOT NULL,
  `ID_User` int(11) NOT NULL,
  `CurrentBidDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `auction`
--

INSERT INTO `auction` (`ID`, `ID_car`, `CurrentBid`, `StartBid`, `ID_User`, `CurrentBidDate`, `EndDate`) VALUES
(1, 1, 350000, 150000, 2, '2019-12-15 18:46:45', '2019-12-31 02:00:00');

-- --------------------------------------------------------

--
-- Struktura tabulky `cars`
--

CREATE TABLE `cars` (
  `ID` int(11) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `Consumption` double DEFAULT NULL,
  `Price` int(11) NOT NULL,
  `IsOnMarket` tinyint(1) NOT NULL,
  `YearOfManufacture` int(11) NOT NULL,
  `Tachometer` int(11) NOT NULL,
  `Fuel` varchar(50) NOT NULL,
  `ID_User` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `cars`
--

INSERT INTO `cars` (`ID`, `Name`, `Type`, `Consumption`, `Price`, `IsOnMarket`, `YearOfManufacture`, `Tachometer`, `Fuel`, `ID_User`) VALUES
(1, 'Škoda octavia RS', 'Sedan', 6.2, 350000, 1, 2013, 157000, 'benzín', 1),
(2, 'Merceden Benz cls 250', 'Sedan', 8.3, 750000, 1, 2011, 257523, 'benzín', 1),
(5, 'Renaul Clio', 'Sedan', 5.4, 80000, 1, 2008, 128000, 'benzín', 2),
(6, 'Škoda octavia RS', 'Sedan', 5, 354000, 1, 2009, 123456, 'nafta', 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `employee`
--

CREATE TABLE `employee` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `ID_Address` int(11) NOT NULL,
  `Salary` int(11) NOT NULL,
  `Email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `employee`
--

INSERT INTO `employee` (`ID`, `FirstName`, `LastName`, `Password`, `ID_Address`, `Salary`, `Email`) VALUES
(2, 'Ondřej', 'Nevřela', 'ondra', 1, 220, 'ondra@autobazar.cz'),
(3, 'Matej', 'Orel', 'orel', 1, 150, 'matej@orel.cz');

-- --------------------------------------------------------

--
-- Struktura tabulky `order`
--

CREATE TABLE `order` (
  `ID` int(11) NOT NULL,
  `ID_User` int(11) NOT NULL,
  `ID_Car` int(11) NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struktura tabulky `salary`
--

CREATE TABLE `salary` (
  `ID` int(11) NOT NULL,
  `ID_Employee` int(11) NOT NULL,
  `Hours` int(11) NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `salary`
--

INSERT INTO `salary` (`ID`, `ID_Employee`, `Hours`, `Date`) VALUES
(1, 2, 8, '2019-11-01'),
(2, 2, 7, '2019-11-02'),
(3, 2, 8, '2019-12-01'),
(4, 3, 8, '2019-11-01'),
(5, 3, 7, '2019-12-05'),
(6, 3, 6, '2019-12-12'),
(7, 3, 8, '2019-12-04'),
(8, 3, 6, '2019-12-18');

-- --------------------------------------------------------

--
-- Struktura tabulky `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `ID_Address` int(11) DEFAULT NULL,
  `Email` varchar(50) NOT NULL,
  `Phone` varchar(9) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vypisuji data pro tabulku `user`
--

INSERT INTO `user` (`ID`, `FirstName`, `LastName`, `Password`, `ID_Address`, `Email`, `Phone`) VALUES
(1, 'Karel', 'Orel', 'orel', 2, 'karelorel@gmail.com', '773599900'),
(2, 'Michal', 'Adámik', 'michal', 3, 'madamik@gmail.com', '123321456'),
(3, 'Matej', 'Bezdek', 'matej', 1, 'matej@bezdek.cz', '777555222');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `auction`
--
ALTER TABLE `auction`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `salary`
--
ALTER TABLE `salary`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `address`
--
ALTER TABLE `address`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `admin`
--
ALTER TABLE `admin`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `auction`
--
ALTER TABLE `auction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `cars`
--
ALTER TABLE `cars`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pro tabulku `employee`
--
ALTER TABLE `employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `order`
--
ALTER TABLE `order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pro tabulku `salary`
--
ALTER TABLE `salary`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
