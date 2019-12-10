select  tp.Name, t.TeamName, sum(ks.FGGD) as FGGD, sum(ks.FGNG) as FGNG, sum(ks.XPMade) as XPMade, sum(ks.XPMissed) as XPMissed
from Players.TeamPlayer tp
	inner join Players.KickerStats ks on ks.PlayerID = tp.PlayerID
	inner join NFL.Teams t on t.TeamID = tp.TeamID
group by  t.TeamName, tp.Name
order by t.TeamName