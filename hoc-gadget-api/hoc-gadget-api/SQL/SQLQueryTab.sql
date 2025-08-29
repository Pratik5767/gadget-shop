CREATE TABLE Inventory
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ProductId INT,
	ProductName VARCHAR(100),
	AvailableQnt INT,
	ReOrderPoint INT
)

SELECT * FROM Inventory;