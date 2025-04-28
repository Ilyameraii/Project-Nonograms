CREATE DATABASE Nonograms;

USE Nonograms;


CREATE TABLE Users (
	UsersID INT IDENTITY(1,1) PRIMARY KEY,
	UserLogin NVARCHAR(255) NOT NULL UNIQUE,
	UserPassword NVARCHAR(255) NOT NULL,
	UserEmail NVARCHAR(255) NOT NULL,
	RegistrationDate DATE DEFAULT GETDATE(),
)
CREATE TABLE Difficult(
	DifficultID INT IDENTITY(1,1) PRIMARY KEY,
	DifficultName NVARCHAR(255) NOT NULL,
	DifficultLevel INT NOT NULL,
);
CREATE TABLE Crossword (
    CrosswordID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
	Matrix NVARCHAR(MAX) NOT NULL,
    Width INT NOT NULL,
    Height INT NOT NULL,
	DifficultID INT NOT NULL,

    FOREIGN KEY (DifficultID) REFERENCES Difficult(DifficultID)

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

INSERT INTO Difficult(DifficultLevel,DifficultName)
VALUES
('1', 'Очень лёгкая'),
('2', 'Лёгкая'),
('3', 'Средняя'),
('4', 'Сложная');
SELECT* FROM Crossword;
SELECT* FROM Users;
SELECT* FROM SolvingProcess;
SELECT* FROM Difficult;

DROP TABLE SolvingProcess;
DROP TABLE Crossword;
DROP TABLE Users;
DROP TABLE Difficult;