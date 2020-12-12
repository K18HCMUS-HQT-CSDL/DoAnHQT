use HQT_CSDL
go

-- create unique key
ALTER TABLE NguoiThue 
ADD CONSTRAINT Unique_NguoiThue_SDT
UNIQUE (SDT)
GO

ALTER TABLE ChuNha 
ADD CONSTRAINT Unique_ChuNha
UNIQUE (DiaChi,SDT)
Go

ALTER TABLE LoaiNha 
ADD CONSTRAINT Unique_LoaiNha
UNIQUE (TenLoai)
GO

ALTER TABLE NhanVien
ADD CONSTRAINT Unique_NhanVien_SDT
UNIQUE (SDT)
GO


ALTER TABLE ChiNhanh
ADD CONSTRAINT Unique_ChiNhanh_SDT_FAX
UNIQUE (SDT,FAX)
GO
-- rang buoc mien gia tri
ALTER TABLE NhanVien
ADD CONSTRAINT Range_NhanVien_GT
CHECK (GioiTinh in (-1,0,1)) -- 0: Nam ; 1: Nu ; -1: Khac
GO

ALTER TABLE NhanVien
ADD CONSTRAINT Range_NhanVien_Luong
CHECK (Luong between 2000000 and 50000000)
GO

ALTER TABLE NhanVien
ADD CONSTRAINT Cons_TuoiHon18
CHECK (datediff(year, NgaySinh, getdate()) > 18)  
GO

ALTER TABLE NhaThue
ADD CONSTRAINT Cons_NhaThue_NgayHH
CHECK (NgayHetHan > NgayDang)   
GO

ALTER TABLE NhaBan
ADD CONSTRAINT Cons_NhaBan_NgayHH
CHECK (NgayHetHan > NgayDang)   
GO


--------------------------------TRIGGER RANG BUOC
-- Trigger rang buoc khi them mot chi nhanh
-- Nội dung: Không được thêm chi nhánh có địa chỉ trùng với địa chỉ các chi nhánh khác
create trigger TR_ChiNhanh_BF_INS
on ChiNhanh
Instead of Insert
as
begin
	set nocount on;
	declare @duong nvarchar(20)
	declare @kv nvarchar(20)
	declare @quan nvarchar(20)
	declare @tp nvarchar(20)
	set @duong=(select TenDuong from inserted)
	set @kv=(select TenKhuVuc from inserted)
	set @quan=(select TenQuan from inserted)
	set @tp=(select TenTP from inserted)

	if not exists(select * from ChiNhanh where TenDuong=@duong and TenKhuVuc=@kv and TenQuan=@quan and TenTP=@tp)
		insert into ChiNhanh select * from inserted
	else print 'Dia chi chi nhanh khong hop le!'

end
go

-- Trigger rang buoc khi them mot nha
-- Nội dung: Không được thêm nhà có địa chỉ trùng với địa chỉ nhà khác
create trigger TR_Nha_BF_INS
on Nha
Instead of Insert
as
begin
	set nocount on;
	declare @duong nvarchar(20)
	declare @kv nvarchar(20)
	declare @quan nvarchar(20)
	declare @tp nvarchar(20)
	set @duong=(select TenDuong from inserted)
	set @kv=(select TenKV from inserted)
	set @quan=(select TenQuan from inserted)
	set @tp=(select TenTP from inserted)

	if not exists(select * from Nha where TenDuong=@duong and TenKV=@kv and TenQuan=@quan and TenTP=@tp)
		insert into Nha select * from inserted
	else print 'Dia chi nha khong hop le!'

end
go

--drop trigger TR_HopDong_BF_INS
--go
---- Trigger truoc khi them mot lich su xem se kiem tra
---- Nội dung: Ngày xem phải trong khoảng ngày đăng và ngày hết hạn của căn nhà (thuê/bán)
--create trigger TR_LichSuXem_BF_INS
--on LichSuXem
--Instead of Insert
--as
--begin
--	declare c cursor for select MaNha, NgayXem from inserted 
--	declare @NgayXem datetime
--	declare @MaNha char(8)
--	open c
--	fetch next from c into @MaNha, @NgayXem
--	while (@@FETCH_STATUS=0)
--	begin
--		if (0!=(select count(*) from NhaThue where MaNha=@MaNha and @NgayXem between NgayDang and NgayHetHan) 
--			or 0!=(select count(*) from NhaBan where MaNha=@MaNha and @NgayXem between NgayDang and NgayHetHan))
		
--			insert into LichSuXem
--			select* 
--			from inserted where MaNha=@MaNha
		
--		else print 'Lich su xem khong hop le!'
--		fetch next from c into @MaNha, @NgayXem
--	end
--	close c
--	deallocate c
--end
--go


---- Trigger truoc khi chen hop dong se kiem tra
----1. khach hang da xem qua can nha hay chua 
----2. Tinh trang can nha co onsale hay k va xac dinh loai hop dong
--create trigger TR_HopDong_BF_INS
--on HopDong
--Instead of Insert
--as
--begin
--	declare c cursor for select MaNT, MaNha from inserted 
--	declare @MaNT char(8)
--	declare @MaNha char(8)
--	open c
--	fetch next from c into @MaNT, @MaNha
--	while (@@FETCH_STATUS=0)
--	begin
--		declare @hadSeen tinyint
--		set @hadSeen = (select count(*) from LichSuXem where MaNT = @MaNT and MaNha = @MaNha)
--		if @hadSeen != 0 
		
--			insert into HopDong(MaHD,MaNT,MaNha,LoaiHD,ThoiGian) 
--			select MaHD,MaNT,MaNha, LoaiHD=(Select LoaiGiaoDich from Nha where MaNha=@MaNha), ThoiGian 
--			from inserted where inserted.MaNT = @MaNT and MaNha=@MaNha
		
--		else print 'Khong the tao hop dong nay!'
--		fetch next from c into @MaNT, @MaNha
--	end
--	close c
--	deallocate c
--end
--go


--------------------------------- TRIGGER CAP NHAT


---- Trigger cap nhat So luot xem tren cac bang thue va ban sau khi them mot lich su xem
--create trigger TR_LichSuXem_AF_INS on LichSuXem
--after insert
--as
 
--declare @manha char(8)
--declare @mant char(8)
--declare @ngayxem datetime
--select @manha= inserted.MaNha from inserted
--select @mant= inserted.MaNT from inserted
--select @ngayxem= inserted.NgayXem from inserted
--if(exists(select * from NhaBan where @manha=MaNha))
--begin
--update NhaBan
--set SoLuotXem=SoLuotXem+1 where @manha=MaNha
--end
--else if(exists(select * from NhaThue where @manha=MaNha))
--begin
--update NhaThue
--set SoLuotXem=SoLuotXem+1 where @manha=MaNha
--end

--go
----Trigger cap nhat tinh trang nha sau khi them 1 dong vao hop dong
--create trigger TR_HopDong_AF_INS on HopDong
--after insert
--as
--set nocount on;
--declare @mant char(8)
--declare @manha char(8)
--declare @ThoiGian datetime
--select @mant= inserted.MaNT from inserted
--select @manha= inserted.MaNha from inserted
--select @ThoiGian= inserted.ThoiGian from inserted
--if(exists(Select * from NhaBan where MaNha=@manha))

--begin
--update NhaBan set TinhTrangBan=1 where MaNha=@manha
--update NhaBan set NgayHetHan=@ThoiGian where MaNha=@manha
--end

--else if(exists(select * from NhaThue where MaNha=@manha))
--begin

--update NhaThue set SoLuongPhong = SoLuongPhong - 1 where MaNha=@manha
--update NhaThue set TinhTrangThue=1 where MaNha=@manha and SoLuongPhong=0
--update NhaThue set NgayHetHan=@ThoiGian where MaNha=@manha and SoLuongPhong=0

--end
--go

--Trigger xoa nha thue
create trigger TR_NhaThue_BF_DL 
on NhaThue
instead of delete as
begin
	print 'Du lieu nha da duoc cap nhat'

	update NhaThue
	set TinhTrangThue=1 where MaNha = (select MaNha from deleted)

	update NhaThue
	set NgayHetHan=CONVERT(Date,GETDATE()) where MaNha = (Select MaNha from deleted)
end
go


--Trigger xoa nha ban
create trigger TR_NhaBan_BF_DL 
on NhaBan
instead of delete as
begin
	print 'Du lieu nha da duoc cap nhat'

	update NhaBan
	set TinhTrangBan=1 where MaNha = (select MaNha from deleted)

	update NhaBan
	set NgayHetHan=CONVERT(Date,GETDATE()) where MaNha = (Select MaNha from deleted)
end
go

--Trigger xoa nhan vien
create trigger TR_NhanVien_BF_DL 
on NhanVien
instead of delete as
begin
	print 'Du lieu nha da duoc cap nhat'

	update NhanVien
	set TinhTrang=0 where MaNV = (select MaNV from deleted)

end
go

--Trigger xoa hop dong thue nha
create trigger TR_HopDong_BF_DL 
on HopDong
instead of delete as
begin
set nocount on;
declare @loaiHD bit
declare @MaNha char(8)
	print 'Du lieu nha da duoc cap nhat'

	if @loaiHD=1 and (exists (select * from NhaThue where MaNha=@MaNha and NgayHetHan>=GETDATE()))
	update NhaThue set TinhTrangThue=0 where MaNha = (select MaNha from deleted)

end
go


