/**
--Query 1
--Displays QBs ordered by touchdowns, pass yards, and name.
SELECT Player.Name, PS.Touchdowns, PS.PassYards, Player.Position
FROM Players.PlayerInfo AS Player
	INNER JOIN Players.PlayerStats AS PS ON PS.PlayerID = Player.PlayerID
WHERE Player.Position = 'QB'
ORDER BY PS.Touchdowns DESC, PS.PassYards DESC, Player.Name ASC
**/
SELECT Player.Name
FROM Players.PlayerInfo AS Player
ORDER BY Player.PlayerID DESC