CREATE TABLE [dbo].[OperationResult] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [OperationID]   INT           NOT NULL,
    [ArgumentCount] INT           NOT NULL,
    [Arguments]     NVARCHAR (50) NULL,
    [Result]        NVARCHAR (50) NULL,
    [ExecTimeMs]    BIGINT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_OperationResult_ToOperation] FOREIGN KEY ([OperationID]) REFERENCES [Operation]([OperationID]) 
);

