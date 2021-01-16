--ERR06: Lost Update
--T1 (User = Nhân viên): thực hiện update số phòng sau khi hợp đồng thành công
--T2 (User = Chủ nhà): thực hiện update số phòng còn lại mới

-------------------------------TRAN 01
--User: NhanVien
--Proc: Sau khi thêm 1 hợp đồng liên quan tới thuê phòng, cập nhập lại ngay số phòng hiện có
create or alter proc CapNhapSauHopDong_Fixed
@mhd as char(8),
@manha as char(8),
@sphd as int
as
begin
--begin try
SET TRANSACTION ISOLATION LEVEL repeatable READ  --COMMITTED
begin tran sp_CapNhapSau
declare @temp int
select @temp=SoLuongPhong from NhaThue with (UPDLOCK) where MaNha=@manha
if(not exists(select * from HopDong where MaHD=@mhd) or not exists(select* from NhaThue where MaNha=@manha))
begin
RAISERROR('Chuyen nhan vien khong thanh cong',1,1)
ROLLBACK TRAN sp_CapNhapSau
end
else
waitfor delay '00:00:10'
update NhaThue
set SoLuongPhong=@temp-@sphd
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
----------------------------------------------Test

go
--exec XemNV_uncommited
go
--exec CapNhapPhong 'NHA00001',4
go
update NhaThue set SoLuongPhong=4 where MaNha='NHA00001'