SET IDENTITY_INSERT [dbo].[OperationResult] ON
INSERT INTO [dbo].[OperationResult] ([Id], [OperationID], [ArgumentCount], [Arguments], [Result], [ExecTimeMs]) VALUES (1, 1, 2, N'1, 3', N'4', 10000)
INSERT INTO [dbo].[OperationResult] ([Id], [OperationID], [ArgumentCount], [Arguments], [Result], [ExecTimeMs]) VALUES (2, 1, 2, N'1,4', N'5', 1)
SET IDENTITY_INSERT [dbo].[OperationResult] OFF
