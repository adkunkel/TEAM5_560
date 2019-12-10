--Query 5
--Displays Kickers ordered by field goals made, extra points made, field goals missed, extra points missed and name.
SELECT Player.Name, TG.Week, Kicker.FGGD, Kicker.FGNG, Kicker.XPMade, Kicker.XPMissed, Player.Position
FROM Players.TeamPlayer AS TP
	INNER JOIN Players.PlayerInfo AS Player ON Player.PlayerID = TP.PlayerID
	INNER JOIN Players.KickerStats AS Kicker ON Kicker.PlayerID = TP.PlayerID
	INNER JOIN Games.TeamGame TG ON Kicker.TeamGameID = TG.GameID
GROUP BY Player.Name, TG.Week, Kicker.FGGD, Kicker.FGNG, Kicker.XPMade, Kicker.XPMissed, Player.Position
ORDER BY Kicker.FGGD DESC, Kicker.XPMade DESC, Kicker.FGNG, Kicker.XPMissed, Player.Name ASC;