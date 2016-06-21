
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2016 08:35:35
-- Generated from EDMX file: C:\Users\Perenzin Elia\Source\Repos\CinemaMasters\CinemaMasters\Models\CinemaMasters.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaMasters];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FilmId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vorstellung] DROP CONSTRAINT [FK_FilmId];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmHasKinosaal] DROP CONSTRAINT [FK_FilmId];
GO
IF OBJECT_ID(N'[dbo].[FK_KinosaalId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmHasKinosaal] DROP CONSTRAINT [FK_KinosaalId];
GO
IF OBJECT_ID(N'[dbo].[FK_PlatzId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservierungHasPlatz] DROP CONSTRAINT [FK_PlatzId];
GO
IF OBJECT_ID(N'[dbo].[FK_ReiheId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservierung] DROP CONSTRAINT [FK_ReiheId];
GO
IF OBJECT_ID(N'[dbo].[FK_ReservierungId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservierungHasPlatz] DROP CONSTRAINT [FK_ReservierungId];
GO
IF OBJECT_ID(N'[dbo].[FK_KinosaalId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reihe] DROP CONSTRAINT [FK_KinosaalId];
GO
IF OBJECT_ID(N'[dbo].[FK_ReiheId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Platz] DROP CONSTRAINT [FK_ReiheId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Film]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Film];
GO
IF OBJECT_ID(N'[dbo].[FilmHasKinosaal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmHasKinosaal];
GO
IF OBJECT_ID(N'[dbo].[Kinobesucher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kinobesucher];
GO
IF OBJECT_ID(N'[dbo].[Kinosaal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kinosaal];
GO
IF OBJECT_ID(N'[dbo].[Platz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Platz];
GO
IF OBJECT_ID(N'[dbo].[Reihe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reihe];
GO
IF OBJECT_ID(N'[dbo].[Reservierung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservierung];
GO
IF OBJECT_ID(N'[dbo].[ReservierungHasPlatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReservierungHasPlatz];
GO
IF OBJECT_ID(N'[dbo].[Vorstellung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vorstellung];
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

-- Creating table 'FilmHasKinosaal'
CREATE TABLE [dbo].[FilmHasKinosaal] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FilmId] int  NOT NULL,
    [KinosaalId] int  NOT NULL
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
    [ReiheId] int  NOT NULL
);
GO

-- Creating table 'Reihe'
CREATE TABLE [dbo].[Reihe] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KinosaalId] int  NOT NULL,
    [Reihennummer] int  NULL
);
GO

-- Creating table 'Reservierung'
CREATE TABLE [dbo].[Reservierung] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReiheId] int  NOT NULL
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
    [FilmId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'FilmHasKinosaal'
ALTER TABLE [dbo].[FilmHasKinosaal]
ADD CONSTRAINT [PK_FilmHasKinosaal]
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

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmId'
CREATE INDEX [IX_FK_FilmId]
ON [dbo].[Vorstellung]
    ([FilmId]);
GO

-- Creating foreign key on [FilmId] in table 'FilmHasKinosaal'
ALTER TABLE [dbo].[FilmHasKinosaal]
ADD CONSTRAINT [FK_FilmId]
    FOREIGN KEY ([FilmId])
    REFERENCES [dbo].[Film]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmId'
CREATE INDEX [IX_FK_FilmId]
ON [dbo].[FilmHasKinosaal]
    ([FilmId]);
GO

-- Creating foreign key on [KinosaalId] in table 'FilmHasKinosaal'
ALTER TABLE [dbo].[FilmHasKinosaal]
ADD CONSTRAINT [FK_KinosaalId]
    FOREIGN KEY ([KinosaalId])
    REFERENCES [dbo].[Kinosaal]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KinosaalId'
CREATE INDEX [IX_FK_KinosaalId]
ON [dbo].[FilmHasKinosaal]
    ([KinosaalId]);
GO

-- Creating foreign key on [KinosaalId] in table 'Reihe'
ALTER TABLE [dbo].[Reihe]
ADD CONSTRAINT [FK_KinosaalId]
    FOREIGN KEY ([KinosaalId])
    REFERENCES [dbo].[Kinosaal]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KinosaalId'
CREATE INDEX [IX_FK_KinosaalId]
ON [dbo].[Reihe]
    ([KinosaalId]);
GO

-- Creating foreign key on [PlatzId] in table 'ReservierungHasPlatz'
ALTER TABLE [dbo].[ReservierungHasPlatz]
ADD CONSTRAINT [FK_PlatzId]
    FOREIGN KEY ([PlatzId])
    REFERENCES [dbo].[Platz]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlatzId'
CREATE INDEX [IX_FK_PlatzId]
ON [dbo].[ReservierungHasPlatz]
    ([PlatzId]);
GO

-- Creating foreign key on [ReiheId] in table 'Platz'
ALTER TABLE [dbo].[Platz]
ADD CONSTRAINT [FK_ReiheId]
    FOREIGN KEY ([ReiheId])
    REFERENCES [dbo].[Reihe]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReiheId'
CREATE INDEX [IX_FK_ReiheId]
ON [dbo].[Platz]
    ([ReiheId]);
GO

-- Creating foreign key on [ReiheId] in table 'Reservierung'
ALTER TABLE [dbo].[Reservierung]
ADD CONSTRAINT [FK_ReiheId]
    FOREIGN KEY ([ReiheId])
    REFERENCES [dbo].[Reihe]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReiheId'
CREATE INDEX [IX_FK_ReiheId]
ON [dbo].[Reservierung]
    ([ReiheId]);
GO

-- Creating foreign key on [ReservierungId] in table 'ReservierungHasPlatz'
ALTER TABLE [dbo].[ReservierungHasPlatz]
ADD CONSTRAINT [FK_ReservierungId]
    FOREIGN KEY ([ReservierungId])
    REFERENCES [dbo].[Reservierung]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReservierungId'
CREATE INDEX [IX_FK_ReservierungId]
ON [dbo].[ReservierungHasPlatz]
    ([ReservierungId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------