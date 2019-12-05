Select ds.DefenseStatID
From Player.DefenseStats ds
GroupBy ds.RushYards asc, ds.PassYards asc
