
CREATE DATABASE K22CNT3_TranDuyVu_2210900138_db;
USE K22CNT3_TranDuyVu_2210900138_db;

CREATE TABLE QUAN_TRI (
    AdminID VARCHAR(50) PRIMARY KEY,
    TenDangNhap VARCHAR(50),
    MatKhau VARCHAR(30),
    Email VARCHAR(100)
);

CREATE TABLE Game (
    GameID INT PRIMARY KEY,
    Ten VARCHAR(100),
    TheLoai VARCHAR(50),
    MoTa VARCHAR(500),
    NgayPhatHanh DATETIME,
    NhaPhatTrien VARCHAR(100),
    DanhGia TINYINT
);

CREATE TABLE KHACH_HANG (
    KhachHangID INT PRIMARY KEY,
    Ten NVARCHAR(100),
    DiaChi NVARCHAR(200),
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    NgayThamGia DATE
);

CREATE TABLE DANH_GIA (
    ReviewID INT PRIMARY KEY,
    GameID INT,
    AdminID VARCHAR(50),
    KhachHangID INT,
    NoiDungDanhGia Varchar(500),
    DanhGia TINYINT,
    NgayDanhGia DATETIME,
    FOREIGN KEY (GameID) REFERENCES Game(GameID),
    FOREIGN KEY (AdminID) REFERENCES QUAN_TRI(AdminID),
    FOREIGN KEY (KhachHangID) REFERENCES KHACH_HANG(KhachHangID)
);

INSERT INTO QUAN_TRI (AdminID, TenDangNhap, MatKhau, Email) VALUES
('A001', 'TDV', '25112004', 'duyvutran2004@gmail.com'),
('A002', 'admin2', 'password456', 'admin2@gmail.com'),
('A003', 'admin3', 'password789', 'admin3@gmail.com'),
('A004', 'admin4', 'password101', 'admin4@gmail.com'),
('A005', 'admin5', 'password202', 'admin5@gmail.com');


INSERT INTO Game (GameID, Ten, TheLoai, MoTa, NgayPhatHanh, NhaPhatTrien, DanhGia) VALUES
(1, 'Touhou 1', 'Bullet Hell', 'Highly Responsive to Prayers', '1996-11-25', 'ZUN SOFT', 5),
(2, 'Touhou 2', 'Bullet Hell', 'Story of Eastern Wonderland', '1997-08-15', 'ZUN SOFT', 5),
(3, 'Touhou 3', 'Bullet Hell', 'Phantasmagoria of Dim.Dream', '1997-12-29', 'ZUN SOFT', 5),
(4, 'Touhou 4', 'Bullet Hell', 'Lotus Land Story', '1998-08-14', 'ZUN SOFT', 5),
(5, 'Touhou 5', 'Bullet Hell', 'Mystic Square', '1998-12-30', 'ZUN SOFT', 5);

INSERT INTO KHACH_HANG (KhachHangID, Ten, DiaChi, Email, SoDienThoai, NgayThamGia) VALUES
(101, 'Tran Van A', 'Ha Noi', 'vana@gmail.com', '0912345678', '2022-10-01'),
(102, 'Nguyen Thi B', 'Ho Chi Minh', 'thib@gmail.com', '0912345679', '2021-11-15'),
(103, 'Le Minh C', 'Da Nang', 'minhc@gmail.com', '0912345680', '2023-01-25'),
(104, 'Pham Hong D', 'Hai Phong', 'hongd@gmail.com', '0912345681', '2020-08-05'),
(105, 'Vo Van E', 'Can Tho', 'vane@gmail.com', '0912345682', '2023-09-18');


INSERT INTO DANH_GIA (ReviewID, GameID, AdminID, KhachHangID, NoiDungDanhGia, DanhGia, NgayDanhGia) VALUES
(1, 1, 'A001', 101, 'Very fun game, enjoyed it a lot!', 5, '2023-10-10'),
(2, 2, 'A002', 102, 'Great bullet hell game!', 5, '2023-08-15'),
(3, 3, 'A003', 103, 'Challenging bullet hell, worth playing.', 5, '2023-09-20'),
(4, 4, 'A004', 104, 'Engaging strategy bullet hell.', 5, '2023-07-30'),
(5, 5, 'A005', 105, 'Amazing bullet hell experience!', 5, '2023-06-25');

SELECT * FROM QUAN_TRI;
SELECT * FROM Game;
SELECT * FROM KHACH_HANG;
SELECT * FROM DANH_GIA;

DROP TABLE IF EXISTS DANH_GIA;
DROP TABLE IF EXISTS KHACH_HANG;
DROP TABLE IF EXISTS Game;
DROP TABLE IF EXISTS QUAN_TRI;
