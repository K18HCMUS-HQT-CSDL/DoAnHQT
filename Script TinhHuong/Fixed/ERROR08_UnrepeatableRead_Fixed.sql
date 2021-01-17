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

----TEST
exec sp_xem_NguoiThue_fixed 'CN000001'
exec sp_update_NguoiThue_fixed 'NT000001',N'Phan Đình Thư'

