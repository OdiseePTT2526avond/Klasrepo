# Situering
Dit is de documentatie van de bibliotheek mijnbib met een beperkte set requirements. Zie de documentatie in mijnbib en use cases voor de aangepaste versie.

## use case tests
Maak in UC2.cs de use case tests voor use case 2. Vermits deze ook uc1 en 4 bevat moeten ook deze in de tests voorkomen. Test natuurlijk ook de alternatieve scenarios.  
De stappen van de use case tests kan je vanuit de controller oproepen.

## test doubles
De services zijn afhankelijk van de repository klasse. Er bestaan reeds testen voor de service klassen maar die zijn gemaakt zonder test doubles. :(

Maak de nodige test doubles aan voor de repository klasse zodat de services getest kunnen worden in een zo simpel mogelijke omgeving. In je double gebruik je andere data dan in de echte repository zodat je zeker weet dat de double gebruikt wordt. Pas natuurlijk de data waar de tests op Asserten zodat ze overeenkomen met de data uit de double.

## TDD
Voeg toe:
Req21 Mijnbib kan bepalen hoeveel extra ontleningen een lid nog mag maken.  
Req22 Een lid mag maximaal 2 open ontleningen op elk ogenblik hebben.  
Maak natuurlijk eerst unit tests voor deze requirements en pas daarna de code aan zodat de tests slagen. Pas daarna ook de use case tests aan zodat ze ook deze nieuwe requirements testen. Deze req staat best in uc2 tussen stap 4 en 5.  
Tip: Er zijn in de controller al methodes aanwezig die je hierbij kunnen helpen: 
HuidigLidMagUitlenen en GetAantalOpenUitleningen. Controle op het aantal open ontleningen gebeurd best niet in de controller maar in de service laag want het zijn business rules en geen UI regels (vb is de input een nummer of een string).
Tip: Kijk naar ValideerLidkaart_AlleLidkaarten_WorksCorrectly

Req30 Een lid kan geen werk ontlenen dat op dit moment reeds is uitgeleend.  
Req31 Mijnbib kan bepalen of een werk reeds is uitgeleend of niet.  
unit tests -> code -> use case tests. Dit kan best in uc2 tussen na stap 5, het ingeven van het werknr.
