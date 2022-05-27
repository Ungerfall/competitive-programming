<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT T.id
    ,CASE
        WHEN T.p_id IS NULL THEN 'Root'
        WHEN NOT EXISTS (SELECT 1 FROM Tree WHERE p_id = T.id) THEN 'Leaf'
        ELSE 'Inner'
    END AS type
FROM Tree AS T
ORDER BY T.id