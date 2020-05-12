/*--------------------------------
-- Trigger - Tr_Abrechnung_AbrechnungPosition
--------------------------------*/
DROP TRIGGER IF EXISTS MUSTERAG.TR_Abrechnung_AbrechnungPosition;
DELIMITER $$
CREATE
	TRIGGER MUSTERAG.TR_Abrechnung_AbrechnungPosition AFTER INSERT 
	ON MUSTERAG.Abrechnung_AbrechnungPosition 
	FOR EACH ROW BEGIN
		DECLARE l_price DECIMAL;
		DECLARE l_time TIME;
		DECLARE l_billLimit DECIMAL;
		DECLARE l_credit DECIMAL;
		DECLARE l_day_difference INT;
		DECLARE l_month_check TINYINT DEFAULT 0;
        DECLARE done INT DEFAULT FALSE;
		
        DECLARE cur_days CURSOR FOR
		SELECT DATEDIFF(NOW(), ab.time) FROM
		MUSTERAG.abrechnung_abrechnungposition aap
		JOIN MUSTERAG.abrechnungPosition ab
		ON ab.idAbrechnungPosition = aap.fidAbrechnungPosition
		WHERE aap.fidAbrechnung = NEW.fidAbrechnung;
		
        DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
        
        -- Get summ of all prices
		SELECT SUM(ap.price) INTO l_price
        FROM MUSTERAG.AbrechnungPosition ap
        JOIN MUSTERAG.Abrechnung_AbrechnungPosition aap
        ON ap.idAbrechnungPosition = aap.fidAbrechnungPosition
        WHERE aap.fidAbrechnung = NEW.fidAbrechnung;
		
        -- Get bill limit of customers pod
		SELECT DISTINCT billLimit, credit INTO l_billLimit, l_credit FROM
		MUSTERAG.Abrechnung_Abrechnungposition aap
		JOIN MUSTERAG.Abrechnung ab
		ON aap.fidAbrechnung = idAbrechnung
		JOIN MUSTERAG.Pod po
		ON po.idPod = ab.fidPod
		WHERE aap.fidAbrechnung = NEW.fidAbrechnung;
		
        -- Get 3 months check
		OPEN cur_days;
		MONTH_DIFFERENCE: LOOP
			FETCH cur_days INTO l_day_difference;
			IF l_day_difference > 90 THEN
				SET l_month_check = 1;
				LEAVE MONTH_DIFFERENCE;
			END IF;
			IF done THEN
				LEAVE MONTH_DIFFERENCE;
			END IF;
		END LOOP MONTH_DIFFERENCE;
		CLOSE cur_days;
		
		-- Update Abrechnung 
		IF (l_month_check = 1 OR l_price > 1000 OR l_price > l_billLimit) THEN
			UPDATE MUSTERAG.Abrechnung SET bill = (l_price - l_credit), isPaid = 1 WHERE idAbrechnung = NEW.fidAbrechnung;
		END IF;
		
    END$$
DELIMITER ;	

