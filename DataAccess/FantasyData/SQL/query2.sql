--Query 2
--Displays RBs ordered by touchdowns, rush yards, and name.
SELECT Player.Name, PS.Touchdowns, PS.RushYards, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
WHERE Player.Position = 'RB'
ORDER BY PS.Touchdowns DESC, PS.RushYards DESC, Player.Name ASC