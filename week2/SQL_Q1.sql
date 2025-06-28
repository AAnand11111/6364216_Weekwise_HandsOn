-- Create and use the database
CREATE DATABASE OnlineRetailDb;
GO

USE OnlineRetailDB;
GO


-- Reset Products table if it exists
DROP TABLE IF EXISTS Products;


-- Create table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);


-- Insert sample products
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 800.00),
(4, 'Headphones', 'Accessories', 150.00),
(5, 'Mouse', 'Accessories', 150.00),
(6, 'Keyboard', 'Accessories', 100.00);


-- Exercise 1: ROW_NUMBER
SELECT 
    ProductID, ProductName, Category, Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;


-- Exercise 1: RANK
SELECT 
    ProductID, ProductName, Category, Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products;


-- Exercise 1: DENSE_RANK
SELECT 
    ProductID, ProductName, Category, Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;


-- Show only Top 3 products per category using ROW_NUMBER
WITH RankedProducts AS (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS rn
    FROM Products
)
SELECT * FROM RankedProducts WHERE rn <= 3;
