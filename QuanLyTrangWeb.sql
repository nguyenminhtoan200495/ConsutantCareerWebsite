Use master
GO
if DB_ID ('QuanLyTrangWeb') is not null
Drop Database QuanLyTrangWeb
GO
Create Database QuanLyTrangWeb
GO
Use QuanLyTrangWeb
GO
Create Table TRUONG
(
	MATRUONG varchar(20),
	TENTRUONG nvarchar(50),
	LOAITRUONG nvarchar(20),
	Constraint PK_TRUONG
	Primary key (MATRUONG)
)
Create Table CHUYENNGANH
(
	MANGANH varchar(20),
	TENNGANH nvarchar(50),
	MATRUONG varchar(20),
	KHOITHI varchar(10),
	Constraint PK_CHUYENNGANH
	Primary key (MANGANH, KHOITHI)
)
Create Table DIEMCHUAN
(
	DIEM float,
	MANGANH varchar(20),
	KHOITHI varchar(10),
	NAM int,
	Constraint PK_DIEM
	Primary key (MANGANH, KHOITHI, NAM)
)

Create Table CAUHOI
(
	MACAUHOI int IDENTITY(1, 1) NOT NULL,
	TENCAUHOI nvarchar(50),
	NOIDUNG nvarchar(500),
	NGAYGUI datetime,	
	Constraint PK_CAUHOI
	Primary key (MACAUHOI)
)
Create Table CAUTRALOI
(
	MACAUTRALOI int IDENTITY(1, 1) NOT NULL,
	MACAUHOI int,
	TRALOI nvarchar(500),
	NGAYGUI datetime,
	HOTEN nvarchar(50),
	Constraint PK_CAUTRALOI
	Primary key (MACAUTRALOI)
)
Create Table THISINH
(
	ID int IDENTITY(1, 1) NOT NULL,
	SBD varchar(10),
	HOTEN nvarchar(50),
	NGAYSINH datetime,
	Constraint PK_THISINH
	Primary key (ID)
)
Create Table DIEMTHI
(
	ID int IDENTITY(1, 1) NOT NULL,
	SBD varchar(10),
	DIEM float,
	MATRUONG varchar(20),
	MANGANH varchar(20),
	KHOITHI varchar(10),
	Constraint PK_DIEMTHI
	Primary key (ID)
)
Create Table TUVAN
(
	ID int IDENTITY(1, 1) NOT NULL,
	SOTHICH nvarchar(50),
	MONHOCYEUTHICH nvarchar(50),
	DIEMMANH nvarchar(50),
	DIEMYEU nvarchar(50),
	KYNANG nvarchar(50),
	CONGVIEC nvarchar(50),
	TRALOI nvarchar(50),
	Constraint PK_TUVAN
	Primary key (ID)
)
Create Table ADMIN
(
	ID int IDENTITY(1, 1) NOT NULL,
	TAIKHOAN varchar(50),
	MATKHAU varchar(50),
	Constraint PK_ADMIN
	Primary key (ID)
)

Alter Table CHUYENNGANH
Add Constraint FK_CHUYENNGANH_TRUONG
Foreign key (MATRUONG)
References TRUONG(MATRUONG)

Alter Table DIEMCHUAN
Add Constraint FK_DIEMCHUAN_CHUYENNGANH
Foreign key (MANGANH, KHOITHI)
References CHUYENNGANH(MANGANH, KHOITHI)

Alter Table CAUTRALOI
Add Constraint FK_CAUTRALOI_CAUHOI
Foreign key (MACAUHOI)
References CAUHOI(MACAUHOI)

Alter Table DIEMTHI
Add Constraint FK_DIEMTHI_TRUONG
Foreign key (MATRUONG)
References TRUONG(MATRUONG),
Constraint FK_DIEMTHI_CHUYENNGANH
Foreign key (MANGANH, KHOITHI)
References CHUYENNGANH(MANGANH, KHOITHI)

INSERT TRUONG
	Values('DHKT', N'ĐẠI HỌC KINH TẾ TP.HCM', N'ĐẠI HỌC'),
		('DHKHTN', N'ĐẠI HỌC KHOA HỌC TỰ NHIÊN TP.HCM', N'ĐẠI HỌC'),
		('DHSP', N'ĐẠI HỌC SƯ PHẠM TP.HCM', N'ĐẠI HỌC')
INSERT CHUYENNGANH
	Values('KT001', N'KẾ TOÁN', 'DHKT', 'A'),
		('KT001', N'KẾ TOÁN', 'DHKT', 'A1'),
		('KT002', N'KIỂM TOÁN', 'DHKT', 'A'),
		('KT002', N'KIỂM TOÁN', 'DHKT', 'A1'),
		('TN001', N'CÔNG NGHỆ THÔNG TIN', 'DHKHTN', 'A'),
		('TN001', N'CÔNG NGHỆ THÔNG TIN', 'DHKHTN', 'A1'),
		('TN002', N'TOÁN TIN', 'DHKHTN', 'A'),
		('TN002', N'TOÁN TIN', 'DHKHTN', 'A1'),
		('TN003', N'CÔNG NGHỆ SINH HỌC', 'DHKHTN', 'A1'),
		('TN003', N'CÔNG NGHỆ SINH HỌC', 'DHKHTN', 'B'),
		('SP001', N'GIÁO VIÊN MẦM NON', 'DHSP', 'A'),
		('SP001', N'GIÁO VIÊN MẦM NON', 'DHSP', 'A1'),
		('SP002', N'GIÁO VIÊN TIỂU HỌC', 'DHSP', 'A'),
		('SP002', N'GIÁO VIÊN TIỂU HỌC', 'DHSP', 'A1')
INSERT DIEMCHUAN
	Values(20.5, 'KT001', 'A', 2015),
		(21, 'KT001', 'A1', 2015),
		(20.5, 'KT002', 'A', 2015),
		(21, 'KT002', 'A1', 2015),
		(21, 'TN001', 'A', 2015),
		(21.5, 'TN001', 'A1', 2015),
		(20, 'TN002', 'A', 2015),
		(20.5, 'TN002', 'A1', 2015),
		(21, 'TN003', 'A1', 2015),
		(21, 'TN003', 'B', 2015),
		(19.5, 'SP001', 'A', 2015),
		(19.5, 'SP001', 'A1', 2015),
		(20, 'SP002', 'A', 2015),
		(20, 'SP002', 'A1', 2015)
INSERT CAUHOI
	Values(N'Sức khỏe', N'Sức khỏe là một vấn đề quan trọng', '11/05/2015'),
		(N'Dinh dưỡng', N'Dinh dưỡng là một vấn đề quan trọng', '11/05/2015'),
		(N'Điểm chuẩn', N'Điểm chuẩn có thể tăng nhẹ',  '11/05/2015')
INSERT CAUTRALOI
	Values(1, N'Làm sao để có sức khỏe tốt?', '11/05/2015', N'Nguyễn Minh Tiến'),
		(2, N'Làm sao để có chế độ dinh dưỡng thích hợp?', '11/05/2015', N'Nguyễn Minh Tiến'),
		(3, N'Điểm chuẩn 2015 liệu rằng có tăng?', '11/05/2015', N'Nguyễn Anh Như'),
		(1, N'Liệu rằng có nên ngủ quá muộn?', '11/05/2015', N'Nguyễn Như Thủy')
INSERT THISINH
	Values('600', N'Nguyễn Minh Tiến', '03/01/1991'),
		('601', N'Nguyễn Minh Trung', '03/27/1991'),
		('602', N'Nguyễn Minh Trí', '08/30/1991')
INSERT DIEMTHI
	Values('600', 24, 'DHKHTN', 'TN001', 'A'),
		('601', 23, 'DHKHTN', 'TN002', 'A1'),
		('602', 22, 'DHKT', 'KT001', 'A')
INSERT TUVAN
	Values(N'Nghe nhạc, chơi games', N'Tin Học', N'Tư duy logic', N'Rụt rè', N'Phát triển máy tính', N'Lập trình viên', null),
		(N'Nghe nhạc, thể thao', N'Toán', N'Tư duy logic', N'Rụt rè', N'Quản lý sổ sách', N'Kiểm toán', null)
INSERT ADMIN
	Values('nguyenminhtiend', 'tien859694'),
		('nguyenminhtoan1995', 'toan859694')