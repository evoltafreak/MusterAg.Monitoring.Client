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

**LINQ Checkbox**  
Durch das Aktivieren der LINQ-Checkbox werden alle Datenbankabfragen via LINQ getätigt.
Beide Implementierungen liefern jedoch dieselben Resultate zurück.

**Location Tree anzeigen**  
Wenn man den Button `Location Tree anzeigen` betätigt, wird ein Fenster geöffnet, welches die Locations in einer `TreeView` anzeigt.
![LocationTreeWindow][LocationTreeWindow]

## CustomerWindow  
Im `CustomerWindow` können die Kunden verwaltet werden.
![CustomerWindow][CustomerWindow]

**Suche**  
Im oberen Bereich befindet sich die `Suche`. Dort kann man mittels QuickSearch die Kunden nach `Vorname` und `Nachname` durchsuchen.

**DataGrid der Kunden**  
In dem DataGrid werden alle wichtigen Informationen über die Kunden dargestellt:  
- `ID` - Identifikationsnummer des Kunden
- `Gender` - Geschlecht
- `Firstname` - Vorname
- `Lastname` - Nachname
- `Location` - Wohnort
- `Birthday` - Geburtstag
- `Email` - E-Mail-Adresse
- `Tel` - Telefonnummer

**Kunden laden**
Mit dem Button `Kunden laden` werden alle Kunden in der Datenbank geladen.

**Kunde erfassen**
Wenn man den Button `Kunde erfassen` anklickt, öffnet sich ein neues Fenster in dem man einen neuen Kunden anlegen kann.  
Dabei stehen Textfelder, Dropdowns und ein Datepicker zur Verfügung.  
![CustomerWindow_Create][CustomerWindow_Create]

**Kunde editieren**
Dasselbe Fenster wie oben wird geöffnet wenn man den Punkt `Kunde eitieren` anwählt und den entsprechenden Kunden im DataGrid selektiert.  
Dabei werden die Werte bereits in den GUI-Elementen befüllt und können überschrieben werden.  
![CustomerWindow_Update][CustomerWindow_Update]

**Kunde löschen**
Als letzten Punkt, kann man noch einen Kunden löschen. Dabei muss man wieder einen Kunden im DataGrid selektieren und  
danach den Button `Kunde löschen` betätigen.

[MainWindow]: ./Images/MainWindow.png "MainWindow"
[MainWindow_LoadData]: ./Images/MainWindow_LoadData.png "MainWindow_LoadData"
[MainWindow_AddLog]: ./Images/MainWindow_AddLog.png "MainWindow_AddLog"
[MainWindow_FindDuplicates]: ./Images/MainWindow_FindDuplicates.png "MainWindow_FindDuplicates"
[MainWindow_ShowAllLocation]: ./Images/MainWindow_ShowAllLocation.png "MainWindow_ShowAllLocation"
[CustomerWindow]: ./Images/CustomerWindow.png "CustomerWindow"
[CustomerWindow_Create]: ./Images/CustomerDetailWindow_Create.png "CustomerWindow_Create"
[CustomerWindow_Update]: ./Images/CustomerDetailWindow_Update.png "CustomerWindow_Update"
[LocationTreeWindow]: ./Images/LocationTreeWindow.png "LocationTreeWindow"
