-- 1. Quản lý Tài khoản & Nhân viên
CREATE TABLE UserAccount (
    MaNguoiDung SERIAL PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau TEXT NOT NULL, 
    VaiTro VARCHAR(20) NOT NULL CHECK (VaiTro IN ('Admin', 'Waiter', 'Kitchen')),
    HoTen TEXT NOT NULL,
    SDT VARCHAR(15),
    Email VARCHAR(100) UNIQUE,
    TrangThai BOOLEAN DEFAULT TRUE, -- TRUE: Hoạt động, FALSE: Bị khóa
    NgayTao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    -- Phục vụ Token & Login
    Token TEXT,
    ThoiGianHetHanToken TIMESTAMP,
    TrangThaiOnline BOOLEAN DEFAULT FALSE,
    ThoiGianDangNhap TIMESTAMP,
    ThoiGianDangXuat TIMESTAMP
);

-- 2. Quản lý Thực đơn
CREATE TABLE LoaiMon (
    MaLoaiMon SERIAL PRIMARY KEY,
    TenLoai TEXT NOT NULL,
    MoTa TEXT,
    TrangThai BOOLEAN DEFAULT TRUE
);

CREATE TABLE Menu (
    MaMon SERIAL PRIMARY KEY,
    TenMon TEXT NOT NULL,
    Gia NUMERIC(12, 2) NOT NULL CHECK (Gia >= 0),
    MoTa TEXT,
    TrangThai TEXT DEFAULT 'Còn hàng',
    MaLoaiMon INT REFERENCES LoaiMon(MaLoaiMon) ON DELETE SET NULL
);

-- 3. Quản lý Bàn ăn
CREATE TABLE BanAn (
    MaBanAn SERIAL PRIMARY KEY,
    TenBan TEXT NOT NULL,
    SoChoNgoi INT DEFAULT 2,
    TrangThai TEXT DEFAULT 'Trống' CHECK (TrangThai IN ('Trống', 'Có khách', 'Đã đặt')),
    MaNhanVien INT REFERENCES UserAccount(MaNguoiDung), -- Nhân viên phụ trách bàn
    NgayTao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 4. Khách hàng & Khuyến mãi (Bổ sung theo yêu cầu)
CREATE TABLE KhachHang (
    MaKH SERIAL PRIMARY KEY,
    TenKH TEXT,
    SDT VARCHAR(15) NOT NULL UNIQUE,
    DiemTichLuy FLOAT DEFAULT 0 CHECK (DiemTichLuy >= 0),
    NgayDangKy TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE KhuyenMai (
    MaKM SERIAL PRIMARY KEY,
    CodeKM VARCHAR(50) NOT NULL UNIQUE,
    MoTa TEXT,
    LoaiKM VARCHAR(20) CHECK (LoaiKM IN ('Phần trăm', 'Số tiền')),
    GiaTriGiam NUMERIC(12, 2) NOT NULL,
    GiamToiDa NUMERIC(12, 2), -- Dùng khi giảm theo %
    NgayBatDau TIMESTAMP NOT NULL,
    NgayHetHan TIMESTAMP NOT NULL,
    SoLuongDung INT DEFAULT 0,
    GioiHanDung INT,
    TrangThai BOOLEAN DEFAULT TRUE,
    CONSTRAINT CHK_HSD CHECK (NgayHetHan > NgayBatDau)
);

-- 5. Đơn hàng & Chế biến (Dành cho Phục vụ và Bếp)
CREATE TABLE DonHang (
    MaDonHang SERIAL PRIMARY KEY,
    MaBanAn INT NOT NULL REFERENCES BanAn(MaBanAn),
    MaNVOrder INT NOT NULL REFERENCES UserAccount(MaNguoiDung),
    NgayOrder TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    TrangThai INT DEFAULT 0, -- 0: Mới, 1: Đang chế biến, 2: Hoàn thành, 3: Đã hủy
    TenKH TEXT, -- Khách vãng lai không cần lưu MaKH
    SDTKH VARCHAR(15),
    GhiChu TEXT,
    LoaiDonHang VARCHAR(20) DEFAULT 'Tại chỗ'
);

CREATE TABLE CTDonHang (
    MaCT SERIAL PRIMARY KEY,
    MaDonHang INT NOT NULL REFERENCES DonHang(MaDonHang) ON DELETE CASCADE,
    MaMon INT NOT NULL REFERENCES Menu(MaMon),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia NUMERIC(12, 2) NOT NULL,
    GhiChuKhach TEXT,
    GhiChuBep TEXT,
    MaNhanVienCheBien INT REFERENCES UserAccount(MaNguoiDung),
    UuTien BOOLEAN DEFAULT FALSE,
    ThoiGianBatDau TIMESTAMP,
    ThoiGianHoanThanh TIMESTAMP,
    ThoiGianDuKien INT, -- Số phút dự kiến
    TrangThaiItem INT DEFAULT 0 -- 0: Chờ, 1: Đang làm, 2: Xong
);

-- 6. Hóa đơn & Thanh toán (Kế toán & Giảm giá)
CREATE TABLE HoaDon (
    MaHD SERIAL PRIMARY KEY,
    MaDonHang INT UNIQUE NOT NULL REFERENCES DonHang(MaDonHang),
    MaBanAn INT REFERENCES BanAn(MaBanAn),
    MaNV INT NOT NULL REFERENCES UserAccount(MaNguoiDung),
    MaKH INT REFERENCES KhachHang(MaKH), -- Để tích điểm
    MaKM INT REFERENCES KhuyenMai(MaKM), -- Để áp mã giảm giá
    NgayTao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    TongTien NUMERIC(12, 2) NOT NULL, -- Tiền trước giảm giá
    SoTienGiam NUMERIC(12, 2) DEFAULT 0,
    ThanhTien NUMERIC(12, 2) NOT NULL, -- Tiền thực tế khách phải trả
    TrangThai VARCHAR(20) DEFAULT 'Chưa thanh toán',
    PhuongThucThanhToan TEXT,
    GhiChu TEXT
);

CREATE TABLE ThanhToan (
    MaGiaoDich SERIAL PRIMARY KEY,
    MaHD INT NOT NULL REFERENCES HoaDon(MaHD),
    MaNhanVien INT NOT NULL REFERENCES UserAccount(MaNguoiDung),
    SoTienNhan NUMERIC(12, 2) NOT NULL,
    SoTienThua NUMERIC(12, 2) DEFAULT 0,
    MaGiaoDichNganHang TEXT, -- Nếu chuyển khoản
    ThoiGianThanhToan TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    QRCodeURL TEXT, -- URL QR thanh toán
    GhiChu TEXT
);

-- 7. Tin nhắn nội bộ
CREATE TABLE TinNhan (
    MaTinNhan SERIAL PRIMARY KEY,
    MaNguoiGui INT NOT NULL REFERENCES UserAccount(MaNguoiDung),
    MaNguoiNhan INT REFERENCES UserAccount(MaNguoiDung),
    NoiDung TEXT NOT NULL,
    ThoiGian TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    DaDoc BOOLEAN DEFAULT FALSE
);