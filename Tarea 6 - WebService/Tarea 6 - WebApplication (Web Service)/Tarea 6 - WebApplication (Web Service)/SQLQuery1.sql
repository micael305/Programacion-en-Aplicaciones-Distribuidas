-- Crear Tabla Cotizacion

CREATE TABLE Cotizacion (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Moneda NVARCHAR(10) NOT NULL,
        Casa NVARCHAR(50) NOT NULL,
        Nombre NVARCHAR(100) NOT NULL,
        Compra DECIMAL(18, 4) NOT NULL,
        Venta DECIMAL(18, 4) NOT NULL,
        FechaActualizacion DATETIME NOT NULL
    );

-- Insertar Datos de Ejemplo
INSERT INTO Cotizacion (Moneda, Casa, Nombre, Compra, Venta, FechaActualizacion)
VALUES
('USD', 'oficial', 'Dólar', 1415, 1465, '2025-10-17 10:55:00'),
('EUR', 'oficial', 'Euro', 1626.6061, 1640.6204, '2025-10-17 10:55:00'),
('BRL', 'oficial', 'Real Brasileño', 260.6522, 260.7938, '2025-10-17 10:55:00'),
('CLP', 'oficial', 'Peso Chileno', 1.4716, 1.4716, '2025-10-17 10:55:00'),
('UYU', 'oficial', 'Peso Uruguayo', 35.3353, 35.3355, '2025-10-17 10:55:00'),
('GBP', 'oficial', 'Libra Esterlina', 1870.52, 1886.81, '2025-10-16 07:55:00');