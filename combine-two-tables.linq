<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT P.firstName
    ,P.lastName
    ,A.city
    ,A.state
FROM Person AS P
LEFT OUTER JOIN Address AS A ON A.personId = P.personId
