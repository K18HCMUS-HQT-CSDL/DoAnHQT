USE [HQT_CSDL]
GO

--CapNhapNV
/****** Object:  StoredProcedure [dbo].[CapNhapNhanVien]    Script Date: 11/27/2020 8:41:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CapNhapNhanVien]
@manv as char(8),
@luong as money,
@mcn as char(8)
as
begin
if(exists(select * from NhanVien A where A.MaNV=@manv))
begin
if(@mcn is not null and @luong is null)
begin
update NhanVien
set MaCN=@mcn
where MaNV=@manv
end
else if(@mcn is null and @luong is not null)
begin
update NhanVien
set Luong=@luong
where MaNV=@manv
end
else if(@mcn is not null and @luong is not null)
begin
update NhanVien
set Luong=@luong,MaCN=@mcn
where MaNV=@manv
end
end
end
go

--ThemNV
/****** Object:  StoredProcedure [dbo].[ThemNV]    Script Date: 11/27/2020 8:41:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[ThemNV]
@manv as char(8),
@tennv as nvarchar(20),
@diachi as nvarchar(50),
@sdt as char(10),
@gt as tinyint,
@ngaysinh as datetime,
@luong as money,
@mcn as char(8),
@maql as char(8)
as
begin
insert into NhanVien
values(@manv,@tennv,@diachi,@sdt,@gt,@ngaysinh,@luong,@mcn,@maql,'1')
end
go

--XoaNV
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[XoaNV]
@manv as char(8)
as
begin
delete from NhanVien where MaNV=@manv
end
