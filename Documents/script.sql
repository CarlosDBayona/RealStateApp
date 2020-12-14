IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Properties] (
    [Id] int NOT NULL IDENTITY,
    [Latitude] real NOT NULL,
    [Longitude] real NOT NULL,
    [CreatedAt] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Price] real NOT NULL,
    [OwnerName] nvarchar(max) NULL,
    [OwnerPhone] nvarchar(max) NULL,
    [Area] real NOT NULL,
    [Rooms] int NOT NULL,
    [Bathrooms] int NOT NULL,
    CONSTRAINT [PK_Properties] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201211235808_InitialMigration', N'3.1.10');

GO

CREATE TABLE [Characteristic] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Characteristic] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [CharacteristicType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CharacteristicType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Type] (
    [Id] int NOT NULL IDENTITY,
    [CharacteristicTypeId] int NOT NULL,
    [PropertyId] int NOT NULL,
    [CharacteristicId] int NOT NULL,
    CONSTRAINT [PK_Type] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Type_Characteristic_CharacteristicId] FOREIGN KEY ([CharacteristicId]) REFERENCES [Characteristic] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Type_CharacteristicType_CharacteristicTypeId] FOREIGN KEY ([CharacteristicTypeId]) REFERENCES [CharacteristicType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Type_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Type_CharacteristicId] ON [Type] ([CharacteristicId]);

GO

CREATE INDEX [IX_Type_CharacteristicTypeId] ON [Type] ([CharacteristicTypeId]);

GO

CREATE INDEX [IX_Type_PropertyId] ON [Type] ([PropertyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212001929_AddedPropertyRelations', N'3.1.10');

GO

ALTER TABLE [Type] DROP CONSTRAINT [FK_Type_Characteristic_CharacteristicId];

GO

ALTER TABLE [Type] DROP CONSTRAINT [FK_Type_CharacteristicType_CharacteristicTypeId];

GO

ALTER TABLE [Type] DROP CONSTRAINT [FK_Type_Properties_PropertyId];

GO

ALTER TABLE [Type] DROP CONSTRAINT [PK_Type];

GO

ALTER TABLE [CharacteristicType] DROP CONSTRAINT [PK_CharacteristicType];

GO

EXEC sp_rename N'[Type]', N'PropertyCharacteristics';

GO

EXEC sp_rename N'[CharacteristicType]', N'CharacteristicTypes';

GO

EXEC sp_rename N'[PropertyCharacteristics].[IX_Type_PropertyId]', N'IX_PropertyCharacteristics_PropertyId', N'INDEX';

GO

EXEC sp_rename N'[PropertyCharacteristics].[IX_Type_CharacteristicTypeId]', N'IX_PropertyCharacteristics_CharacteristicTypeId', N'INDEX';

GO

EXEC sp_rename N'[PropertyCharacteristics].[IX_Type_CharacteristicId]', N'IX_PropertyCharacteristics_CharacteristicId', N'INDEX';

GO

ALTER TABLE [PropertyCharacteristics] ADD CONSTRAINT [PK_PropertyCharacteristics] PRIMARY KEY ([Id]);

GO

ALTER TABLE [CharacteristicTypes] ADD CONSTRAINT [PK_CharacteristicTypes] PRIMARY KEY ([Id]);

GO

ALTER TABLE [PropertyCharacteristics] ADD CONSTRAINT [FK_PropertyCharacteristics_Characteristic_CharacteristicId] FOREIGN KEY ([CharacteristicId]) REFERENCES [Characteristic] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PropertyCharacteristics] ADD CONSTRAINT [FK_PropertyCharacteristics_CharacteristicTypes_CharacteristicTypeId] FOREIGN KEY ([CharacteristicTypeId]) REFERENCES [CharacteristicTypes] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PropertyCharacteristics] ADD CONSTRAINT [FK_PropertyCharacteristics_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212003304_UpdatedDbContextNames', N'3.1.10');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Properties]') AND [c].[name] = N'CreatedAt');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Properties] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Properties] ALTER COLUMN [CreatedAt] datetime2 NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212030307_FixedPropertyCreatedAt', N'3.1.10');

GO

ALTER TABLE [Properties] ADD [Description] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212031813_AddedDescriptionToPropertyEntity', N'3.1.10');

GO

ALTER TABLE [PropertyCharacteristics] DROP CONSTRAINT [FK_PropertyCharacteristics_Characteristic_CharacteristicId];

GO

ALTER TABLE [Characteristic] DROP CONSTRAINT [PK_Characteristic];

GO

EXEC sp_rename N'[Characteristic]', N'Characteristics';

GO

ALTER TABLE [Characteristics] ADD CONSTRAINT [PK_Characteristics] PRIMARY KEY ([Id]);

GO

ALTER TABLE [PropertyCharacteristics] ADD CONSTRAINT [FK_PropertyCharacteristics_Characteristics_CharacteristicId] FOREIGN KEY ([CharacteristicId]) REFERENCES [Characteristics] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201213081150_AddedCharacteristicsToDbset', N'3.1.10');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201213214658_AddCascadeDeletePropertyCharacteristics', N'3.1.10');

GO

