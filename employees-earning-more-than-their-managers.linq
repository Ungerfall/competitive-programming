<Query Kind="SQL" />

# Write your MySQL query statement below
/*
SELECT E.name AS Employee
FROM Employee AS E
INNER JOIN Employee AS M ON M.id = E.managerId
WHERE E.salary > M.salary
*/
SELECT E.name AS Employee
FROM Employee AS E
WHERE EXISTS(
    SELECT 1
    FROM Employee AS M
    WHERE M.id = E.managerId
        AND E.salary > M.salary)
	