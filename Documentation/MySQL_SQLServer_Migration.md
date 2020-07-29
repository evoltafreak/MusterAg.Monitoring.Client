# MySQL to SQL Server Migration Guide

## Database Versions
MySQL - 8.0.20  
SQL Server - 2017 - 14.0.2027.2  

## Installations
### Install SQL Server Migration Assistant for MySQL 
Installieren Sie zuerst das [Tool](https://docs.microsoft.com/en-us/sql/ssma/mysql/sql-server-migration-assistant-for-mysql-mysqltosql?view=sql-server-ver15) `SQL Server Migration Assistant for MySQL (MySQLToSQL)`  
Bei diesem Migration Guide wird die Version [8.10.0](https://download.microsoft.com/download/2/9/2/29255648-7F68-4E27-B2F2-F20434FBB230/SSMAforMySQL_8.10.0.msi) verwendet.  

### Install MySQL ODBC Connector
Installieren Sie den ODBC Driver mit der Version [8.20.0](https://cdn.mysql.com//Downloads/Connector-ODBC/8.0/mysql-connector-odbc-8.0.20-winx64.msi).

## Migration
Öffnen Sie den SSMA und erstellen Sie ein neues Projekt. Danach klicken Sie auf `Connect to MySQL` und übernehmen folgenden Einstellungen:
![SSMA_MySQL_Connection][SSMA_MySQL_Connection]  
Danach klicken Sie auf `Connect` und wählen die zu migrierende Datenbank aus. In unserem Falle wäre das `MUSTERAG`. Bestätigen Sie mit `OK`.   
Anschliessend klicken Sie auf `Connect to SQL Server`. Übernehmen sie folgende Einstellungen und klicken Sie auf `Connect`:  
![SSMA_SQLServer_Connection][SSMA_SQLServer_Connection]  
Wenn noch keine `musterag`-Datenbank existiert, bestätigen Sie mit `Ja`. Wenn der `SQL Server Agent` nicht läuft starten Sie ihn manuell unter Windows unter `Dienste (Services)`.
Danach selektieren Sie auf der linken Seite im `My SQL Metadata Explorer` die Datenbank `musterag` und navigieren via Rechtsklick auf `Convert Schema`.
Als zweiten Punkt wählen Sie noch den Eintrag `Migrate Data` aus, um die Daten zu migrieren.  
Falls es zu Fehler kommt, müssen diese manuell behoben werden.

## Generate Models in EF Core (Database first)
Um in Entity Framework Core Modelklassen mit dem Database-First-Ansatz zu generieren, muss man folgenden Befehle ausführen:
`Install-Package Microsoft.EntityFrameworkCore.Tools`  
`Install-Package Microsoft.EntityFrameworkCore.SqlServer`  
`Scaffold-DbContext "Server=SURFACE;Database=musterag;User Id=<userId>;Password=<password>;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models  

## Import BAK-File
Ein Backup-File steht ebenfalls im Source-Code zur Verfügung, welches via `SSMS` direkt importiert werden kann [musterag.bak](./Restore/musterag.bak). 

[SSMA_MySQL_Connection]: ./Images/SSMA_MySQL_Connection.png "SSMA_MySQL_Connection"
[SSMA_SQLServer_Connection]: ./Images/SSMA_SQLServer_Connection.png "SSMA_SQLServer_Connection"