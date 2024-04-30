-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 30, 2024 at 05:08 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `simsdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `disciplinaryaction`
--

CREATE TABLE `disciplinaryaction` (
  `id` int(11) NOT NULL,
  `violationId` int(11) NOT NULL,
  `offenseLevel` varchar(250) NOT NULL,
  `description` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `disciplinaryaction`
--

INSERT INTO `disciplinaryaction` (`id`, `violationId`, `offenseLevel`, `description`) VALUES
(1, 1, '1st', 'Marked in the teacher\'s class record'),
(2, 1, '2nd', 'Verbal Reprimand with marked in the teacher\'s class record'),
(3, 1, '3rd', 'Marked absent in the teacher\'s class record'),
(4, 2, '1st', 'Marked in the teacher\'s class record'),
(5, 2, '2nd', 'Excuse letter noted by Parent or Guardian'),
(6, 2, '3rd', 'Excuse letter noted by Parent or Guardian and with verbal warning from the teacher'),
(7, 2, '4th', 'Excuse letter noted by Parent or Guardian and with verbal warning from the teacher'),
(8, 2, '5th', 'Excuse letter noted by Parent or Guardian and with verbal warning from the teacher'),
(9, 2, '6th', 'Excuse letter noted by Parent or Guardian and with verbal warning from the teacher'),
(10, 2, '7th', 'Permit-for-Readmission from the Discipline Coordinator, Guidance Counselor, and parent or guardian, to be certified by the Dean concerned and to be approved by the Vice-President on Academic Affairs'),
(11, 2, '8th', 'Dropping from the class (subject) when the number of hours of absence reaches 10% of total class hours');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `studentId` int(11) NOT NULL,
  `firstname` varchar(250) NOT NULL,
  `middlename` varchar(250) NOT NULL,
  `lastname` varchar(250) NOT NULL,
  `birthdate` text NOT NULL,
  `age` int(11) NOT NULL,
  `gender` varchar(30) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(250) NOT NULL,
  `province` varchar(250) NOT NULL,
  `city` varchar(250) NOT NULL,
  `barangay` varchar(250) NOT NULL,
  `street` varchar(250) NOT NULL,
  `zip` int(11) NOT NULL,
  `studentIdNum` varchar(50) NOT NULL,
  `department` varchar(250) NOT NULL,
  `course` varchar(250) NOT NULL,
  `parentName` varchar(250) NOT NULL,
  `parentEmail` varchar(250) NOT NULL,
  `parentHome` varchar(250) NOT NULL,
  `parentContact` varchar(50) NOT NULL,
  `yearLevel` varchar(250) NOT NULL,
  `academicYear` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`studentId`, `firstname`, `middlename`, `lastname`, `birthdate`, `age`, `gender`, `phone`, `email`, `password`, `province`, `city`, `barangay`, `street`, `zip`, `studentIdNum`, `department`, `course`, `parentName`, `parentEmail`, `parentHome`, `parentContact`, `yearLevel`, `academicYear`) VALUES
(86, 'Angel Ace', 'Verdida', 'Viagedor', '2024-04-30', 0, 'Male', '53454352342', 'aceviagedor@gmail.com', 'gwapako', 'Cebu', 'Bogo', 'Sudlonon', 'Sudlonun', 6010, '1234', 'College of Teacher Education', 'Bachelor of Elementary Education', 'Angel Ace Viagedor', 'aceviagedor@gmail.com', 'Sudlonun', '424324', '4th year', '2022-2023');

-- --------------------------------------------------------

--
-- Table structure for table `studentviolation`
--

CREATE TABLE `studentviolation` (
  `violationId` int(11) NOT NULL,
  `studentName` varchar(250) NOT NULL,
  `studentIdNum` varchar(250) NOT NULL,
  `course` varchar(250) NOT NULL,
  `academicYear` varchar(250) NOT NULL,
  `violationType` varchar(250) NOT NULL,
  `violationDate` varchar(250) NOT NULL,
  `violationTime` varchar(250) NOT NULL,
  `offenseLevel` varchar(250) NOT NULL,
  `disciplinaryAction` text NOT NULL,
  `offenseType` varchar(250) NOT NULL,
  `location` varchar(250) NOT NULL,
  `description` text NOT NULL,
  `reportingName` varchar(250) NOT NULL,
  `reportingRole` varchar(250) NOT NULL,
  `reportingContact` varchar(30) NOT NULL,
  `status` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studentviolation`
--

INSERT INTO `studentviolation` (`violationId`, `studentName`, `studentIdNum`, `course`, `academicYear`, `violationType`, `violationDate`, `violationTime`, `offenseLevel`, `disciplinaryAction`, `offenseType`, `location`, `description`, `reportingName`, `reportingRole`, `reportingContact`, `status`) VALUES
(36, 'Angel Ace Verdida Viagedor', '1234', 'Bachelor of Elementary Education', '2022-2023', 'Absence from Class', '13:34', '13:34', '2nd', 'Excuse letter noted by Parent or Guardian', 'major', 'dsadad', 'ssdadasd', 'daasdd', 'aDSASD', '3242432423', 'pending');

-- --------------------------------------------------------

--
-- Table structure for table `useraccount`
--

CREATE TABLE `useraccount` (
  `userId` int(11) NOT NULL,
  `firstname` varchar(250) DEFAULT NULL,
  `lastname` varchar(250) DEFAULT NULL,
  `username` varchar(250) NOT NULL,
  `email` varchar(250) DEFAULT NULL,
  `password` varchar(250) NOT NULL,
  `role` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `useraccount`
--

INSERT INTO `useraccount` (`userId`, `firstname`, `lastname`, `username`, `email`, `password`, `role`) VALUES
(66, 'Admin', 'Admin', 'admin', 'admin@gmail.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin'),
(67, 'Staff', 'Staff', 'staff', 'staff@gmail.com', '1562206543da764123c21bd524674f0a8aaf49c8a89744c97352fe677f7e4006', 'staff');

-- --------------------------------------------------------

--
-- Table structure for table `violation`
--

CREATE TABLE `violation` (
  `id` int(11) NOT NULL,
  `violationName` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `violation`
--

INSERT INTO `violation` (`id`, `violationName`) VALUES
(1, 'Tardiness'),
(2, 'Absence from Class');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `disciplinaryaction`
--
ALTER TABLE `disciplinaryaction`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`studentId`);

--
-- Indexes for table `studentviolation`
--
ALTER TABLE `studentviolation`
  ADD PRIMARY KEY (`violationId`);

--
-- Indexes for table `useraccount`
--
ALTER TABLE `useraccount`
  ADD PRIMARY KEY (`userId`);

--
-- Indexes for table `violation`
--
ALTER TABLE `violation`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `disciplinaryaction`
--
ALTER TABLE `disciplinaryaction`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `studentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=87;

--
-- AUTO_INCREMENT for table `studentviolation`
--
ALTER TABLE `studentviolation`
  MODIFY `violationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `useraccount`
--
ALTER TABLE `useraccount`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT for table `violation`
--
ALTER TABLE `violation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
