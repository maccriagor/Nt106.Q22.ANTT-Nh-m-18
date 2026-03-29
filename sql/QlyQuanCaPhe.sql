-- 1. Tài khoản hệ thống
CREATE TABLE Account (
    AccID SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    UserPassword TEXT NOT NULL, 
    Email VARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(15),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Waiter', 'Kitchen', 'Customer')),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 2. Nhân viên & Khách hàng
CREATE TABLE Employees (
    EmpID SERIAL PRIMARY KEY,
    AccID INT NOT NULL REFERENCES Account(AccID) ON DELETE CASCADE,
    FullName TEXT NOT NULL,
    Position TEXT NOT NULL,
    PhoneNumber VARCHAR(15)
);

CREATE TABLE Customers (
    CustID SERIAL PRIMARY KEY,
    AccID INT REFERENCES Account(AccID) ON DELETE SET NULL,
    FullName TEXT NOT NULL,
    PhoneNumber VARCHAR(15) UNIQUE,
    Points FLOAT DEFAULT 0 CHECK (Points >= 0)
);

-- 3. Thực đơn & Bàn
CREATE TABLE Category (
    CatID SERIAL PRIMARY KEY,
    CatName TEXT NOT NULL
);

CREATE TABLE Products (
    ProdID SERIAL PRIMARY KEY,
    CatID INT NOT NULL REFERENCES Category(CatID),
    ProdName TEXT NOT NULL,
    Price NUMERIC NOT NULL CHECK (Price >= 0),
    ProductStatus TEXT DEFAULT 'Còn hàng'
);

CREATE TABLE TableFood (
    TableID SERIAL PRIMARY KEY,
    TableName TEXT NOT NULL,
    TableStatus TEXT DEFAULT 'Trống' CHECK (TableStatus IN ('Trống', 'Có khách', 'Đã đặt'))
);

-- 4. Đơn hàng & Chi tiết
CREATE TABLE Orders (
    OrderID SERIAL PRIMARY KEY,
    TableID INT NOT NULL REFERENCES TableFood(TableID),
    EmpID INT NOT NULL REFERENCES Employees(EmpID),
    OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    OrderStatus INT DEFAULT 0 CHECK (OrderStatus IN (0, 1, 2, 3))
);

CREATE TABLE OrderInfo (
    OrderItemID SERIAL PRIMARY KEY,
    OrderID INT NOT NULL REFERENCES Orders(OrderID) ON DELETE CASCADE,
    ProdID INT NOT NULL REFERENCES Products(ProdID),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Notes TEXT,
    ItemStatus INT DEFAULT 0 CHECK (ItemStatus IN (0, 1))
);

-- 5. Khuyến mãi & Hóa đơn
CREATE TABLE VoucherList (
    VoucherID SERIAL PRIMARY KEY,
    VoucherCode VARCHAR(50) NOT NULL UNIQUE,
    SalePercentage FLOAT CHECK (SalePercentage BETWEEN 0 AND 100),
    MaxSaleAmount NUMERIC CHECK (MaxSaleAmount >= 0),
    StartDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ExpDate TIMESTAMP NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    CONSTRAINT CHK_VoucherDate CHECK (ExpDate > StartDate)
);

CREATE TABLE Bills (
    BillID SERIAL PRIMARY KEY,
    OrderID INT NOT NULL UNIQUE REFERENCES Orders(OrderID),
    VoucherID INT REFERENCES VoucherList(VoucherID),
    CustID INT REFERENCES Customers(CustID),
    PayDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    TotalPrice NUMERIC NOT NULL,
    FinalPrice NUMERIC NOT NULL,
    CashReceived NUMERIC NOT NULL,
    ChangePrice NUMERIC GENERATED ALWAYS AS (CashReceived - FinalPrice) STORED,
    CONSTRAINT CHK_Payment CHECK (CashReceived >= FinalPrice)
);

-- 6. Kho & Tin nhắn
CREATE TABLE Ingredients (
    IngID SERIAL PRIMARY KEY,
    IngName TEXT NOT NULL,
    Quantity FLOAT NOT NULL CHECK (Quantity >= 0),
    Unit VARCHAR(20) NOT NULL CHECK (Unit IN ('gram', 'lít', 'ml', 'cái', 'hộp', 'kg'))
);

CREATE TABLE Messages (
    MsgID SERIAL PRIMARY KEY,
    SenderID INT NOT NULL REFERENCES Account(AccID),
    ReceiverID INT REFERENCES Account(AccID),
    Content TEXT NOT NULL,
    SendTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsRead BOOLEAN DEFAULT FALSE
);