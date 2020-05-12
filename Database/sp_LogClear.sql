/*--------------------------------
-- Stored Procedure - LogClear
-- Example:
-- CALL MUSTERAG.LogClear(1);
--------------------------------*/
DROP PROCEDURE IF EXISTS MUSTERAG.LogClear;
DELIMITER $$
CREATE PROCEDURE MUSTERAG.LogClear (IN id INT)
BEGIN
	DELETE FROM Pod_Logging WHERE fidLogging = id;
	DELETE FROM Logging WHERE idLogging = id;
END $$
DELIMITER ;
