--TINH HUONG 02:

create OR alter proc sp_tang_Luong_nhanvien
@maNV char(8),
@maCN char(8),
@Luong money
as
begin
begin tran
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
	
	RAISERROR('Thong tin khong hop le',1,1)
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
commit tran
select * from NhanVien where MaCN=@maCN
end
GO
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
	
	RAISERROR('Ma Chi nhanh khong hop le',1,1)
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

--TEST
exec sp_tang_Luong_nhanvien 'NV000017', 'CN000005', 5000000
exec sp_tang_luong_theochinhanh 'CN000005', 1.1

select * from NhanVien where MaCN='CN000005'
 update NhanVien set Luong=20000000 where MaCN='CN000005'