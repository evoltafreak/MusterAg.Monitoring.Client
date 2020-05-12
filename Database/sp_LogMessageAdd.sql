/*--------------------------------
-- Stored Procedure - LogMessageAdd
-- Example:
-- CALL MUSTERAG.LogMessageAdd(1,1,"Testlog");
--------------------------------*/
DROP PROCEDURE IF EXISTS MUSTERAG.LogMessageAdd;
DELIMITER $$
CREATE PROCEDURE MUSTERAG.LogMessageAdd (
	IN idPod INT,
	IN idSeverity INT,
	IN message LONGBLOB
)
BEGIN
	INSERT INTO MUSTERAG.Logging (timestamp, message, fidSeverity) VALUES (NOW(), message, idSeverity); 
	INSERT INTO MUSTERAG.Pod_Logging (fidPod, fidLogging) VALUES (idPod, LAST_INSERT_ID());
END $$
DELIMITER ;
