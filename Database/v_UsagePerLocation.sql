CREATE OR REPLACE VIEW v_UsagePerLocation
AS
SELECT d.idDevice, l.address, l.addressNr, l.fidPlace, d.description, d.maxcapacity, ((Select count(*) FROM networkinterface n WHERE n.fidDevice = d.idDevice)* 100 / d.maxcapacity) as occSlots 
FROM location l INNER JOIN device d ON l.idLocation = d.fidLocation
INNER JOIN categories c ON d.fidCategories = c.idCategories
INNER JOIN networkinterface n ON d.idDevice = n.fidDevice
GROUP BY d.idDevice;

