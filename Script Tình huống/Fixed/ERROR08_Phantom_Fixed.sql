------------------------------------------------------PHANTOM--------------------------------------------------------------------------------------------
--Tình huống 08: Phantom
--T1 (User = ngườithue): thực hiện thống kê nhà thuê 
--T2 (User = chủ nhà): thêm 1 nha thuê 


-------------------TRAN 01
CREATE OR ALTER PROC sp_xem_NhaThue2_fixed
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEl SERIALIZABLE
	WAITFOR DELAY '00:00:20'
	SELECT * FROM NhaThue
COMMIT TRAN
END
GO
---------------TRAN 02
CREATE OR ALTER PROC sp_them_NhaThue_fixed
@maChuNha char(8),
@maNha char(8),
@soLuongPhong int,
@giaThue money,
@ngayHetHan datetime
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_them_NhaThue_fixed
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	INSERT INTO NhaThue(MaNha,SoLuongPhong, GiaThue ,NgayDang, NgayHetHan, SoLuotXem, TinhTrangThue) VALUES (@maNha, @soLuongPhong ,@giaThue, GETDATE(), @ngayHetHan, 0, 1)
	IF NOT EXISTS(SELECT * FROM Nha WHERE MaNha=@maNha AND MaChuNha = @maChuNha)
BEGIN
	
	RAISERROR('Them nha khong thanh cong',1,1)
	ROLLBACK TRAN sp_them_NhaThue_fixed
END
ELSE
COMMIT TRAN sp_them_NhaThue_fixed
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them nha khong thanh cong',1,1);
END CATCH
END
GO

--TEST
INSERT INTO Nha VALUES
('NHA00021', N'21 Nguyễn Đình Chiểu', N'Quận 3', N'Phường 4', N'Hồ Chí Minh', 'NV000001', '0', 'LOAI01', 'HOST0010')

exec sp_xem_NhaThue2_fixed
exec sp_them_NhaThue_fixed 'HOST0010', 'NHA00021', '5', '2000000000',  '2021-12-21 00:00:00'

--SELECT * FROM NhaThue
GO
