------------------------------------------------------PHANTOM---------------------------------------------------------------------------------------------T1 (User = ngườithue): thực hiện thống kê nhà thuê 
--T1 (User = NguoiThue): xem nha thuê 
--T2 (User = chủ nhà): them 1 nha thuê 

------TRAN 01
CREATE OR ALTER PROC sp_xem_NhaThue
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	WAITFOR DELAY '00:00:20'
	SELECT * FROM NhaThue
COMMIT TRAN
END
GO
------TRAN 02
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


--TEST
INSERT INTO Nha VALUES
('NHA00016', N'8 Nguyễn Đình Chiểu', N'Quận 3', N'Phường 4', N'Hồ Chí Minh', 'NV000001', '0', 'LOAI01', 'HOST0001')

exec sp_xem_NhaThue 
exec sp_them_NhaThue 'HOST0001', 'NHA00016', '6', '2000000000',  '2021-12-21 00:00:00'

SELECT * FROM NhaThue
GO
