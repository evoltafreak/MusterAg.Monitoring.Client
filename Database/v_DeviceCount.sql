CREATE VIEW DEVICE_COUNT AS
	SELECT
	'Anzahl verwaltete Devices' AS category,
	po.validFrom,
	COUNT(po.idPod) AS val
	FROM MUSTERAG.Pod po
	JOIN MUSTERAG.Device de
	ON po.idPod = de.fidPod
	WHERE po.validFrom >= DATEADD(year,-3,GETDATE())
	GROUP BY po.validFrom;