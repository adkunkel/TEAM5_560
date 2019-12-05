Select ts.TeamID
From NFL.TeamStats ts
GroupBy ts.Record asc, ts.PointsScored asc
