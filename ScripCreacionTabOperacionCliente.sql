CREATE TABLE [dbo].[Operacion_ClienteJIM] (
    [ClienteId]   INT NOT NULL,
    [OperacionId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ClienteId] ASC, [OperacionId] ASC),
    FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente_JIM] ([ClienteId]),
    FOREIGN KEY ([OperacionId]) REFERENCES [dbo].[Operacion] ([OperacionID])
);

