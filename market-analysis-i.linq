# Write your MySQL query statement below
SELECT U.user_id AS buyer_id
    ,U.join_date
    ,COALESCE(t.orders_in_2019, 0) AS orders_in_2019
FROM Users AS U
LEFT OUTER JOIN (
    SELECT O.buyer_id
        ,COUNT(*) AS orders_in_2019
    FROM Orders AS O
    WHERE YEAR(O.order_date) = 2019
    GROUP BY O.buyer_id
) t ON t.buyer_id = U.user_id
