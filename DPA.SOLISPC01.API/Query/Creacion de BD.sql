CREATE DATABASE SistemaReservasCanchas;
GO

-- Usar la base de datos reci�n creada
USE SistemaReservasCanchas;
GO

-- Crear la tabla 'Canchas'
CREATE TABLE Canchas (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- ID se autogenera, clave primaria
    Nombre NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Ubicaci�n NVARCHAR(200) NOT NULL
);
GO

-- Crear la tabla 'Reservas'
CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- ID se autogenera, clave primaria
    Fecha DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    ClienteNombre NVARCHAR(100) NOT NULL,
    CanchaId INT,  -- Clave for�nea que referencia la tabla 'Canchas'
    CONSTRAINT FK_Reservas_Canchas FOREIGN KEY (CanchaId) REFERENCES Canchas(Id)
);
GO

-- Insertar 10 registros en la tabla 'Canchas'
INSERT INTO Canchas (Nombre, Tipo, Ubicaci�n) 
VALUES 
('Cancha 1', 'F�tbol', 'Av. Siempre Viva 123'),
('Cancha 2', 'F�tbol', 'Calle Ficticia 456'),
('Cancha 3', 'Tenis', 'Calle Real 789'),
('Cancha 4', 'V�ley', 'Av. Central 101'),
('Cancha 5', 'F�tbol', 'Calle 10 de Agosto 202'),
('Cancha 6', 'Tenis', 'Calle de la Paz 303'),
('Cancha 7', 'F�tbol', 'Av. Los Andes 404'),
('Cancha 8', 'B�squet', 'Calle del Sol 505'),
('Cancha 9', 'F�tbol', 'Av. del Mar 606'),
('Cancha 10', 'V�ley', 'Calle del R�o 707');
GO

-- Insertar 10 registros en la tabla 'Reservas'
INSERT INTO Reservas (Fecha, HoraInicio, HoraFin, ClienteNombre, CanchaId) 
VALUES 
('2025-05-10', '10:00', '12:00', 'Juan P�rez', 1),
('2025-05-10', '12:00', '14:00', 'Ana G�mez', 2),
('2025-05-10', '14:00', '16:00', 'Carlos Ruiz', 3),
('2025-05-11', '09:00', '11:00', 'Laura L�pez', 4),
('2025-05-11', '11:00', '13:00', 'Jos� Mart�nez', 5),
('2025-05-12', '15:00', '17:00', 'Mar�a S�nchez', 6),
('2025-05-12', '16:00', '18:00', 'Pedro Garc�a', 7),
('2025-05-13', '08:00', '10:00', 'Luis Fern�ndez', 8),
('2025-05-13', '10:00', '12:00', 'Elena Rodr�guez', 9),
('2025-05-14', '13:00', '15:00', 'Miguel D�az', 10);
GO
