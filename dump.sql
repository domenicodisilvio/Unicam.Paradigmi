USE [master]
GO
/****** Object:  Database [LibreriaParadigmi]    Script Date: 19/09/2024 19:58:51 ******/
CREATE DATABASE [LibreriaParadigmi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibreriaParadigmi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibreriaParadigmi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibreriaParadigmi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibreriaParadigmi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibreriaParadigmi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibreriaParadigmi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibreriaParadigmi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibreriaParadigmi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibreriaParadigmi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibreriaParadigmi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibreriaParadigmi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET RECOVERY FULL 
GO
ALTER DATABASE [LibreriaParadigmi] SET  MULTI_USER 
GO
ALTER DATABASE [LibreriaParadigmi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibreriaParadigmi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibreriaParadigmi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibreriaParadigmi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibreriaParadigmi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibreriaParadigmi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibreriaParadigmi', N'ON'
GO
ALTER DATABASE [LibreriaParadigmi] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibreriaParadigmi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibreriaParadigmi]
GO
/****** Object:  User [paradigmi]    Script Date: 19/09/2024 19:58:51 ******/
CREATE USER [paradigmi] FOR LOGIN [paradigmi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [paradigmi]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 19/09/2024 19:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libri]    Script Date: 19/09/2024 19:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libri](
	[ISBN] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Autore] [varchar](50) NOT NULL,
	[DataDiPubblicazione] [date] NOT NULL,
	[Editore] [varchar](50) NOT NULL,
	[nomeCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Libri] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 19/09/2024 19:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libri]  WITH CHECK ADD  CONSTRAINT [FK_Libri_Categorie] FOREIGN KEY([nomeCategoria])
REFERENCES [dbo].[Categorie] ([Nome])
GO
ALTER TABLE [dbo].[Libri] CHECK CONSTRAINT [FK_Libri_Categorie]
GO
USE [master]
GO
ALTER DATABASE [LibreriaParadigmi] SET  READ_WRITE 
GO