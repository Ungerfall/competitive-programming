<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT S.stock_name
    ,SUM(CASE WHEN S.operation = 'Buy' THEN -1 ELSE 1 END * S.price) AS capital_gain_loss
FROM Stocks AS S
GROUP BY S.stock_name