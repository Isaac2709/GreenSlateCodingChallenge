USE [GSCodeChallenge]
GO

SET IDENTITY_INSERT [User] ON
GO
INSERT INTO [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (1, 'Isaac', 'Pacheco Corella')
INSERT INTO [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (2, 'Carlos', 'Mendez')
INSERT INTO [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (3, 'Rimarria', 'Appling')
GO
SET IDENTITY_INSERT [User] OFF
GO

SET IDENTITY_INSERT [Project] ON
GO
INSERT INTO [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (1, '01/03/2019', '01/10/2019', 2)
INSERT INTO [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (2, '01/10/2019', '01/11/2019', 2)
INSERT INTO [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (3, '01/11/2019', '01/12/2019', 2)
INSERT INTO [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (4, '01/12/2019', '01/01/2020', 2)
INSERT INTO [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (5, '01/12/2019', '01/02/2020', 2)
GO
SET IDENTITY_INSERT [Project] OFF
GO


INSERT INTO [dbo].[UserProject]([UserId],[ProjectId],[IsActive],[AssignedDate]) VALUES (1, 1, 1, '01/03/2019')
INSERT INTO [dbo].[UserProject]([UserId],[ProjectId],[IsActive],[AssignedDate]) VALUES (1, 2, 1, '01/12/2019')
INSERT INTO [dbo].[UserProject]([UserId],[ProjectId],[IsActive],[AssignedDate]) VALUES (1, 3, 1, '01/12/2019')
INSERT INTO [dbo].[UserProject]([UserId],[ProjectId],[IsActive],[AssignedDate]) VALUES (1, 4, 0, '01/12/2019')
INSERT INTO [dbo].[UserProject]([UserId],[ProjectId],[IsActive],[AssignedDate]) VALUES (1, 5, 0, '01/12/2019')
GO


