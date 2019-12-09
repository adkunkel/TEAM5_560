--Query 6
--Displays Defenses ordered by pass yards, rush yards, touchdowns, and safeties.
SELECT T.TeamName, D.PassYardsAllowed, D.RushYardsAllowed, D.Touchdowns, D.Safeties, D.Interceptions, D.Fumbles
FROM NFL.Teams T
	INNER JOIN Players.DefenseStats D On D.PlayerID = T.TeamID
ORDER BY D.PassYardsAllowed ASC, D.RushYardsAllowed ASC, D.Touchdowns DESC, D.Safeties DESC