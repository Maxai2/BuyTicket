CREATE DATABASE FilmTicket
GO
USE FilmTicket
GO

CREATE TABLE Film
(
	Id int IDENTITY(1,1),
	Film_Name nvarchar(60) NOT NULL,
	[Year] int NOT NULL,
	Duration int NOT NULL,

	CONSTRAINT PK_Film_Id PRIMARY KEY (Id)
)

CREATE TABLE [Type]
(
	Id int IDENTITY(1, 1),
	[Type_Name] nvarchar(20) NOT NULL,

	CONSTRAINT PK_Type_Id PRIMARY KEY (Id)
)

CREATE TABLE Hall
(
	Id int IDENTITY(1, 1),
	NumOfHall int NOT NULL,
	SeatRowCount int NOT NULL,
	SeatColCount int NOT NULL,

	CONSTRAINT PK_Hall_Id PRIMARY KEY (Id)
)

CREATE TABLE Seans
(
	Id int IDENTITY(1, 1),
	Seans_Data DATE NOT NULL,
	Seans_Time TIME NOT NULL,
	Price int NOT NULL,
	Film_Id int NOT NULL,
	[Type_Id] int NOT NULL,
	Hall_Id int NOT NULL,

	CONSTRAINT PK_Seans_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Seans_Film_Id FOREIGN KEY (Film_Id) REFERENCES Film(Id),
	CONSTRAINT FK_Seans_Type_Id FOREIGN KEY ([Type_Id]) REFERENCES [Type](Id),
	CONSTRAINT FK_Seans_Hall_Id FOREIGN KEY (Hall_Id) REFERENCES Hall(Id),
)

CREATE TABLE Ticket
(
	Id int IDENTITY(1, 1),
	Email nvarchar(30) NOT NULL,
	Seat_Row int NOT NULL,
	Seat_Col int NOT NULL,
	Ticket_DateTime DATETIME2 NOT NULL,
	Seans_Id int NOT NULL,

	CONSTRAINT PK_Ticket_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Ticket_Seans_Id FOREIGN KEY (Seans_Id) REFERENCES Seans(Id)
)

INSERT INTO Film (Film_Name, [Year], Duration)
VALUES (N'Хан Соло', 2018, 150), (N'Реинкарниация', 2018, 130), (N'Дэдпул', 2018, 110), (N'Мир Юрского Периуда', 2018, 130)

INSERT INTO [Type] ([Type_Name])
VALUES (N'2D'), (N'3D')

INSERT INTO Hall (NumOfHall, SeatColCount, SeatRowCount)
VALUES (1, 5, 6), (2, 6, 8), (3, 4, 4)

INSERT INTO Seans (Film_Id, Hall_Id, Price, Seans_Data, Seans_Time, [Type_Id])
VALUES (1, 1, 15, '07/06/2018', '12:00', 2), (1, 2, 10, '07/06/2018', '14:35', 2)


DELETE FROM Seans

DBCC CHECKIDENT('Seans', RESEED, 0)

INSERT INTO Seans (Film_Id, Hall_Id, Price, Seans_Data, Seans_Time, [Type_Id])
VALUES (4, 2, 6, GETDATE(), '19:10', 1), (4, 3, 8, GETDATE(), '22:05', 2),
		(3, 1, 5, GETDATE(), '20:30', 2), (3, 2, 7, GETDATE(), '21:45', 1),
		(2, 2, 7, GETDATE(), '18:30', 1), (2, 1, 20, GETDATE(), '22:40', 2),
		(1, 3, 15, GETDATE(), '15:05', 2), (1, 2, 7, GETDATE(), '23:05', 1)

SELECT *
FROM Seans

DELETE FROM Ticket

DBCC CHECKIDENT('Ticket', RESEED, 0)