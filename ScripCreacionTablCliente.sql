CREATE TABLE [dbo].[Cliente_JIM] (
    [ClienteId] INT IDENTITY(1,1) NOT NULL, 
    [Nombre] NVARCHAR(100) NOT NULL,       
    [Apellido] NVARCHAR(100) NOT NULL,    
    [Direccion] NVARCHAR(255) NOT NULL, 
    [Telefono] INT NOT NULL,             
    [Email] NVARCHAR(100) NOT NULL,   
    [FechaRegistro] DATETIME DEFAULT (GETDATE()) NULL, 
    [Nif] NVARCHAR(9) NOT NULL,           
    [Activo] NVARCHAR(1) NOT NULL,        
    PRIMARY KEY CLUSTERED ([ClienteId] ASC) 
);
