use HQT_CSDL
go

--User: NhanVien
--Proc: Sau khi thêm 1 hợp đồng liên quan tới thuê phòng, cập nhập lại ngay số phòng hiện có
create or alter proc CapNhapSauHopDong
@mhd as char(8),
@manha as char(8)
as
begin
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
begin tran sp_CapNhapSau
declare @temp int
select @temp=SoLuongPhong from NhaThue where MaNha=@manha
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
select * from NhaThue where MaNha=@manha
commit tran sp_CapNhapSau
end
go

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
exec CapNhapPhong 'NHA00001',4
go
exec CapNhapSauHopDong 'HD000001','NHA00001'
go

--update NhaThue set SoLuongPhong=4 where MaNha='NHA00001'




