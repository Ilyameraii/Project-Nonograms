CREATE DATABASE Nonograms;

USE Nonograms;


CREATE TABLE Users (
	UsersID INT IDENTITY(1,1) PRIMARY KEY,
	UserLogin NVARCHAR(255) NOT NULL UNIQUE,
	UserPassword NVARCHAR(255) NOT NULL,
	UserEmail NVARCHAR(255) NOT NULL,
	RegistrationDate DATE DEFAULT GETDATE(),
)
CREATE TABLE Crossword (
    CrosswordID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
	Matrix NVARCHAR(MAX) NOT NULL,
    Width INT NOT NULL,
    Height INT NOT NULL,
	Difficult INT NOT NULL,
);
CREATE TABLE SolvingProcess (
    SolvingProcessID INT IDENTITY(1,1) PRIMARY KEY,
    UsersID INT,
    CrosswordID INT,
    StatusOfCrossword BIT DEFAULT 0, -- 0 - не решен, 1 - решен
    Progress NVARCHAR(MAX), 
    StartTime DATETIME2 DEFAULT GETDATE(), -- Время начала решения
    EndTime DATETIME2, -- Время завершения решения
    LeadTime INT, -- Время выполнения (в секундах)
    HintsUsed INT DEFAULT 0, -- Количество использованных подсказок (новое поле)
    Mistakes INT DEFAULT 0, -- Количество ошибок
    FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
    FOREIGN KEY (CrosswordID) REFERENCES Crossword(CrosswordID)
);
SELECT* FROM Crossword;
SELECT* FROM Users;
SELECT* FROM SolvingProcess;


DROP TABLE SolvingProcess;
DROP TABLE Crossword;
DROP TABLE Users;

CREATE DATABASE Nonograms_1_2;

USE Nonograms_1_2;;


CREATE TABLE Users (
	UsersID INT IDENTITY(1,1) PRIMARY KEY,
	UserLogin NVARCHAR(255) NOT NULL UNIQUE,
	UserPassword NVARCHAR(255) NOT NULL,
	UserEmail NVARCHAR(255) NOT NULL,
	RegistrationDate DATE DEFAULT GETDATE(),
)
CREATE TABLE Crossword (
    CrosswordID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
	Matrix NVARCHAR(MAX) NOT NULL,
    Width INT NOT NULL,
    Height INT NOT NULL,
	Difficult INT NOT NULL,
);
CREATE TABLE SolvingProcess (
    SolvingProcessID INT IDENTITY(1,1) PRIMARY KEY,
    UsersID INT,
    CrosswordID INT,
    StatusOfCrossword BIT DEFAULT 0, -- 0 - не решен, 1 - решен
    Progress NVARCHAR(MAX), 
    StartTime DATETIME2 DEFAULT GETDATE(), -- Время начала решения
    EndTime DATETIME2, -- Время завершения решения
    LeadTime INT, -- Время выполнения (в секундах)
    HintsUsed INT DEFAULT 0, -- Количество использованных подсказок (новое поле)
    Mistakes INT DEFAULT 0, -- Количество ошибок
    FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
    FOREIGN KEY (CrosswordID) REFERENCES Crossword(CrosswordID)
);
SELECT* FROM Crossword;
SELECT* FROM Users;
SELECT* FROM SolvingProcess;


DROP TABLE SolvingProcess;
DROP TABLE Crossword;
DROP TABLE Users;