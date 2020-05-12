/*--------------------------------
-- Stored Procedure - PodBill
-- Example:
-- CALL MUSTERAG.PodBill(1, 1, 'Test', 100);
--------------------------------*/
DROP PROCEDURE IF EXISTS MUSTERAG.PodBill;
DELIMITER $$
CREATE PROCEDURE MUSTERAG.PodBill (IN p_idAbrechnung INT, p_idPositionType INT, p_description VARCHAR(4000), p_price DECIMAL)
BEGIN
	INSERT INTO MUSTERAG.AbrechnungPosition (description, price, time, fidPositionType) VALUES (p_description, p_price, NOW(), p_idPositionType);
    INSERT INTO MUSTERAG.Abrechnung_AbrechnungPosition (fidAbrechnung, fidAbrechnungPosition) VALUES (p_idAbrechnung, LAST_INSERT_ID());  
END $$
DELIMITER ;

