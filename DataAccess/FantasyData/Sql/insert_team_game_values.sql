INSERT Games.TeamGame(TeamID, GameID, [Week], IsHomeTeam)
	(SELECT T.TeamID, G.GameID, G.Week, 1
		FROM Games.Game G
			LEFT JOIN NFL.Teams T ON G.HomeTeamID = T.TeamID);
		
INSERT Games.TeamGame(TeamID, GameID, [Week], IsHomeTeam)
	(SELECT T.TeamID, G.GameID, G.Week, 0
		FROM Games.Game G
			LEFT JOIN NFL.Teams T ON G.VisitorTeamID = T.TeamID);