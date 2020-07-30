CREATE VIEW POD_AVG AS
    SELECT DISTINCT
    po.description,
    COUNT(de.description) OVER (PARTITION BY po.idPod, po.validFrom) AS val
    FROM MUSTERAG.Pod po
    JOIN MUSTERAG.Device de
    ON po.idPod = de.fidPod
    WHERE po.validFrom >= DATEADD(year,-3,GETDATE())