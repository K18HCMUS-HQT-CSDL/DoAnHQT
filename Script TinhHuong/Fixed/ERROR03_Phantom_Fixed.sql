--TINH HUONG 03: Phantom
--T1 (User = NguoiThue): Thực hiện xem danh sách nhà
--T2 (User = ChuNha): Thực hiện thêm NhaBan 

----------------TRAN 01
CREATE OR ALTER PROC sp_them_NhaBan_Fixed
@maChuNha char(8),
@maNha char(8),
@soLuongPhong int,
@giaBan money,
@dieuKien text,
@ngayHetHan datetime
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_them_NhaBan
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	INSERT INTO NhaBan(MaNha,SoLuongPhong,GiaBan,DieuKien,NgayDang, NgayHetHan, SoLuotXem, TinhTrangBan) VALUES (@maNha, @soLuongPhong ,@giaBan, @dieuKien, GETDATE(), @ngayHetHan, 0, 1)
	IF NOT EXISTS(SELECT * FROM Nha WHERE MaNha=@maNha AND MaChuNha = @maChuNha)
BEGIN
	
	RAISERROR('Them nha ban khong thanh cong',1,1)
	ROLLBACK TRAN sp_them_NhaBan
END
ELSE
COMMIT TRAN sp_them_NhaBan
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them nha ban khong thanh cong',1,1);
END CATCH
END
GO

----------------TRAN 02
CREATE OR ALTER PROC sp_xem_NhaBan_er3_Fixed
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	SELECT * FROM NhaBan
	WAITFOR DELAY '00:00:07'
	SELECT * FROM NhaBan
COMMIT TRAN
END
GO

--TEST
--INSERT INTO Nha VALUES ('NHA00016', N'8 Nguyễn Đình Chiểu', N'Quận 3', N'Phường 4', N'Hồ Chí Minh', 'NV000001', '0', 'LOAI01', 'HOST0001')


--exec sp_xem_NhaBan
--exec sp_them_NhaBan 'HOST0001', 'NHA00016', '6', '2000000000', 'Dat coc truoc 20%', '2021-12-21 00:00:00'

--GO
