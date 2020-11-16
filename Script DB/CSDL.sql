/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 15.2 		*/
/*  Created On : 09-Nov-2020 4:37:07 PM 				*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

create database HQT_CSDL
go

use HQT_CSDL

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ChiNhanh_NhanVien]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ChiNhanh] DROP CONSTRAINT [FK_ChiNhanh_NhanVien]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_HopDong_NguoiThue]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [HopDong] DROP CONSTRAINT [FK_HopDong_NguoiThue]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_HopDong_Nha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [HopDong] DROP CONSTRAINT [FK_HopDong_Nha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_LichSuXem_NguoiThue]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [LichSuXem] DROP CONSTRAINT [FK_LichSuXem_NguoiThue]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_LichSuXem_Nha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [LichSuXem] DROP CONSTRAINT [FK_LichSuXem_Nha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NguoiThue_ChiNhanh]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NguoiThue] DROP CONSTRAINT [FK_NguoiThue_ChiNhanh]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NguoiThue_LoaiNha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NguoiThue] DROP CONSTRAINT [FK_NguoiThue_LoaiNha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Nha_ChuNha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Nha] DROP CONSTRAINT [FK_Nha_ChuNha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Nha_LoaiNha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Nha] DROP CONSTRAINT [FK_Nha_LoaiNha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Nha_NhanVien]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Nha] DROP CONSTRAINT [FK_Nha_NhanVien]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NhaBan_Nha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NhaBan] DROP CONSTRAINT [FK_NhaBan_Nha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NhanVien_ChiNhanh]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NhanVien] DROP CONSTRAINT [FK_NhanVien_ChiNhanh]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NhanVien_NhanVien]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NhanVien] DROP CONSTRAINT [FK_NhanVien_NhanVien]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_NhaThue_Nha]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [NhaThue] DROP CONSTRAINT [FK_NhaThue_Nha]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ChiNhanh]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ChiNhanh]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ChuNha]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ChuNha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[HopDong]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [HopDong]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[LichSuXem]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [LichSuXem]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[LoaiNha]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [LoaiNha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[NguoiThue]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [NguoiThue]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Nha]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Nha]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[NhaBan]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [NhaBan]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[NhanVien]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [NhanVien]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[NhaThue]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [NhaThue]
GO

/* Create Tables */

CREATE TABLE [ChiNhanh]
(
	[MaCN] char(8) NOT NULL,
	[TenDuong] nvarchar(20) NOT NULL,
	[TenQuan] nvarchar(20) NOT NULL,
	[TenKhuVuc] nvarchar(20) NOT NULL,
	[TenTP] nvarchar(20) NOT NULL,
	[SDT] char(10) NOT NULL,
	[FAX] varchar(10) NOT NULL,
	[MaNV] char(8) NULL
)
GO

CREATE TABLE [ChuNha]
(
	[MaChuNha] char(8) NOT NULL,
	[TenChuNha] nvarchar(20) NOT NULL,
	[DiaChi] nvarchar(50) NOT NULL,
	[SDT] char(10) NULL
)
GO

CREATE TABLE [HopDong]
(
	[MaHD] char(8) NOT NULL,
	[LoaiHD] bit NOT NULL,
	[ThoiGian] datetime NOT NULL,
	[MaNT] char(8) NULL,
	[MaNha] char(8) NULL
)
GO

CREATE TABLE [LichSuXem]
(
	[MaNha] char(8) NOT NULL,
	[MaNT] char(8) NOT NULL,
	[NgayXem] datetime NOT NULL,
	[NhanXet] text NOT NULL
)
GO

CREATE TABLE [LoaiNha]
(
	[MaLoai] char(8) NOT NULL,
	[TenLoai] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [NguoiThue]
(
	[MaNT] char(8) NOT NULL,
	[TenNT] nvarchar(20) NOT NULL,
	[DiaChi] nvarchar(50) NOT NULL,
	[SDT] char(10) NOT NULL,
	[TieuChi] money NOT NULL,
	[MaCN] char(8) NULL,
	[YeuCau] char(8) NULL
)
GO

CREATE TABLE [Nha]
(
	[MaNha] char(8) NOT NULL,
	[TenDuong] nvarchar(20) NOT NULL,
	[TenQuan] nvarchar(20) NOT NULL,
	[TenKV] nvarchar(20) NOT NULL,
	[TenTP] nvarchar(20) NOT NULL,
	[MaNV] char(8) NULL,
	[LoaiGiaoDich] bit NULL,
	[MaLoai] char(8) NULL,
	[MaChuNha] char(8) NULL
)
GO

CREATE TABLE [NhaBan]
(
	[GiaBan] money NOT NULL,
	[DieuKien] text NOT NULL,
	[MaNha] char(8) NOT NULL,
	[SoLuongPhong] int NOT NULL,
	[NgayDang] datetime NOT NULL,
	[NgayHetHan] datetime NOT NULL,
	[SoLuotXem] int NULL DEFAULT 0,
	[TinhTrangBan] bit NOT NULL
)
GO

CREATE TABLE [NhanVien]
(
	[MaNV] char(8) NOT NULL,
	[TenNV] nvarchar(20) NOT NULL,
	[DiaChi] nvarchar(50) NOT NULL,
	[SDT] char(10) NOT NULL,
	[GioiTinh] tinyint NOT NULL,
	[NgaySinh] datetime NOT NULL,
	[Luong] money NULL,
	[MaCN] char(8) NULL,
	[MaQuanLy] char(8) NOT NULL,
	[TinhTrang] bit NULL
)
GO

CREATE TABLE [NhaThue]
(
	[GiaThue] money NOT NULL,
	[MaNha] char(8) NOT NULL,
	[SoLuongPhong] int NOT NULL,
	[NgayDang] datetime NOT NULL,
	[NgayHetHan] datetime NOT NULL,
	[SoLuotXem] int NULL DEFAULT 0,
	[TinhTrangThue] bit NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [ChiNhanh] 
 ADD CONSTRAINT [PK_ChiNhanh]
	PRIMARY KEY CLUSTERED ([MaCN] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ChiNhanh_NhanVien] 
 ON [ChiNhanh] ([MaNV] ASC)
GO

ALTER TABLE [ChuNha] 
 ADD CONSTRAINT [PK_ChuNha]
	PRIMARY KEY CLUSTERED ([MaChuNha] ASC)
GO

ALTER TABLE [HopDong] 
 ADD CONSTRAINT [PK_HopDong]
	PRIMARY KEY CLUSTERED ([MaHD] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_HopDong_NguoiThue] 
 ON [HopDong] ([MaNT] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_HopDong_Nha] 
 ON [HopDong] ([MaNha] ASC)
GO

ALTER TABLE [LichSuXem] 
 ADD CONSTRAINT [PK_LichSuXem]
	PRIMARY KEY CLUSTERED ([MaNha] ASC,[MaNT] ASC,[NgayXem] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_LichSuXem_NguoiThue] 
 ON [LichSuXem] ([MaNT] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_LichSuXem_Nha] 
 ON [LichSuXem] ([MaNha] ASC)
GO

ALTER TABLE [LoaiNha] 
 ADD CONSTRAINT [PK_LoaiNha]
	PRIMARY KEY CLUSTERED ([MaLoai] ASC)
GO

ALTER TABLE [NguoiThue] 
 ADD CONSTRAINT [PK_NguoiThue]
	PRIMARY KEY CLUSTERED ([MaNT] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NguoiThue_ChiNhanh] 
 ON [NguoiThue] ([MaCN] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NguoiThue_LoaiNha] 
 ON [NguoiThue] ([YeuCau] ASC)
GO

ALTER TABLE [Nha] 
 ADD CONSTRAINT [PK_Nha]
	PRIMARY KEY CLUSTERED ([MaNha] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Nha_ChuNha] 
 ON [Nha] ([MaChuNha] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Nha_LoaiNha] 
 ON [Nha] ([MaLoai] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Nha_NhanVien] 
 ON [Nha] ([MaNV] ASC)
GO

ALTER TABLE [NhaBan] 
 ADD CONSTRAINT [PK_NhaBan]
	PRIMARY KEY CLUSTERED ([MaNha] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NhaBan_Nha] 
 ON [NhaBan] ([MaNha] ASC)
GO

ALTER TABLE [NhanVien] 
 ADD CONSTRAINT [PK_NhanVien]
	PRIMARY KEY CLUSTERED ([MaNV] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NhanVien_ChiNhanh] 
 ON [NhanVien] ([MaCN] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NhanVien_NhanVien] 
 ON [NhanVien] ([MaQuanLy] ASC)
GO

ALTER TABLE [NhaThue] 
 ADD CONSTRAINT [PK_NhaThue]
	PRIMARY KEY CLUSTERED ([MaNha] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_NhaThue_Nha] 
 ON [NhaThue] ([MaNha] ASC)
GO

/* Create Foreign Key Constraints */

ALTER TABLE [ChiNhanh] ADD CONSTRAINT [FK_ChiNhanh_NhanVien]
	FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [HopDong] ADD CONSTRAINT [FK_HopDong_NguoiThue]
	FOREIGN KEY ([MaNT]) REFERENCES [NguoiThue] ([MaNT]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [HopDong] ADD CONSTRAINT [FK_HopDong_Nha]
	FOREIGN KEY ([MaNha]) REFERENCES [Nha] ([MaNha]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [LichSuXem] ADD CONSTRAINT [FK_LichSuXem_NguoiThue]
	FOREIGN KEY ([MaNT]) REFERENCES [NguoiThue] ([MaNT]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [LichSuXem] ADD CONSTRAINT [FK_LichSuXem_Nha]
	FOREIGN KEY ([MaNha]) REFERENCES [Nha] ([MaNha]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NguoiThue] ADD CONSTRAINT [FK_NguoiThue_ChiNhanh]
	FOREIGN KEY ([MaCN]) REFERENCES [ChiNhanh] ([MaCN]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NguoiThue] ADD CONSTRAINT [FK_NguoiThue_LoaiNha]
	FOREIGN KEY ([YeuCau]) REFERENCES [LoaiNha] ([MaLoai]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Nha] ADD CONSTRAINT [FK_Nha_ChuNha]
	FOREIGN KEY ([MaChuNha]) REFERENCES [ChuNha] ([MaChuNha]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Nha] ADD CONSTRAINT [FK_Nha_LoaiNha]
	FOREIGN KEY ([MaLoai]) REFERENCES [LoaiNha] ([MaLoai]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Nha] ADD CONSTRAINT [FK_Nha_NhanVien]
	FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NhaBan] ADD CONSTRAINT [FK_NhaBan_Nha]
	FOREIGN KEY ([MaNha]) REFERENCES [Nha] ([MaNha]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NhanVien] ADD CONSTRAINT [FK_NhanVien_ChiNhanh]
	FOREIGN KEY ([MaCN]) REFERENCES [ChiNhanh] ([MaCN]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NhanVien] ADD CONSTRAINT [FK_NhanVien_NhanVien]
	FOREIGN KEY ([MaQuanLy]) REFERENCES [NhanVien] ([MaNV]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [NhaThue] ADD CONSTRAINT [FK_NhaThue_Nha]
	FOREIGN KEY ([MaNha]) REFERENCES [Nha] ([MaNha]) ON DELETE No Action ON UPDATE No Action
GO
