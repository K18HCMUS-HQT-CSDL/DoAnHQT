use HQT_CSDL
go
------------------------------------------------------PHANTOM--------------------------------------------------------------------------------------------
CREATE OR ALTER PROC sp_them_NhaThue
@maChuNha char(8),
@maNha char(8),
@soLuongPhong int,
@giaThue money,
@ngayHetHan datetime
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_them_NhaThue
	INSERT INTO NhaThue(MaNha,SoLuongPhong, GiaThue ,NgayDang, NgayHetHan, SoLuotXem, TinhTrangThue) VALUES (@maNha, @soLuongPhong ,@giaThue, GETDATE(), @ngayHetHan, 0, 1)
	IF NOT EXISTS(SELECT * FROM Nha WHERE MaNha=@maNha AND MaChuNha = @maChuNha)
BEGIN
	
	RAISERROR('Them nha khong thanh cong',16,1)
	ROLLBACK TRAN sp_them_NhaThue
END
ELSE
COMMIT TRAN sp_them_NhaBan
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them nha khong thanh cong',16,1);
END CATCH
END
GO

CREATE OR ALTER PROC sp_xem_NhaThue2
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	WAITFOR DELAY '00:00:20'
	SELECT * FROM NhaThue
COMMIT TRAN
END
GO

--TEST
INSERT INTO Nha VALUES
('NHA00016', N'8 Nguyễn Đình Chiểu', N'Quận 3', N'Phường 4', N'Hồ Chí Minh', 'NV000001', '0', 'LOAI01', 'HOST0001')

exec sp_xem_NhaThue2 
exec sp_them_NhaThue 'HOST0001', 'NHA00016', '6', '2000000000',  '2021-12-21 00:00:00'

SELECT * FROM NhaThue
GO
