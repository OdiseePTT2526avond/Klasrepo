# Bibliotheek: mijnbib
## Situering
De app mijnbib is een zelfbedieningssysteem voor bibliotheken en wordt gebruikt door de leden van de bib. Elk lid heeft een lidkaart.
Op dit moment kan enkel een uitlening geregistreerd worden, maar geen werken worden ingeleverd.
Er kan maar 1 lid tegelijk inlogt zijn in de applicatie (per computer).

## Woordenlijst
Een werk is een boek, e-boek, DVD, ...   
Een ontlening/uitlening zal een werk uitlenen aan een lid.  
Een inlevering is het teruggeven van een ontleend werk.  
Een open ontlening is een ontlening die nog niet is ingeleverd.  
Een lid is een persoon waarvan de lidkaart geverifieerd geldig is.  

## Business process model
* ACT10 Een persoon kiest voor uitlenen of inleveren.
* ACT20 Een persoon biedt lidkaart aan.
* ACT30 Lid biedt een werk aan ter ontlening.
* ACT40 Lid beslist of er nog een werk wordt ontleent of niet.
* ACT50 Lid leest de "niet geimplementeerd" mededeling die verschijnt op het scherm.


## Requirements:
Req01 Een persoon kan een sessie openen door een lidkaart aan te bieden  
Req02 Mijnbib kent alle geldige lidkaarten.  
Req03 Mijnbib kan bepalen of een lidkaart geldig is of niet.  
Req04 Een persoon kiest voor uitlenen of inleveren.  
Req10 Een lid kan kiezen om in te leveren of uit te lenen, niet beide tegelijk.  
Req11 Mijnbib verontschuldigt zich bij het lid dat inleveren nog niet mogelijk is.  
Req20 Mijnbib kent alle ontleningen van elk lid.  
Req32 Mijnbib kan een nieuwe uitlening onthouden.  
Req40 Een lid kan een sessie afsluiten.  

## Mogelijke classes
Persoon: Geen data over tenzij het een lid is. Enkel een lid kan boeken ontlenen.  
Lid   
Lidkaart: lijkt vanuit het perspectief van de applicatie identiek aan lid  
Mijnbib: de applicatie  
Werk  
Ontlening/Uitlening  
Sessie: zelfde als het proces 1 maal uitvoeren vanaf de lidkaart wordt aangeboden tot het afsluiten.  
## Data  
Lid/lidkaart:   
lidnaam en nummer  
Werk:  
*	Auteur en naam  
*	werknr  
Ontlening:  
*	Lid  
*	Werk  
*	Uitleendatum   
*	Inleverdatum  (niet gebruikt in deze versie))
Sessie  
*	Lid (ingelogt)  


## Toewijzen van verantwoordelijkheden
Navigatie 
Navigatie van data: bepaal in welke richting je de data opzoekt. Vb Lid -> ontlening = we kennen het lid en we zoeken de ontleningen op van dit lid.
Lid -> ontlening: ja, gebruikt in ACT30
Ontlening -> lid: Neen (dit is waarschijnlijk wel interessant voor de bibliotheekmedewerkers of de automatische reminder email klasse maar die staan niet in de opgave)
Ontlening -> werk: niet gebruikt
Werk-> ontlening: ja voor requirement 30

