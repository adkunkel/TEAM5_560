--Query 3
--Displays WRs ordered by touchdowns, receiving yards, receptions, and name.
SELECT Player.Name, TG.Week, PS.Touchdowns, PS.ReceivingYards, PS.Receptions, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
	INNER JOIN Games.TeamGame TG ON PS.TeamGameID = TG.GameID
WHERE Player.Position = 'WR'
GROUP BY Player.Name, TG.Week, PS.Touchdowns, PS.ReceivingYards, PS.Receptions, Player.Position
ORDER BY PS.Touchdowns DESC, PS.ReceivingYards DESC, PS.Receptions DESC, Player.Name ASC;