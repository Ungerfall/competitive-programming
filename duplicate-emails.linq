<Query Kind="SQL" />

k# Write your MySQL query statement below
SELECT P.email AS Email
FROM Person AS P
GROUP BY P.email
HAVING COUNT(P.email) > 1