--TINH HUONG 03:
CREATE OR ALTER PROC sp_them_NhaBan
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

CREATE OR ALTER PROC sp_xem_NhaBan2
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	WAITFOR DELAY '00:00:07'
	SELECT * FROM NhaBan
COMMIT TRAN
END
GO

--TEST
INSERT INTO Nha VALUES
('NHA00016', N'8 Nguyễn Đình Chiểu', N'Quận 3', N'Phường 4', N'Hồ Chí Minh', 'NV000001', '0', 'LOAI01', 'HOST0001')

exec sp_xem_NhaBan2
exec sp_them_NhaBan 'HOST0001', 'NHA00016', '6', '2000000000', 'Dat coc truoc 20%', '2021-12-21 00:00:00'

SELECT * FROM NhaBan
GO
