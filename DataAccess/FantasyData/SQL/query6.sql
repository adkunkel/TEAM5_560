Select ps.PlayerID
From Player.PlayerStats ps
GroupBy ps.RecievingYards asc, ps.Recipetions asc, ps.Touchdowns asc
