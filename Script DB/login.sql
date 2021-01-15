
/****** Object:  StoredProcedure [dbo].[login_role]    Script Date: 11/19/2020 12:25:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create or alter proc [dbo].[login_role]
@username char(20),
@role varchar(20) output
as
begin
set nocount on;
select @role= name from sys.database_principals where principal_id =
( 
select rl.role_principal_id FROM sys.database_principals as pr join 
	sys.database_role_members as rl 
	on rl.member_principal_id=pr.principal_id and (pr.type='R' or pr.type='S') and pr.name=@username
)
--print @role
end

--Tao ROLE
exec sp_addrole 'Dev'
exec sp_addrole 'CEO'
exec sp_addrole 'NhanVienQuanLy'
exec sp_addrole 'NhanVien'
exec sp_addrole 'ChuNha'
exec sp_addrole 'NguoiThue'
--Tao LOGIN
exec sp_addlogin 'CEO_log', '1234567','HQT_CSDL'
exec sp_addlogin 'NV000001', 'nvql01','HQT_CSDL'
exec sp_addlogin 'NV000005', 'nvql05','HQT_CSDL'
exec sp_addlogin 'NV000006',  'nhanvien06','HQT_CSDL'
EXEC sp_addlogin 'HOST0001','chunha01','HQT_CSDL'

--Tao user
CREATE USER [CEO_log] FOR LOGIN [CEO_log] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NV000001] FOR LOGIN [NV000001] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NV000005] FOR LOGIN [NV000005] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NV000006] FOR LOGIN [NV000006] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [HOST0001] FOR LOGIN [HOST0001] WITH DEFAULT_SCHEMA=[dbo]
GO
--add ROLEMEMBER
exec sp_addrolemember 'CEO', 'CEO_log'
exec sp_addrolemember 'NhanVienQuanLy', 'NV000001'
exec sp_addrolemember 'NhanVienQuanLy', 'NV000005'
exec sp_addrolemember 'NhanVien', 'NV000006'
EXEC sp_addrolemember 'ChuNha','HOST0001'

--Gan chuc nang login
GRANT EXECUTE ON login_role to CEO
GRANT EXECUTE ON login_role to NhanVienQuanLy
GRANT EXECUTE ON login_role to NhanVien
GRANT EXECUTE ON login_role to ChuNha
GRANT EXECUTE ON login_role to NguoiThue

--Gan phan quyen Database
GRANT SELECT ON dbo.ChiNhanh TO NhanVienQuanly
GRANT SELECT ON dbo.ChiNhanh TO CEO
GRANT SELECT ON dbo.NhanVien TO CEO
GRANT EXECUTE ON dbo.ChuyenNV TO CEO
GRANT EXECUTE ON ChuyenNV_Error TO CEO
GRANT SELECT ON dbo.NhanVien TO NhanVienQuanLy
GRANT EXECUTE ON dbo.XemNV_uncommited TO NhanVienQuanLy
GRANT EXECUTE ON dbo.XemNV_commited TO NhanVienQuanLy
GRANT EXECUTE ON dbo.CapNhapSauHopDong_Error TO NhanVien
GRANT EXECUTE ON dbo.CapNhapSauHopDong TO NhanVien
GRANT SELECT ON dbo.Nha TO ChuNha
GRANT EXECUTE ON dbo.CapNhapPhong_Error TO ChuNha
GRANT EXECUTE ON dbo.CapNhapPhong TO ChuNha