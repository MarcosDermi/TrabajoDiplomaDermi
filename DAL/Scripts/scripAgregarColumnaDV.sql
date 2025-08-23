USE [DB_IngSoft]
GO

-- Agregar columna DV a la tabla Users
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'DV')
BEGIN
    ALTER TABLE Users ADD DV NVARCHAR(MAX) NULL;
END
GO

-- Crear tabla para el DV del sistema si no existe
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DVSistema')
BEGIN
    CREATE TABLE DVSistema (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DV NVARCHAR(MAX) NOT NULL,
        FechaActualizacion DATETIME DEFAULT GETDATE()
    );
    
    -- Insertar registro inicial
    INSERT INTO DVSistema (DV) VALUES ('');
END
GO 