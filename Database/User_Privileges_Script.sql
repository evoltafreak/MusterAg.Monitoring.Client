CREATE USER 'geschaeftsfuehrer'@'localhost' IDENTIFIED BY 'password1';

GRANT SELECT ON musterag.* TO 'geschaeftsfuehrer'@'localhost';

CREATE USER 'abteilungsleiter1'@'localhost' IDENTIFIED BY 'password2';
GRANT SELECT ON musterag.pod TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.pod TO 'abteilungsleiter1'@'localhost';

CREATE USER 'abteilungsleiter2'@'localhost' IDENTIFIED BY 'password3';
GRANT SELECT ON musterag.pod TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.pod TO 'abteilungsleiter2'@'localhost';

CREATE USER 'sachbearbeiter1'@'localhost' IDENTIFIED BY 'password3';

###Leseberechtigung###1

GRANT SELECT ON musterag.pod TO'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.customer TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.location TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.location_pod TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.customer_pod TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.severity TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.logging TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.place TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.credential TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.device TO 'sachbearbeiter1'@'localhost'; 
GRANT SELECT ON musterag.device_credential TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.networkinterface TO 'sachbearbeiter1'@'localhost';
GRANT SELECT ON musterag.networkinterfacemode TO 'sachbearbeiter1'@'localhost';

###Bearbeitungsberechtigung###1

GRANT INSERT ON musterag.customer TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.customer_pod TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.severity TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.logging TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.place TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.credential TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.device TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.device_credential TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.networkinterface TO 'sachbearbeiter1'@'localhost';
GRANT INSERT ON musterag.networkinterfacemode TO 'sachbearbeiter1'@'localhost';

CREATE USER 'sachbearbeiter2'@'localhost' IDENTIFIED BY 'password4';

###Leseberechtigung###2

GRANT SELECT ON musterag.pod TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.customer TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.location TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.location_pod TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.customer_pod TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.severity TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.logging TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.place TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.credential TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.device TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.device_credential TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.networkinterface TO 'sachbearbeiter2'@'localhost';
GRANT SELECT ON musterag.networkinterfacemode TO 'sachbearbeiter2'@'localhost';

###Bearbeitungsberechtigung###2

GRANT INSERT ON musterag.customer TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.customer_pod TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.severity TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.logging TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.place TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.credential TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.device TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.device_credential TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.networkinterface TO 'sachbearbeiter2'@'localhost';
GRANT INSERT ON musterag.networkinterfacemode TO 'sachbearbeiter2'@'localhost';

###Leseberechtigung###3

GRANT SELECT ON musterag.pod TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.customer TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.location TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.location_pod TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.customer_pod TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.severity TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.logging TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.place TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.credential TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.device TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.device_credential TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.networkinterface TO 'abteilungsleiter1'@'localhost';
GRANT SELECT ON musterag.networkinterfacemode TO 'abteilungsleiter1'@'localhost';

###Bearbeitungsberechtigung###3

GRANT INSERT ON musterag.pod TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.customer TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.location TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.location_pod TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.customer_pod TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.severity TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.logging TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.place TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.credential TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.device TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.device_credential TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.networkinterface TO 'abteilungsleiter1'@'localhost';
GRANT INSERT ON musterag.networkinterfacemode TO 'abteilungsleiter1'@'localhost';
 
###Leseberechtigung###4

GRANT SELECT ON musterag.pod TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.customer TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.location TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.location_pod TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.customer_pod TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.severity TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.logging TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.place TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.credential TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.device TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.device_credential TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.networkinterface TO 'abteilungsleiter2'@'localhost';
GRANT SELECT ON musterag.networkinterfacemode TO 'abteilungsleiter2'@'localhost';

###Bearbeitungsberechtigung###4

GRANT INSERT ON musterag.pod TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.customer TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.location TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.location_pod TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.customer_pod TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.severity TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.logging TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.place TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.credential TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.device TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.device_credential TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.networkinterface TO 'abteilungsleiter2'@'localhost';
GRANT INSERT ON musterag.networkinterfacemode TO 'abteilungsleiter2'@'localhost';

CREATE USER 'logger1'@'localhost' IDENTIFIED BY 'password5';
GRANT INSERT ON musterag.logging TO 'logger1'@'localhost';

CREATE USER 'logger2'@'localhost' IDENTIFIED BY 'password6';
GRANT INSERT ON musterag.logging TO 'logger2'@'localhost';

CREATE USER 'geraete_monitoring_tools1'@'localhost' IDENTIFIED BY 'password7';
GRANT SELECT ON musterag.logging TO 'geraete_monitoring_tools1'@'localhost';
GRANT DELETE ON musterag.logging TO 'geraete_monitoring_tools1'@'localhost';

CREATE USER 'geraete_monitoring_tools2'@'localhost' IDENTIFIED BY 'password8';
GRANT SELECT ON musterag.logging TO 'geraete_monitoring_tools2'@'localhost';
GRANT DELETE ON musterag.logging TO 'geraete_monitoring_tools2'@'localhost';
