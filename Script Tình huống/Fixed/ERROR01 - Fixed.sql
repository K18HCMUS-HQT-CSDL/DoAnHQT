--TINH HUONG 01:
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
create OR alter proc sp_xem_NhaBan_Fixed
as
begin
begin tran sp_xem_NhaBan_Fixed
set transaction isolation level read committed
select * from NhaBan
commit tran sp_xem_NhaBan_Fixed
end
GO
--TEST
exec sp_them_HDNhaBan_Fixed 'NV000006','HD000006', 'NHA00006', 'NT0006'
exec sp_xem_NhaBan_Fixed

SELECT * FROM HopDong
SELECT * FROM NhaBan


update NhaBan set TinhTrangBan = 1 where MaNha='NHA00006'
DELETE HopDong WHERE MaHD='HD000006'
GO
