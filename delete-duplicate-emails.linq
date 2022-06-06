<Query Kind="SQL" />

# Please write a DELETE statement and DO NOT write a SELECT statement.
# Write your MySQL query statement below
DELETE FROM Person
WHERE id IN (
    SELECT t.id
    FROM (
        SELECT P.email
            ,P.id
            ,ROW_NUMBER() OVER(PARTITION BY P.email ORDER BY P.id) AS 'RowNumber'
        FROM Person AS P
    ) AS t
    WHERE t.RowNumber > 1
)