CREATE OR REPLACE VIEW v_UsagePerPod
AS
SELECT d.idDevice, cu.firstname, cu.lastname, p.description as POD, d.description as Device, c.Description as Category, d.maxcapacity, ((Select count(*) FROM networkinterface n WHERE n.fidDevice = d.idDevice)* 100) as occSlots 
FROM customer_pod cp INNER JOIN device d ON cp.fidpod = d.fidpod
INNER JOIN pod p ON p.idPod = cp.fidPod
INNER JOIN Customer cu ON cu.idCustomer = cp.fidCustomer
INNER JOIN categories c ON d.fidCategories = c.idCategories
INNER JOIN networkinterface n ON d.idDevice = n.fidDevice
GROUP BY d.idDevice;

