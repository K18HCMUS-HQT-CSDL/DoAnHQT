-- ERROR01
-----------------------------------------
--TINH HUONG 01:DIRTY READ
--T1 (User = NhanVien): Thực hiện thêm một hợp đồng (NV có mã là ‘NV000006’)
--T2 (User = NguoiThue): Thực hiện thống kê NhaBan 

----------------TRAN 01
create OR alter proc sp_them_HDNhaBan
@maNV char(8),
@maHD char(8),
@maNha char(8),
@maNT char(8)
as
begin
begin try
BEGIN TRAN sp_them_HDNhaBan
update NhaBan set TinhTrangBan = 0 where MaNha=@maNha
insert into HopDong(MaHD,LoaiHD,ThoiGian,MaNT,MaNha) values (@maHD,0,GETDATE(),@maNT,@maNha)
waitfor delay '00:00:07'
if not exists(select * from NhaBan where MaNha=@maNha) or not exists(select * from NguoiThue where MaNT=@maNT) or not exists(select * from Nha where MaNha=@maNha and MaNV=@maNV)
begin
	
	RAISERROR('Them hop dong khong thanh cong',16,1)
	ROLLBACK TRAN sp_them_HDNhaBan
end
else
COMMIT TRAN sp_them_HDNhaBan
end try
begin catch
waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them hop dong khong thanh cong',16,1);
end catch
end
GO

----------------TRAN 02
create OR alter proc sp_xem_NhaBan
as
begin
begin tran
set transaction isolation level read uncommitted
select * from NhaBan
commit tran
end
GO


-- ERROR02
-----------------------------------------
--TINH HUONG 02: LOST UPDATE
--T1 (User = NhanVienQuanLy): Thực hiện tăng lương của 1 nhân viên trong chi nhánh lên 5tr
--T2 (User = CEO): Thực hiện tăng hệ số lương của 1 chi nhánh


----------------TRAN 01
create OR alter proc sp_tang_Luong_nhanvien
@maNV char(8),
@maCN char(8),
@Luong money
as
begin

set transaction isolation level read committed
begin try
BEGIN TRAN sp_capnhat_Luong_nhanvien
declare @setluong money
select @setluong=Luong from NhanVien where MaNV=@maNV

waitfor delay '00:00:07'
set @setluong=@setluong+@Luong
update NhanVien set Luong = @setluong where MaNV=@maNV 

if not exists(select * from NhanVien where MaNV=@maNV and MaCN=@maCN) 
begin
	
	RAISERROR('Thong tin khong hop le',16,1)
	ROLLBACK TRAN sp_capnhat_Luong_nhanvien
end
else
COMMIT TRAN sp_capnhat_Luong_nhanvien
end try
begin catch
waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_capnhat_Luong_nhanvien
	   
end catch
select * from NhanVien where MaCN=@maCN
end
GO

----------------TRAN 02
create OR alter proc sp_tang_luong_theochinhanh
@maCN char(8),
@hesoLuong float
as
begin
begin try
BEGIN TRAN sp_tang_luong_theochinhanh
update NhanVien set Luong = Luong*@hesoLuong where MaCN=@maCN

waitfor delay '00:00:07'
if not exists(select * from NhanVien where MaCN=@maCN) 
begin
	
	RAISERROR('Ma Chi nhanh khong hop le',16,1)
	ROLLBACK TRAN sp_tang_luong_theochinhanh
end
else
COMMIT TRAN sp_tang_luong_theochinhanh
end try
begin catch
waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_tang_luong_theochinhanh
	   
end catch
select * from NhanVien where MaCN=@maCN
end
GO



-- ERROR03
-----------------------------------------
--TINH HUONG 03: PHANTOM
--T1 (User = NguoiThue): Thực hiện xem danh sách Nhà Bán
--T2 (User = ChuNha): Thực hiện thêm NhaBan 

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
	
	RAISERROR('Them nha ban khong thanh cong',16,1)
	ROLLBACK TRAN sp_them_NhaBan
END
ELSE
COMMIT TRAN sp_them_NhaBan
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them nha ban khong thanh cong',16,1);
END CATCH
END
GO

CREATE OR ALTER PROC sp_xem_NhaBan
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SELECT * FROM NhaBan
	WAITFOR DELAY '00:00:07'
COMMIT TRAN
END
GO



-- ERROR04
-----------------------------------------
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
	RAISERROR('Khong ton tai ma nguoi thue nay.',16,1)
	ROLLBACK TRAN sp_sua_NguoiThue
	END
ELSE
UPDATE NguoiThue SET TenNT = @tenNT, DiaChi = @diaChi, SDT = @sdt, TieuChi = @tieuChi, YeuCau = @yeuCau WHERE MaNT = @maNT
COMMIT TRAN sp_sua_NguoiThue
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Không ton tai ma nguoi thue nay',16,1);
END CATCH
END
GO


-- ERROR05
-----------------------------------------
--ERR05: Dirty read
--T1 (User = CEO): thực hiện update chi nhánh và nhân viên quản lý cho 1 nhân viên
--T2 (User = QLCN): thực hiện thống kê nhân viên tại các chi nhánh

----STORE PROC T01
--User: CEO
--Proc: Chuyển Nhân viên sang chi nhánh khác và đồng thời chỉ đạo 1 nhân viên quản lý mới cho nhân viên đó
create or alter proc ChuyenNV
@manv as char(8),
@mcn as char(8),
@mql as char(8)
as
begin
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
begin tran sp_ChuyenNV_uncommited
--select * from NhanVien where MaNV=@manv
--select * from ChiNhanh where MaCN=@mcn
update NhanVien
set MaCN=@mcn
where MaNV=@manv
waitfor delay '00:00:10'
if(not exists(select * from ChiNhanh where MaCN=@mcn) or not exists(select * from NhanVien where MaNV=@manv))
begin
RAISERROR('Chuyen nhan vien khong thanh cong',16,1)
ROLLBACK TRAN sp_ChuyenNV_uncommited
end
else
update NhanVien
set MaQuanLy=@mql
where MaNV=@manv
select * from NhanVien where MaNV=@manv
--waitfor delay '00:00:05'
commit TRAN sp_ChuyenNV_uncommited
end
go

----STORE PROC 02
--User: QLCN
--Proc: Thống kê nhan vien trong cac chi nhanh
create or alter proc XemNV_uncommited
as
begin
SET TRANSACTION ISOLATION LEVEL read unCOMMITTED
begin tran
select * from NhanVien
commit tran
end
go


-- ERROR06
--ERR06: Lost Update
--T1 (User = Nhân viên): thực hiện update số phòng sau khi hợp đồng thành công
--T2 (User = Chủ nhà): thực hiện update số phòng còn lại mới

-------------------------------TRAN 01
--User: NhanVien
--Proc: Sau khi thêm 1 hợp đồng liên quan tới thuê phòng, cập nhập lại ngay số phòng hiện có
create or alter proc CapNhapSauHopDong_Error
@mhd as char(8)
as
begin
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
begin tran sp_CapNhapSau
declare @temp INT
DECLARE @manha CHAR(8)
SELECT @manha=(SELECT DISTINCT MaNha FROM dbo.HopDong WHERE @mhd=MaHD)
select @temp=SoLuongPhong from NhaThue where MaNha=@manha
if(not exists(select * from HopDong where MaHD=@mhd) or not exists(select* from NhaThue where MaNha=@manha))
begin
RAISERROR('Cap nhap phong khong thanh cong',1,1)
ROLLBACK TRAN sp_CapNhapSau
end
else
waitfor delay '00:00:10'
update NhaThue
set SoLuongPhong=@temp-1
where MaNha=@manha
select * from NhaThue where MaNha=@manha
commit tran sp_CapNhapSau
end
go

-------------------------------TRAN 02
--User: ChuNha
--Proc: Khi có xây thêm phòng hay khách cũ trả phòng, chủ nhà cập nhập lại số phòng
create or alter proc CapNhapPhong_Error
@manha as char(8),
@spt as int
as
begin
SET TRANSACTION ISOLATION LEVEL READ unCOMMITTED
begin tran sp_CapNhap
declare @temp int
select @temp=SoLuongPhong from NhaThue where MaNha=@manha
if(not exists(select* from NhaThue where MaNha=@manha))
begin
RAISERROR('Chuyen nhan vien khong thanh cong',1,1)
ROLLBACK TRAN sp_CapNhap
end
else
--waitfor delay '00:00:05'
update NhaThue
set SoLuongPhong=@temp+@spt
where MaNha=@manha
select * from NhaThue where MaNha=@manha
commit tran sp_CapNhap
end
go

-------------------------------TRAN 02
--User: ChuNha
--Proc: Khi có xây thêm phòng hay khách cũ trả phòng, chủ nhà cập nhập lại số phòng
create or alter proc CapNhapPhong
@manha as char(8),
@spt as int
as
begin
SET TRANSACTION ISOLATION LEVEL READ unCOMMITTED
begin tran sp_CapNhap
declare @temp int
select @temp=SoLuongPhong from NhaThue where MaNha=@manha
if(not exists(select* from NhaThue where MaNha=@manha))
begin
RAISERROR('Chuyen nhan vien khong thanh cong',16,1)
ROLLBACK TRAN sp_CapNhap
end
else
--waitfor delay '00:00:05'
update NhaThue
set SoLuongPhong=@temp+@spt
where MaNha=@manha
select * from NhaThue where MaNha=@manha
commit tran sp_CapNhap
end
go


-- ERROR07
-----------------------------------------
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



-- ERROR08
-----------------------------------------
-------------------------------------------------------------Unrepeateale read-------------------------------------------------------------------
--T1 (User = Nhân viên): thực hiện thống kê Người thuê nhà thuộc chi nhánh
--T2 (User = người thuê): người thuê NT000001 thực hiện update thông tin của mình

------TRAN 01
create OR alter proc sp_xem_NguoiThue_er8
@MaCN varchar(8)
as
begin
begin tran
set transaction isolation level read committed
WAITFOR DELAY '00:00:20'
select * from NguoiThue where MaCN=@MaCN
commit tran
end
GO

------TRAN 02
create OR alter proc sp_update_NguoiThue_er8
@maNT char(8),
@TenNT nvarchar(20)
as
begin
begin tran
set transaction isolation level read committed
begin try
BEGIN TRAN sp_update_NguoiThue
select MaNT from NguoiThue where MaNT=@maNT
waitfor delay '00:00:20'
update NguoiThue set TenNT = @TenNT where MaNT=@maNT
if not exists(select * from NguoiThue where MaNT=@maNT) 
begin
	
	RAISERROR('Thong tin khong hop le',16,1)
	ROLLBACK TRAN sp_update_NguoiThue
end
else
COMMIT TRAN sp_update_NguoiThue
end try
begin catch
waitfor delay '00:00:20'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_update_NguoiThue
	   
end catch
commit tran
end
GO



-- ERROR09
-----------------------------------------
-- TINH HUONG: nhan vien cap nhat nhan xet
---------------------- TRAN 01

CREATE or ALTER PROC sp_updateLSX
@maNT CHAR(8),
@maNha CHAR(8),
@NX NVARCHAR(50)
AS
BEGIN
BEGIN TRAN --sp_updateLSX
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



-- ERROR10
-----------------------------------------
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