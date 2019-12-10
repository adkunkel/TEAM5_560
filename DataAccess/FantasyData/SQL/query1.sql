--Query 1
--Displays QBs ordered by touchdowns, pass yards, and name.
SELECT Player.Name, TG.Week, PS.Touchdowns, PS.PassYards, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
	INNER JOIN Games.TeamGame TG ON PS.TeamGameID = TG.GameID
WHERE Player.Position = 'QB'
GROUP BY Player.Name, TG.Week, PS.Touchdowns, PS.PassYards, Player.Position
ORDER BY PS.Touchdowns DESC, PS.PassYards DESC, Player.Name ASC;
