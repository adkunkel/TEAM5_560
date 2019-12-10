-- roster 
select t.TeamName, tp.Name, pi.Position, sum(ps.PassYards) as PassYards, sum(ps.RushYards) as RushYards, sum(ps.ReceivingYards) as ReceivingYards, sum(ps.Receptions) as Receptions, sum(ps.Touchdowns) as Touchdowns, sum(ps.Interceptions) as Interceptions, sum(ps.Fumbles) as Fumbles
from NFL.Teams t
	inner join Players.TeamPlayer tp on tp.TeamID = t.TeamID
	inner join Players.PlayerInfo pi on pi.PlayerID = tp.PlayerID
	inner join Players.PlayerStats ps on ps.PlayerID = tp.PlayerID
where t.TeamName = 'Kansas City Chiefs'
group by t.TeamName, tp.Name, pi.Position