USE HQT_CSDL
GO

--LoaiNha
INSERT INTO LoaiNha VALUES
('LOAI01', N'Nhà Cấp 1'),
('LOAI02', N'Nhà Cấp 2'),
('LOAI03', N'Nhà Cấp 3'),
('LOAI04', N'Nhà Cấp 4')

--ChuNha
INSERT INTO ChuNha VALUES
('HOST0001', N'Nguyễn Xuân Thiện', N'65A Tran Binh Trong, Binh Thanh, Ho Chi Minh', '0919691128'),
('HOST0002', N'Trần Ngọc Ngạn', N'7A2 Au Co,Tan Binh, Ho Chi Minh', '0958483895'),
('HOST0003', N'Ngô Trà My', N'141 Phuong Mai, Dong Da, Ha Noi', '0438522899'),
('HOST0004', N'Quách Thành Tín', N'61 Tran Huu Tuoc, Dong Da, Ha Noi', '0988954436'),
('HOST0005', N'Nguyễn Quang Ðức', N'176/38 Tran Huy Lieu, Phu Nhuan, Ho Chi Minh', '0903724159'),
('HOST0006', N'Vũ Quốc Bình', N'20B Ky Dong, Phuong 9, Quan 3, Ho Chi Minh', '0839307763'),
('HOST0007', N'Đỗ Hồng Việt', N'10J Tran Nhat Duat, Tan Dinh, Quan 1, Ho Chi Minh', '0838484466'),
('HOST0008', N'Nguyễn Ðình Thiện', N'67/140 Bui Dinh Tuy, Binh Thanh, Ho Chi Minh', '0918770546'),
('HOST0009', N'Nguyễn Hạnh My', N'185/12 Pham Ngu Lao, Quan 1, Ho Chi Minh', '0838377439'),
('HOST0010', N'Võ Dạ Hương', N'87/12 Pham Ngu Lao, Quan 1, Ho Chi Minh', '0838377439'),
('HOST0011', N'Ngô Hoàng Lâm', N'Phan Van Doi, Ho Chi Minh', '0903824286'),
('HOST0012', N'Chu Ðức Hải', N'1A Phan Ton, Dakao, Ho Chi Minh', '0838207186'),
('HOST0013', N'Hà Nam Việt', N'315 Huynh Van Banh, Phu Nhuan, Ho Chi Minh', '0988118795'),
('HOST0014', N'Lý Phương Nam', N'100/564 Thich Quang Duc, Phu Nhuan, Ho Chi Minh', '0939950330'),
('HOST0015', N'Nguyễn Trung Anh', N'283/21 Pham Ngu Lao, Quan 1, Ho Chi Minh', '0939306073')

--ChiNhanh
INSERT INTO ChiNhanh VALUES --Chưa thêm mã NV quản lý, và phải thêm từng dòng một do lỗi ở RBTV
('CN000001', N'227 Nguyễn Văn Cừ', N'Quận 5', N'Hồ Chí Minh', N'Hồ Chí Minh', '1900000001', '1900000001', NULL)
INSERT INTO ChiNhanh VALUES
('CN000002', N'268 Lý Thường Kiệt', N'Quận 10', N'Hồ Chí Minh', N'Hồ Chí Minh', '1900000002', '1900000002', NULL)
INSERT INTO ChiNhanh VALUES
('CN000003', N'10 Đinh Tiên Hoàng', N'Quận 1', N'Hồ Chí Minh', N'Hồ Chí Minh', '1900000003', '1900000003', NULL)
INSERT INTO ChiNhanh VALUES
('CN000004', N'234 Pasteur', N'Quận 3', N'Hồ Chí Minh', N'Hồ Chí Minh', '1900000004', '1900000004', NULL)
INSERT INTO ChiNhanh VALUES
('CN000005', N'1 Võ Văn Ngân', N'Thủ Đức', N'Hồ Chí Minh', N'Hồ Chí Minh', '1900000005', '1900000005', NULL)

--NhanVien (MaNV, TenNV, DiaChi, SDT, GioiTinh, NgaySinh, Luong, MaCN, MaQuanLy, TinhTrang)
INSERT INTO NhanVien VALUES
('NV000001', N'Vũ Yến Ngọc', N'KTX Khu B - ĐHQG HCM, Đông Hòa, Dĩ An, Bình Dương', '0980000001', '1', '2000-01-01', '30000000', 'CN000001', 'NV000001', '1'),
('NV000002', N'Lê Ngọc Bảo Ngân', N'Thủ Đức, Hồ Chí Minh', '0980000002', '1', '2000/01/01', '25000000', 'CN000001', 'NV000001', '1'),
('NV000003', N'N.Trần Ái Nguyên', N'Thủ Đức, Hồ Chí Minh', '0980000003', '1', '2000/01/01', '25000000', 'CN000001', 'NV000001', '1'),
('NV000004', N'Võ Đại Nam', N'Thủ Đức, Hồ Chí Minh', '0980000004', '0', '2000/01/01', '20000000', 'CN000001', 'NV000001', '1'),
('NV000005', N'Phạm Văn Minh Phương', N'Thủ Đức, Hồ Chí Minh', '0980000005', '0', '2000/01/01', '20000000', 'CN000001', 'NV000001', '1'),
('NV000006', N'Huỳnh Trung Nguyên', N'Thủ Đức, Hồ Chí Minh', '0980000006', '0', '2000/01/01', '20000000', 'CN000002', 'NV000002', '1'),
('NV000007', N'Nguyễn Thăng Long', N'Thủ Đức, Hồ Chí Minh', '0980000007', '0', '2000/01/01', '20000000', 'CN000002', 'NV000002', '1'),
('NV000008', N'Lê Gia Thịnh', N'Thủ Đức, Hồ Chí Minh', '0980000008', '0', '2000/01/01', '20000000', 'CN000002', 'NV000002', '1'),
('NV000009', N'Hoàng Cường Thịnh', N'Thủ Đức, Hồ Chí Minh', '0980000009', '0', '2000/01/01', '20000000', 'CN000003', 'NV000003', '1'),
('NV000010', N'Dương Khánh Bình', N'Thủ Đức, Hồ Chí Minh', '0980000010', '0', '2000/01/01', '20000000', 'CN000003', 'NV000003', '1'),
('NV000011', N'Hoàng An Nam', N'Thủ Đức, Hồ Chí Minh', '0980000011', '0', '2000/01/01', '20000000', 'CN000003', 'NV000003', '1'),
('NV000012', N'Ngô Hoàng Dũng', N'Thủ Đức, Hồ Chí Minh', '0980000012', '0', '2000/01/01', '20000000', 'CN000004', 'NV000004', '1'),
('NV000013', N'Nguyễn Thái Sơn', N'Thủ Đức, Hồ Chí Minh', '0980000013', '0', '2000/01/01', '20000000', 'CN000004', 'NV000004', '1'),
('NV000014', N'Đặng Phúc Sinh', N'Thủ Đức, Hồ Chí Minh', '0980000014', '0', '2000/01/01', '20000000', 'CN000004', 'NV000004', '1'),
('NV000015', N'Dương Tâm Trang', N'Thủ Đức, Hồ Chí Minh', '0980000015', '1', '2000/01/01', '20000000', 'CN000005', 'NV000005', '1'),
('NV000016', N'Nguyễn Ái Nhi', N'Thủ Đức, Hồ Chí Minh', '0980000016', '1', '2000/01/01', '20000000', 'CN000005', 'NV000005', '1'),
('NV000017', N'Phạm Phương Liên', N'Thủ Đức, Hồ Chí Minh', '0980000017', '1', '2000/01/01', '20000000', 'CN000005', 'NV000005', '0')

--Update Nhân viên quản lý Chi Nhánh
UPDATE ChiNhanh 
SET MaNV = 'NV000001' WHERE MaCN = 'CN000001'
UPDATE ChiNhanh 
SET MaNV = 'NV000002' WHERE MaCN = 'CN000002'
UPDATE ChiNhanh 
SET MaNV = 'NV000003' WHERE MaCN = 'CN000003'
UPDATE ChiNhanh 
SET MaNV = 'NV000004' WHERE MaCN = 'CN000004'
UPDATE ChiNhanh 
SET MaNV = 'NV000005' WHERE MaCN = 'CN000005'

--Nha (MaNha, Ten Duong, Quan, Khu Vuc, Thanh Pho, MaNV, Loai Giao Dich, MaLoai, MaChuNha)
INSERT INTO Nha VALUES
('NHA00001', N'149 Nguyễn Du', N'Quận 1', N'Bến Thành', N'Hồ Chí Minh', 'NV000001', '1', 'LOAI03', 'HOST0001')
INSERT INTO Nha VALUES
('NHA00002', N'30/3D Quang Trung', N'Gò Vấp', N'Phường 12', N'Hồ Chí Minh', 'NV000002', '1', 'LOAI03', 'HOST0002')
INSERT INTO Nha VALUES
('NHA00003', N'80/39 Đường 4', N'Thủ Đức', N'Tam Phú', N'Hồ Chí Minh', 'NV000003', '1', 'LOAI02', 'HOST0003')
INSERT INTO Nha VALUES
('NHA00004', N'54 Tôn Thất Đàm', N'Quận 1', N'Nguyễn Thái Bình', N'Hồ Chí Minh', 'NV000004', '1', 'LOAI01', 'HOST0004')
INSERT INTO Nha VALUES
('NHA00005', N'737 Lê Hồng Phong', N'Quận 10', N'Phường 12', N'Hồ Chí Minh', 'NV000005', '1', 'LOAI04', 'HOST0005')
INSERT INTO Nha VALUES
('NHA00006', N'10 Đường 11', N'Phú Nhuận', N'Phường 12', N'Hồ Chí Minh', 'NV000006', '0', 'LOAI03', 'HOST0006')
INSERT INTO Nha VALUES
('NHA00007', N'176/1 Lê Văn Sỹ ', N'Phú Nhuận', N'Phường 10', N'Hồ Chí Minh', 'NV000007', '0', 'LOAI02', 'HOST0007')
INSERT INTO Nha VALUES
('NHA00008', N'77 Nguyễn Trọng Lợi', N'Tân Bình', N'Phường 4', N'Hồ Chí Minh', 'NV000008', '0', 'LOAI04', 'HOST0008')
INSERT INTO Nha VALUES
('NHA00009', N'122 Nghĩa Phát', N'Tân Bình', N'Phường 7', N'Hồ Chí Minh', 'NV000009', '0', 'LOAI04', 'HOST0009')
INSERT INTO Nha VALUES
('NHA00010', N'73 Đường 5', N'Thủ Đức', N'Linh Trung', N'Hồ Chí Minh', 'NV000010', '0', 'LOAI04', 'HOST0010')
INSERT INTO Nha VALUES
('NHA00011', N'367 Nguyễn Trãi', N'Quận 1', N'Phường 12', N'Hồ Chí Minh', 'NV000011', '0', 'LOAI01', 'HOST0011')
INSERT INTO Nha VALUES
('NHA00012', N'2517 Quốc lộ 1A', N'Quận 12', N'Bình Trị Đông', N'Hồ Chí Minh', 'NV000012', '0', 'LOAI02', 'HOST0012')
INSERT INTO Nha VALUES
('NHA00013', N'425 Kinh Dương Vương', N'Bình Tân', N'An Lạc', N'Hồ Chí Minh', 'NV000013', '0', 'LOAI04', 'HOST0013')
INSERT INTO Nha VALUES
('NHA00014', N'9A Thoại Ngọc Hầu', N'Tân Phú', N'Thanh Hoa', N'Hồ Chí Minh', 'NV000014', '0', 'LOAI02', 'HOST0014')
INSERT INTO Nha VALUES
('NHA00015', N'20 Nguyễn Đình Chinh', N'Phú Nhuận', N'Phường 11', N'Hồ Chí Minh', 'NV000015', '0', 'LOAI01', 'HOST0015')

--NhaThue (GiaThue, MaNha, SoLuongPhong, NgayDang, NgayHetHan, SoLuotXem, TinhTrangThue) (TinhTrangThue=0 là đang được thuê, = 1 là chưa được thuê)
INSERT INTO NhaThue VALUES
('10000000', 'NHA00001', '4', '2020-01-01', '2020-12-31', '1', '0'),
('10000000', 'NHA00002', '4', '2020-01-01', '2020-12-31', '1', '0'),
('10000000', 'NHA00003', '4', '2020-01-01', '2020-12-31', '1', '0'),
('10000000', 'NHA00004', '4', '2020-01-01', '2020-12-31', '1', '0'),
('10000000', 'NHA00005', '4', '2020-01-01', '2020-12-31', '1', '0')

--NhaBan (GiaBan, DieuKien, MaNha, SoLuongPhong, NgayDang, NgayHetHan, SoLuotXem, TinhTrangBan) (TinhTrangBan = 0 là đã bán, = 1 là chưa bán)
INSERT INTO NhaBan VALUES
('2500000000', N'Đặt cọc trước 20%.','NHA00006', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00007', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00008', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00009', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00010', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00011', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00012', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00013', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00014', '6', '2020-01-01', '2020-12-31', '1', '1'),
('2500000000', N'Đặt cọc trước 20%.','NHA00015', '6', '2020-01-01', '2020-12-31', '1', '1')

--NguoiThue (MaNT, TenNT, DiaChi, SDT, TieuChi, MaCN, YeuCau) (TieuChi là tiền)
INSERT INTO NguoiThue VALUES
('NT000001', N'Đỗ Hoàng Minh', N'36 Nguyen Thi Tan, Phuong 2, Quan 8, Ho Chi Minh', '0938569076', '20000000', 'CN000001', 'LOAI03')
INSERT INTO NguoiThue VALUES
('NT000002', N'An Ðức Cường', N'11 Nguyen Dinh Chieu, Dakao , Quan 1, Ho Chi Minh', '0838226173', '20000000', 'CN000002', 'LOAI03')
INSERT INTO NguoiThue VALUES
('NT000003', N'Nguyễn Xuân Huy', N'39 Su Van Hanh, Phuong 12, Quan 10, Ho Chi Minh', '0938459372', '20000000', 'CN000003', 'LOAI02')
INSERT INTO NguoiThue VALUES
('NT000004', N'Lê Xuân Trang', N'5 Phan Dang Luu, Phuong 7, Phu Nhuan, Ho Chi Minh', '0838256173', '20000000', 'CN000004', 'LOAI01')
INSERT INTO NguoiThue VALUES
('NT000005', N'Bùi Tú Sương', N'198 Co Giang, Co Giang, Quan 1, Ho Chi Minh', '0939204964', '20000000', 'CN000005', 'LOAI04')
INSERT INTO NguoiThue VALUES
('NT000006', N'Phan Ðình Thiện', N'18 Nguyen Dinh Chieu, Dakao , Quan 1, Ho Chi Minh', '0839951661', '20000000', 'CN000001', 'LOAI03')
INSERT INTO NguoiThue VALUES
('NT000007', N'Phạm Tuấn Khang', N'1 Vo Van Ngan, Thu Duc, Ho Chi Minh', '0839231668', '20000000', 'CN000001', 'LOAI02')

--LichSuXem (MaNha, MaNT, NgayXem, NhanXet)
INSERT INTO LichSuXem VALUES
('NHA00001', 'NT000001', '2020-01-02', N'Nhà đẹp. Thuê luôn.'),
('NHA00002', 'NT000002', '2020-01-02', N'Nhà đẹp. Thuê luôn.'),
('NHA00003', 'NT000003', '2020-01-02', N'Nhà đẹp. Thuê luôn.'),
('NHA00004', 'NT000004', '2020-01-02', N'Nhà đẹp. Thuê luôn.'),
('NHA00005', 'NT000005', '2020-01-02', N'Nhà đẹp. Thuê luôn.'),
('NHA00006', 'NT000006', '2020-01-02', N'Nhà đẹp. Mua luôn.'),
('NHA00007', 'NT000007', '2020-01-02', N'Nhà đẹp. Mua luôn.')

--HopDong (MaHD, LoaiHD, ThoiGian, MaNT, MaNha), LoaiHD = 0 là bán, 1 là thuê
INSERT INTO HopDong (LoaiHD, ThoiGian,MaNT,MaNha) VALUES
('1', '2020-01-03', 'NT000001', 'NHA00001'),
('1', '2020-01-03', 'NT000002', 'NHA00002'),
('1', '2020-01-03', 'NT000003', 'NHA00003'),
('1', '2020-01-03', 'NT000004', 'NHA00004'),
('1', '2020-01-03', 'NT000005', 'NHA00005')

select * from HopDong