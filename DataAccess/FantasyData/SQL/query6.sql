--Query 6
--Displays Defenses ordered by touchdowns, safeties, and team name.
SELECT Team.TeamName, Defense.Touchdowns, Defense.Safeties, Defense.PassYardsAllowed, Defense.RushYardsAllowed
FROM Players.TeamPlayer AS TP
	INNER JOIN NFL.Teams AS Team ON Team.TeamID = TP.TeamID
	INNER JOIN Players.DefenseStats AS Defense ON Defense.PlayerID = TP.TeamID
ORDER BY Defense.Touchdowns DESC, Defense.Safeties DESC, Team.TeamName ASC