-- TINH HUONG: nhan vien cap nhat nhan xet
---------------------- TRAN 01
use HQT_CSDL
go

CREATE or ALTER PROC sp_updateLSX
@maNT CHAR(8),
@maNha CHAR(8),
@NX NVARCHAR(50)
AS
BEGIN
BEGIN TRAN --sp_updateLSX
	SET TRAN ISOLATION LEVEL SERIALIZABLE
	DECLARE @nxet NVARCHAR(50) = (SELECT NhanXet FROM LichSuXem 
									WHERE MaNT = @maNT and MaNha = @maNha 
											AND NgayXem = (select max(lsx.NgayXem) from LichSuXem lsx WHERE lsx.MaNT = @maNT and lsx.MaNha = @maNha) )
	IF (@nxet is not null)
		BEGIN
			SET @nxet = @nxet + @NX
		END
	ELSE
		BEGIN
			ROLLBACK TRAN
			RETURN
		END
	WAITFOR DELAY '00:00:07'
BEGIN TRY
	UPDATE LichSuXem SET NhanXet = @nxet  WHERE MaNha = @maNha and MaNT = @maNT
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

SELECT * FROM LichSuXem WHERE MaNha = @maNha and MaNT = @maNT
END
GO

------------------TRAN 02
CREATE or ALTER PROC sp_updateLSX_2
@maNT CHAR(8),
@maNha CHAR(8),
@NX NVARCHAR(50)
AS
BEGIN
	BEGIN TRAN 
	SET TRAN ISOLATION LEVEL SERIALIZABLE
	DECLARE @nxet NVARCHAR(50) = (SELECT NhanXet FROM LichSuXem WHERE MaNT = @maNT and MaNha = @maNha)
	IF (@nxet is not null)
		BEGIN
			SET @nxet = @nxet + @NX
		END
	ELSE
		BEGIN
			ROLLBACK TRAN
			RETURN
		END
	WAITFOR DELAY '00:00:07'
BEGIN TRY
	UPDATE LichSuXem SET NhanXet = @nxet  WHERE MaNha = @maNha and MaNT = @maNT
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

SELECT * FROM LichSuXem WHERE MaNha = @maNha and MaNT = @maNT
END
GO

------TEST---
EXEC sp_updateLSX_2 'NT000005', 'NHA00005', N' phòng nhỏ'
select * from LichSuXem

EXEC sp_updateLSX 'NT000005', 'NHA00005', N' hẻm ồn'
select * from LichSuXem
