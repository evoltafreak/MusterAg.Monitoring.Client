# Documentation

## Main Window
Die Applikation startet mit dem `MainWindow`. Das Fenster ist mittels einem `Grid` dargestellt und kann
somit ganz einfach vergrössert und verkleinert werden, wobei sich die inneren UI-Elemente automatisch anpassen.

**Fenstertitel `Muster Ag Monitoring`**  
![MainWindow][MainWindow]

**Datenbankverbindung als Label und Textfeld**  
Mittels Änderung dieses Feldes, kann man den `ConnectionString` zur Datenbank ändern.  

**DataGrid der Logs**  
In dem DataGrid werden alle wichtigen Informationen über die Logs dargestellt:  
- `ID` - Identifikationsnummer des Pods
- `Pod` - Name des Pods
- `Location` - Ort des Gerätes
- `Hostname` - Hostname des Gerätes
- `Severity` - Schwierigskeitsgrad des Logs
- `Timestamp` - Zeitstempel des Logs
- `Message` - Inhalt des Logs

**Buttons mit diversen Funktionalitäten**  
Im unteren Bereich des Fenster befinden sich Buttons diversen Funktionalitäten (unten erläutert), dargestellt in einem `WrapPanel`:  

**Logs laden**  
Hier werden alle Logs der Pods geladen. Die View `v_logentries` wird aufgerufen.
![MainWindow_LoadData][MainWindow_LoadData]

**Logs löschen**  
Hier werden alle Logeinträge eines im DataGrid markierten Pods gelöscht. Die Stored Procedure `sp_LogClear` wird aufgerufen.
Wenn kein Pod selektiert wurde, wird eine Fehlermeldung angezeigt.

**Logs hinzufügen**  
Dabei wird ein neues Fenster geöffnet, welches erlaubt `Message`, `Pod` und `Log level` auszuwählen.
Die `Message` wird in einer Textbox dargestellt. Der `Pod` und der `Log level` werden in einer DropDown dargestellt, welche bereits mit möglichen Werten ausgefüllt ist.
Wenn `Speichern` gedrückt wird, werden die ausgewählten Werte via Stored Procedure `sp_LogMessageAdd` in die Datenbank hinzugefügt.
Es müssen alle Felder ausgewählt werden. Ansonsten erscheint eine Fehlermeldung.
![MainWindow_AddLog][MainWindow_AddLog]

**Duplikate finden**  
Wenn man diesen Button drückt, werden alle Logeinträge, welches dieselbe `Message` und `Severity` haben in einer `MessageBox` angezeigt.
![MainWindow_FindDuplicates][MainWindow_FindDuplicates]

**Alle Standorte anzeigen**  
Hier werden alle eingetragenen Standorte in einer `MessageBox` angezeigt. Die Anzahl wird ebenfalls visualisiert.
![MainWindow_ShowAllLocation][MainWindow_ShowAllLocation]

[MainWindow]: ./Images/MainWindow.png "MainWindow"
[MainWindow_LoadData]: ./Images/MainWindow_LoadData.png "MainWindow_LoadData"
[MainWindow_AddLog]: ./Images/MainWindow_AddLog.png "MainWindow_AddLog"
[MainWindow_FindDuplicates]: ./Images/MainWindow_FindDuplicates.png "MainWindow_FindDuplicates"
[MainWindow_ShowAllLocation]: ./Images/MainWindow_ShowAllLocation.png "MainWindow_ShowAllLocation"

