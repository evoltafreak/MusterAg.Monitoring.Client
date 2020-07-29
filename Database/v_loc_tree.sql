CREATE OR REPLACE VIEW LOC_TREE AS
	WITH cteLocTree AS (
		SELECT
		idLocation,
		address,
		addressNr,
		ISNULL(parent, 0) AS parent,
		0 as lvl
		FROM MUSTERAG.Location
		WHERE parent IS NULL
		UNION ALL
		SELECT
		lo.idLocation,
		lo.address,
		lo.addressNr,
		ISNULL(lo.parent, 0) AS parent,
		lo2.lvl + 1
		FROM MUSTERAG.Location lo
		JOIN cteLocTree lo2
		ON lo2.idLocation = lo.parent
	)
	SELECT * FROM cteLocTree