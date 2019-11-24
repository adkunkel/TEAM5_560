IF SCHEMA_ID(N'NFL') IS NULL
	EXEC(N'CREATE SCHEMA [NFL];');
GO
IF SCHEMA_ID(N'Games') IS NULL
	EXEC(N'CREATE SCHEMA [Games];');
GO
IF SCHEMA_ID(N'Players') IS NULL
	EXEC(N'CREATE SCHEMA [Players];');
GO
IF SCHEMA_ID(N'Experts') IS NULL
	EXEC(N'CREATE SCHEMA [Experts];');
GO


DROP TABLE IF EXISTS Experts.WeeklyRankings;
DROP TABLE IF EXISTS Players.PlayerStats;
DROP TABLE IF EXISTS Players.DefenseStats;
DROP TABLE IF EXISTS Players.KickerStats;
DROP TABLE IF EXISTS Players.TeamPlayer;
DROP TABLE IF EXISTS Players.PlayerInfo;
DROP TABLE IF EXISTS Players.Player;
DROP TABLE IF EXISTS Games.TeamGame;
DROP TABLE IF EXISTS Games.Game;
DROP TABLE IF EXISTS Games.Season;
DROP TABLE IF EXISTS NFL.TeamStats;
DROP TABLE IF EXISTS NFL.Teams;

CREATE TABLE NFL.Teams
(
	TeamID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TeamName NVARCHAR(64) NOT NULL UNIQUE
);

CREATE TABLE NFL.TeamStats
(
	TeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID) PRIMARY KEY,
	Record NVARCHAR(8) NOT NULL DEFAULT(N'0-0-0'),
	PointsScored INT NOT NULL DEFAULT(0),
	PointsAllowed INT NOT NULL DEFAULT(0)
);


CREATE TABLE Games.Season
(
	SeasonID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Year] INT NOT NULL DEFAULT(0) UNIQUE
);

CREATE TABLE Games.Game
(
	GameID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	HomeTeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID),
	VisitorTeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID),
	[Week] INT NOT NULL,
	SeasonID INT NOT NULL FOREIGN KEY REFERENCES Games.Season(SeasonID),
	[Date] DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	Result NVARCHAR(64)
);

CREATE TABLE Games.TeamGame
(
	TeamGameID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID),
	GameID INT NOT NULL FOREIGN KEY REFERENCES Games.Game(GameID),
	IsHomeTeam BIT NOT NULL 
);

CREATE TABLE Players.Player
(
	PlayerID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID)
);

CREATE TABLE Players.PlayerInfo
(
	PlayerInfoID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.Player(PlayerID),
	[Name] NVARCHAR(64) NOT NULL,
	[Status] NVARCHAR(64),
	Height NVARCHAR(32),
	[Weight] INT,
	YearsPro INT,
	BirthDate DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	Position NVARCHAR(16)
);

CREATE TABLE Players.TeamPlayer
(
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.Player(PlayerID) PRIMARY KEY,
	TeamID INT NOT NULL FOREIGN KEY REFERENCES NFL.Teams(TeamID),
	StartDate DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	EndDate DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);

CREATE TABLE Players.KickerStats
(
	KickerStatsID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.TeamPlayer(PlayerID),
	XPMade INT NOT NULL DEFAULT(0),
	XPMissed INT NOT NULL DEFAULT(0),
	FGGD INT NOT NULL DEFAULT(0),
	FGNG INT NOT NULL DEFAULT(0),
	TeamGameID INT NOT NULL FOREIGN KEY REFERENCES Games.TeamGame(TeamGameID),
	ByeWeek INT NOT NULL DEFAULT(0),

	UNIQUE(PlayerID, TeamGameID)
);

CREATE TABLE Players.DefenseStats
(
	DefenseStatsID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.TeamPlayer(PlayerID),
	PassYardsAllowed INT NOT NULL DEFAULT(0),
	RushYardsAllowed INT NOT NULL DEFAULT(0),
	TouchdownsAllowed INT NOT NULL DEFAULT(0),
	Touchdowns INT NOT NULL DEFAULT(0),
	Safeties INT NOT NULL DEFAULT(0),
	Interceptions INT NOT NULL DEFAULT(0),
	Fumbles INT NOT NULL DEFAULT(0),
	TeamGameID INT NOT NULL FOREIGN KEY REFERENCES Games.TeamGame(TeamGameID),
	ByeWeek INT NOT NULL DEFAULT(0),

	UNIQUE(PlayerID, TeamGameID)
);

CREATE TABLE Players.PlayerStats
(
	PlayerStatsID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.TeamPlayer(PlayerID),
	PassYards INT NOT NULL DEFAULT(0),
	RushYards INT NOT NULL DEFAULT(0),
	RecievingYards INT NOT NULL DEFAULT(0),
	Receptions INT NOT NULL DEFAULT(0),
	Touchdowns INT NOT NULL DEFAULT(0),
	Interceptions INT NOT NULL DEFAULT(0),
	Fumbles INT NOT NULL DEFAULT(0),
	TeamGameID INT NOT NULL FOREIGN KEY REFERENCES Games.TeamGame(TeamGameID),
	ByeWeek INT NOT NULL DEFAULT(0),

	UNIQUE(PlayerID, TeamGameID)
);


CREATE TABLE Experts.WeeklyRankings
(
	RankingID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	PlayerID INT NOT NULL FOREIGN KEY REFERENCES Players.Player(PlayerID),
	OverallRank INT,
	PositionRank INT,
	[Week] INT NOT NULL
);

