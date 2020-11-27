USE [HQT_CSDL]
GO
/****** Object:  StoredProcedure [dbo].[login_role]    Script Date: 11/19/2020 12:25:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter proc [dbo].[login_role]
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
exec sp_addlogin 'sysad_N07', '1234567','HQT_CSDL'
exec sp_addlogin 'ql01', 'ql01','HQT_CSDL'
exec sp_addlogin 'user01', 'user01','HQT_CSDL'
exec sp_addlogin 'cnha01', 'cnha01','HQT_CSDL'
exec sp_addlogin 'CEO01','CEO01','HQT_CSDL'
--Tao user
CREATE USER [sysad_N07] FOR LOGIN [sysad_N07] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [ql01] FOR LOGIN [ql01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [user01] FOR LOGIN [user01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [cnha01] FOR LOGIN [cnha01] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [CEO01] FOR LOGIN [CEO01] WITH DEFAULT_SCHEMA=[dbo]
GO
--add ROLEMEMBER
exec sp_addrolemember 'db_owner', 'sysad_N07'
exec sp_addrolemember 'QuanLyChiNhanh', 'ql01'
exec sp_addrolemember 'NguoiThue', 'user01'
exec sp_addrolemember 'ChuNha', 'cnha01'
exec sp_addrolemember 'CEO', 'CEO01'


GRANT EXECUTE ON login_role to CEO
GRANT EXECUTE ON login_role to NhanVienQuanLy
GRANT EXECUTE ON login_role to NhanVien
GRANT EXECUTE ON login_role to ChuNha
GRANT EXECUTE ON login_role to NguoiThue
