-- Fill Member Table

insert into Member (Name, Surname)
select 'Abel','Batson'

insert into Member (Name, Surname)
select 'Caley', 'Donaldson'

insert into Member (Name, Surname)
select 'Elisa', 'Franken'

insert into Member (Name, Surname)
select 'Gordon', 'Hines'

insert into Member (Name, Surname)
select 'Ilse', 'Jansen'

insert into Member (Name, Surname)
select 'Kaleb', 'Lehman'

insert into Member (Name, Surname)
select 'Muneer', 'Nawat'

insert into Member (Name, Surname)
select 'Olaf', 'Piork'

insert into Member (Name, Surname)
select 'Qaneeth', 'Rushdie'

insert into Member (Name, Surname)
select 'Salazar', 'Trust'

insert into Member (Name, Surname)
select 'Ugwe', 'Valencia'

insert into Member (Name, Surname)
select 'Waynona', 'Xanadu'

insert into Member (Name, Surname)
select 'Yng', 'Zu'
go
 
update Member set email = lower(name + '.' + surname + '@chessclub.co')
update Member set Birthday = cast(ID as varchar(2)) + ' June 1989'
update Member set TotalGamesPlayed = 5, CurrentRank = ID

