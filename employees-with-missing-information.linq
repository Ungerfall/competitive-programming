<Query Kind="SQL" />

# Write your MySQL query statement below
(SELECT E.employee_id
FROM Employees AS E
WHERE E.name IS NULL
    OR NOT EXISTS (
        SELECT 1
        FROM Salaries AS S
        WHERE S.employee_id = E.employee_id
            AND S.salary IS NOT NULL))

UNION

(SELECT S.employee_id
FROM Salaries AS S
WHERE S.salary IS NULL
    OR NOT EXISTS(
        SELECT 1
        FROM Employees AS E
        WHERE E.employee_id = S.employee_id
            AND E.name IS NOT NULL))
ORDER BY 1            
