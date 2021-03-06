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
--TEST
exec sp_them_HDNhaBan 'NV000006','HD000006', 'NHA00006', 'NT0006'
exec sp_xem_NhaBan

SELECT * FROM HopDong
SELECT * FROM NhaBan


update NhaBan set TinhTrangBan = 1 where MaNha='NHA00006'
DELETE HopDong WHERE MaHD='HD000006'
GO
