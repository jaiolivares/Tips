USE [master]
GO

/****** Object:  Database [CrudMvcApi]    Script Date: 18-06-2023 22:23:19 ******/
CREATE DATABASE [CrudMvcApi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudMvcApi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CrudMvcApi.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CrudMvcApi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CrudMvcApi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [CrudMvcApi] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudMvcApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CrudMvcApi] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CrudMvcApi] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CrudMvcApi] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CrudMvcApi] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CrudMvcApi] SET ARITHABORT OFF 
GO

ALTER DATABASE [CrudMvcApi] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CrudMvcApi] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CrudMvcApi] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CrudMvcApi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CrudMvcApi] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CrudMvcApi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CrudMvcApi] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CrudMvcApi] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CrudMvcApi] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CrudMvcApi] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CrudMvcApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CrudMvcApi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CrudMvcApi] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CrudMvcApi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CrudMvcApi] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CrudMvcApi] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CrudMvcApi] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CrudMvcApi] SET RECOVERY FULL 
GO

ALTER DATABASE [CrudMvcApi] SET  MULTI_USER 
GO

ALTER DATABASE [CrudMvcApi] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CrudMvcApi] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CrudMvcApi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [CrudMvcApi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [CrudMvcApi] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [CrudMvcApi] SET  READ_WRITE 
GO


