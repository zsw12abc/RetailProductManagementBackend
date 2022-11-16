--Creating all tables

CREATE TABLE "Product"
(
    "Id"         INTEGER NOT NULL UNIQUE,
    "Name"       TEXT    NOT NULL,
    "Price"      REAL,
    "Active"     INTEGER CHECK ("Active" IN (0, 1)),
    "CreateDate" TEXT,
    "DeleteDate" TEXT,
    "Type"       INTEGER,
    FOREIGN KEY ("Type") REFERENCES "ProductType" ("ProductTypeId"),
    PRIMARY KEY ("Id" AUTOINCREMENT)
);

CREATE TABLE "ProductType"
(
    "ProductTypeId" INTEGER NOT NULL UNIQUE,
    "ProductType"   TEXT,
    PRIMARY KEY ("ProductTypeId" AUTOINCREMENT)
);

INSERT INTO "ProductType" ("ProductType")
VALUES ('Books'),
       ('Electronics'),
       ('Food'),
       ('Furniture'),
       ('Toys');

INSERT INTO Product (Name, Price, Active, CreateDate, DeleteDate, Type)
VALUES ('Product 1', 100, 1, '2019-01-01', NULL, 1),
       ('Product 2', 200, 1, '2019-01-01', NULL, 2),
       ('Product 3', 300, 0, '2019-01-01', NULL, 3),
       ('Product 4', 400, 0, '2019-01-01', NULL, 4),
       ('Product 5', 500, 1, '2019-01-01', NULL, 5),
       ('Product 6', 600, 1, '2019-01-01', NULL, 1),
       ('Product 7', 700, 1, '2019-01-01', NULL, 2),
       ('Product 8', 800, 0, '2019-01-01', NULL, 3),
       ('Product 9', 900, 0, '2019-01-01', NULL, 4),
       ('Product 10', 1000, 1, '2019-01-01', NULL, 5),
       ('Product 11', 1100, 1, '2019-01-01', NULL, 1),
       ('Product 12', 1200, 1, '2019-01-01', NULL, 2),
       ('Product 13', 1300, 0, '2019-01-01', NULL, 3),
       ('Product 14', 1400, 0, '2019-01-01', NULL, 4),
       ('Product 15', 1500, 1, '2019-01-01', NULL, 5),
       ('Product 16', 1600, 1, '2019-01-01', NULL, 1),
       ('Product 17', 1700, 1, '2019-01-01', NULL, 2),
       ('Product 18', 1800, 0, '2019-01-01', NULL, 3),
       ('Product 19', 1900, 0, '2019-01-01', NULL, 4),
       ('Product 20', 2000, 1, '2019-01-01', NULL, 5);


--Testing
SELECT Id, Name, Price, Active, CreateDate, DeleteDate, ProductType
FROM Product P
         INNER JOIN ProductType PT ON PT.ProductTypeId = P.Type;

UPDATE Product
SET Name   = 'Product Update 21',
    Price  = 100,
    Active = 0,
    Type   = ProductTypeId FROM Product INNER JOIN ProductType
ON ProductType = 'Books'
WHERE Id = 21;

SELECT Id
FROM Product
WHERE Id = 1 LIMIT 1;

INSERT INTO Product (Name, Price, Active, Type, CreateDate)
VALUES (@Name, @Price, @Active, (SELECT ProductTypeId FROM ProductType WHERE ProductType = @ProductType), @CreateDate)


UPDATE Product
SET Name   = 'Test223',
    Price  = 1001,
    Active = 1,
    Type   = PT.ProductTypeId FROM  ProductType PT
WHERE ProductType = 'Books' AND Product.Id = 23;

SELECT *
FROM Product P
         INNER JOIN ProductType PT ON PT.ProductTypeId = P.Type
WHERE p.Id = 23

SELECT ProductTypeId, ProductType
FROM ProductType