CREATE DATABASE BankSystem;
Use BankSystem;

CREATE TABLE Bank (
	[Name] VARCHAR(100) NOT NULL UNIQUE,
	Code VARCHAR(25) PRIMARY KEY,
	BuildingNumber INT NOT NULL,
	Street VARCHAR(75) NOT NULL,
	City VARCHAR(50) NOT NULL,
	Country VARCHAR(50) NOT NULL,
);


CREATE TABLE Branch (
	Number INT,
	BankCode VARCHAR(25) FOREIGN KEY REFERENCES Bank(Code),
	BuildingNumber INT NOT NULL,
	Street VARCHAR(75) NOT NULL,
	City VARCHAR(50) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	PRIMARY KEY(Number, BankCode)
);

CREATE TABLE Customer (
	SSN VARCHAR(50) PRIMARY KEY,
	FirstName VARCHAR(255) NOT NULL,
	MiddleName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	Phone VARCHAR(20) NOT NULL,
	BuildingNumber INT NOT NULL,
	Street VARCHAR(75) NOT NULL,
	City VARCHAR(50) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
);

CREATE TABLE Employee (
	SSN VARCHAR(50) PRIMARY KEY,
	FirstName VARCHAR(255) NOT NULL,
	MiddleName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	Phone VARCHAR(20) NOT NULL,
	BuildingNumber INT NOT NULL,
	Street VARCHAR(75) NOT NULL,
	City VARCHAR(50) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Admin] VARCHAR(10) CHECK ([Admin] in ('True', 'False')) DEFAULT 'False'
);

CREATE TABLE Account (
	Number INT IDENTITY(1, 1) PRIMARY KEY,
	BranchNumber INT NOT NULL,
	BankCode VARCHAR(25) NOT NULL,
	[Type] VARCHAR(25) NOT NULL,
	Balance REAL DEFAULT 0,
	CSSN VARCHAR(50) FOREIGN KEY REFERENCES Customer(SSN),
);

CREATE TABLE Loan (
	Number INT,
	[Type] VARCHAR(25) NOT NULL,
	BranchNumber INT NOT NULL,
	BankCode VARCHAR(25) NOT NULL,
	PRIMARY KEY(Number, BranchNumber, BankCode),
	FOREIGN KEY(BranchNumber, BankCode) REFERENCES Branch(Number, BankCode)
);

CREATE TABLE Requests (
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	AccountNumber INT FOREIGN KEY REFERENCES Account(Number) ON DELETE CASCADE,
	LoanNumber INT NOT NULL,
	BranchNumber INT NOT NULL,
	BankCode VARCHAR(25) NOT NULL,
	Amount REAL CHECK (Amount > 0),
	FOREIGN KEY(LoanNumber, BranchNumber, BankCode) REFERENCES Loan(Number, BranchNumber, BankCode),
);

CREATE TABLE ProcessLoanRequest (
	ESSN VARCHAR(50) FOREIGN KEY REFERENCES Employee(SSN),
	RequestID INT FOREIGN KEY REFERENCES Requests(ID) ON DELETE CASCADE,
	[State] VARCHAR(10) CHECK([State] in ('Accepted', 'Rejected', 'Paid'))
);