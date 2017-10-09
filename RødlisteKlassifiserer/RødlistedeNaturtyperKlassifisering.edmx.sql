
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2017 13:48:32
-- Generated from EDMX file: C:\Users\japed\source\repos\RødlistedeNaturområder\RødlisteKlassifiserer\RødlistedeNaturtyperKlassifisering.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RødlistedeNaturområderKlassifisering4];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RødlisteVurderingsenhetRødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteVurderingsenhetSet] DROP CONSTRAINT [FK_RødlisteVurderingsenhetRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_KartleggingsKodeNaturområdeTypeKode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KartleggingsKodeSet] DROP CONSTRAINT [FK_KartleggingsKodeNaturområdeTypeKode];
GO
IF OBJECT_ID(N'[dbo].[FK_RødlisteKlassifiseringRødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteKlassifiseringSet] DROP CONSTRAINT [FK_RødlisteKlassifiseringRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering_Beskrivelsesvariabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_Beskrivelsesvariabel];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_KartleggingsKodeRødlisteKlassifisering_KartleggingsKode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering] DROP CONSTRAINT [FK_KartleggingsKodeRødlisteKlassifisering_KartleggingsKode];
GO
IF OBJECT_ID(N'[dbo].[FK_KartleggingsKodeRødlisteKlassifisering_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering] DROP CONSTRAINT [FK_KartleggingsKodeRødlisteKlassifisering_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_NaturområdeTypeKodeRødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteKlassifiseringSet] DROP CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_KriterieRødlisteVurderingsenhet_Kriterie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KriterieRødlisteVurderingsenhet] DROP CONSTRAINT [FK_KriterieRødlisteVurderingsenhet_Kriterie];
GO
IF OBJECT_ID(N'[dbo].[FK_KriterieRødlisteVurderingsenhet_RødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KriterieRødlisteVurderingsenhet] DROP CONSTRAINT [FK_KriterieRødlisteVurderingsenhet_RødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_PåvirkningRødlisteVurderingsenhet_Påvirkning]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PåvirkningRødlisteVurderingsenhet] DROP CONSTRAINT [FK_PåvirkningRødlisteVurderingsenhet_Påvirkning];
GO
IF OBJECT_ID(N'[dbo].[FK_PåvirkningRødlisteVurderingsenhet_RødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PåvirkningRødlisteVurderingsenhet] DROP CONSTRAINT [FK_PåvirkningRødlisteVurderingsenhet_RødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_RødlisteVurdeingsenhetVersjonRødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteVurderingsenhetSet] DROP CONSTRAINT [FK_RødlisteVurdeingsenhetVersjonRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_NaturnivåRødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteVurderingsenhetSet] DROP CONSTRAINT [FK_NaturnivåRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_KodeVersjonNaturområdeTypeKode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NaturområdeTypeKodeSet] DROP CONSTRAINT [FK_KodeVersjonNaturområdeTypeKode];
GO
IF OBJECT_ID(N'[dbo].[FK_KodeVersjonBeskrivelsesvariabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelSet] DROP CONSTRAINT [FK_KodeVersjonBeskrivelsesvariabel];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering1_Beskrivelsesvariabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering1_Beskrivelsesvariabel];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering1_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering1_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_RødlisteKlassifiseringNaturområde_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Naturområde_RødlisteKlassifiseringSet] DROP CONSTRAINT [FK_RødlisteKlassifiseringNaturområde_RødlisteKlassifisering];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NaturområdeTypeKodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NaturområdeTypeKodeSet];
GO
IF OBJECT_ID(N'[dbo].[RødlisteVurderingsenhetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RødlisteVurderingsenhetSet];
GO
IF OBJECT_ID(N'[dbo].[KartleggingsKodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KartleggingsKodeSet];
GO
IF OBJECT_ID(N'[dbo].[RødlisteKlassifiseringSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RødlisteKlassifiseringSet];
GO
IF OBJECT_ID(N'[dbo].[BeskrivelsesvariabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BeskrivelsesvariabelSet];
GO
IF OBJECT_ID(N'[dbo].[KriterieSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KriterieSet];
GO
IF OBJECT_ID(N'[dbo].[PåvirkningSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PåvirkningSet];
GO
IF OBJECT_ID(N'[dbo].[RødlisteVurdeingsenhetVersjonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RødlisteVurdeingsenhetVersjonSet];
GO
IF OBJECT_ID(N'[dbo].[NaturnivåSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NaturnivåSet];
GO
IF OBJECT_ID(N'[dbo].[KodeVersjonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KodeVersjonSet];
GO
IF OBJECT_ID(N'[dbo].[Naturområde_RødlisteKlassifiseringSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Naturområde_RødlisteKlassifiseringSet];
GO
IF OBJECT_ID(N'[dbo].[BeskrivelsesvariabelRødlisteKlassifisering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[KartleggingsKodeRødlisteKlassifisering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[KriterieRødlisteVurderingsenhet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KriterieRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[PåvirkningRødlisteVurderingsenhet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PåvirkningRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[BeskrivelsesvariabelRødlisteKlassifisering1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NaturområdeTypeKodeSet'
CREATE TABLE [dbo].[NaturområdeTypeKodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [nivå] nvarchar(max)  NOT NULL,
    [KodeVersjon_Id] int  NOT NULL
);
GO

-- Creating table 'RødlisteVurderingsenhetSet'
CREATE TABLE [dbo].[RødlisteVurderingsenhetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [tema] nvarchar(max)  NOT NULL,
    [kategori] nvarchar(max)  NOT NULL,
    [RødlisteVurderingsenhetRødlisteVurderingsenhet_RødlisteVurderingsenhet1_Id] int  NULL,
    [RødlisteVurdeingsenhetVersjon_Id] int  NOT NULL,
    [Naturnivå_Id] int  NOT NULL
);
GO

-- Creating table 'KartleggingsKodeSet'
CREATE TABLE [dbo].[KartleggingsKodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] smallint  NULL,
    [nivå] nvarchar(max)  NULL,
    [navn] nvarchar(max)  NOT NULL,
    [NaturområdeTypeKode_Id] int  NOT NULL,
    [KartleggingsKodeAggregate_Id] int  NULL
);
GO

-- Creating table 'RødlisteKlassifiseringSet'
CREATE TABLE [dbo].[RødlisteKlassifiseringSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RødlisteVurderingsenhet_Id] int  NOT NULL,
    [NaturområdeTypeKode_Id] int  NULL
);
GO

-- Creating table 'BeskrivelsesvariabelSet'
CREATE TABLE [dbo].[BeskrivelsesvariabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [navn] nvarchar(max)  NULL,
    [KodeVersjon_Id] int  NOT NULL
);
GO

-- Creating table 'KriterieSet'
CREATE TABLE [dbo].[KriterieSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PåvirkningSet'
CREATE TABLE [dbo].[PåvirkningSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RødlisteVurdeingsenhetVersjonSet'
CREATE TABLE [dbo].[RødlisteVurdeingsenhetVersjonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NaturnivåSet'
CREATE TABLE [dbo].[NaturnivåSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KodeVersjonSet'
CREATE TABLE [dbo].[KodeVersjonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Naturområde_RødlisteKlassifiseringSet'
CREATE TABLE [dbo].[Naturområde_RødlisteKlassifiseringSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [naturområde_id] bigint  NOT NULL,
    [RødlisteKlassifisering_Id] int  NULL
);
GO

-- Creating table 'BeskrivelsesvariabelRødlisteKlassifisering'
CREATE TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] (
    [Beskrivelsesvariabel_Id] int  NOT NULL,
    [RødlisteKlassifisering_Id] int  NOT NULL
);
GO

-- Creating table 'KartleggingsKodeRødlisteKlassifisering'
CREATE TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering] (
    [KartleggingsKode_Id] int  NOT NULL,
    [RødlisteKlassifisering_Id] int  NOT NULL
);
GO

-- Creating table 'KriterieRødlisteVurderingsenhet'
CREATE TABLE [dbo].[KriterieRødlisteVurderingsenhet] (
    [Kriterie_Id] int  NOT NULL,
    [RødlisteVurderingsenhet_Id] int  NOT NULL
);
GO

-- Creating table 'PåvirkningRødlisteVurderingsenhet'
CREATE TABLE [dbo].[PåvirkningRødlisteVurderingsenhet] (
    [Påvirkning_Id] int  NOT NULL,
    [RødlisteVurderingsenhet_Id] int  NOT NULL
);
GO

-- Creating table 'BeskrivelsesvariabelRødlisteKlassifisering1'
CREATE TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1] (
    [InnsnevrendeBeskrivelsesvariabel_Id] int  NOT NULL,
    [RødlisteKlassifiseringInnsnevring_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NaturområdeTypeKodeSet'
ALTER TABLE [dbo].[NaturområdeTypeKodeSet]
ADD CONSTRAINT [PK_NaturområdeTypeKodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RødlisteVurderingsenhetSet'
ALTER TABLE [dbo].[RødlisteVurderingsenhetSet]
ADD CONSTRAINT [PK_RødlisteVurderingsenhetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KartleggingsKodeSet'
ALTER TABLE [dbo].[KartleggingsKodeSet]
ADD CONSTRAINT [PK_KartleggingsKodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[RødlisteKlassifiseringSet]
ADD CONSTRAINT [PK_RødlisteKlassifiseringSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BeskrivelsesvariabelSet'
ALTER TABLE [dbo].[BeskrivelsesvariabelSet]
ADD CONSTRAINT [PK_BeskrivelsesvariabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KriterieSet'
ALTER TABLE [dbo].[KriterieSet]
ADD CONSTRAINT [PK_KriterieSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PåvirkningSet'
ALTER TABLE [dbo].[PåvirkningSet]
ADD CONSTRAINT [PK_PåvirkningSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RødlisteVurdeingsenhetVersjonSet'
ALTER TABLE [dbo].[RødlisteVurdeingsenhetVersjonSet]
ADD CONSTRAINT [PK_RødlisteVurdeingsenhetVersjonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NaturnivåSet'
ALTER TABLE [dbo].[NaturnivåSet]
ADD CONSTRAINT [PK_NaturnivåSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KodeVersjonSet'
ALTER TABLE [dbo].[KodeVersjonSet]
ADD CONSTRAINT [PK_KodeVersjonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Naturområde_RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[Naturområde_RødlisteKlassifiseringSet]
ADD CONSTRAINT [PK_Naturområde_RødlisteKlassifiseringSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Beskrivelsesvariabel_Id], [RødlisteKlassifisering_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering]
ADD CONSTRAINT [PK_BeskrivelsesvariabelRødlisteKlassifisering]
    PRIMARY KEY CLUSTERED ([Beskrivelsesvariabel_Id], [RødlisteKlassifisering_Id] ASC);
GO

-- Creating primary key on [KartleggingsKode_Id], [RødlisteKlassifisering_Id] in table 'KartleggingsKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering]
ADD CONSTRAINT [PK_KartleggingsKodeRødlisteKlassifisering]
    PRIMARY KEY CLUSTERED ([KartleggingsKode_Id], [RødlisteKlassifisering_Id] ASC);
GO

-- Creating primary key on [Kriterie_Id], [RødlisteVurderingsenhet_Id] in table 'KriterieRødlisteVurderingsenhet'
ALTER TABLE [dbo].[KriterieRødlisteVurderingsenhet]
ADD CONSTRAINT [PK_KriterieRødlisteVurderingsenhet]
    PRIMARY KEY CLUSTERED ([Kriterie_Id], [RødlisteVurderingsenhet_Id] ASC);
GO

-- Creating primary key on [Påvirkning_Id], [RødlisteVurderingsenhet_Id] in table 'PåvirkningRødlisteVurderingsenhet'
ALTER TABLE [dbo].[PåvirkningRødlisteVurderingsenhet]
ADD CONSTRAINT [PK_PåvirkningRødlisteVurderingsenhet]
    PRIMARY KEY CLUSTERED ([Påvirkning_Id], [RødlisteVurderingsenhet_Id] ASC);
GO

-- Creating primary key on [InnsnevrendeBeskrivelsesvariabel_Id], [RødlisteKlassifiseringInnsnevring_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering1'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1]
ADD CONSTRAINT [PK_BeskrivelsesvariabelRødlisteKlassifisering1]
    PRIMARY KEY CLUSTERED ([InnsnevrendeBeskrivelsesvariabel_Id], [RødlisteKlassifiseringInnsnevring_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RødlisteVurderingsenhetRødlisteVurderingsenhet_RødlisteVurderingsenhet1_Id] in table 'RødlisteVurderingsenhetSet'
ALTER TABLE [dbo].[RødlisteVurderingsenhetSet]
ADD CONSTRAINT [FK_RødlisteVurderingsenhetRødlisteVurderingsenhet]
    FOREIGN KEY ([RødlisteVurderingsenhetRødlisteVurderingsenhet_RødlisteVurderingsenhet1_Id])
    REFERENCES [dbo].[RødlisteVurderingsenhetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteVurderingsenhetRødlisteVurderingsenhet'
CREATE INDEX [IX_FK_RødlisteVurderingsenhetRødlisteVurderingsenhet]
ON [dbo].[RødlisteVurderingsenhetSet]
    ([RødlisteVurderingsenhetRødlisteVurderingsenhet_RødlisteVurderingsenhet1_Id]);
GO

-- Creating foreign key on [NaturområdeTypeKode_Id] in table 'KartleggingsKodeSet'
ALTER TABLE [dbo].[KartleggingsKodeSet]
ADD CONSTRAINT [FK_KartleggingsKodeNaturområdeTypeKode]
    FOREIGN KEY ([NaturområdeTypeKode_Id])
    REFERENCES [dbo].[NaturområdeTypeKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartleggingsKodeNaturområdeTypeKode'
CREATE INDEX [IX_FK_KartleggingsKodeNaturområdeTypeKode]
ON [dbo].[KartleggingsKodeSet]
    ([NaturområdeTypeKode_Id]);
GO

-- Creating foreign key on [RødlisteVurderingsenhet_Id] in table 'RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[RødlisteKlassifiseringSet]
ADD CONSTRAINT [FK_RødlisteKlassifiseringRødlisteVurderingsenhet]
    FOREIGN KEY ([RødlisteVurderingsenhet_Id])
    REFERENCES [dbo].[RødlisteVurderingsenhetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteKlassifiseringRødlisteVurderingsenhet'
CREATE INDEX [IX_FK_RødlisteKlassifiseringRødlisteVurderingsenhet]
ON [dbo].[RødlisteKlassifiseringSet]
    ([RødlisteVurderingsenhet_Id]);
GO

-- Creating foreign key on [Beskrivelsesvariabel_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering]
ADD CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_Beskrivelsesvariabel]
    FOREIGN KEY ([Beskrivelsesvariabel_Id])
    REFERENCES [dbo].[BeskrivelsesvariabelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteKlassifisering_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering]
ADD CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifisering_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering'
CREATE INDEX [IX_FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering]
ON [dbo].[BeskrivelsesvariabelRødlisteKlassifisering]
    ([RødlisteKlassifisering_Id]);
GO

-- Creating foreign key on [KartleggingsKode_Id] in table 'KartleggingsKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering]
ADD CONSTRAINT [FK_KartleggingsKodeRødlisteKlassifisering_KartleggingsKode]
    FOREIGN KEY ([KartleggingsKode_Id])
    REFERENCES [dbo].[KartleggingsKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteKlassifisering_Id] in table 'KartleggingsKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[KartleggingsKodeRødlisteKlassifisering]
ADD CONSTRAINT [FK_KartleggingsKodeRødlisteKlassifisering_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifisering_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartleggingsKodeRødlisteKlassifisering_RødlisteKlassifisering'
CREATE INDEX [IX_FK_KartleggingsKodeRødlisteKlassifisering_RødlisteKlassifisering]
ON [dbo].[KartleggingsKodeRødlisteKlassifisering]
    ([RødlisteKlassifisering_Id]);
GO

-- Creating foreign key on [NaturområdeTypeKode_Id] in table 'RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[RødlisteKlassifiseringSet]
ADD CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering]
    FOREIGN KEY ([NaturområdeTypeKode_Id])
    REFERENCES [dbo].[NaturområdeTypeKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NaturområdeTypeKodeRødlisteKlassifisering'
CREATE INDEX [IX_FK_NaturområdeTypeKodeRødlisteKlassifisering]
ON [dbo].[RødlisteKlassifiseringSet]
    ([NaturområdeTypeKode_Id]);
GO

-- Creating foreign key on [Kriterie_Id] in table 'KriterieRødlisteVurderingsenhet'
ALTER TABLE [dbo].[KriterieRødlisteVurderingsenhet]
ADD CONSTRAINT [FK_KriterieRødlisteVurderingsenhet_Kriterie]
    FOREIGN KEY ([Kriterie_Id])
    REFERENCES [dbo].[KriterieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteVurderingsenhet_Id] in table 'KriterieRødlisteVurderingsenhet'
ALTER TABLE [dbo].[KriterieRødlisteVurderingsenhet]
ADD CONSTRAINT [FK_KriterieRødlisteVurderingsenhet_RødlisteVurderingsenhet]
    FOREIGN KEY ([RødlisteVurderingsenhet_Id])
    REFERENCES [dbo].[RødlisteVurderingsenhetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KriterieRødlisteVurderingsenhet_RødlisteVurderingsenhet'
CREATE INDEX [IX_FK_KriterieRødlisteVurderingsenhet_RødlisteVurderingsenhet]
ON [dbo].[KriterieRødlisteVurderingsenhet]
    ([RødlisteVurderingsenhet_Id]);
GO

-- Creating foreign key on [Påvirkning_Id] in table 'PåvirkningRødlisteVurderingsenhet'
ALTER TABLE [dbo].[PåvirkningRødlisteVurderingsenhet]
ADD CONSTRAINT [FK_PåvirkningRødlisteVurderingsenhet_Påvirkning]
    FOREIGN KEY ([Påvirkning_Id])
    REFERENCES [dbo].[PåvirkningSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteVurderingsenhet_Id] in table 'PåvirkningRødlisteVurderingsenhet'
ALTER TABLE [dbo].[PåvirkningRødlisteVurderingsenhet]
ADD CONSTRAINT [FK_PåvirkningRødlisteVurderingsenhet_RødlisteVurderingsenhet]
    FOREIGN KEY ([RødlisteVurderingsenhet_Id])
    REFERENCES [dbo].[RødlisteVurderingsenhetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PåvirkningRødlisteVurderingsenhet_RødlisteVurderingsenhet'
CREATE INDEX [IX_FK_PåvirkningRødlisteVurderingsenhet_RødlisteVurderingsenhet]
ON [dbo].[PåvirkningRødlisteVurderingsenhet]
    ([RødlisteVurderingsenhet_Id]);
GO

-- Creating foreign key on [RødlisteVurdeingsenhetVersjon_Id] in table 'RødlisteVurderingsenhetSet'
ALTER TABLE [dbo].[RødlisteVurderingsenhetSet]
ADD CONSTRAINT [FK_RødlisteVurdeingsenhetVersjonRødlisteVurderingsenhet]
    FOREIGN KEY ([RødlisteVurdeingsenhetVersjon_Id])
    REFERENCES [dbo].[RødlisteVurdeingsenhetVersjonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteVurdeingsenhetVersjonRødlisteVurderingsenhet'
CREATE INDEX [IX_FK_RødlisteVurdeingsenhetVersjonRødlisteVurderingsenhet]
ON [dbo].[RødlisteVurderingsenhetSet]
    ([RødlisteVurdeingsenhetVersjon_Id]);
GO

-- Creating foreign key on [Naturnivå_Id] in table 'RødlisteVurderingsenhetSet'
ALTER TABLE [dbo].[RødlisteVurderingsenhetSet]
ADD CONSTRAINT [FK_NaturnivåRødlisteVurderingsenhet]
    FOREIGN KEY ([Naturnivå_Id])
    REFERENCES [dbo].[NaturnivåSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NaturnivåRødlisteVurderingsenhet'
CREATE INDEX [IX_FK_NaturnivåRødlisteVurderingsenhet]
ON [dbo].[RødlisteVurderingsenhetSet]
    ([Naturnivå_Id]);
GO

-- Creating foreign key on [KodeVersjon_Id] in table 'NaturområdeTypeKodeSet'
ALTER TABLE [dbo].[NaturområdeTypeKodeSet]
ADD CONSTRAINT [FK_KodeVersjonNaturområdeTypeKode]
    FOREIGN KEY ([KodeVersjon_Id])
    REFERENCES [dbo].[KodeVersjonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KodeVersjonNaturområdeTypeKode'
CREATE INDEX [IX_FK_KodeVersjonNaturområdeTypeKode]
ON [dbo].[NaturområdeTypeKodeSet]
    ([KodeVersjon_Id]);
GO

-- Creating foreign key on [KodeVersjon_Id] in table 'BeskrivelsesvariabelSet'
ALTER TABLE [dbo].[BeskrivelsesvariabelSet]
ADD CONSTRAINT [FK_KodeVersjonBeskrivelsesvariabel]
    FOREIGN KEY ([KodeVersjon_Id])
    REFERENCES [dbo].[KodeVersjonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KodeVersjonBeskrivelsesvariabel'
CREATE INDEX [IX_FK_KodeVersjonBeskrivelsesvariabel]
ON [dbo].[BeskrivelsesvariabelSet]
    ([KodeVersjon_Id]);
GO

-- Creating foreign key on [InnsnevrendeBeskrivelsesvariabel_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering1'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1]
ADD CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering1_Beskrivelsesvariabel]
    FOREIGN KEY ([InnsnevrendeBeskrivelsesvariabel_Id])
    REFERENCES [dbo].[BeskrivelsesvariabelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteKlassifiseringInnsnevring_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering1'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1]
ADD CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering1_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifiseringInnsnevring_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BeskrivelsesvariabelRødlisteKlassifisering1_RødlisteKlassifisering'
CREATE INDEX [IX_FK_BeskrivelsesvariabelRødlisteKlassifisering1_RødlisteKlassifisering]
ON [dbo].[BeskrivelsesvariabelRødlisteKlassifisering1]
    ([RødlisteKlassifiseringInnsnevring_Id]);
GO

-- Creating foreign key on [RødlisteKlassifisering_Id] in table 'Naturområde_RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[Naturområde_RødlisteKlassifiseringSet]
ADD CONSTRAINT [FK_RødlisteKlassifiseringNaturområde_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifisering_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteKlassifiseringNaturområde_RødlisteKlassifisering'
CREATE INDEX [IX_FK_RødlisteKlassifiseringNaturområde_RødlisteKlassifisering]
ON [dbo].[Naturområde_RødlisteKlassifiseringSet]
    ([RødlisteKlassifisering_Id]);
GO

-- Creating foreign key on [KartleggingsKodeAggregate_Id] in table 'KartleggingsKodeSet'
ALTER TABLE [dbo].[KartleggingsKodeSet]
ADD CONSTRAINT [FK_KartleggingsKodeKartleggingsKode]
    FOREIGN KEY ([KartleggingsKodeAggregate_Id])
    REFERENCES [dbo].[KartleggingsKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartleggingsKodeKartleggingsKode'
CREATE INDEX [IX_FK_KartleggingsKodeKartleggingsKode]
ON [dbo].[KartleggingsKodeSet]
    ([KartleggingsKodeAggregate_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------