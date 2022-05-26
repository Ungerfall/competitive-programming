<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT S.score
    ,DENSE_RANK() OVER(ORDER BY S.score DESC) AS 'rank'
FROM Scores AS S
ORDER BY S.score DESC