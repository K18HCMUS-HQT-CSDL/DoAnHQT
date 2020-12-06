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
CREATE PROC sp_NT_Update (@MaNT char(8), @TenNT nvarchar(20), @DiaChi nvarchar(50), @SDT char(10), @TieuChi money, @LoaiNhaYeuCau char(8))
AS
BEGIN
	UPDATE NguoiThue
	SET TenNT = @TenNT, DiaChi = @DiaChi, SDT = @SDT, TieuChi = @TieuChi, YeuCau = @LoaiNhaYeuCau
	WHERE MaNT = @MaNT
END
GO
