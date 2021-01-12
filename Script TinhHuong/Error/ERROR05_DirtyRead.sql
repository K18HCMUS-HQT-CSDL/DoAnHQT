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
-----------TEST

exec XemNV_uncommited
go
exec ChuyenNV 'NV000001','CN000002','NV000002'
go









