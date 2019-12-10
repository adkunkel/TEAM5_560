--defense stats
select  t.TeamName, sum(ds.PassYardsAllowed) as PassYardsAllowed, sum(ds.RushYardsAllowed) as RushYardsAllowed, sum(ds.Touchdowns) as TouchdownsAllowed, sum(ds.Safeties) as Safeties, sum(ds.Interceptions) as Interceptions, sum(ds.Fumbles) as Fumbles
from Players.TeamPlayer tp
	inner join Players.DefenseStats ds on ds.PlayerID = tp.PlayerID
	inner join NFL.Teams t on t.TeamID = tp.TeamID
group by  t.TeamName
order by t.TeamName