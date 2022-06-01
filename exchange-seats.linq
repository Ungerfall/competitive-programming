<Query Kind="SQL" />

# Write your MySQL query statement below
SELECT LeftSeat.id,
    CASE WHEN RightSeat.student IS NULL THEN LeftSeat.student ELSE RightSeat.student END AS student
FROM Seat AS LeftSeat
LEFT OUTER JOIN Seat AS RightSeat ON RightSeat.id = CASE
    WHEN LeftSeat.id % 2 = 1 THEN LeftSeat.id + 1
    ELSE LeftSeat.id - 1
END