--Query 6
--Displays Defenses ordered by pass yards, rush yards, touchdowns, and safeties.
SELECT T.TeamName, TG.Week, D.PassYardsAllowed, D.RushYardsAllowed, D.Touchdowns, D.Safeties, D.Interceptions, D.Fumbles
FROM NFL.Teams T
	INNER JOIN Players.DefenseStats D On D.PlayerID = T.TeamID
	INNER JOIN Games.TeamGame TG ON D.TeamGameID = TG.GameID
GROUP BY T.TeamName, TG.Week, D.PassYardsAllowed, D.RushYardsAllowed, D.Touchdowns, D.Safeties, D.Interceptions, D.Fumbles
ORDER BY D.Touchdowns ASC, D.Safeties DESC, D.PassYardsAllowed ASC, D.RushYardsAllowed ASC;