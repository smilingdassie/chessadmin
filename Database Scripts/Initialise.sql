if not exists(select * from sys.sysdatabases where name = 'ChessAdminDb')
begin
	create database ChessAdminDb 
end
use ChessAdminDb
go
create table Member
(ID int identity primary key,
 Name varchar(400),
 Surname varchar(400),
 Email varchar(400),
 Birthday datetime,
 TotalGamesPlayed int,
 CurrentRank int
 )
 go
  create table Game
  (ID int identity primary key,
  PlayerOneID int,
  PlayerTwoID int,
  GameDateTime datetime,
  WinnerID int,
  IsDraw bit,
  PlayerOneCurrentRank int,
  PlayerTwoCurrentRank int,
  PlayerOneRankAfterGame int,
  PlayerTwoRankAfterGame int
  )
  go 

  