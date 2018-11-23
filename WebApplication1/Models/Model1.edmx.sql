
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2018 13:47:23
-- Generated from EDMX file: c:\users\student\source\repos\WebApplication\WebApplication1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [coffeedb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CoffeDate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoffeDate];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CoffeDates'
CREATE TABLE [dbo].[CoffeDates] (
    [Id] int  NOT NULL,
    [Time] nvarchar(100)  NULL,
    [Passed] int  NULL,
    [ShoutId] nvarchar(100)  NULL,
    [ShoutPrice] nvarchar(100)  NULL,
    [Venue] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CoffeDates'
ALTER TABLE [dbo].[CoffeDates]
ADD CONSTRAINT [PK_CoffeDates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------