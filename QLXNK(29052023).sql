create database QLXNK2
use QLXNK2


create table KHOHANG
(
	MaKhoHang integer identity(1,1) primary key not null,
	LoaiKho	nvarchar(200) not null,
	TenKhohang nvarchar(255) not null,
	DiaChi nvarchar(255) not null,
	SDTKho varchar(20) not null,
	Succhua integer not null 
)

create table VITRIKHO
(
	MaVTK integer identity(1,1) primary key not null,
	TenVTK nvarchar(255) not null,
	MoTa nvarchar(255),
	MaKhoHang integer not null,
	foreign key (MaKhoHang) references KHOHANG on update cascade
)

create table NHACUNGCAP
(
	MaNCC integer identity(1,1) primary key not null,
	TenNCC nvarchar(255) not null,
	DiachiNCC nvarchar(255) not null,
	SDTNCC varchar(20) not null
)

create table NHOMSANPHAM
(
	MaNhomSP integer identity(1,1) primary key not null,
	TenNhomSP nvarchar(255) not null,
	Mota nvarchar(255)
)

create table SANPHAM
(
	MaSP integer identity(1,1) primary key not null,
	TenSP nvarchar(255) not null,
	Mota nvarchar(255), 
	DonGia float not null,
	DonViTinh varchar(50) not null,
	SoLuongTon integer not null,
	HinhAnh varchar(255),
	KhoiLuong float ,
	MaNCC integer not null,
	MaNhomSP integer not null,
	foreign key (MaNCC) references NHACUNGCAP on update cascade,
	foreign key (MaNhomSP) references NHOMSANPHAM on update cascade
)

create table VITRISP
(
	MaVTSP integer identity(1,1) primary key not null,
	SoLuong integer not null,
	MaSP integer not null,
	MaVTK integer not null,
	foreign key (MaSP) references SANPHAM on update cascade,
	foreign key (MaVTK) references VITRIKHO on update cascade
)

create table DONHANG
(
	MaDH integer identity(1,1) primary key not null,
	KhachHang nvarchar(255) not null,
	DiaChi nvarchar(255) not null,
	SDT varchar(20) not null,
	NgayLapDonHang date not null,
	GiaTriDH float not null
)

create table CHITIETDONHANG
(
	MaCTDH integer identity(1,1) primary key not null,
	MaSP integer not null,
	MaDH integer not null,
	DonGia float not null,
	SoLuong integer not null,
	foreign key (MaSP) references SANPHAM on update cascade,
	foreign key (MaDH) references DONHANG on update cascade
)

create table PHIEUNHAPKHO
(
	MaPNK integer identity(1,1) primary key not null,
	NgayNhap date not null,
	TongTien float not null,
	TongSPNhapKho integer not null,
	MaNCC integer not null,
	foreign key (MaNCC) references NHACUNGCAP on update cascade
)

create table CTPHIEUNHAPKHO
(
	MaCTPNK integer identity(1,1) primary key not null,
	MaSP integer not null,
	MaPNK integer not null,
	DonGia float not null,
	SoLuongNhap integer not null,
	foreign key (MaSP) references SANPHAM on update cascade,
	foreign key (MaPNK) references PHIEUNHAPKHO 
)

create table PHIEUXUATKHO
(
	MaPXK integer identity(1,1) primary key not null,
	NgayXuat date not null, 
	TongTien float not null,
	TongSPXuatKho integer not null
)

create table CTPHIEUXUATKHO
(
	MaCTPXK integer identity(1,1) primary key not null,
	MaSP integer not null,
	MaPXK integer not null,
	DonGia float not null,
	SoLuongXuat integer not null,
	foreign key (MaSP) references SANPHAM on update cascade,
	foreign key (MaPXK) references PHIEUXUATKHO on update cascade
)

create table CHUCVU
(
	MaCV integer identity(1,1) primary key not null,
	TenCV nvarchar(255) not null,
	MoTa nvarchar(255)
)

create table NHANVIEN
(
	MaNV integer identity(1,1) primary key not null,
	TenNV nvarchar(255) not null,
	Email varchar(255) not null,
	MatKhau varchar(50) not null,
	ImgUrl text ,
	MaCV integer not null,
	foreign key (MaCV) references CHUCVU on update cascade
)
create index 
on SANPHAM
select distinct Mota from SANPHAM 

SELECT top 1000  creation_time 
        ,last_execution_time
        ,total_physical_reads
        ,total_logical_reads 
        ,total_logical_writes
        , execution_count
        , total_worker_time
        , total_elapsed_time
        , total_elapsed_time / execution_count avg_elapsed_time
        ,SUBSTRING(st.text, (qs.statement_start_offset/2) + 1,
         ((CASE statement_end_offset
          WHEN -1 THEN DATALENGTH(st.text)
          ELSE qs.statement_end_offset END
            - qs.statement_start_offset)/2) + 1) AS statement_text
FROM sys.dm_exec_query_stats AS qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
ORDER BY total_elapsed_time / execution_count DESC


CREATE PROCEDURE GetProductAndTransactionData
AS
BEGIN
    SELECT p.TenSP, p.SoLuongTon, 
           SUM(pt.TongSPXuatKho) AS TransactionQuantity
    FROM SANPHAM p
    LEFT JOIN PHIEUXUATKHO pt ON p.MaSP = pt.MaPXK
    GROUP BY p.TenSP, p.SoLuongTon
END


CREATE PROCEDURE GetProductAndTransactionData
AS
BEGIN
    SELECT p.MaSP AS ProductId, p.TenSP AS ProductName, p.Mota AS ProductDescription, 
           p.DonGia AS ProductPrice, p.DonViTinh AS ProductUnit, p.SoLuongTon AS ProductQuantity, p.HinhAnh AS ProductImageUrl,
           p.KhoiLuong AS ProductWeight,
           t.MaPXK  AS TransactionId, t.NgayXuat AS TransactionDateTime, t.TongSPXuatKho AS TransactionTotal,
           COUNT(pt.MaSP) AS TransactionProductCount
    FROM SANPHAM p
    LEFT JOIN CTPHIEUXUATKHO  pt ON p.MaSP = pt.MaSP
    LEFT JOIN PHIEUXUATKHO t ON pt.MaPXK = t.MaPXK
    GROUP BY p.MaSP, p.TenSP, p.Mota, p.DonGia, p.DonViTinh, p.SoLuongTon, p.HinhAnh, p.KhoiLuong, 
             t.MaPXK, t.NgayXuat, t.TongSPXuatKho
END
drop procedure GetSalesData1

select * from SANPHAM
CREATE PROCEDURE [dbo].[GetSalesData1]
AS
BEGIN
SELECT p.TenSP, SUM(od.SoLuongXuat) AS Quantity
FROM SANPHAM p
INNER JOIN CTPHIEUXUATKHO od ON p.MaSP = od.MaSP
INNER JOIN PHIEUXUATKHO o ON od.MaPXK = o.MaPXK
GROUP BY p.TenSP
END