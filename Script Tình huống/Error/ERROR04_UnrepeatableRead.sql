--TINH HUONG 04:UNREPEATABLE READ
--T1 (User = NhanVien): Thực hiện xem danh sách NguoiThue
--T2 (User = NguoiThue): Thực hiện cập nhật thông tin NguoiThue

-------------TRAN 1
CREATE OR ALTER PROC sp_xem_NguoiThue
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	SELECT * FROM NguoiThue
	WAITFOR DELAY '00:00:07'
	SELECT * FROM NguoiThue
COMMIT TRAN
END
GO
-------------TRAN 2
CREATE OR ALTER PROC sp_sua_NguoiThue
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
	   
    RAISERROR ('Không ton tai ma nguoi thue nay',1,1);
END CATCH
END
GO

--TEST
exec sp_xem_NguoiThue
exec sp_sua_NguoiThue 'NT000007', N'Phạm Văn Minh', '1 Vo Van Ngan, Thu Duc, Ho Chi Minh', '0839231668', '20000000', 'LOAI02  '