--top 10
select Top 10 tp.Name, p.Touchdowns, tg.Week, pi.Position, t.TeamName
from Players.PlayerStats p
inner join Games.TeamGame tg on tg.TeamGameID = p.TeamGameID
inner join Players.TeamPlayer tp on tp.PlayerID = p.PlayerID
inner join Players.PlayerInfo pi on pi.PlayerID = tp.PlayerID
inner join NFL.Teams t on t.TeamID = tp.TeamID
where tg.Week = 1
Order by p.Touchdowns desc