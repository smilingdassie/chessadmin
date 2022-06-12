/*
Ranking
Each member is ranked from 1..n. Where 1 is the top player in the club and n is the
lowest-ranked player in the club.
When players play a match, their ranks can change, based on the following rules:
? If the higher-ranked player wins against their opponent, neither of their ranks change
? If it’s a draw, the lower-ranked player can gain one position, unless the two players are
adjacent. So if the players are ranked 10th and 11th, and it’s a draw, no change in
ranking takes place. But if the players are ranked 10th and 15th, and it’s a draw, the
player with rank 15 will move up to rank 14 and the player with rank 10 will stay the
same
? If the lower-ranked player beats a higher-ranked player, the higher-ranked player will
move one rank down, and the lower level player will move up by half the difference
between their original ranks.
For example, if players ranked 10th and 16th play and the lower-ranked player wins, the
first player will move to rank 11th and the other player will move to rank (16 - 10) / 2 = 3
placed up, to rank 13th
*/
create proc GameFinishedEvent
as
begin
	select 1
end
go


