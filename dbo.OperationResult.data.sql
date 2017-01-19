SET IDENTITY_INSERT [dbo].[OperationResult] ON
INSERT INTO [dbo].[OperationResult] ([Id], [OperationID], [ArgumentCount], [Arguments], [Result], [ExecTimeMs]) VALUES (1, 1, 2, N'1, 2 ', N'3', 10000)
INSERT INTO [dbo].[OperationResult] ([Id], [OperationID], [ArgumentCount], [Arguments], [Result], [ExecTimeMs]) VALUES (2, 1, 1, N'1', N'1', 10000)
INSERT INTO [dbo].[OperationResult] ([Id], [OperationID], [ArgumentCount], [Arguments], [Result], [ExecTimeMs]) VALUES (3, 2, 1, N'1', N'5', 6588)
SET IDENTITY_INSERT [dbo].[OperationResult] OFF
