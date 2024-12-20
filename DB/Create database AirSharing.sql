
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'AirSharing')
BEGIN
    use [model]
	alter database AirSharing set single_user with rollback immediate
    DROP DATABASE AirSharing  
END
Create database AirSharing
Use AirSharing


-- Create tables section -------------------------------------------------

-- Table User

CREATE TABLE [User]
(
 [ID_User] Int IDENTITY NOT NULL,
 [Login] Varchar(120) NOT NULL,
 [Email] Varchar(120) NOT NULL,
 [Password] Varchar(120) NOT NULL,
 [ID_Passport] Int NOT NULL
)
go

-- Create indexes for table User

CREATE INDEX [IX_Relationship4] ON [User] ([ID_Passport])
go

-- Add keys for table User

ALTER TABLE [User] ADD CONSTRAINT [ID_User] PRIMARY KEY ([ID_User])
go

-- Table FlightLicense

CREATE TABLE [FlightLicense]
(
 [Surname] Varchar(120) NOT NULL,
 [Name] Varchar(120) NOT NULL,
 [NumberFlightLicense] Char(15) NOT NULL,
 [ID_FlightLicense] Int IDENTITY NOT NULL,
 [BirthDay] Date NOT NULL,
 [DateofIssue] Date NOT NULL,
 [DateofExpiry] Datetime NOT NULL,
 [LicenseCategory] Varchar(120) NOT NULL,
 [CityofResidence] Varchar(120) NULL,
 [CountryofResidence] Varchar(120) NOT NULL,
 [ID_User] Int NOT NULL
)
go

-- Create indexes for table FlightLicense

CREATE INDEX [IX_R1_User_FlightLicense] ON [FlightLicense] ([ID_User])
go

-- Add keys for table FlightLicense

ALTER TABLE [FlightLicense] ADD CONSTRAINT [ID_FlightLicense] PRIMARY KEY ([ID_FlightLicense])
go

-- Table Aircraft

CREATE TABLE [Aircraft]
(
 [ID_Aircraft] Int IDENTITY NOT NULL,
 [SerialNumber] Char(7) NOT NULL,
 [ModelName] Varchar(120) NOT NULL,
 [ManufactureCountry] Varchar(120) NOT NULL,
 [Status] Varchar(30) NULL,
 [ID_AircraftCategory] Int NOT NULL
)
go

-- Create indexes for table Aircraft

CREATE INDEX [IX_R9] ON [Aircraft] ([ID_AircraftCategory])
go

-- Add keys for table Aircraft

ALTER TABLE [Aircraft] ADD CONSTRAINT [ID_Aircraft] PRIMARY KEY ([ID_Aircraft])
go

-- Table AircraftCategory

CREATE TABLE [AircraftCategory]
(
 [ID_AircraftCategory] Int IDENTITY NOT NULL,
 [AircraftType] Varchar(120) NOT NULL
)
go

-- Add keys for table AircraftCategory

ALTER TABLE [AircraftCategory] ADD CONSTRAINT [ID_AircraftCategory] PRIMARY KEY ([ID_AircraftCategory])
go

-- Table Passport

CREATE TABLE [Passport]
(
 [ID_Passport] Int IDENTITY NOT NULL,
 [Surname] Varchar(120) NOT NULL,
 [Name] Varchar(120) NOT NULL,
 [MiddleName] Varchar(120) NULL,
 [DateofIssue] Date NOT NULL,
 [CodeDepartament] Char(7) NOT NULL,
 [Sex] Char(1) NOT NULL,
 [BirthDay] Date NOT NULL,
 [PlaceBorn] Varchar(120) NOT NULL,
 [PlaceIssue] Varchar(120) NOT NULL,
 [Number] Char(10) NOT NULL
)
go

-- Add keys for table Passport

ALTER TABLE [Passport] ADD CONSTRAINT [ID_Passport] PRIMARY KEY ([ID_Passport])
go

-- Table AircraftInfo

CREATE TABLE [AircraftInfo]
(
 [ID_AircraftInfo] Int IDENTITY NOT NULL,
 [PassengerCapacity] Int NOT NULL,
 [MaxWeight] Decimal(10,2) NOT NULL,
 [EngineType] Varchar(120) NOT NULL,
 [EnginesCount] Int NOT NULL,
 [ID_Aircraft] Int NOT NULL
)
go

-- Create indexes for table AircraftInfo

CREATE INDEX [IX_R10] ON [AircraftInfo] ([ID_Aircraft])
go

-- Add keys for table AircraftInfo

ALTER TABLE [AircraftInfo] ADD CONSTRAINT [ID_AircraftInfo] PRIMARY KEY ([ID_AircraftInfo])
go

-- Table AircraftCoordinates

CREATE TABLE [AircraftCoordinates]
(
 [ID_AircraftCoordinates] Int IDENTITY NOT NULL,
 [Altitude] Decimal(10,2) NOT NULL,
 [PressureOnBoard] Decimal(5,2) NOT NULL,
 [Speed] Decimal(5,2) NOT NULL,
 [Latitude] Decimal(8,6) NOT NULL,
 [Longitude] Decimal(9,6) NOT NULL,
 [ID_Aircraft] Int NOT NULL
)
go

-- Create indexes for table AircraftCoordinates

CREATE INDEX [IX_R11] ON [AircraftCoordinates] ([ID_Aircraft])
go

-- Add keys for table AircraftCoordinates

ALTER TABLE [AircraftCoordinates] ADD CONSTRAINT [ID_AircraftCoordinates] PRIMARY KEY ([ID_AircraftCoordinates])
go

-- Table Admin

CREATE TABLE [Admin]
(
 [IDAdmin] Int NOT NULL,
 [ID_User] Int NOT NULL
)
go

-- Add keys for table Admin

ALTER TABLE [Admin] ADD CONSTRAINT [ID_Admin] PRIMARY KEY ([IDAdmin],[ID_User])
go

-- Table Rental

CREATE TABLE [Rental]
(
 [ID_Rental] Int IDENTITY NOT NULL,
 [StartDate] Date NOT NULL,
 [RentalTime] Time NOT NULL,
 [CountOfHours] Int NOT NULL,
 [TotalPrice] Decimal(10,2) NOT NULL,
 [RentalStatus] Varchar(30) NOT NULL,
 [ID_User] Int NOT NULL,
 [ID_FlightLicense] Int NOT NULL,
 [ID_Aircraft] Int NOT NULL
)
go

-- Create indexes for table Rental

CREATE INDEX [IX_R4] ON [Rental] ([ID_User])
go

CREATE INDEX [IX_R7] ON [Rental] ([ID_FlightLicense])
go

CREATE INDEX [IX_R12] ON [Rental] ([ID_Aircraft])
go

-- Add keys for table Rental

ALTER TABLE [Rental] ADD CONSTRAINT [ID_Rental] PRIMARY KEY ([ID_Rental])
go

-- Table AircraftRegistrCertificate

CREATE TABLE [AircraftRegistrCertificate]
(
 [SerialNumber] Char(7) NOT NULL,
 [CertifacteNumber] Char(10) NOT NULL,
 [DateofIssue] Date NOT NULL,
 [DateofExpiry] Date NOT NULL,
 [ID_Aircaft] Int NOT NULL,
 [Attribute1] Int NOT NULL,
 [ID_AircraftRegistrCertificate] Int IDENTITY NOT NULL
)
go

-- Create indexes for table AircraftRegistrCertificate

CREATE INDEX [IX_R13] ON [AircraftRegistrCertificate] ([ID_Aircaft])
go

CREATE INDEX [IX_R20] ON [AircraftRegistrCertificate] ([Attribute1])
go

-- Add keys for table AircraftRegistrCertificate

ALTER TABLE [AircraftRegistrCertificate] ADD CONSTRAINT [ID_AircraftRegistrCertificates] PRIMARY KEY ([ID_AircraftRegistrCertificate])
go

-- Table Airfield

CREATE TABLE [Airfield]
(
 [ID_Airfield] Int IDENTITY NOT NULL,
 [Name] Varchar(120) NOT NULL,
 [Country] Varchar(120) NOT NULL,
 [City] Varchar(120) NULL,
 [Latitude] Decimal(8,6) NOT NULL,
 [Longitude] Decimal(9,6) NOT NULL
)
go

-- Add keys for table Airfield

ALTER TABLE [Airfield] ADD CONSTRAINT [ID_Airfield] PRIMARY KEY ([ID_Airfield])
go

-- Table ServiceInfo

CREATE TABLE [ServiceInfo]
(
 [ID_ServiceInfo] Int IDENTITY NOT NULL,
 [TimeOfViolation] Datetime NOT NULL,
 [Decription] Varchar(30) NOT NULL,
 [ID_Aircraft] Int NOT NULL
)
go

-- Create indexes for table ServiceInfo

CREATE INDEX [IX_R15] ON [ServiceInfo] ([ID_Aircraft])
go

-- Add keys for table ServiceInfo

ALTER TABLE [ServiceInfo] ADD CONSTRAINT [ID_ServiceInfo] PRIMARY KEY ([ID_ServiceInfo])
go

-- Table AircraftInsurance

CREATE TABLE [AircraftInsurance]
(
 [InsuranceNumber] Char(10) NOT NULL,
 [SerialNumber] Char(7) NOT NULL,
 [InsuranceCompany] Varchar(120) NOT NULL,
 [DateofIssue] Date NOT NULL,
 [DateofExpiry] Date NOT NULL,
 [CoverageAmount] Decimal(10,2) NOT NULL,
 [Status] Char(10) NOT NULL,
 [ID_Aircraft] Int NOT NULL,
 [ID_LeasingCompany] Int NOT NULL,
 [ID_AircraftInsurance] Int IDENTITY NOT NULL
)
go

-- Create indexes for table AircraftInsurance

CREATE INDEX [IX_R16] ON [AircraftInsurance] ([ID_Aircraft])
go

CREATE INDEX [IX_R24] ON [AircraftInsurance] ([ID_LeasingCompany])
go

-- Add keys for table AircraftInsurance

ALTER TABLE [AircraftInsurance] ADD CONSTRAINT [ID_AircraftInsurance] PRIMARY KEY ([ID_AircraftInsurance])
go

-- Table Employee

CREATE TABLE [Employee]
(
 [ID_Employee] Int IDENTITY NOT NULL,
 [FullName] Varchar(120) NOT NULL,
 [PassportNumber] Char(10) NOT NULL,
 [PostName] Varchar(120) NOT NULL,
 [MailAdress] Varchar(120) NOT NULL,
 [SalaryRate] Decimal(10,2) NOT NULL,
 [ID_Airfield] Int NOT NULL,
 [Number] Int NOT NULL
)
go

-- Create indexes for table Employee

CREATE INDEX [IX_R22] ON [Employee] ([ID_Airfield])
go

CREATE INDEX [IX_Relationship3] ON [Employee] ([Number])
go

-- Add keys for table Employee

ALTER TABLE [Employee] ADD CONSTRAINT [ID_Employee] PRIMARY KEY ([ID_Employee])
go

-- Table MoneyTransaction

CREATE TABLE [MoneyTransaction]
(
 [ID_MoneyTransaction] Int IDENTITY NOT NULL,
 [TransactionType] Char(120) NOT NULL,
 [Amount] Decimal(10,2) NOT NULL,
 [TransactionDate] Datetime NOT NULL,
 [ID_User_Sender] Int NOT NULL,
 [ID_Rental] Int NOT NULL
)
go

-- Create indexes for table MoneyTransaction

CREATE INDEX [IX_R5] ON [MoneyTransaction] ([ID_User_Sender])
go

CREATE INDEX [IX_R19] ON [MoneyTransaction] ([ID_Rental])
go

-- Add keys for table MoneyTransaction

ALTER TABLE [MoneyTransaction] ADD CONSTRAINT [ID_MoneyTransaction] PRIMARY KEY ([ID_MoneyTransaction])
go

-- Table LeasingCompany

CREATE TABLE [LeasingCompany]
(
 [OGRN] Char(13) NOT NULL,
 [CompanyName] Varchar(120) NOT NULL,
 [ContactEMail] Varchar(120) NOT NULL,
 [ID_LeasingCompany] Int IDENTITY NOT NULL
)
go

-- Add keys for table LeasingCompany

ALTER TABLE [LeasingCompany] ADD CONSTRAINT [ID_LeasingCompany] PRIMARY KEY ([ID_LeasingCompany])
go

-- Table LeasingInfo

CREATE TABLE [LeasingInfo]
(
 [ID_LeasingInfo] Int IDENTITY NOT NULL,
 [SerialNumber] Char(7) NOT NULL,
 [LeaseStartDate] Date NOT NULL,
 [LeaseEndDate] Date NOT NULL,
 [MonthlyPayment] Decimal(10,2) NOT NULL,
 [ID_Aircraft] Int NOT NULL,
 [ID_LeasingCompany] Int NOT NULL
)
go

-- Create indexes for table LeasingInfo

CREATE INDEX [IX_R25] ON [LeasingInfo] ([ID_LeasingCompany])
go

CREATE INDEX [IX_Relationship2] ON [LeasingInfo] ([ID_Aircraft])
go

-- Add keys for table LeasingInfo

ALTER TABLE [LeasingInfo] ADD CONSTRAINT [ID_LeasingInfo] PRIMARY KEY ([ID_LeasingInfo])
go

-- Table PaymentInfo

CREATE TABLE [PaymentInfo]
(
 [ID_PaymetnInfo] Int IDENTITY NOT NULL,
 [CardNumber] Char(16) NOT NULL,
 [CVC] Char(4) NOT NULL,
 [ID_User] Int NOT NULL
)
go

-- Create indexes for table PaymentInfo

CREATE INDEX [IX_R6] ON [PaymentInfo] ([ID_User])
go

-- Add keys for table PaymentInfo

ALTER TABLE [PaymentInfo] ADD CONSTRAINT [ID_PaymentInfo] PRIMARY KEY ([ID_PaymetnInfo])
go

-- Table ServiceInfo_Airfield

CREATE TABLE [ServiceInfo_Airfield]
(
 [ID_ServiceInfo] Int NOT NULL,
 [ID_Airfield] Int NOT NULL
)
go

-- Table Employee_ServiceInfo

CREATE TABLE [Employee_ServiceInfo]
(
 [ID_Employee] Int NOT NULL,
 [ID_ServiceInfo] Int NOT NULL
)
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Admin] ADD CONSTRAINT [R3_User_Admin] FOREIGN KEY ([ID_User]) REFERENCES [User] ([ID_User]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [FlightLicense] ADD CONSTRAINT [R1_User_FlightLicense] FOREIGN KEY ([ID_User]) REFERENCES [User] ([ID_User]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Rental] ADD CONSTRAINT [R4_User_Rental] FOREIGN KEY ([ID_User]) REFERENCES [User] ([ID_User]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [MoneyTransaction] ADD CONSTRAINT [R5_User_MoneyTransaction] FOREIGN KEY ([ID_User_Sender]) REFERENCES [User] ([ID_User]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PaymentInfo] ADD CONSTRAINT [R6_User_PaymentInfo] FOREIGN KEY ([ID_User]) REFERENCES [User] ([ID_User]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Rental] ADD CONSTRAINT [R7_FlightLicense_Rental] FOREIGN KEY ([ID_FlightLicense]) REFERENCES [FlightLicense] ([ID_FlightLicense]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Aircraft] ADD CONSTRAINT [R9_AircraftCategory_Aircraft] FOREIGN KEY ([ID_AircraftCategory]) REFERENCES [AircraftCategory] ([ID_AircraftCategory]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftInfo] ADD CONSTRAINT [R10_Aircraft_AircraftInfo] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftCoordinates] ADD CONSTRAINT [R11_Aircraft_AircraftCoordinates] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Rental] ADD CONSTRAINT [R12_Aircraft_Rental] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftRegistrCertificate] ADD CONSTRAINT [R13_Aircraft_AircraftRegistrCertificate] FOREIGN KEY ([ID_Aircaft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [ServiceInfo] ADD CONSTRAINT [R15_Aircraft_ServiceInfo] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftInsurance] ADD CONSTRAINT [R16_Aircraft_AircraftInsurance] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [MoneyTransaction] ADD CONSTRAINT [R19_Rental_MoneyTransaction] FOREIGN KEY ([ID_Rental]) REFERENCES [Rental] ([ID_Rental]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftRegistrCertificate] ADD CONSTRAINT [R20_LeasingCompany_AircraftRegistrCertificate] FOREIGN KEY ([Attribute1]) REFERENCES [LeasingCompany] ([ID_LeasingCompany]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [ServiceInfo_Airfield] ADD CONSTRAINT [R21_ServiceInfo] FOREIGN KEY ([ID_ServiceInfo]) REFERENCES [ServiceInfo] ([ID_ServiceInfo]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [ServiceInfo_Airfield] ADD CONSTRAINT [R21_Airfield] FOREIGN KEY ([ID_Airfield]) REFERENCES [Airfield] ([ID_Airfield]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Employee] ADD CONSTRAINT [R22_Airfield_Employee] FOREIGN KEY ([ID_Airfield]) REFERENCES [Airfield] ([ID_Airfield]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Employee_ServiceInfo] ADD CONSTRAINT [R23_Employee_Employee_ServiceInfo] FOREIGN KEY ([ID_Employee]) REFERENCES [Employee] ([ID_Employee]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Employee_ServiceInfo] ADD CONSTRAINT [R23_ServiceInfo_Employee_ServiceInfo] FOREIGN KEY ([ID_ServiceInfo]) REFERENCES [ServiceInfo] ([ID_ServiceInfo]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [AircraftInsurance] ADD CONSTRAINT [R24_LeasingCompany_AircraftInsurance] FOREIGN KEY ([ID_LeasingCompany]) REFERENCES [LeasingCompany] ([ID_LeasingCompany]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [LeasingInfo] ADD CONSTRAINT [R25_LeasingCompany_LeasingInfo] FOREIGN KEY ([ID_LeasingCompany]) REFERENCES [LeasingCompany] ([ID_LeasingCompany]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [LeasingInfo] ADD CONSTRAINT [R17_Aircraft_LeasingInfo] FOREIGN KEY ([ID_Aircraft]) REFERENCES [Aircraft] ([ID_Aircraft]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Employee] ADD CONSTRAINT [R18_Passport_Employee] FOREIGN KEY ([Number]) REFERENCES [Passport] ([ID_Passport]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [User] ADD CONSTRAINT [R2_Passport_User] FOREIGN KEY ([ID_Passport]) REFERENCES [Passport] ([ID_Passport]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




