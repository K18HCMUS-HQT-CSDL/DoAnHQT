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
RAISERROR('Chuyen nhan vien khong thanh cong',1,1)
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