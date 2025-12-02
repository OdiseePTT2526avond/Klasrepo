# Inventory oefening

## Situering

Een magazijnbeheerder van een dierenwinkel maakte een eenvoudig systeem om zijn voorraad bij te houden.
Hij heeft de mogelijkheid hebben om een order/bestelling te maken door in de linkse lijst te dubbel klikken op een product.

Elk product heeft een naam, een prijs en een hoeveelheid in voorraad.
Vele functionaliteiten ontbreken nog in dit systeem maar ook de programeervaardigheden blijken beperkt.

## Huidige code
De te verkopen producten zijn StockItems. De applicatie interface toont links de huidige voorraad van StockItems en rechts de huidige bestelling (Order).

De user kan een StockItem toevoegen aan de orderlijst door te dubbelklikken op een StockItem in de voorraadlijst.

De klasse InventoryWindow is een partial class, dwz het is 1 class die beschreven staat in meerdere bestanden (InventoryWindowCalculations en InventoryWindowLoading).

## Opgave

1. Verbeter de code van het magazijnsysteem door het SRP principe ten volle toe te passen.
2. Schrijf voor elke class EN method een comment (///) die de verantwoordelijkheden van deze method beschrijft. Evalueer of elke method enkel hieraan bijdraagt.  
 Hint:Denk denk goed na over de rol die de code behind van een Window heeft in een applicatie. 
3. In punt 4 staat extra functionaliteit die nog niet bestaat. Voor elke functionaliteit bepaal je de juiste class en de juiste property of method. Schrijf dit neer in deze README file.  
  vb.  
	> REQXXX: Voor een opgegeven dag moet een rapport kunnen opgesteld worden dat het totaal aantal bestellingen van die dag bewaard.  
	> Class: DagelijksRapport.  
	> Property:int totaalAntalBestellingen  
	> Method: int BerekenTotaalAantalBestellingen().

4. Extra functionaliteit:
   * REQ001 Als een bestelling met producten meer dan 10 euro bedraagt, moet er een korting worden toegepast op het totaalbedrag. Een lege bestelling is geen bestelling.
   * REQ002 De korting is nu 10% maar moet in een variabele ergens opgeslagen zijn. Denk na over de plaats waar deze variabele best bewaard wordt.
   * REQ003 De magazijnbeheerder wil alle bestellingen onthouden die hij gemaakt heeft tijdens zijn sessie. Dat is inclusief de verkochte producten.
   * REQ004 Bewaar een bestelling als op de processOrderButton geklikt wordt.
   * REQ005 Verwijder de zichtbare bestellingenlijst als op de processOrderButton geklikt wordt.
   * REQ006 Het aantal bewaarde bestellingen moet berekent worden.
5. Maak de nodige classes, properties en methods aan maar je hoeft de methods niet te implementeren.  
  vb 
	`````` csharp
	/// Stelt het rapport op dat alle belangrijke zaken van 1 dag bijhoudt.
	public class DagelijksRapport(Datetime rapportDatum)  {
		private DateTime rapportDatum;
		private int aantalBestellingen;

		/// Berekent het aantal bestellingen op de rapportDatum.
		private int BerekenAantalBestellingen() { }
	}
	``````

Hint: denk goed na over de rol die de code behind van een Window heeft in een applicatie. 
