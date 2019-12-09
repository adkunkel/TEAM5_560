--Query 3
--Displays WRs ordered by touchdowns, receiving yards, receptions, and name.
SELECT Player.Name, PS.Touchdowns, PS.ReceivingYards, PS.Receptions, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
WHERE Player.Position = 'WR'
ORDER BY PS.Touchdowns DESC, PS.ReceivingYards DESC, PS.Receptions DESC, Player.Name ASC