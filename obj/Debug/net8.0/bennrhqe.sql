CREATE TABLE [AppRoles] (
    [Id] int NOT NULL IDENTITY,
    [Definition] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AppRoles] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Departments] (
    [Id] int NOT NULL IDENTITY,
    [Definition] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [EmployeeMaster] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [Region] nvarchar(max) NOT NULL,
    [PostalCode] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeMaster] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [AppUsers] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(25) NOT NULL,
    [Password] nvarchar(25) NOT NULL,
    [FirstName] nvarchar(10) NOT NULL,
    [LastName] nvarchar(15) NOT NULL,
    [Email] nvarchar(70) NOT NULL,
    [PhoneNumber] nvarchar(20) NOT NULL,
    [DeparmentId] int NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AppUsers_Departments_DeparmentId] FOREIGN KEY ([DeparmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AppUserRoles] (
    [Id] int NOT NULL IDENTITY,
    [AppUserId] int NOT NULL,
    [AppRoleId] int NOT NULL,
    CONSTRAINT [PK_AppUserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AppUserRoles_AppRoles_AppRoleId] FOREIGN KEY ([AppRoleId]) REFERENCES [AppRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AppUserRoles_AppUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] ntext NOT NULL,
    [TypeOfDoc] nvarchar(30) NOT NULL,
    [ClassOfDoc] nvarchar(30) NOT NULL,
    [SenderName] nvarchar(max) NULL,
    [ReceiverName] nvarchar(max) NULL,
    [DocState] int NOT NULL,
    [DocStatus] int NOT NULL,
    [ReplyDocId] int NULL,
    [SendDate] datetime2 NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ReceiveDate] datetime2 NULL,
    [RoomNumber] nvarchar(max) NULL,
    [ShelfNumber] nvarchar(max) NULL,
    [isBorrowed] bit NOT NULL,
    [BorrowerName] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AppUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_AppUserRoles_AppRoleId] ON [AppUserRoles] ([AppRoleId]);
GO


CREATE UNIQUE INDEX [IX_AppUserRoles_AppUserId_AppRoleId] ON [AppUserRoles] ([AppUserId], [AppRoleId]);
GO


CREATE INDEX [IX_AppUsers_DeparmentId] ON [AppUsers] ([DeparmentId]);
GO


CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);
GO


