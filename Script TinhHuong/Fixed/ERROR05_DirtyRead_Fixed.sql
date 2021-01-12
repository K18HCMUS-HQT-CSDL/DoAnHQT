------Tình hướng 5: Dirty read
--User 1: CEO
--Tran01: Chuyển Nhân viên sang chi nhánh khác và đồng thời chỉ đạo 1 nhân viên quản lý mới cho nhân viên đó
--User 2: QLCN
--Tran02: Thống kê nhan vien trong cac chi nhanh
use HQT_CSDL
go
----------------------------------Tran01
create or alter proc ChuyenNV
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
create or alter proc XemNV_uncommited
as
begin
SET TRANSACTION ISOLATION LEVEL read COMMITTED
begin tran
select * from NhanVien
commit tran
end
go



--------------------------TEST
use HQT_CSDL
go
exec ChuyenNV 'NV000008','CN000004'
go
exec CapNhapSauHopDong 'HD000001','NHA00001',2
go









