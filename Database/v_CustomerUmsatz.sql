CREATE VIEW CUSTOMER_UMSATZ AS
    SELECT DISTINCT
    cu.firstname,
    po.validFrom,
    SUM(ap.price) OVER (PARTITION BY po.validFrom) AS val
    FROM MUSTERAG.Pod po
    JOIN MUSTERAG.Abrechnung ab
    ON ab.fidPod = po.idPod
    JOIN MUSTERAG.customer_pod cp
    ON cp.fidPod = po.idPod
    JOIN MUSTERAG.customer cu
    ON cu.idCustomer = cp.fidCustomer
    JOIN MUSTERAG.abrechnung_abrechnungposition aa
    ON aa.fidAbrechnung = ab.idAbrechnung
    JOIN MUSTERAG.abrechnungposition ap
    ON aa.fidAbrechnungPosition = ap.idAbrechnungPosition
    WHERE po.validFrom >= DATEADD(year,-3,GETDATE())
