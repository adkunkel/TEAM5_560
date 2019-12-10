--Query --Query 2
--Displays RBs ordered by touchdowns, rush yards, and name.
SELECT Player.Name, TG.Week, PS.Touchdowns, PS.RushYards, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
	INNER JOIN Games.TeamGame TG ON PS.TeamGameID = TG.GameID
WHERE Player.Position = 'RB'
GROUP BY Player.Name, TG.Week, PS.Touchdowns, PS.RushYards, Player.Position
ORDER BY PS.Touchdowns DESC, PS.RushYards DESC, Player.Name ASC;