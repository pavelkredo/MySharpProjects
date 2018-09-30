CREATE TABLE [dbo].[Projects] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [ProjectName]      NVARCHAR (MAX) NULL,
    [CustomerName]     NVARCHAR (MAX) NULL,
    [ImplementerName]  NVARCHAR (MAX) NULL,
    [ChiefId]          INT            NULL,
    [ImplementerId]    INT            NULL,
    [StartProjectDate] NVARCHAR (MAX) NULL,
    [EndProjectDate]   NVARCHAR (MAX) NULL,
    [Priority]         INT            NOT NULL,
    [Comment]          NVARCHAR (MAX) NULL,
    [Employee_Id]      INT            NULL,
    CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Projects_dbo.Employees_ChiefId] FOREIGN KEY ([ChiefId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Projects_dbo.Employees_ImplementerId] FOREIGN KEY ([ImplementerId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Projects_dbo.Employees_Employee_Id] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employees] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ChiefId]
    ON [dbo].[Projects]([ChiefId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ImplementerId]
    ON [dbo].[Projects]([ImplementerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_Id]
    ON [dbo].[Projects]([Employee_Id] ASC);

