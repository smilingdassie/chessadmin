USE [ChessAdminDb]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 2022/06/13 03:01:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerOneID] [int] NOT NULL,
	[PlayerTwoID] [int] NOT NULL,
	[GameDate] [date] NOT NULL,
	[WinnerID] [int] NULL,
	[IsDraw] [bit] NOT NULL,
	[PlayerOneCurrentRank] [int] NULL,
	[PlayerTwoCurrentRank] [int] NULL,
	[PlayerOneRankAfterGame] [int] NULL,
	[PlayerTwoRankAfterGame] [int] NULL,
	[GameTime] [time](7) NOT NULL,
	[GameDateTime]  AS (CONVERT([datetime],(CONVERT([char](8),[GameDate],(112))+' ')+CONVERT([char](8),[GameTime],(108)))),
 CONSTRAINT [PK__Game__3214EC27A2AB5F8C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2022/06/13 03:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](400) NULL,
	[Surname] [varchar](400) NULL,
	[Email] [varchar](400) NULL,
	[Birthday] [datetime] NULL,
	[TotalGamesPlayed] [int] NULL,
	[CurrentRank] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Member] ON 
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (1, N'Abel', N'Batson', N'abel.batson@chessclub.co', CAST(N'1989-06-01T00:00:00.000' AS DateTime), 0, 1)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (2, N'Caley', N'Donaldson', N'caley.donaldson@chessclub.co', CAST(N'1989-06-02T00:00:00.000' AS DateTime), 0, 2)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (3, N'Elisa', N'Franken', N'elisa.franken@chessclub.co', CAST(N'1989-06-03T00:00:00.000' AS DateTime), 0, 3)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (4, N'Gordon', N'Hines', N'gordon.hines@chessclub.co', CAST(N'1989-06-04T00:00:00.000' AS DateTime), 0, 4)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (5, N'Ilse', N'Jansen', N'ilse.jansen@chessclub.co', CAST(N'1989-06-05T00:00:00.000' AS DateTime), 0, 5)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (6, N'Kaleb', N'Lehman', N'kaleb.lehman@chessclub.co', CAST(N'1989-06-06T00:00:00.000' AS DateTime), 0, 6)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (7, N'Muneer', N'Nawat', N'muneer.nawat@chessclub.co', CAST(N'1989-06-07T00:00:00.000' AS DateTime), 0, 7)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (8, N'Olaf', N'Piork', N'olaf.piork@chessclub.co', CAST(N'1989-06-08T00:00:00.000' AS DateTime), 0, 8)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (9, N'Qaneeth', N'Rushdie', N'qaneeth.rushdie@chessclub.co', CAST(N'1989-06-09T00:00:00.000' AS DateTime), 0, 9)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (10, N'Salazar', N'Trust', N'salazar.trust@chessclub.co', CAST(N'1989-06-10T00:00:00.000' AS DateTime), 0, 10)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (11, N'Ugwe', N'Valencia', N'ugwe.valencia@chessclub.co', CAST(N'1989-06-11T00:00:00.000' AS DateTime), 0, 11)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (12, N'Waynona', N'Xanadu', N'waynona.xanadu@chessclub.co', CAST(N'1989-06-12T00:00:00.000' AS DateTime), 0, 12)
GO
INSERT [dbo].[Member] ([ID], [Name], [Surname], [Email], [Birthday], [TotalGamesPlayed], [CurrentRank]) VALUES (13, N'Yng', N'Zu', N'yng.zu@chessclub.co', CAST(N'1989-06-13T00:00:00.000' AS DateTime), 0, 13)
GO
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Member] FOREIGN KEY([PlayerOneID])
REFERENCES [dbo].[Member] ([ID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Member]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Member1] FOREIGN KEY([PlayerTwoID])
REFERENCES [dbo].[Member] ([ID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Member1]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Member2] FOREIGN KEY([WinnerID])
REFERENCES [dbo].[Member] ([ID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Member2]
GO
