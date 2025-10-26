with recursive pickup_points_to_pay as (
	select pp.id,
		pp.prev_id,
		case when exists (select 1 from brand_data where pickup_point_id = pp.id) then 1 else 0 end as is_payed,
		pp.id as latest_id
	from pickup_point as pp
	where pp.branded_since = :targetDate

	union all

	select pp.id,
		pp.prev_id,
		case when exists (select 1 from brand_data where pickup_point_id = pp.id) then 1 else 0 end as is_payed,
		ppp.latest_id
	from pickup_points_to_pay as ppp
	inner join pickup_point as pp on pp.id = ppp.prev_id
	where pp.id <> ppp.prev_id
)
select ppp.latest_id as id
from pickup_points_to_pay as ppp
group by ppp.latest_id
having sum(ppp.is_payed) = 0;
