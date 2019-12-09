--Query 5
--Displays Kickers in ordered by field goals made, extra points made, and name.
SELECT *
FROM Players.TeamPlayer AS TP
	INNER JOIN Players.PlayerInfo AS Player ON Player.PlayerID = TP.PlayerID
	INNER JOIN Players.KickerStats AS Kicker ON Kicker.PlayerID = TP.PlayerID
ORDER BY Kicker.FGGD DESC, Kicker.XPMade DESC, Player.Name ASC