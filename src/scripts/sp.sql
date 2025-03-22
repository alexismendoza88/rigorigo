 use[bdPedidos]

CREATE TABLE Pedidos (
    PedidoID INT IDENTITY(1,1) PRIMARY KEY,
    Cedula NVARCHAR(20) NOT NULL,
    Direccion NVARCHAR(100) NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);


CREATE PROCEDURE sp_InsertPedido
            @Cedula NVARCHAR(20),
            @Direccion NVARCHAR(100),
            @ValorTotal DECIMAL(18,2)
        AS
        BEGIN
            INSERT INTO Pedidos (Cedula, Direccion, ValorTotal)
            VALUES (@Cedula, @Direccion, @ValorTotal);

            SELECT SCOPE_IDENTITY() AS PedidoID;
        END