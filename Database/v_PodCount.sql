CREATE VIEW POD_COUNT AS
	SELECT
	'Anzahl verwaltete PODs' AS category,
	po.validFrom,
	COUNT(po.idPod) AS val
	FROM MUSTERAG.Pod po
	WHERE po.validFrom >= DATEADD(year,-3,GETDATE())
	GROUP BY po.validFrom;