<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT T.request_at AS Day
    ,ROUND(
        SUM(CASE WHEN T.status IN ('cancelled_by_driver', 'cancelled_by_client') THEN 1 ELSE 0 END)
        / COUNT(1)       
        ,2) AS 'Cancellation Rate'
FROM Trips AS T
INNER JOIN Users AS CL ON CL.users_id = T.client_id
INNER JOIN Users AS DR ON DR.users_id = T.driver_id
WHERE CL.banned = 'No'
    AND DR.banned = 'No'
    AND T.request_at >= '2013-10-01'
    AND T.request_at < '2013-10-04'
GROUP BY T.request_at