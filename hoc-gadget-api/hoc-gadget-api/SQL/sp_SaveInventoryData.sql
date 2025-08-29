-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Salunkhe
-- Create date: 9-08-2025
-- Description:	<Description>
-- =============================================
CREATE PROCEDURE sp_SaveInventoryData
	-- Add the parameters for the stored procedure here
	@ProductId INT,
	@ProductName VARCHAR(100),
	@AvailableQnt INT,
	@ReOrderPoint INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT Inventory
	(
		ProductId,
		ProductName,
		AvailableQnt,
		ReOrderPoint
	)
	VALUES
	(
		@ProductId,
		@ProductName,
		@AvailableQnt,
		@ReOrderPoint
	)
END
GO