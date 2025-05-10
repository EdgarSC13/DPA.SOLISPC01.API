CREATE DATABASE SistemaReservasCanchas;
GO

-- Usar la base de datos recién creada
USE SistemaReservasCanchas;
GO

-- Crear la tabla 'Canchas'
CREATE TABLE Canchas (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- ID se autogenera, clave primaria
    Nombre NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Ubicación NVARCHAR(200) NOT NULL
);
GO

-- Crear la tabla 'Reservas'
CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- ID se autogenera, clave primaria
    Fecha DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    ClienteNombre NVARCHAR(100) NOT NULL,
    CanchaId INT,  -- Clave foránea que referencia la tabla 'Canchas'
    CONSTRAINT FK_Reservas_Canchas FOREIGN KEY (CanchaId) REFERENCES Canchas(Id)
);
GO

-- Insertar 10 registros en la tabla 'Canchas'
INSERT INTO Canchas (Nombre, Tipo, Ubicación) 
VALUES 
('Cancha 1', 'Fútbol', 'Av. Siempre Viva 123'),
('Cancha 2', 'Fútbol', 'Calle Ficticia 456'),
('Cancha 3', 'Tenis', 'Calle Real 789'),
('Cancha 4', 'Vóley', 'Av. Central 101'),
('Cancha 5', 'Fútbol', 'Calle 10 de Agosto 202'),
('Cancha 6', 'Tenis', 'Calle de la Paz 303'),
('Cancha 7', 'Fútbol', 'Av. Los Andes 404'),
('Cancha 8', 'Básquet', 'Calle del Sol 505'),
('Cancha 9', 'Fútbol', 'Av. del Mar 606'),
('Cancha 10', 'Vóley', 'Calle del Río 707');
GO

-- Insertar 10 registros en la tabla 'Reservas'
INSERT INTO Reservas (Fecha, HoraInicio, HoraFin, ClienteNombre, CanchaId) 
VALUES 
('2025-05-10', '10:00', '12:00', 'Juan Pérez', 1),
('2025-05-10', '12:00', '14:00', 'Ana Gómez', 2),
('2025-05-10', '14:00', '16:00', 'Carlos Ruiz', 3),
('2025-05-11', '09:00', '11:00', 'Laura López', 4),
('2025-05-11', '11:00', '13:00', 'José Martínez', 5),
('2025-05-12', '15:00', '17:00', 'María Sánchez', 6),
('2025-05-12', '16:00', '18:00', 'Pedro García', 7),
('2025-05-13', '08:00', '10:00', 'Luis Fernández', 8),
('2025-05-13', '10:00', '12:00', 'Elena Rodríguez', 9),
('2025-05-14', '13:00', '15:00', 'Miguel Díaz', 10);
GO
