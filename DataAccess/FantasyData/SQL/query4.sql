--Query 4
--Displays TEs ordered by touchdowns, receiving yards, receptions, and name.
SELECT Player.Name, PS.Touchdowns, PS.ReceivingYards, PS.Receptions, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
WHERE Player.Position = 'TE'
ORDER BY PS.Touchdowns DESC, PS.ReceivingYards DESC, PS.Receptions DESC, Player.Name ASC