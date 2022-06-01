<Query Kind="SQL" />

# Write your MySQL query statement below
(SELECT t.salary AS SecondHighestSalary
FROM (
    SELECT DENSE_RANK() OVER(ORDER BY e.salary DESC) AS DenseRank
        ,e.salary
    FROM Employee AS e
) t
WHERE t.DenseRank = 2
LIMIT 1 OFFSET 0)

UNION

(SELECT NULL AS SecondHighestSalary)
LIMIT 1 OFFSET 0