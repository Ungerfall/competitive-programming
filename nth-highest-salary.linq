<Query Kind="SQL" />

CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  RETURN (
    # Write your MySQL query statement below.
    (SELECT t.salary
	FROM (
	    SELECT DENSE_RANK() OVER(ORDER BY e.salary DESC) AS DenseRank
	        ,e.salary
	    FROM Employee AS e
	) t
	WHERE t.DenseRank = N
	LIMIT 1 OFFSET 0)

	UNION

	(SELECT NULL AS salary)
	LIMIT 1 OFFSET 0
  );
END