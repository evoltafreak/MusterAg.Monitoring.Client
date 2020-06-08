DROP DATABASE IF EXISTS MUSTERAG;

-- Create MUSTERAG Schema
CREATE SCHEMA IF NOT EXISTS MUSTERAG DEFAULT CHARACTER SET utf8;
USE MUSTERAG;

-- Severity
CREATE TABLE IF NOT EXISTS MUSTERAG.Severity (
  idSeverity INT NOT NULL AUTO_INCREMENT,
  severity VARCHAR(45) NOT NULL,
  PRIMARY KEY (idSeverity)
);

-- Logging
CREATE TABLE IF NOT EXISTS MUSTERAG.Logging (
  idLogging INT NOT NULL AUTO_INCREMENT,
  timestamp TIMESTAMP NOT NULL,
  message LONGBLOB NOT NULL,
  fidSeverity INT NOT NULL,
  PRIMARY KEY (idLogging),
  CONSTRAINT fk_Logging_Severity
    FOREIGN KEY (fidSeverity)
    REFERENCES MUSTERAG.Severity (idSeverity)
);

-- Place
CREATE TABLE IF NOT EXISTS MUSTERAG.Place (
  idPlace INT NOT NULL AUTO_INCREMENT,
  zipCode VARCHAR(5) NOT NULL,
  place VARCHAR(200) NOT NULL,
  canton VARCHAR(200) NOT NULL,
  cantonAbb VARCHAR(2) NOT NULL,
  PRIMARY KEY (idPlace)
);

-- Location
CREATE TABLE IF NOT EXISTS MUSTERAG.Location (
  idLocation INT NOT NULL AUTO_INCREMENT,
  address VARCHAR(200) NOT NULL,
  addressNr VARCHAR(10),
  fidPlace INT NOT NULL,
  PRIMARY KEY (idLocation),
  CONSTRAINT fk_Location_Place
    FOREIGN KEY (fidPlace)
    REFERENCES MUSTERAG.Place (idPlace)
);

-- Customer
CREATE TABLE IF NOT EXISTS MUSTERAG.Customer (
  idCustomer INT NOT NULL AUTO_INCREMENT,
  gender CHAR(1) NOT NULL,
  firstname VARCHAR(200) NOT NULL,
  lastname VARCHAR(200) NOT NULL,
  birthdate DATE NOT NULL,
  email VARCHAR(200) NOT NULL,
  tel VARCHAR(20) NOT NULL,
  fidLocation INT NOT NULL,
  PRIMARY KEY (idCustomer),
  CONSTRAINT fk_Customer_Location
    FOREIGN KEY (fidLocation)
    REFERENCES MUSTERAG.Location (idLocation)
);

-- Pod
CREATE TABLE IF NOT EXISTS MUSTERAG.Pod (
	idPod INT NOT NULL AUTO_INCREMENT,
	description VARCHAR(200),
	billLimit DECIMAL,
	credit DECIMAL,
	fidCustomer INT NOT NULL,
	PRIMARY KEY (idPod),
	CONSTRAINT fk_Pod_Customer
	  FOREIGN KEY (fidCustomer)
	  REFERENCES MUSTERAG.Customer (idCustomer)
);

-- Pod_Logging
CREATE TABLE IF NOT EXISTS MUSTERAG.Pod_Logging (
  fidPod INT NOT NULL,
  fidLogging INT NOT NULL,
  CONSTRAINT fk_PodLogging_Pod
    FOREIGN KEY (fidPod)
    REFERENCES MUSTERAG.Pod (idPod),
  CONSTRAINT fk_PodLogging_Logging
    FOREIGN KEY (fidLogging)
    REFERENCES MUSTERAG.Logging (idLogging)
);

-- Categories
CREATE TABLE IF NOT EXISTS MUSTERAG.categories (
  idCategories INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(200) NOT NULL,
  PRIMARY KEY (idCategories)
);

-- Device
CREATE TABLE IF NOT EXISTS MUSTERAG.Device (
  idDevice INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(200),
  isPhysical TINYINT(1) NOT NULL,
  hostname VARCHAR(200) NOT NULL,
  ipAddress VARCHAR(45) NOT NULL,
  fidLocation INT NOT NULL,
  maxcapacity INT,
  fidPod INT NOT NULL,
  fidCategories INT NOT NULL,
  PRIMARY KEY (idDevice),
  CONSTRAINT fk_Device_Location
    FOREIGN KEY (fidLocation)
    REFERENCES MUSTERAG.Location (idLocation),
  CONSTRAINT fk_Device_Pod
    FOREIGN KEY (fidPod)
    REFERENCES MUSTERAG.Pod (idPod),
  CONSTRAINT fk_Device_Categories
      FOREIGN KEY (fidCategories)
      REFERENCES MUSTERAG.categories (idCategories)
);


-- NetworkinterfaceMode
CREATE TABLE IF NOT EXISTS MUSTERAG.NetworkinterfaceMode (
  idNetworkinterfaceMode INT NOT NULL AUTO_INCREMENT,
  networkinterfaceMode VARCHAR(200) NOT NULL,
  speed VARCHAR(200) NOT NULL,
  PRIMARY KEY (idNetworkinterfaceMode)
);


-- NetworkInterface
CREATE TABLE IF NOT EXISTS MUSTERAG.NetworkInterface (
  idNetworkInterface INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(200),
  fidNetworkInterfaceMode INT NOT NULL,
  fidDevice INT NOT NULL,
  isPhysical TINYINT(1) NOT NULL,
  PRIMARY KEY (idNetworkInterface),
  CONSTRAINT fk_NetworkInterface_NetworkInterfaceMode
    FOREIGN KEY (fidNetworkInterfaceMode)
    REFERENCES MUSTERAG.NetworkInterfaceMode (idNetworkInterfaceMode),
  CONSTRAINT fk_NetworkInterface_Device
    FOREIGN KEY (fidDevice)
    REFERENCES MUSTERAG.Device (idDevice)
);


-- Credential
CREATE TABLE IF NOT EXISTS MUSTERAG.Credential (
  idCredential INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(45) NOT NULL,
  password VARCHAR(45) NOT NULL,
  description VARCHAR(200),
  PRIMARY KEY (idCredential)
);


-- Device_Credential
CREATE TABLE IF NOT EXISTS MUSTERAG.Device_Credential (
  fidDevice INT NOT NULL,
  fidCredential INT NOT NULL,
  CONSTRAINT fk_DeviceCredential_Device
    FOREIGN KEY (fidDevice)
    REFERENCES MUSTERAG.Device (idDevice),
  CONSTRAINT fk_DeviceCredential_Credential
    FOREIGN KEY (fidCredential)
    REFERENCES MUSTERAG.Credential (idCredential)
);


-- Abrechnung
CREATE TABLE IF NOT EXISTS MUSTERAG.Abrechnung (
  idAbrechnung INT NOT NULL AUTO_INCREMENT,
  isPaid TINYINT(1) NOT NULL,
  bill DECIMAL,
  fidPod INT NOT NULL,
  PRIMARY KEY (idAbrechnung),
  CONSTRAINT fk_Abrechnung_Pod
    FOREIGN KEY (fidPod)
    REFERENCES MUSTERAG.Pod (idPod)
);


-- Customer_Pod
CREATE TABLE IF NOT EXISTS MUSTERAG.Customer_Pod (
  fidCustomer INT NOT NULL,
  fidPod INT NOT NULL,
  priority TINYINT NOT NULL,
  CONSTRAINT fk_CustomerPod_Customer
    FOREIGN KEY (fidCustomer)
    REFERENCES MUSTERAG.Customer (idCustomer),
  CONSTRAINT fk_CustomerPod_Pod
    FOREIGN KEY (fidPod)
    REFERENCES MUSTERAG.Pod (idPod)
);


-- Location_Pod
CREATE TABLE IF NOT EXISTS MUSTERAG.Location_Pod (
  fidLocation INT NOT NULL,
  fidPod INT NOT NULL,
  CONSTRAINT fk_LocationPod_Location
    FOREIGN KEY (fidLocation)
    REFERENCES MUSTERAG.Location (idLocation),
  CONSTRAINT fk_LocationPod_Pod
    FOREIGN KEY (fidPod)
    REFERENCES MUSTERAG.Pod (idPod)
);

-- PositionType
CREATE TABLE IF NOT EXISTS MUSTERAG.PositionType (
  idPositionType INT NOT NULL AUTO_INCREMENT,
  positionType VARCHAR(200) NOT NULL,
  PRIMARY KEY (idPositionType)
);

-- AbrechnungPosition
CREATE TABLE IF NOT EXISTS MUSTERAG.AbrechnungPosition (
  idAbrechnungPosition INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(200),
  price DECIMAL NOT NULL,
  time TIME NOT NULL,
  fidPositionType INT NOT NULL,
  PRIMARY KEY (idAbrechnungPosition),
  CONSTRAINT fk_AbrechnungPosition_PositionType
    FOREIGN KEY (fidPositionType)
    REFERENCES MUSTERAG.PositionType (idPositionType)
);

-- Abrechnung_AbrechnungPosition
CREATE TABLE IF NOT EXISTS MUSTERAG.Abrechnung_AbrechnungPosition (
  fidAbrechnung INT NOT NULL,
  fidAbrechnungPosition INT NOT NULL,
  CONSTRAINT fk_Abrechnung_AbrechnungPosition
    FOREIGN KEY (fidAbrechnung)
    REFERENCES MUSTERAG.Abrechnung (idAbrechnung),
  CONSTRAINT fk_AbrechnungPosition_AbrechnungPosition
    FOREIGN KEY (fidAbrechnungPosition)
    REFERENCES MUSTERAG.AbrechnungPosition (idAbrechnungPosition)
);
