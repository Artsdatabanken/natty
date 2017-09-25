
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/25/2017 13:55:39
-- Generated from EDMX file: C:\Users\japed\source\repos\RødlistedeNaturområder\Forms_dev3\RødlistedeNaturtyperKlassifisering.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RødlistedeNaturområderKlassifisering];
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
    ALTER TABLE [dbo].[NaturområdeTypeKodeSet] DROP CONSTRAINT [FK_KartleggingsKodeNaturområdeTypeKode];
GO
IF OBJECT_ID(N'[dbo].[FK_RødlisteKlassifiseringRødlisteVurderingsenhet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteKlassifiseringSet] DROP CONSTRAINT [FK_RødlisteKlassifiseringRødlisteVurderingsenhet];
GO
IF OBJECT_ID(N'[dbo].[FK_NaturområdeTypeKodeRødlisteKlassifisering_NaturområdeTypeKode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering] DROP CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering_NaturområdeTypeKode];
GO
IF OBJECT_ID(N'[dbo].[FK_NaturområdeTypeKodeRødlisteKlassifisering_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering] DROP CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering_Beskrivelsesvariabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_Beskrivelsesvariabel];
GO
IF OBJECT_ID(N'[dbo].[FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] DROP CONSTRAINT [FK_BeskrivelsesvariabelRødlisteKlassifisering_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_KriterieRødlisteKlassifisering_Kriterie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KriterieRødlisteKlassifisering] DROP CONSTRAINT [FK_KriterieRødlisteKlassifisering_Kriterie];
GO
IF OBJECT_ID(N'[dbo].[FK_KriterieRødlisteKlassifisering_RødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KriterieRødlisteKlassifisering] DROP CONSTRAINT [FK_KriterieRødlisteKlassifisering_RødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[FK_PåvirkningRødlisteKlassifisering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RødlisteKlassifiseringSet] DROP CONSTRAINT [FK_PåvirkningRødlisteKlassifisering];
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
IF OBJECT_ID(N'[dbo].[NaturområdeTypeKodeRødlisteKlassifisering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[BeskrivelsesvariabelRødlisteKlassifisering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering];
GO
IF OBJECT_ID(N'[dbo].[KriterieRødlisteKlassifisering]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KriterieRødlisteKlassifisering];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NaturområdeTypeKodeSet'
CREATE TABLE [dbo].[NaturområdeTypeKodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [versjon] nvarchar(max)  NOT NULL,
    [nivå] nvarchar(max)  NOT NULL,
    [navn] nvarchar(max)  NOT NULL,
    [KartleggingsKode_Id] int  NOT NULL
);
GO

-- Creating table 'RødlisteVurderingsenhetSet'
CREATE TABLE [dbo].[RødlisteVurderingsenhetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [tema] nvarchar(max)  NOT NULL,
    [versjon] nvarchar(max)  NOT NULL,
    [parent_Id] int  NOT NULL
);
GO

-- Creating table 'KartleggingsKodeSet'
CREATE TABLE [dbo].[KartleggingsKodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] smallint  NOT NULL,
    [nivå] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RødlisteKlassifiseringSet'
CREATE TABLE [dbo].[RødlisteKlassifiseringSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [kategori] nvarchar(max)  NOT NULL,
    [RødlisteVurderingsenhet_Id] int  NOT NULL,
    [Påvirkning_Id] int  NOT NULL,
    [parent_Id] int  NOT NULL
);
GO

-- Creating table 'BeskrivelsesvariabelSet'
CREATE TABLE [dbo].[BeskrivelsesvariabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [verdi] nvarchar(max)  NOT NULL,
    [navn] nvarchar(max)  NULL
);
GO

-- Creating table 'KriterieSet'
CREATE TABLE [dbo].[KriterieSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PåvirkningSet'
CREATE TABLE [dbo].[PåvirkningSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'NaturområdeTypeKodeRødlisteKlassifisering'
CREATE TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering] (
    [NaturområdeTypeKode_Id] int  NOT NULL,
    [RødlisteKlassifisering_Id] int  NOT NULL
);
GO

-- Creating table 'BeskrivelsesvariabelRødlisteKlassifisering'
CREATE TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering] (
    [Beskrivelsesvariabel_Id] int  NOT NULL,
    [RødlisteKlassifisering_Id] int  NOT NULL
);
GO

-- Creating table 'KriterieRødlisteKlassifisering'
CREATE TABLE [dbo].[KriterieRødlisteKlassifisering] (
    [Kriterie_Id] int  NOT NULL,
    [RødlisteKlassifisering_Id] int  NOT NULL
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

-- Creating primary key on [NaturområdeTypeKode_Id], [RødlisteKlassifisering_Id] in table 'NaturområdeTypeKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering]
ADD CONSTRAINT [PK_NaturområdeTypeKodeRødlisteKlassifisering]
    PRIMARY KEY CLUSTERED ([NaturområdeTypeKode_Id], [RødlisteKlassifisering_Id] ASC);
GO

-- Creating primary key on [Beskrivelsesvariabel_Id], [RødlisteKlassifisering_Id] in table 'BeskrivelsesvariabelRødlisteKlassifisering'
ALTER TABLE [dbo].[BeskrivelsesvariabelRødlisteKlassifisering]
ADD CONSTRAINT [PK_BeskrivelsesvariabelRødlisteKlassifisering]
    PRIMARY KEY CLUSTERED ([Beskrivelsesvariabel_Id], [RødlisteKlassifisering_Id] ASC);
GO

-- Creating primary key on [Kriterie_Id], [RødlisteKlassifisering_Id] in table 'KriterieRødlisteKlassifisering'
ALTER TABLE [dbo].[KriterieRødlisteKlassifisering]
ADD CONSTRAINT [PK_KriterieRødlisteKlassifisering]
    PRIMARY KEY CLUSTERED ([Kriterie_Id], [RødlisteKlassifisering_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [parent_Id] in table 'RødlisteVurderingsenhetSet'
ALTER TABLE [dbo].[RødlisteVurderingsenhetSet]
ADD CONSTRAINT [FK_RødlisteVurderingsenhetRødlisteVurderingsenhet]
    FOREIGN KEY ([parent_Id])
    REFERENCES [dbo].[RødlisteVurderingsenhetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteVurderingsenhetRødlisteVurderingsenhet'
CREATE INDEX [IX_FK_RødlisteVurderingsenhetRødlisteVurderingsenhet]
ON [dbo].[RødlisteVurderingsenhetSet]
    ([parent_Id]);
GO

-- Creating foreign key on [KartleggingsKode_Id] in table 'NaturområdeTypeKodeSet'
ALTER TABLE [dbo].[NaturområdeTypeKodeSet]
ADD CONSTRAINT [FK_KartleggingsKodeNaturområdeTypeKode]
    FOREIGN KEY ([KartleggingsKode_Id])
    REFERENCES [dbo].[KartleggingsKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KartleggingsKodeNaturområdeTypeKode'
CREATE INDEX [IX_FK_KartleggingsKodeNaturområdeTypeKode]
ON [dbo].[NaturområdeTypeKodeSet]
    ([KartleggingsKode_Id]);
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

-- Creating foreign key on [NaturområdeTypeKode_Id] in table 'NaturområdeTypeKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering]
ADD CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering_NaturområdeTypeKode]
    FOREIGN KEY ([NaturområdeTypeKode_Id])
    REFERENCES [dbo].[NaturområdeTypeKodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteKlassifisering_Id] in table 'NaturområdeTypeKodeRødlisteKlassifisering'
ALTER TABLE [dbo].[NaturområdeTypeKodeRødlisteKlassifisering]
ADD CONSTRAINT [FK_NaturområdeTypeKodeRødlisteKlassifisering_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifisering_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NaturområdeTypeKodeRødlisteKlassifisering_RødlisteKlassifisering'
CREATE INDEX [IX_FK_NaturområdeTypeKodeRødlisteKlassifisering_RødlisteKlassifisering]
ON [dbo].[NaturområdeTypeKodeRødlisteKlassifisering]
    ([RødlisteKlassifisering_Id]);
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

-- Creating foreign key on [Kriterie_Id] in table 'KriterieRødlisteKlassifisering'
ALTER TABLE [dbo].[KriterieRødlisteKlassifisering]
ADD CONSTRAINT [FK_KriterieRødlisteKlassifisering_Kriterie]
    FOREIGN KEY ([Kriterie_Id])
    REFERENCES [dbo].[KriterieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RødlisteKlassifisering_Id] in table 'KriterieRødlisteKlassifisering'
ALTER TABLE [dbo].[KriterieRødlisteKlassifisering]
ADD CONSTRAINT [FK_KriterieRødlisteKlassifisering_RødlisteKlassifisering]
    FOREIGN KEY ([RødlisteKlassifisering_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KriterieRødlisteKlassifisering_RødlisteKlassifisering'
CREATE INDEX [IX_FK_KriterieRødlisteKlassifisering_RødlisteKlassifisering]
ON [dbo].[KriterieRødlisteKlassifisering]
    ([RødlisteKlassifisering_Id]);
GO

-- Creating foreign key on [Påvirkning_Id] in table 'RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[RødlisteKlassifiseringSet]
ADD CONSTRAINT [FK_PåvirkningRødlisteKlassifisering]
    FOREIGN KEY ([Påvirkning_Id])
    REFERENCES [dbo].[PåvirkningSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PåvirkningRødlisteKlassifisering'
CREATE INDEX [IX_FK_PåvirkningRødlisteKlassifisering]
ON [dbo].[RødlisteKlassifiseringSet]
    ([Påvirkning_Id]);
GO

-- Creating foreign key on [parent_Id] in table 'RødlisteKlassifiseringSet'
ALTER TABLE [dbo].[RødlisteKlassifiseringSet]
ADD CONSTRAINT [FK_RødlisteKlassifiseringRødlisteKlassifisering]
    FOREIGN KEY ([parent_Id])
    REFERENCES [dbo].[RødlisteKlassifiseringSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RødlisteKlassifiseringRødlisteKlassifisering'
CREATE INDEX [IX_FK_RødlisteKlassifiseringRødlisteKlassifisering]
ON [dbo].[RødlisteKlassifiseringSet]
    ([parent_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------