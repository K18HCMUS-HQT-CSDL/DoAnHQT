-- ERROR01
-----------------------------------------
--TINH HUONG 01:DIRTY READ_fixed
--T1 (User = NhanVien): Thực hiện thêm một hợp đồng 
--T2 (User = NguoiThue): Thực hiện thống kê NhaBan 

-----------------------------TRANS 01
create OR alter proc sp_them_HDNhaBan_Fixed
@maNV char(8),
@maHD char(8),
@maNha char(8),
@maNT char(8)
as
begin
begin try
BEGIN TRAN sp_them_HDNhaBan_Fixed
update NhaBan set TinhTrangBan = 0 where MaNha=@maNha
insert into HopDong(MaHD,LoaiHD,ThoiGian,MaNT,MaNha) values (@maHD,0,GETDATE(),@maNT,@maNha)
waitfor delay '00:00:07'
if not exists(select * from NhaBan where MaNha=@maNha) or not exists(select * from NguoiThue where MaNT=@maNT) or not exists(select * from Nha where MaNha=@maNha and MaNV=@maNV)
begin
	
	RAISERROR('Them hop dong khong thanh cong',16,1)
	ROLLBACK TRAN sp_them_HDNhaBan_Fixed
end
else
COMMIT TRAN sp_them_HDNhaBan_Fixed
end try
begin catch
waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN
	   
    RAISERROR ('Them hop dong khong thanh cong',16,1);
end catch
end
GO


-----------------------------TRANS 02
create OR alter proc sp_xem_NhaBan_Fixed
as
begin
begin tran sp_xem_NhaBan_Fixed
set transaction isolation level read committed
select * from NhaBan
commit tran sp_xem_NhaBan_Fixed
end
GO



-- ERROR02
-----------------------------------------
--TINH HUONG 02: LOST UPDATE
--T1 (User = NhanVienQuanLy): Thực hiện tăng lương của 1 nhân viên trong chi nhánh lên 5tr
--T2 (User = CEO): Thực hiện tăng hệ số lương của 1 chi nhánh

------------------------------ TRANS 01
create or alter proc sp_tang_Luong_nhanvien_Fixed
@maNV char(8),
@maCN char(8),
@Luong money
as
begin

begin try
set transaction isolation level repeatable read
BEGIN TRAN sp_capnhat_Luong_nhanvien_Fixed

declare @setluong money
select @setluong=Luong from NhanVien with (UPDLOCK) where MaNV=@maNV 

waitfor delay '00:00:07'
set @setluong=@setluong+@Luong
update NhanVien set Luong = @setluong where MaNV=@maNV 

if not exists(select * from NhanVien where MaNV=@maNV and MaCN=@maCN) 
begin
	
	RAISERROR('Thong tin khong hop le',16,1)
	ROLLBACK TRAN sp_capnhat_Luong_nhanvien_Fixed
end
else
COMMIT TRAN sp_capnhat_Luong_nhanvien_Fixed
end try
begin catch
--waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_capnhat_Luong_nhanvien_Fixed
	--Bat DEADLOCK
	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
    
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );  
	   
	   
end catch
select * from NhanVien where MaCN=@maCN
end
GO

-------------------------------- TRANS 02
create OR alter proc sp_tang_luong_theochinhanh_Fixed
@maCN char(8),
@hesoLuong float
as
begin
begin try
set transaction isolation level repeatable read
BEGIN TRAN sp_tang_luong_theochinhanh_Fixed
update NhanVien set Luong = Luong*@hesoLuong where MaCN=@maCN
waitfor delay '00:00:07'
if not exists(select * from NhanVien where MaCN=@maCN) 
begin
	
	RAISERROR('Ma Chi nhanh khong hop le',16,1)
	ROLLBACK TRAN sp_tang_luong_theochinhanh_Fixed
end
else
COMMIT TRAN sp_tang_luong_theochinhanh_Fixed
end try
begin catch
--waitfor delay '00:00:07'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_tang_luong_theochinhanh_Fixed
	--Bat DEADLOCK
	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
    
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );  
	   
end catch
select * from NhanVien where MaCN=@maCN
end
GO



-- ERROR03
-----------------------------------------
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



-- ERROR04
-----------------------------------------
--TINH HUONG 04: Unrepeatable Read
--T1 (User = NhanVien): Thực hiện xem danh NguoiThue
--T2 (User = NguoiThue): Thực hiện cập nhật thông tin NguoiThue

----------------TRAN 01
CREATE OR ALTER PROC sp_xem_NguoiThue_Fixed
AS
BEGIN
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	SELECT * FROM NguoiThue
	WAITFOR DELAY '00:00:07'
	SELECT * FROM NguoiThue
COMMIT TRAN
END
GO

----------------TRAN 02
CREATE OR ALTER PROC sp_sua_NguoiThue_Fixed
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



-- ERROR05
-----------------------------------------
------Tình huống 5: Dirty read
--User 1: CEO
--Tran01: Chuyển Nhân viên sang chi nhánh khác và đồng thời chỉ đạo 1 nhân viên quản lý mới cho nhân viên đó
--User 2: QLCN
--Tran02: Thống kê nhan vien trong cac chi nhanh
use HQT_CSDL
go
----------------------------------Tran01
create or alter proc ChuyenNV_Fixed
@manv as char(8),
@mcn as char(8)
--@mql as char(8)
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
RAISERROR('Chuyen nhan vien khong thanh cong',1,1)
ROLLBACK TRAN sp_ChuyenNV_uncommited
end
else
update NhanVien
set MaQuanLy=(select distinct MaNV from ChiNhanh where MaCN=@mcn) 
where MaNV=@manv
end
select * from NhanVien where MaNV=@manv
--waitfor delay '00:00:05'
commit TRAN sp_ChuyenNV_uncommited
go

----------------------------------------Tran02
create or alter proc XemNV_uncommited_Fixed
as
begin
SET TRANSACTION ISOLATION LEVEL read COMMITTED
begin tran
select * from NhanVien
commit tran
end
go



--ERR06: Lost Update
--T1 (User = Nhân viên): thực hiện update số phòng sau khi hợp đồng thành công
--T2 (User = Chủ nhà): thực hiện update số phòng còn lại mới

-------------------------------TRAN 01
--User: NhanVien
--Proc: Sau khi thêm 1 hợp đồng liên quan tới thuê phòng, cập nhập lại ngay số phòng hiện có
create or alter proc CapNhapSauHopDong_Fixed
@mhd as char(8)
as
begin
--begin try
SET TRANSACTION ISOLATION LEVEL repeatable READ  --COMMITTED
begin tran sp_CapNhapSau
declare @temp INT
DECLARE @manha CHAR(8)
SELECT @manha=(SELECT DISTINCT MaNha FROM dbo.HopDong WHERE @mhd=MaHD)
select @temp=SoLuongPhong from NhaThue with (UPDLOCK) where MaNha=@manha
if(not exists(select * from HopDong where MaHD=@mhd) or not exists(select* from NhaThue where MaNha=@manha))
begin
RAISERROR('Chuyen nhan vien khong thanh cong',1,1)
ROLLBACK TRAN sp_CapNhapSau
end
else
waitfor delay '00:00:10'
update NhaThue
set SoLuongPhong=@temp-1
where MaNha=@manha
commit tran sp_CapNhapSau
IF @@TRANCOUNT > 0
begin
       ROLLBACK TRAN sp_CapNhapSau
	--Bat DEADLOCK
	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
    
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );
end
else
--select * from NhaThue where MaNha=@manha
--end try
--begin catch
--waitfor delay '00:00:07'
--end catch
select * from NhaThue where MaNha=@manha
end
go

-------------------------------TRAN 02
--User: ChuNha
--Proc: Khi có xây thêm phòng hay khách cũ trả phòng, chủ nhà cập nhập lại số phòng
create or alter proc CapNhapPhong_Fixed
@manha as char(8),
@spt as int
as
begin
--begin try
SET TRANSACTION ISOLATION LEVEL repeatable READ --unCOMMITTED
begin tran sp_CapNhap
declare @temp int
select @temp=SoLuongPhong from NhaThue with (UPDLOCK) where MaNha=@manha
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
commit tran sp_CapNhap
IF @@TRANCOUNT > 0
begin
       ROLLBACK TRAN sp_CapNhap
	--Bat DEADLOCK
	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
    
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );
end
else
--select * from NhaThue where MaNha=@manha
--end try
--begin catch
--waitfor delay '00:00:07'
--end catch
select * from NhaThue where MaNha=@manha
end
go

-------------------------------TRAN 02
--User: ChuNha
--Proc: Khi có xây thêm phòng hay khách cũ trả phòng, chủ nhà cập nhập lại số phòng
create or alter proc CapNhapPhong_Fixed
@manha as char(8),
@spt as int
as
begin
--begin try
SET TRANSACTION ISOLATION LEVEL repeatable READ --unCOMMITTED
begin tran sp_CapNhap
declare @temp int
select @temp=SoLuongPhong from NhaThue with (UPDLOCK) where MaNha=@manha
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
commit tran sp_CapNhap
IF @@TRANCOUNT > 0
begin
       ROLLBACK TRAN sp_CapNhap
	--Bat DEADLOCK
	DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
    
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );
end
else
--select * from NhaThue where MaNha=@manha
--end try
--begin catch
--waitfor delay '00:00:07'
--end catch
select * from NhaThue where MaNha=@manha
end
go



-- ERROR07
-----------------------------------------
------------------------------------------------------PHANTOM--------------------------------------------------------------------------------------------
--Tình huống 08: Phantom
--T1 (User = ngườithue): thực hiện thống kê nhà thuê 
--T2 (User = chủ nhà): thêm 1 nha thuê 


-------------------TRAN 01
CREATE OR ALTER PROC sp_xem_NhaThue_fixed
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

-- ERROR08
-----------------------------------------
-- Tình huống 07: unrepeateale read fixed
--T1 (User = Nhân viên): thực hiện thống kê Người thuê nhà thuộc chi nhánh
--T2 (User = người thuê): người thuê NT000001 thực hiện update thông tin của mình

-------------------TRAN 01
create OR alter proc sp_xem_NguoiThue_er8_fixed
@MaCN varchar(8)
as
begin
begin tran sp_xem_NguoiThue_fixed
set transaction isolation level repeatable read
	select * from NguoiThue where MaCN=@MaCN
WAITFOR DELAY '00:00:20'
	select * from NguoiThue where MaCN=@MaCN
commit tran sp_xem_NguoiThue_fixed
end
GO
--------------------TRAN 02
create OR alter proc sp_update_NguoiThue_fixed
@maNT char(8),
@TenNT nvarchar(20)
as
begin
Begin tran
begin try
begin tran sp_update_NguoiThue_er8_fixed
set transaction isolation level read uncommitted
if not exists(select * from NguoiThue where MaNT=@maNT) 
begin
	
	RAISERROR('Thong tin khong hop le',1,1)
	ROLLBACK TRAN sp_update_NguoiThue_fixed
end
else
update NguoiThue set TenNT = @TenNT where MaNT=@maNT
COMMIT TRAN sp_update_NguoiThue_fixed
end try
begin catch
--waitfor delay '00:00:20'
	IF @@TRANCOUNT > 0
       ROLLBACK TRAN sp_update_NguoiThue_fixed
	 RAISERROR('Thong tin khong hop le',1,1)  
end catch
commit tran
end
GO



-- ERROR09
-----------------------------------------

-- ERROR10
-----------------------------------------