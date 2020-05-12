-- V_LOGENTRIES
CREATE OR REPLACE VIEW V_LOGENTRIES AS 
	SELECT
    log.idLogging AS id,
    po.description AS pod,
    lo.address AS location,
    de.hostname,
    se.severity,
    log.timestamp,
    CONVERT(log.message USING utf8) AS message
    FROM MUSTERAG.Pod po
    JOIN MUSTERAG.Location_Pod lp
		ON lp.fidPod = po.idPod
    JOIN MUSTERAG.Location lo
		ON lo.idLocation = lp.fidLocation
    JOIN MUSTERAG.Device de
		ON po.idPod = de.fidPod
	JOIN MUSTERAG.Pod_Logging pl
		ON po.idPod = pl.fidPod
	JOIN MUSTERAG.Logging log
		ON log.idLogging = pl.fidLogging
    JOIN MUSTERAG.Severity se
		ON log.fidSeverity = se.idSeverity;
		