<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT t.Department
    ,t.Employee
    ,t.Salary
FROM (
    SELECT E.name AS Employee
        ,E.salary AS Salary
        ,D.name AS Department
        ,DENSE_RANK() OVER(PARTITION BY D.id ORDER BY E.salary DESC) AS DenseRank
    FROM Employee AS E
    INNER JOIN Department AS D ON D.id = E.departmentId
) t
WHERE t.DenseRank <= 3