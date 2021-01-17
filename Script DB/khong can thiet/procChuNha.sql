use HQT_CSDL
Go
CREATE or ALTER PROC sp_XemTTNhaSoHuu
@MaChuNha char(8)
AS
BEGIN
	SELECT * FROM Nha n WHERE n.MaChuNha=@MaChuNha 
END
GO

--Proc Update so phong
CREATE OR ALTER PROC sp_Update_SLPhong
@MaChuNha char(8),
@MaNha char(8),
@SLPhong int
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_Update_SLPhong
--SET TRANSACTION ISOLATION LEVEL READ COMMITTED
WAITFOR DELAY '00:00:20'
IF NOT EXISTS(SELECT * FROM Nha WHERE MaChuNha=@MaChuNha and MaNha=@MaNha)
	BEGIN
	RAISERROR('Khong ton tai ma nguoi thue nay.',1,1)
	ROLLBACK TRAN sp_Update_SLPhong
	END
ELSE
UPDATE NhaThue SET SoLuongPhong=@SLPhong where MaNha=@MaNha
COMMIT TRAN sp_Update_SLPhong
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Cap nhat thong tin khong thanh cong.',1,1);
END CATCH
END
GO
--Proc Update so phong fixed
CREATE OR ALTER PROC sp_Update_SLPhong_Fixed
@MaChuNha char(8),
@MaNha char(8),
@SLPhong int
AS
BEGIN
BEGIN TRY
BEGIN TRAN sp_Update_SLPhong_Fixed
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
WAITFOR DELAY '00:00:20'
IF NOT EXISTS(SELECT * FROM Nha WHERE MaChuNha=@MaChuNha and MaNha=@MaNha)
	BEGIN
	RAISERROR('Khong ton tai ma nguoi thue nay.',1,1)
	ROLLBACK TRAN sp_Update_SLPhong_Fixed
	END
ELSE
UPDATE NhaThue SET SoLuongPhong=@SLPhong where MaNha=@MaNha
COMMIT TRAN sp_Update_SLPhong_Fixed
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Cap nhat thong tin khong thanh cong.',1,1);
END CATCH
END
GO

grant exec on sp_XemTTNhaSoHuu to ChuNha
grant exec on sp_Update_SLPhong_Fixed to ChuNha
grant exec on sp_Update_SLPhong to ChuNha
grant exec on sp_them_NhaThue_fixed to ChuNha
grant exec on sp_them_NhaThue to ChuNha
go
