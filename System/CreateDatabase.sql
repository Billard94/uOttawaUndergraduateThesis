drop database oscs;
CREATE DATABASE  IF NOT EXISTS `oscs` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `oscs`;

-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: oscs
-- ------------------------------------------------------
-- Server version 5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `RegisteredPatient`
--

DROP TABLE IF EXISTS `RegisteredPatient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `RegisteredPatient` (
  `Username` varchar(100) NOT NULL,
  `RegisteredPatientID` int(11) NOT NULL,
  `MailID` int(11) DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `VerificationStatus` varchar(10) DEFAULT NULL,
  `Password` varchar(300) DEFAULT NULL,
  `DecadeOfBirth` varchar(10) DEFAULT NULL,
  `PostalCodeHome` varchar(10) DEFAULT NULL,
  `RegisterDate` datetime DEFAULT NULL,
  `RequireSurgery` tinyint(1) DEFAULT NULL,
  `DoctorAgrees` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RegisteredPatient`
--

LOCK TABLES `RegisteredPatient` WRITE;
/*!40000 ALTER TABLE `RegisteredPatient` DISABLE KEYS */;
INSERT INTO `RegisteredPatient` VALUES ('Alex', 1,' 123', 'Male', 'Enable', 'M+Alts65YPNys8y+BN3+ng==', '1990-1999', 'K6K', now(), NULL, NULL);
/*!40000 ALTER TABLE `RegisteredPatient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Verify`
--

DROP TABLE IF EXISTS `Verify`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Verify` (
  `VerificationID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) DEFAULT NULL,
  `VerificationCode` varchar(200) DEFAULT NULL,
  `VerificationDate` datetime DEFAULT NULL,
  PRIMARY KEY (`VerificationID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Verify`
--

LOCK TABLES `Verify` WRITE;
/*!40000 ALTER TABLE `Verify` DISABLE KEYS */;
INSERT INTO `Verify` VALUES (2,'Ali','http://localhost:50162/Activate.aspx?token=e1d8bb26-4c7e-4d7f-91cb-34985de961d0', now());
/*!40000 ALTER TABLE `Verify` ENABLE KEYS */;
UNLOCK TABLES;


-- --
-- -- Table structure for table `Mail`
-- --

DROP TABLE IF EXISTS `Mail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mail` (
  `MailID` int(11) NOT NULL,
  `From` varchar(256) DEFAULT NULL,
  `To` varchar(256) DEFAULT NULL,
  `Subject` varchar(256) DEFAULT NULL,
  `Body` varchar(256) DEFAULT NULL,
  `CC` varchar(256) DEFAULT NULL,
  `MailStatus` varchar(256) DEFAULT NULL,
  `SentDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MailID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mail`
--

LOCK TABLES `Mail` WRITE;
/*!40000 ALTER TABLE `Mail` DISABLE KEYS */;
INSERT INTO `Mail` VALUES (2,'CSI4900@hotmail.com', 'alexbillard@me.com', 'Test', 'http://localhost:50162/Activate.aspx?token=e1d8bb26-4c7e-4d7f-91cb-34985de961d0',NULL, 'Delivered', now());
/*!40000 ALTER TABLE `Mail` ENABLE KEYS */;
UNLOCK TABLES;


-- --
-- -- Table structure for table `KeeleStarTTool`
-- --

DROP TABLE IF EXISTS `KeeleStarTTool`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `KeeleStarTTool` (
  `KeeleStarID` int(11) NOT NULL AUTO_INCREMENT,
  `RegisteredPatientID` int(11) DEFAULT NULL,
  `HospitalPatientID` int(11) DEFAULT NULL,
  `TotalScore` int(2) DEFAULT NULL,
  `SubScore` int(2) DEFAULT NULL,
  `RiskLevel` varchar(30) DEFAULT NULL,
  `ScoreDate` datetime DEFAULT NULL,
  PRIMARY KEY (`KeeleStarID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `KeeleStarTTool`
--

LOCK TABLES `KeeleStarTTool` WRITE;
/*!40000 ALTER TABLE `KeeleStarTTool` DISABLE KEYS */;
INSERT INTO `KeeleStarTTool` (RegisteredPatientID, HospitalPatientID, TotalScore, SubScore, RiskLevel, ScoreDate) VALUES (1,2,9,5,'Not at all',now());
INSERT INTO `KeeleStarTTool` (RegisteredPatientID, HospitalPatientID, TotalScore, SubScore, RiskLevel, ScoreDate) VALUES (2,3,8,6,'Not at all222',now());

/*!40000 ALTER TABLE `KeeleStarTTool` ENABLE KEYS */;
UNLOCK TABLES;



-- --
-- -- Table structure for table `PH9Q`
-- --

DROP TABLE IF EXISTS `PH9Q`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PH9Q` (
  `PH9QID` int(11) NOT NULL AUTO_INCREMENT,
  `RegisteredPatientID` int(11) DEFAULT NULL,
  `HospitalPatientID` int(11) DEFAULT NULL,
  `TotalScore` int(2) DEFAULT NULL,
  `DepressionLevel` varchar(30) DEFAULT NULL,
  `ScoreDate` datetime DEFAULT NULL,
  PRIMARY KEY (`PH9QID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PH9Q`
--

LOCK TABLES `PH9Q` WRITE;
/*!40000 ALTER TABLE `PH9Q` DISABLE KEYS */;
INSERT INTO `PH9Q` (RegisteredPatientID, HospitalPatientID, TotalScore, DepressionLevel, ScoreDate) VALUES (1,2,9,'Not at all',now());
/*!40000 ALTER TABLE `PH9Q` ENABLE KEYS */;
UNLOCK TABLES;


-- --
-- -- Table structure for table `Answers`
-- --

DROP TABLE IF EXISTS `Answers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Answers` (
  `AnswerID` int(11) NOT NULL AUTO_INCREMENT,
  `RegisteredPatientID` int(11) DEFAULT NULL,
  `HospitalPatientID` int(11) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  `Answer` varchar(255) DEFAULT NULL,
  `AnswerDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AnswerID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Answers`
--

LOCK TABLES `Answers` WRITE;
/*!40000 ALTER TABLE `Answers` DISABLE KEYS */;
/*!40000 ALTER TABLE `Answers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Questions`
--

DROP TABLE IF EXISTS `Questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Questions` (
  `QuestionID` int(11) NOT NULL AUTO_INCREMENT,
  `QuestionDescription` varchar(600) DEFAULT NULL,
  `QuestionType` varchar(20) DEFAULT NULL,
  `QuestionGroup` int(11) DEFAULT NULL,
  `QuestionOrder` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuestionID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Questions`
--

LOCK TABLES `Questions` WRITE;
/*!40000 ALTER TABLE `Questions` DISABLE KEYS */;

-- GENERAL

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (1, 'For this consultation, what is troubling you?', 'General', 3, 1);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (2, 'How long has it been bothering you?', 'General', 3, 2);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (3, 'Was there an injury or specific event that caused this problem?', 'General', 1, 3);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (4, 'If there was an injury or specific event that caused this problem, please describe:', 'General', 3, 4);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (5, 'Overall, you are getting:', 'General', 2, 5);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (6, 'What makes it worse?', 'General', 4, 6);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (7, 'What makes it better?', 'General', 4, 7);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (8, 'Does this conditions limit your activities?', 'General', 1, 8);

-- TREATMENT

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (9, 'Have you or are you currently doing phyiscal therapy?', 'Treatment', 1, 9);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (10, '	Duration of physical therapy?', 'Treatment', 3, 10);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (11, '		Did physical therapy help?', 'Treatment', 1, 11);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (12, 'Have you or are you currently doing injections?', 'Treatment', 1, 12);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (13, '	How many times have you completed injection treatment?', 'Treatment', 3, 13);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (14, '		Did injection treatment help?', 'Treatment', 1, 14);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (15, 'Have you or are you currently losing weight?', 'Treatment', 1, 15);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (16, '	How much weight have you loss?', 'Treatment', 3, 16);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (17, '		Did losing weight help?', 'Treatment', 1, 17);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (18, 'Have you or are you currently doing cognitive behavioral therapy or mindfulness?', 'Treatment', 1, 18);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (19, '	How many session of cognitive behavioral therapy or mindfulness?', 'Treatment', 3, 19);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (20, '		Did cognitive behavioral therapy or mindfulness help?', 'Treatment', 1, 20);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (21, 'Have you or are you currently doing aerobics?', 'Treatment', 1, 21);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (22, '	Duration of aerobics:', 'Treatment', 3, 22);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (23, '		Did aerobics help?', 'Treatment', 1, 23);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (24, 'Have you or are you currently doing any cardio exercises?', 'Treatment', 1, 24);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (25, '	Duration of cardio exercises:','Treatment', 3, 25);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (26, '		Did cardio exercises help?', 'Treatment', 1, 26);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (27, 'Have you or are you currently doing any core strengthning exercises?', 'Treatment', 1, 27);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (28, '	Duration of core strengthning exercises:', 'Treatment', 3, 28);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (29, '		Did core strengthning exercises help?', 'Treatment', 1, 29);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (30, 'Have you or are you currently doing any stretching exercises?', 'Treatment', 1, 30);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (31, '	Duration of stretching exercises:', 'Treatment', 3, 31);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (32, '		Did stretching exercises help?', 'Treatment', 1, 32);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (33, 'Are you doing any other treatments?', 'Treatment', 1, 33);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (34, '	Describe  the other treatments completed:','Treatment', 3, 34);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (35, '		Does this other treatment help?', 'Treatment', 1, 35);


-- GENERAL


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (36, 'Does your back/neck troubles or other things in your life cause you:', 'General', 2, 36);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (37, 'Is there a WSIB claim related to this injury?', 'General', 1, 37);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (38, 'Is there an insurance claim related to this injury?', 'General', 1, 38);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (39, 'Do you smoke?', 'General', 1, 39);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (40, '	How many cigarettes do you consume per day?', 'General', 3, 40);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (41, '		Have you recently quit smoking?', 'General', 1, 41);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (42, 'Do you use any kind of drugs?', 'General', 1, 42);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (43, '	Please specify on which drug you use?', 'General', 3, 43);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (44, '		Have you recently quit using drugs?', 'General', 1, 44);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (45, 'Do you drink alcohol?', 'General', 1, 45);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (46, '	How many alcoholic beverages do you consume per day?', 'General', 3, 46);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (47, '		Have you recently quit consuming alcoholic beverages?', 'General', 1, 47);


insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (48, 'Do you routinely exercise?', 'General', 1, 48);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (49, '	Please specify the exercise you routinely perform:', 'General', 3, 49);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (50, '		Have you recently quit exercising?', 'General', 1, 50);





insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (51, 'Over the last month have you noticed (Check all that apply)', 'General', 4, 51);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (52, 'What is your occupation?', 'General', 3, 52);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (53, '	Are you currently on disability', 'General', 1, 53);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (54, 'What are your significant hobbies', 'General', 3, 54);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (55, 'Medical Conditions (Current or Past)', 'General', 3, 55);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (56, 'Former surgeries', 'General', 3, 56);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (57, 'Medications', 'General', 3, 57);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (58, 'Allergies', 'General', 3, 58);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (59, 'What is your height', 'General', 3, 59);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (60, 'What is your weight', 'General', 3, 60);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (61, 'What is your waist circumference', 'General', 3, 61);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (62, 'Is your pain / disability significant enough that you would like to undergo surgery?', 'General', 2, 62);

-- KEELE

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (63, 'My back pain has spread down my leg(s) at some time in the last 2 weeks', 'Keele', 1, 63);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (64, 'I have had pain in the shoulder or neck at some time in the last 2 weeks', 'Keele', 1, 64);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (65, 'I have only walked short distances because of my back pain', 'Keele', 1, 65);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (66, 'In the last 2 weeks, I have dressed more slowly than usual because of back pain', 'Keele', 1, 66);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (67, 'It’s not really safe for a person with a condition like mine to be physically active', 'Keele', 1, 67);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (68, 'Worrying thoughts have been going through my mind a lot of the time', 'Keele', 1, 68);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (69, 'I feel that my back pain is terrible and it’s never going to get any better', 'Keele', 1, 69);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (70, 'In general I have not enjoyed all the things I used to enjoy', 'Keele', 1, 70);
insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (71, 'Overall, how bothersome has your back pain been in the last 2 weeks?', 'Keele', 2, 71);

-- PH9Q

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (72, 'Little interest or pleasure in doing things', 'PH9Q', 2, 72);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (73, 'Feeling down, depressed, or hopeless', 'PH9Q', 2, 73);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (74, 'Trouble falling or staying asleep, or sleeping too much?', 'PH9Q', 2, 74);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (75, 'Feeling tired or having little energy', 'PH9Q', 2, 75);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (76, 'Poor appetite or overeating ', 'PH9Q', 2, 76);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (77, 'Feeling bad about yourself — or that you are a failure or have let yourself or your family down', 'PH9Q', 2, 77);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (78, 'Trouble concentrating on things, such as reading the newspaper or watching television', 'PH9Q', 2, 78);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (79, 'Moving or speaking so slowly that other people could have noticed? Or the opposite — being so fidgety or restless that you have been moving around a lot more than usual', 'PH9Q', 2, 79);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (80, 'Thoughts that you would be better off dead or of hurting yourself in some way ', 'PH9Q', 2, 80);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (81, 'How difficult have these problems made it for you to do your work, take care of things at home, or get along with other people?', 'PH9Q', 2, 81);


-- Pain History

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (82, 'Neck pain scale', 'PainHistory', 2, 82);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (83, 'Left arm pain scale', 'PainHistory', 2, 83);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (84, 'Right arm pain scale', 'PainHistory', 2, 84);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (85, 'Back pain scale', 'PainHistory', 2, 85);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (86, 'Left leg pain scale', 'PainHistory', 2, 86);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (87, 'Right leg pain scale', 'PainHistory', 2, 87);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (88, 'When did your neck pain start?', 'PainHistory', 3, 88);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (89, 'When did you arm pain start?', 'PainHistory', 3, 89);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (90, 'When did your back pain start?', 'PainHistory', 3, 90);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (91, 'When did your leg pain start?', 'PainHistory', 3, 91);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (92, 'For NECK / ARM Problems', 'PainHistory', 2, 92);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (93, 'For BACK / LEG Problems', 'PainHistory', 2, 93);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (94, 'I would prefer to treat the pain / weakness in my :', 'PainHistory', 2, 94);




-- Disability Questions: please, circle the one choice which most closely describes your problem

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (95, 'SECTION 1 - Pain Intensity', 'Disability', 2, 95);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (96, 'SECTION 2 - Personal Care', 'Disability', 2, 96);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (97, 'SECTION 3 - Lifting', 'Disability', 2, 97);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (98, 'SECTION 4 - Walking', 'Disability', 2, 98);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (99, 'SECTION 5 - Sitting', 'Disability', 2, 99);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (100, 'SECTION 6 - Standing', 'Disability', 2, 100);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (101, 'SECTION 7 – Sleeping', 'Disability', 2, 101);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (102, 'SECTION 8 - Social Life', 'Disability', 2, 102);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (103, 'SECTION 9 - Travel', 'Disability', 2, 103);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (104, 'SECTION 10 - Changing degree of pain', 'Disability', 2, 104);

-- EQ

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (105, 'Overall Mobility', 'EQ', 2, 105);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (106, 'Overall Self-Care', 'EQ', 2, 106);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (107, 'Usual Activities', 'EQ', 2, 107);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (109, 'Overall Pain/Discomfort', 'EQ', 2, 109);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (110, 'Overall Anxiety/Depression', 'EQ', 2, 110);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (111, 'Overall Health State', 'EQ', 2, 111);

-- GodingShepard

-- 1) During the past 7-days (i.e. 1 week), how many times have you performed any of the following kinds of exercise for more than 15 minutes (please write the appropriate number on each line):

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (112, 'STRENUOUS EXERCISE (HEART BEATS RAPIDLY) (e.g., running, jogging, hockey, football, soccer, squash, basketball, cross country skiing, judo, roller skating, vigorous swimming, vigorous bicycling)', 'GodinShepard', 3, 112);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (113, 'MODERATE EXERCISE (NOT EXHAUSTING) (e.g., fast walking, baseball, tennis, volleyball, easy bicycling, badminton, easy swimming, alpine skiing, dancing, skating, walking up stairs)', 'GodinShepard', 3, 113);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (114, 'MILD EXERCISE (MINIMAL EFFORT) (e.g., yoga, stretching, archery, fishing, golf, curling, horse-shoes, snow-mobiling, easy walking)', 'GodinShepard', 3, 114);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (115, 'On average how many minutes in total per week do you do Moderate to Strenuous exercises/activities.', 'GodinShepard', 3, 115);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (116, 'On average how many minutes in total per week do you do truck or core strengthening exercises/activities.', 'GodinShepard', 3, 116);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (117, 'During the past 7-days (i.e. 1 week), how often did you engage in physical activity long enough to work up a sweat (i.e. heart beats rapidly)?', 'GodinShepard', 2, 117);

-- IPAQ

-- PART 1: JOB-RELATED PHYSICAL ACTIVITY
-- The first section is about your work. This includes paid jobs, farming, volunteer work, course
-- work, and any other unpaid work that you did outside your home. Do not include unpaid work
-- you might do around your home, like housework, yard work, general maintenance, and caring
-- for your family. These are asked in Part 3.

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (118, '1. Do you currently have a job or do any unpaid work outside your home?', 'IPAQ', 1, 118);

-- if no Skip to PART 2: TRANSPORTATION

-- The next Questions are about all the physical activity you did in the last 7 days as part of your
-- paid or unpaid work. This does not include traveling to and from work.

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (119, '2. During the last 7 days, on how many days did you do vigorous physical activities like heavy lifting, digging, heavy construction, or climbing up stairs as part of your work? Think about only those physical activities that you did for at least 10 minutes at a time.', 'IPAQ', 3, 119);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (120, '	No vigorous job-related physical activity', 'IPAQ', 4, 120);
-- No vigorous job-related physical activity Skip to question 4

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (121, '3. How much time did you usually spend on one of those days doing vigorous physical activities as part of your work?', 'IPAQ', 3, 121);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (122, '4. Again, think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do moderate physical activities like carrying light loads as part of your work? Please do not include walking.', 'IPAQ', 3, 122);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (123, '	No vigorous job-related physical activity', 'IPAQ', 4, 123);
-- No vigorous job-related physical activity Skip to question 6

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (124, '5. How much time did you usually spend on one of those days doing moderate physical activities as part of your work?', 'IPAQ', 3, 124);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (125, '6. During the last 7 days, on how many days did you walk for at least 10 minutes at a time as part of your work? Please do not count any walking you did to travel to or from work.', 'IPAQ', 3, 125);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (126, '	No job-related walking', 'IPAQ', 4, 126);
-- No vigorous job-related physical activity Skip to PART 2: TRANSPORTATION

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (127, '7. How much time did you usually spend on one of those days walking as part of your work?', 'IPAQ', 3, 127);

-- PART 2: TRANSPORTATION PHYSICAL ACTIVITY

-- These Questions are about how you traveled from place to place, including to places like work,
-- stores, movies, and so on.

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (128, '8. During the last 7 days, on how many days did you travel in a motor vehicle like a train, bus, car, or tram?', 'IPAQ', 3, 128);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (129, '	No traveling in a motor vehicle', 'IPAQ', 4, 129);
-- No vigorous job-related physical activity Skip to question 10

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (130, '9. How much time did you usually spend on one of those days traveling in a train, bus, car, tram, or other kind of motor vehicle?', 'IPAQ', 3, 130);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (131, '10. During the last 7 days, on how many days did you bicycle for at least 10 minutes at a time to go from place to place?', 'IPAQ', 3, 131);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (132, '	No traveling in a motor vehicle', 'IPAQ', 4, 132);
-- No vigorous job-related physical activity Skip to question 12

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (133, '11. How much time did you usually spend on one of those days to bicycle from place to place?', 'IPAQ', 3, 133);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (134, '12. During the last 7 days, on how many days did you walk for at least 10 minutes at a time to go from place to place?', 'IPAQ', 3, 134);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (135, '	No walking from place to place', 'IPAQ', 4, 135);
-- No vigorous job-related physical activity Skip to PART 3: HOUSEWORK, HOUSE MAINTENANCE, AND CARING FOR FAMILY

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (136, '13. How much time did you usually spend on one of those days walking from place to place?', 'IPAQ', 3, 136);


-- PART 3: HOUSEWORK, HOUSE MAINTENANCE, AND CARING FOR FAMILY
-- This section is about some of the physical activities you might have done in the last 7 days in
-- and around your home, like housework, gardening, yard work, general maintenance work, and
-- caring for your family

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (137, '14. Think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do vigorous physical activities like heavy lifting, chopping wood, shoveling snow, or digging in the garden or yard?', 'IPAQ', 3, 137);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (138, '	No vigorous activity in garden or yard', 'IPAQ', 4, 138);
-- No vigorous job-related physical activity Skip to question 16

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (139, '15. How much time did you usually spend on one of those days doing vigorous physical activities in the garden or yard?', 'IPAQ', 3, 139);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (140, '16. Again, think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do moderate activities like carrying light loads, sweeping, washing windows, and raking in the garden or yard?', 'IPAQ', 3, 140);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (141, '	No moderate activity in garden or yard', 'IPAQ', 4, 141);
-- No vigorous job-related physical activity Skip to question 18

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (142, '17. How much time did you usually spend on one of those days doing moderate physical activities in the garden or yard?', 'IPAQ', 3, 142);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (143, '18. Once again, think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do moderate activities like carrying light loads, washing windows, scrubbing floors and sweeping inside your home?', 'IPAQ', 3, 143);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (144, '	No moderate activity inside home','IPAQ', 4, 144);
-- if no Skip to PART 4: RECREATION, SPORT AND LEISURE-TIME PHYSICAL ACTIVITY', 'IPAQ

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (145, '19. How much time did you usually spend on one of those days doing moderate physical activities inside your home?', 'IPAQ', 3, 145);

-- PART 4: RECREATION, SPORT, AND LEISURE-TIME PHYSICAL ACTIVITY
-- This section is about all the physical activities that you did in the last 7 days solely for
-- recreation, sport, exercise or leisure. Please do not include any activities you have already
-- mentioned.

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (146, '20. Not counting any walking you have already mentioned, during the last 7 days, on how many days did you walk for at least 10 minutes at a time in your leisure time?', 'IPAQ', 3, 146);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (147, '	No walking in leisure time', 'IPAQ', 4, 147);
-- No vigorous job-related physical activity Skip to question 22

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (148, '21. How much time did you usually spend on one of those days walking in your leisure time?', 'IPAQ', 3, 148);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (149, '22. Think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do vigorous physical activities like aerobics, running, fast bicycling, or fast swimming in your leisure time?', 'IPAQ', 3, 149);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (150, '	No vigorous activity in leisure time', 'IPAQ', 4, 150);
-- No vigorous job-related physical activity Skip to question 24

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (151, '23. How much time did you usually spend on one of those days doing vigorous physical activities in your leisure time?', 'IPAQ', 3, 151);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (152, '24. Again, think about only those physical activities that you did for at least 10 minutes at a time. During the last 7 days, on how many days did you do moderate physical activities like bicycling at a regular pace, swimming at a regular pace, and doubles tennis in your leisure time?', 'IPAQ', 3, 152);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (153, '	No moderate activity in leisure time', 'IPAQ', 4, 153);
-- No vigorous job-related physical activity Skip to question 16

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (154, '25. How much time did you usually spend on one of those days doing moderate physical activities in your leisure time?', 'IPAQ', 3, 154);

-- PART 5: TIME SPENT SITTING
-- The last Questions are about the time you spend sitting while at work, at home, while doing
-- course work and during leisure time. This may include time spent sitting at a desk, visiting
-- friends, reading or sitting or lying down to watch television. Do not include any time spent sitting
-- in a motor vehicle that you have already told me about

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (155, '26. During the last 7 days, how much time did you usually spend sitting on a weekday?', 'IPAQ', 3, 155);

insert into Questions(QuestionID, QuestionDescription, QuestionType, QuestionGroup, QuestionOrder)
Values (156, '27. During the last 7 days, how much time did you usually spend sitting on a weekend day?', 'IPAQ', 3, 156);

/*!40000 ALTER TABLE `Questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `QuestionsOption`
--

DROP TABLE IF EXISTS `QuestionsOption`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `QuestionsOption` (
  `OptionID` int(11) NOT NULL AUTO_INCREMENT,
  `OptionDescription` varchar(100) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  PRIMARY KEY (`OptionID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `QuestionsOption`
--

LOCK TABLES `QuestionsOption` WRITE;
/*!40000 ALTER TABLE `QuestionsOption` DISABLE KEYS */;
INSERT INTO `QuestionsOption` VALUES (2,'NO',3),(3,'YES',3);
/*!40000 ALTER TABLE `QuestionsOption` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HospitalPatient`
--

DROP TABLE IF EXISTS `HospitalPatient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `HospitalPatient` (
  `HospitalPatientID` int(11) NOT NULL,
  `MailID` int(11) DEFAULT NULL,
  `RequireSurgery` tinyint(1) DEFAULT NULL,
  `DoctorAgrees` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`HospitalPatientID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HospitalPatient`
--

LOCK TABLES `HospitalPatient` WRITE;
/*!40000 ALTER TABLE `HospitalPatient` DISABLE KEYS */;
INSERT INTO `HospitalPatient` VALUES (3,2,NULL,NULL);
/*!40000 ALTER TABLE `HospitalPatient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'oscs'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-06 20:43:01
