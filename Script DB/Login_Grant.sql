USE [HQT_CSDL]
GO
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
exec sp_addlogin 'NV000007',  'nhanvien07','HQT_CSDL'

exec sp_addlogin 'NT000005', 'thue','HQT_CSDL'
exec sp_addlogin 'NT000006',  'thue','HQT_CSDL'
exec sp_addlogin 'NT000002',  'thue','HQT_CSDL'

exec sp_addlogin 'HOST0001', 'chunha','HQT_CSDL'
exec sp_addlogin 'HOST0002',  'chunha','HQT_CSDL'

--Tao user
CREATE USER [CEO_log] FOR LOGIN [CEO_log] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [NV000001] FOR LOGIN [NV000001] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NV000005] FOR LOGIN [NV000005] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [NV000006] FOR LOGIN [NV000006] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NV000007] FOR LOGIN [NV000007] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [NT000005] FOR LOGIN [NT000005] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NT000006] FOR LOGIN [NT000006] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [NT000002] FOR LOGIN [NT000002] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE USER [HOST0001] FOR LOGIN [HOST0001] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [HOST0002] FOR LOGIN [HOST0002] WITH DEFAULT_SCHEMA=[dbo]
GO

--add ROLEMEMBER
exec sp_addrolemember 'CEO', 'CEO_log'

exec sp_addrolemember 'NhanVienQuanLy', 'NV000001'
exec sp_addrolemember 'NhanVienQuanLy', 'NV000005'

exec sp_addrolemember 'NhanVien', 'NV000006'
exec sp_addrolemember 'NhanVien', 'NV000007'

exec sp_addrolemember 'NguoiThue', 'NT000006'
exec sp_addrolemember 'NguoiThue', 'NT000005'
exec sp_addrolemember 'NguoiThue', 'NT000002'

exec sp_addrolemember 'ChuNha', 'HOST0001'
exec sp_addrolemember 'ChuNha', 'HOST0002'

--Gan chuc nang login
GRANT EXECUTE ON login_role to CEO
GRANT EXECUTE ON login_role to NhanVienQuanLy
GRANT EXECUTE ON login_role to NhanVien
GRANT EXECUTE ON login_role to ChuNha
GRANT EXECUTE ON login_role to NguoiThue

--Gan phan quyen Database

GRANT SELECT, INSERT, UPDATE, DELETE ON NhanVien to CEO, NhanVienQuanLy
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiNhanh to CEO
GRANT SELECT, INSERT, UPDATE, DELETE ON HopDong to NhanVien
GRANT SELECT, INSERT, UPDATE, DELETE ON LichSuXem to NhanVien
GRANT SELECT, INSERT, UPDATE, DELETE ON NguoiThue to NhanVien
GRANT SELECT, INSERT, UPDATE, DELETE ON ChuNha to NhanVien
GRANT SELECT, INSERT, UPDATE, DELETE ON Nha to NhanVien, ChuNha
GRANT SELECT, INSERT, UPDATE, DELETE ON NhaBan to ChuNha
GRANT SELECT, INSERT, UPDATE, DELETE ON NhaThue to ChuNha
GRANT SELECT ON Nha to CEO, NhanVienQuanLy, NguoiThue
GRANT SELECT ON NhaBan to CEO, NhanVienQuanLy, NguoiThue, NhanVien
GRANT SELECT ON NhaThue to CEO, NhanVienQuanLy, NguoiThue, NhanVien

-- Gann execute querry
-- ERROR 01:
GRANT EXECUTE ON sp_them_HDNhaBan TO NhanVien
GRANT EXECUTE ON sp_xem_NhaBan TO NguoiThue

GRANT EXECUTE ON sp_them_HDNhaBan_Fixed TO NhanVien
GRANT EXECUTE ON sp_xem_NhaBan_Fixed TO NguoiThue

-- ERROR 02:
GRANT EXECUTE ON  sp_tang_Luong_nhanvien TO NhanVienQuanLy
GRANT EXECUTE ON  sp_tang_luong_theochinhanh TO CEO

GRANT EXECUTE ON  sp_tang_Luong_nhanvien_Fixed TO NhanVienQuanLy
GRANT EXECUTE ON  sp_tang_luong_theochinhanh_Fixed TO CEO

-- ERROR 03:
GRANT EXECUTE ON  sp_them_NhaBan TO ChuNha

GRANT EXECUTE ON  sp_them_NhaBan_Fixed TO ChuNha
GRANT EXECUTE ON  sp_xem_NhaBan_er3_Fixed TO NguoiThue
-- ERROR 04:
GRANT EXECUTE ON  sp_xem_NguoiThue TO NhanVien
GRANT EXECUTE ON  sp_sua_NguoiThue TO NguoiThue

GRANT EXECUTE ON  sp_xem_NguoiThue_Fixed TO NhanVien
GRANT EXECUTE ON  sp_sua_NguoiThue_Fixed TO NguoiThue

-- ERROR 05:
GRANT EXECUTE ON ChuyenNV TO CEO
GRANT EXECUTE ON XemNV_uncommited TO NhanVienQuanLy

GRANT EXECUTE ON ChuyenNV_Fixed TO CEO
GRANT EXECUTE ON XemNV_uncommited_Fixed TO NhanVienQuanLy

-- ERROR 06:
GRANT EXECUTE ON  CapNhapSauHopDong TO NhanVien
GRANT EXECUTE ON  CapNhapPhong TO ChuNha

GRANT EXECUTE ON  CapNhapSauHopDong_Fixed TO NhanVien
GRANT EXECUTE ON  CapNhapPhong_Fixed TO ChuNha

-- ERROR 07:
GRANT EXECUTE ON  sp_xem_NhaThue TO NguoiThue
GRANT EXECUTE ON  sp_them_NhaThue TO ChuNha

GRANT EXECUTE ON  sp_xem_NhaThue_fixed TO NguoiThue
GRANT EXECUTE ON  sp_them_NhaThue_fixed TO ChuNha
-- ERROR 08:
GRANT EXECUTE ON  sp_xem_NguoiThue_er8 TO NhanVien
GRANT EXECUTE ON  sp_update_NguoiThue_er8 TO NguoiThue

GRANT EXECUTE ON  sp_xem_NguoiThue_er8_fixed TO NhanVien
GRANT EXECUTE ON  sp_update_NguoiThue_er8_fixed TO NguoiThue

-- ERROR 09:
GRANT EXECUTE ON sp_updateLSX TO NhanVien
GRANT EXECUTE ON sp_updateLSX_2 TO NhanVien

GRANT EXECUTE ON sp_them_HDNhaBan_Fixed TO NhanVien
GRANT EXECUTE ON sp_xem_NhaBan_Fixed TO NguoiThue

-- ERROR 10:
GRANT EXECUTE ON  sp_them_HDnhaban_DL TO NhanVien
GRANT EXECUTE ON  sp_them_HDnhaban_DL_2 TO NhanVien

GRANT EXECUTE ON  sp_tang_Luong_nhanvien_Fixed TO NhanVienQuanLy
GRANT EXECUTE ON  sp_tang_luong_theochinhanh_Fixed TO CEO

