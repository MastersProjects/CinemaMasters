
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2016 08:35:35
-- Generated from EDMX file: C:\Users\Perenzin Elia\Source\Repos\CinemaMasters\CinemaMasters\Models\CinemaMasters.edmx
-- --------------------------------------------------

CREATE DATABASE [CinemaMasters]
Go

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaMasters];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Film'
CREATE TABLE [dbo].[Film] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(50)  NOT NULL,
    [Dauer] int  NOT NULL,
    [Altersfreigabe] int  NOT NULL
);
GO

-- Creating table 'Kinobesucher'
CREATE TABLE [dbo].[Kinobesucher] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Vorname] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Telefonnummer] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Kinosaal'
CREATE TABLE [dbo].[Kinosaal] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AnzahlReihe] int  NOT NULL,
    [AnzahlPlaetze] int  NOT NULL,
    [Name] nvarchar(20)  NULL
);
GO

-- Creating table 'Platz'
CREATE TABLE [dbo].[Platz] (
    [Id] int IDENTITY(1,1) NOT NULL,
	[Platznummer] INT NOT NULL,
    [ReiheId] int  NOT NULL
);
GO

-- Creating table 'Reihe'
CREATE TABLE [dbo].[Reihe] (
    [Id] int IDENTITY(1,1) NOT NULL,
	[Reihennummer] int  NULL,
    [KinosaalId] int  NOT NULL
);
GO

-- Creating table 'Reservierung'
CREATE TABLE [dbo].[Reservierung] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KinobesucherId] int  NOT NULL,
	[VorstellungId] int  NOT NULL
);
GO

-- Creating table 'ReservierungHasPlatz'
CREATE TABLE [dbo].[ReservierungHasPlatz] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReservierungId] int  NOT NULL,
    [PlatzId] int  NOT NULL
);
GO

-- Creating table 'Vorstellung'
CREATE TABLE [dbo].[Vorstellung] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Zeit] datetime  NOT NULL,
    [FilmId] int  NOT NULL,
	[KinosaalId] int NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Film'
ALTER TABLE [dbo].[Film]
ADD CONSTRAINT [PK_Film]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kinobesucher'
ALTER TABLE [dbo].[Kinobesucher]
ADD CONSTRAINT [PK_Kinobesucher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kinosaal'
ALTER TABLE [dbo].[Kinosaal]
ADD CONSTRAINT [PK_Kinosaal]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Platz'
ALTER TABLE [dbo].[Platz]
ADD CONSTRAINT [PK_Platz]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reihe'
ALTER TABLE [dbo].[Reihe]
ADD CONSTRAINT [PK_Reihe]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [PK_Reservierung]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReservierungHasPlatz'
ALTER TABLE [dbo].[ReservierungHasPlatz]
ADD CONSTRAINT [PK_ReservierungHasPlatz]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vorstellung'
ALTER TABLE [dbo].[Vorstellung]
ADD CONSTRAINT [PK_Vorstellung]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FilmId] in table 'Vorstellung'
ALTER TABLE [dbo].[Vorstellung]
ADD CONSTRAINT [FK_FilmId]
    FOREIGN KEY ([FilmId])
    REFERENCES [dbo].[Film]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KinosaalId] in table 'Vorstellung'
ALTER TABLE [dbo].[Vorstellung]
ADD CONSTRAINT FK_KinosaalId
    FOREIGN KEY ([KinosaalId])
    REFERENCES [dbo].[Kinosaal]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KinosaalId] in table 'Reihe'
ALTER TABLE [dbo].[Reihe]
ADD CONSTRAINT [FK_KinosaalId_Reihe]
    FOREIGN KEY ([KinosaalId])
    REFERENCES [dbo].[Kinosaal]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PlatzId] in table 'ReservierungHasPlatz'
ALTER TABLE [dbo].[ReservierungHasPlatz]
ADD CONSTRAINT [FK_PlatzId]
    FOREIGN KEY ([PlatzId])
    REFERENCES [dbo].[Platz]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ReservierungId] in table 'ReservierungHasPlatz'
ALTER TABLE [dbo].[ReservierungHasPlatz]
ADD CONSTRAINT [FK_ReservierungId]
    FOREIGN KEY ([ReservierungId])
    REFERENCES [dbo].[Reservierung]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ReiheId] in table 'Platz'
ALTER TABLE [dbo].[Platz]
ADD CONSTRAINT [FK_ReiheId]
    FOREIGN KEY ([ReiheId])
    REFERENCES [dbo].[Reihe]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KinobesucherId] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_KinobesucherId_Reservierung]
    FOREIGN KEY ([KinobesucherId])
    REFERENCES [dbo].[Kinobesucher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VorstellungId] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_VorstellungId_Reservierung]
    FOREIGN KEY ([VorstellungId])
    REFERENCES [dbo].[Vorstellung]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------