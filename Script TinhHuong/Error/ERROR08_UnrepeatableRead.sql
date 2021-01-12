-------------------------------------------------------------Unrepeateale read-------------------------------------------------------------------
--T1 (User = Nhân viên): thực hiện thống kê Người thuê nhà thuộc chi nhánh
--T2 (User = người thuê): người thuê NT000001 thực hiện update thông tin của mình

------TRAN 01
create OR alter proc sp_xem_NguoiThue
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
create OR alter proc sp_update_NguoiThue
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

----TEST
exec sp_xem_NguoiThue 'CN000001'
exec sp_update_NguoiThue 'NT000001',N'Đỗ HOÀNG AN'

Select * from NguoiThue where MaCN='CN000001'
GO