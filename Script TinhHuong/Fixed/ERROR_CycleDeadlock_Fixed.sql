-- TINH HUONG: ca hai nhan vien deu giao dich nha ban
-------------TRAN 01
CREATE or ALTER PROC sp_them_HDnhaban_DL
@maHD CHAR(8),
@maNT CHAR(8),
@maNha CHAR(8)
AS

BEGIN

BEGIN TRAN
	--BEGIN TRAN sp_them_HDnhaban_DL
	SET TRAN ISOLATION LEVEL READ COMMITTED
	DECLARE @tt BIT
	IF NOT EXISTS (SELECT * FROM NhaBan WHERE MaNha = @maNha) --or EXISTS (SELECT * FROM NhaBan WHERE MaNha = @maNha and TinhTrangBan = '0')
	or NOT EXISTS (SELECT * FROM NguoiThue WHERE MaNT = @maNT)
		BEGIN
		ROLLBACK TRAN
			RETURN
		END
	ELSE
		BEGIN
			INSERT INTO HopDong (MaHD, LoaiHD, ThoiGian, MaNT, MaNha) VALUES (@maHD, 0, GETDATE(), @maNT, @maNha)
			SET @tt = '0'
		END
	WAITFOR DELAY '00:00:07'

BEGIN TRY
	UPDATE NhaBan SET TinhTrangBan = @tt WHERE MaNha = @maNha
END TRY

BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);  
			DECLARE @ErrorSeverity INT;  
			DECLARE @ErrorState INT;  
			SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  
    
			RAISERROR 
				(@ErrorMessage, -- Message text.  
				@ErrorSeverity, -- Severity.  
				@ErrorState -- State.  
				);

			IF @@TRANCOUNT > 0
				ROLLBACK TRAN
END CATCH
IF @@TRANCOUNT > 0
	COMMIT TRAN

SELECT * FROM NhaBan WHERE @maNha = MaNha
SELECT * FROM HopDong WHERE @maHD = MaHD
END

GO

--------------------------------- TRAN 02
CREATE or ALTER PROC sp_them_HDnhaban_DL_2
@maHD CHAR(8),
@maNT CHAR(8),
@maNha CHAR(8)
AS

BEGIN

BEGIN TRAN
	--BEGIN TRAN sp_them_HDnhaban_DL
	SET TRAN ISOLATION LEVEL READCOMMITED
	DECLARE @tt BIT
	IF NOT EXISTS (SELECT * FROM NhaBan WHERE MaNha = @maNha) --or EXISTS (SELECT * FROM NhaBan WHERE MaNha = @maNha and TinhTrangBan = '0')
	or NOT EXISTS (SELECT * FROM NguoiThue WHERE MaNT = @maNT)
		BEGIN
		ROLLBACK TRAN
			RETURN
		END
	ELSE
		BEGIN
			SET @tt = '0'
			UPDATE NhaBan SET TinhTrangBan = @tt WHERE MaNha = @maNha
			
		END
	WAITFOR DELAY '00:00:07'

BEGIN TRY
		INSERT INTO HopDong (MaHD, LoaiHD, ThoiGian, MaNT, MaNha) VALUES (@maHD, 0, GETDATE(), @maNT, @maNha)
END TRY

BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);  
			DECLARE @ErrorSeverity INT;  
			DECLARE @ErrorState INT;  
			SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE();  
    
			RAISERROR 
				(@ErrorMessage, -- Message text.  
				@ErrorSeverity, -- Severity.  
				@ErrorState -- State.  
				);

			IF @@TRANCOUNT > 0
				ROLLBACK TRAN
END CATCH
IF @@TRANCOUNT > 0
	COMMIT TRAN

SELECT * FROM NhaBan WHERE @maNha = MaNha
SELECT * FROM HopDong WHERE @maHD = MaHD
END

GO

-----TEST
EXEC sp_them_HDnhaban_DL 'HD000009', 'NT000001', 'NHA00006'
EXEC sp_them_HDnhaban_DL_2 'HD0000010', 'NT000001', 'NHA00006'
--select * from HopDong
--select * from NguoiThue

