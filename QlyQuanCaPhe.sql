CREATE DATABASE QUANLYQUANCAPHE
GO
USE QUANLYQUANCAPHE
GO

-- =============================================
-- 1. TÀI KHOẢN HỆ THỐNG
-- =============================================
CREATE TABLE Account (
    AccID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE, -- Không được trùng tên đăng nhập
    UserPassword NVARCHAR(255) NOT NULL, -- Độ dài lớn để lưu Hash mật khẩu [cite: 35]
    Email NVARCHAR(100) NOT NULL UNIQUE, -- Phục vụ OTP/Quên mật khẩu [cite: 84, 104]
    PhoneNumber NVARCHAR(15),
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Waiter', 'Kitchen', 'Customer')),
    CreatedAt SMALLDATETIME DEFAULT GETDATE()
)
GO

-- =============================================
-- 2. THÔNG TIN NHÂN VIÊN & KHÁCH HÀNG
-- =============================================
CREATE TABLE Employees (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    AccID INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(15),
    FOREIGN KEY (AccID) REFERENCES Account(AccID) ON DELETE CASCADE
)
GO

CREATE TABLE Customers (
    CustID INT IDENTITY(1,1) PRIMARY KEY,
    AccID INT NULL, -- Có thể là khách vãng lai không cần tài khoản
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE,
    Points FLOAT DEFAULT 0 CHECK (Points >= 0), -- Điểm tích lũy không âm [cite: 77, 93]
    FOREIGN KEY (AccID) REFERENCES Account(AccID) ON DELETE SET NULL
)
GO

-- =============================================
-- 3. THỰC ĐƠN & BÀN ĂN
-- =============================================
CREATE TABLE Category (
    CatID INT IDENTITY(1,1) PRIMARY KEY,
    CatName NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Products (
    ProdID INT IDENTITY(1,1) PRIMARY KEY,
    CatID INT NOT NULL,
    ProdName NVARCHAR(100) NOT NULL,
    Price MONEY NOT NULL CHECK (Price >= 0),
    ProductStatus NVARCHAR(20) DEFAULT N'Còn hàng' CHECK (ProductStatus IN (N'Còn hàng', N'Hết hàng')),
    FOREIGN KEY (CatID) REFERENCES Category(CatID)
)
GO

CREATE TABLE TableFood (
    TableID INT IDENTITY(1,1) PRIMARY KEY,
    TableName NVARCHAR(50) NOT NULL,
    TableStatus NVARCHAR(20) DEFAULT N'Trống' CHECK (TableStatus IN (N'Trống', N'Có khách', N'Đã đặt')) 
)
GO

-- =============================================
-- 4. ĐƠN HÀNG & CHI TIẾT (XỬ LÝ REAL-TIME)
-- =============================================
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    TableID INT NOT NULL,
    EmpID INT NOT NULL, -- Nhân viên phục vụ tạo đơn
    OrderDate SMALLDATETIME DEFAULT GETDATE(),
    OrderStatus INT DEFAULT 0 CHECK (OrderStatus IN (0, 1, 2, 3)), -- 0: Chờ, 1: Pha chế, 2: Xong, 3: Hủy [cite: 100]
    FOREIGN KEY (TableID) REFERENCES TableFood(TableID),
    FOREIGN KEY (EmpID) REFERENCES Employees(EmpID)
)
GO

CREATE TABLE OrderInfo (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProdID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Notes NVARCHAR(255), -- Ghi chú yêu cầu đặc biệt [cite: 91]
    ItemStatus INT DEFAULT 0 CHECK (ItemStatus IN (0, 1)), -- 0: Đang làm, 1: Đã xong
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProdID) REFERENCES Products(ProdID)
)
GO

-- =============================================
-- 5. KHUYẾN MÃI & HÓA ĐƠN
-- =============================================
CREATE TABLE VoucherList (
    VoucherID INT IDENTITY(1,1) PRIMARY KEY,
    VoucherCode NVARCHAR(50) NOT NULL UNIQUE,
    SalePercentage FLOAT CHECK (SalePercentage BETWEEN 0 AND 100),
    MaxSaleAmount MONEY CHECK (MaxSaleAmount >= 0),
    StartDate SMALLDATETIME NOT NULL DEFAULT GETDATE(), 
    ExpDate SMALLDATETIME NOT NULL,
    -- Thời điểm tạo bản ghi (Dùng để kiểm toán/Audit)
    CreatedAt SMALLDATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    CONSTRAINT CHK_VoucherDate CHECK (ExpDate > StartDate)
)
GO

CREATE TABLE Bills (
    BillID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL UNIQUE, -- Một đơn hàng chỉ có một hóa đơn [cite: 77]
    VoucherID INT NULL,
    CustID INT NULL,
    PayDate SMALLDATETIME DEFAULT GETDATE(),
    TotalPrice MONEY NOT NULL,
    FinalPrice MONEY NOT NULL,
    CashReceived MONEY CHECK (CashReceived >= 0), --**cashreceived > finalprice
    CONSTRAINT CHK_Payment CHECK (CashReceived > FinalPrice),
    ChangePrice AS (CashReceived - FinalPrice), -- Tiền thừa tự động tính
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (VoucherID) REFERENCES VoucherList(VoucherID),
    FOREIGN KEY (CustID) REFERENCES Customers(CustID)
)
GO

-- =============================================
-- 6. QUẢN LÝ KHO & CÔNG THỨC
-- =============================================
CREATE TABLE Ingredients (
    IngID INT IDENTITY(1,1) PRIMARY KEY,
    IngName NVARCHAR(100) NOT NULL,
    Quantity FLOAT NOT NULL CHECK (Quantity >= 0),
    Unit NVARCHAR(20) NOT NULL -- Gram, Lít... [cite: 77, 94]
    CONSTRAINT CHK_Unit CHECK (Unit IN (N'gram', N'lít', N'ml', N'cái', N'hộp', N'kg'))
)
GO

CREATE TABLE IngReceipts (
    ReceiptID INT IDENTITY(1,1) PRIMARY KEY,
    IngID INT NOT NULL,
    ImportDate SMALLDATETIME DEFAULT GETDATE(),
    ImportQuantity FLOAT NOT NULL CHECK (ImportQuantity > 0),
    TotalCost MONEY NOT NULL,
    Source NVARCHAR(100),
    FOREIGN KEY (IngID) REFERENCES Ingredients(IngID)
)
GO

CREATE TABLE Recipe (
    ProdID INT NOT NULL,
    IngID INT NOT NULL,
    Amount FLOAT NOT NULL CHECK (Amount > 0), -- Lượng tiêu hao
    PRIMARY KEY (ProdID, IngID),
    FOREIGN KEY (ProdID) REFERENCES Products(ProdID),
    FOREIGN KEY (IngID) REFERENCES Ingredients(IngID)
)
GO

-- =============================================
-- 7. CHAT & PHẢN HỒI (CHO NT106 & ANTT)
-- =============================================
CREATE TABLE Feedbacks (
    FeedID INT IDENTITY(1,1) PRIMARY KEY,
    AccID INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    FeedDate SMALLDATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AccID) REFERENCES Account(AccID)
)
GO

CREATE TABLE Messages (
    MsgID INT IDENTITY(1,1) PRIMARY KEY,
    SenderID INT NOT NULL,
    ReceiverID INT NULL, -- NULL nếu là thông báo chung (Broadcast) [cite: 75, 87]
    Content NVARCHAR(MAX) NOT NULL,
    SendTime SMALLDATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    FOREIGN KEY (SenderID) REFERENCES Account(AccID),
    FOREIGN KEY (ReceiverID) REFERENCES Account(AccID)
)
GO


--**********

