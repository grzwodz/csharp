GO
/****** Object:  Table [dbo].[Lekarz]    Script Date: 18-04-2015 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lekarz](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[imie] [varchar](50) NULL,
	[nazwisko] [varchar](50) NULL,
	[adres] [varchar](50) NULL,
	[telefon] [varchar](50) NULL,
	[dataUrodzenia] [date] NULL,
	[idSpecjalizacji] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pacjent]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pacjent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[imie] [varchar](50) NULL,
	[nazwisko] [varchar](50) NULL,
	[adres] [varchar](50) NULL,
	[telefon] [varchar](50) NULL,
	[dataUrodzenia] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Specjalizacja]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Specjalizacja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nazwaSpecjalizacji] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wizyta]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wizyta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idLekarza] [int] NULL,
	[idPacjenta] [int] NULL,
	[dataWizyty] [date] NULL,
	[opis] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Lekarz]  WITH CHECK ADD  CONSTRAINT [FK_Lekarz_Specjalizacja] FOREIGN KEY([idSpecjalizacji])
REFERENCES [dbo].[Specjalizacja] ([ID])
GO
ALTER TABLE [dbo].[Lekarz] CHECK CONSTRAINT [FK_Lekarz_Specjalizacja]
GO
ALTER TABLE [dbo].[Wizyta]  WITH CHECK ADD  CONSTRAINT [FK_Wizyta_Lekarz] FOREIGN KEY([idLekarza])
REFERENCES [dbo].[Lekarz] ([ID])
GO
ALTER TABLE [dbo].[Wizyta] CHECK CONSTRAINT [FK_Wizyta_Lekarz]
GO
ALTER TABLE [dbo].[Wizyta]  WITH CHECK ADD  CONSTRAINT [FK_Wizyta_Pacjent] FOREIGN KEY([idPacjenta])
REFERENCES [dbo].[Pacjent] ([ID])
GO
ALTER TABLE [dbo].[Wizyta] CHECK CONSTRAINT [FK_Wizyta_Pacjent]
GO
/****** Object:  StoredProcedure [dbo].[DeleteLekarz]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLekarz] (
@ID int
)
AS
BEGIN
DELETE FROM Lekarz WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePacjent]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePacjent] (
@ID int
)
AS
BEGIN
DELETE FROM Pacjent WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteWizyta]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteWizyta] (
@ID int

)
AS
BEGIN
DELETE FROM Wizyta WHERE id = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLekarzRecord]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertLekarzRecord]
(
 @LekarzImie Varchar(50),
 @LekarzNazwisko  Varchar(50),
 @LekarzAdres     Varchar(50),
 @LekarzTelefon Varchar(50),
 @LekarzDataUrodzenia date,
 @LekarzIdSpecjalizacji int
) 
As
 Begin
   Insert into Lekarz (imie,nazwisko,adres,telefon,dataUrodzenia,idSpecjalizacji)
   Values(@LekarzImie,@LekarzNazwisko,@LekarzAdres,@LekarzTelefon,@LekarzDataUrodzenia,@LekarzIdSpecjalizacji)
 End
GO
/****** Object:  StoredProcedure [dbo].[InsertPacjentRecord]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertPacjentRecord]
(
 @imie varchar(50),
 @nazwisko varchar(50),
 @dataUrodzenia date,
 @adres varchar(50),
 @telefon varchar(50)
) 
As
 Begin
   Insert Into Pacjent(imie,nazwisko,dataUrodzenia,adres,telefon)
   values (@imie,@nazwisko,@dataUrodzenia,@adres,@telefon)
 End
GO
/****** Object:  StoredProcedure [dbo].[InsertWizyta]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertWizyta] (
@idLekarza int,
@idPacjenta int,
@dataWizyty date,
@opis text
)
AS
BEGIN
INSERT INTO Wizyta(idLekarza,idPacjenta,dataWizyty,opis) VALUES
(@idLekarza,@idPacjenta,@dataWizyty,@opis)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertWizytaRecord]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertWizytaRecord]
(
 @IdLekarz int,
 @IdPacjent int,
 @Data date,
 @Opis text
) 
As
 Begin
   Insert Into Wizyta (idLekarza,idPacjenta,dataWizyty,opis)
   values (@IdLekarz,@IdPacjent,@Data,@Opis)
 End
GO
/****** Object:  StoredProcedure [dbo].[UpdateLekarz]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLekarz] (
@ID int,
@imie varchar(50),
@nazwisko varchar(50),
@dataUrodzenia varchar(50),
@adres varchar(50),
@telefon varchar(50)
)
AS
BEGIN
UPDATE Lekarz SET imie = @imie, nazwisko = @nazwisko, adres = @adres,
telefon = @telefon, dataUrodzenia = @dataUrodzenia WHERE id = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePacjent]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePacjent] (
@ID int,
@imie varchar (50),
@nazwisko varchar(50),
@dataUrodzenia date,
@adres varchar(50),
@telefon varchar(50)
)
AS
BEGIN
UPDATE Pacjent SET imie = @imie, nazwisko = @nazwisko, dataUrodzenia = @dataUrodzenia,
adres = @adres, telefon = @telefon WHERE id =@ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateWizyta]    Script Date: 18-04-2015 19:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateWizyta] (
@ID int,
@dataWizyty date,
@opis text

)
AS
BEGIN
UPDATE Wizyta SET dataWizyty = @dataWizyty,
opis = @opis WHERE id = @ID
END
GO
/* WPROWADZENIE DANYCH */
INSERT INTO Specjalizacja (nazwaSpecjalizacji)
VALUES ('internista');
INSERT INTO Specjalizacja (nazwaSpecjalizacji)
VALUES ('chirurg');
INSERT INTO Lekarz (imie, nazwisko, adres, telefon, dataUrodzenia, idSpecjalizacji)
VALUES ('Adam', 'Nowak', 'Puławska 21 Warszawa 02-220', '111111111', '1970-04-05', 1)
INSERT INTO Lekarz (imie, nazwisko, adres, telefon, dataUrodzenia, idSpecjalizacji)
VALUES ('John', 'Doe', 'Al. Jana Pawła II, Piaseczno', '600022200', '1960-04-05', 2)
INSERT INTO Pacjent (imie, nazwisko, adres, telefon, dataUrodzenia)
VALUES ('Jan', 'Kowalski', 'Naruszewicza 24, 02-260 Warszawa', '725725725', '1990-04-05')
INSERT INTO Pacjent (imie, nazwisko, adres, telefon, dataUrodzenia)
VALUES ('Grzegorz', 'Wodzinski', 'Solidarnosci, 02-260 Warszawa', '500500500', '1996-06-06')
INSERT INTO Wizyta (idLekarza, idPacjenta, dataWizyty, opis)
VALUES (1, 2, '2015-04-18', 'Operacja')
INSERT INTO Wizyta (idLekarza, idPacjenta, dataWizyty, opis)
VALUES (2, 1, '2015-08-29', 'Badanie profilaktyczne')