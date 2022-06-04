<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT C.name AS Customers
FROM Customers AS C
WHERE NOT EXISTS(
    SELECT 1
    FROM Orders AS O
    WHERE O.customerId = C.id)