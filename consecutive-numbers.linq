<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT DISTINCT t.Curr AS ConsecutiveNums
FROM (
    SELECT LAG(L.num, 2) OVER(ORDER BY L.id) AS BeforePrev
        ,LAG(L.num) OVER(ORDER BY L.id) AS Prev
        ,L.num AS Curr
    FROM Logs AS L
) AS t
WHERE t.BeforePrev = t.Prev
    AND t.Prev = t.Curr
