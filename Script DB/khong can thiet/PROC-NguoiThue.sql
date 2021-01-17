USE HQT_CSDL
GO

--Proc Xem Nhà Thuê/Bán
CREATE PROC sp_NT_XemNhaThue
AS
BEGIN
	SELECT * FROM NhaThue WHERE TinhTrangThue = 0
END
GO

CREATE PROC sp_NT_XemNhaBan
AS
BEGIN
	SELECT * FROM NhaBan WHERE TinhTrangBan = 0
END
GO
--Proc Xem hợp đồng đã ký
CREATE PROC sp_NT_XemHopDongDaKy (@MaNT char(8))
AS
BEGIN
	SELECT * FROM HopDong WHERE MaNT = @MaNT
END
GO
--Proc Xem thông tin người thuê
CREATE PROC sp_NT_XemTTNguoiThue (@MaNT char(8))
AS
BEGIN
	SELECT * FROM NguoiThue WHERE MaNT = @MaNT
END
GO

--Proc Xem lịch sử xem nhà
CREATE PROC sp_NT_XemLSXN (@MaNT char(8))
AS
BEGIN
	SELECT * FROM LichSuXem WHERE MaNT = @MaNT
END
GO

--Proc Update thông tin cá nhân (bao gồm tiêu chí)
CREATE OR ALTER PROC sp_NT_Update
@maNT char(8),
@tenNT nvarchar(20),
@diaChi nvarchar(50),
@sdt char(10),
@tieuChi money,
@yeuCau char(8)
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_sua_NguoiThue
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
IF NOT EXISTS(SELECT * FROM NguoiThue WHERE MaNT = @maNT)
	BEGIN
	RAISERROR('Khong ton tai ma nguoi thue nay.',1,1)
	ROLLBACK TRAN sp_sua_NguoiThue
	END
ELSE
UPDATE NguoiThue SET TenNT = @tenNT, DiaChi = @diaChi, SDT = @sdt, TieuChi = @tieuChi, YeuCau = @yeuCau WHERE MaNT = @maNT
COMMIT TRAN sp_sua_NguoiThue
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Cap nhat thong tin khong thanh cong.',1,1);
END CATCH
END
GO