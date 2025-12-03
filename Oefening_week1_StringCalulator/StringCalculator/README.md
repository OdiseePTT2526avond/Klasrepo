## Oefening String Calculator

### Opgave

Bekijk het project met de naam StringCalculator.
De methode `Calculate` in de klasse `StringCalculator` zal, op basis van een gescheiden reeks van gehele getallen, de som van de getallen in de reeks optelt.
Deze methode heeft de volgende requirements
1. Een lege string resulteert in nul '' => 0
2. Een string met 1 getal resulteert in dat getal '1' => 1 '2' => 2
3. Een string met twee getallen gescheiden door een komma resulteren in de som '1,2' => 3 '10,20' => 30
4. Een string met twee getallen gescheiden door een enter/newline ("\n") resulteren in de som '1\n2' => 3
5. Een string met twee of meer getallen gescheiden door een komma of een enter/newline ("\n") resulteren in de som '1\n2,3\n4' => 10
6. Een string met negatieve getallen resulteert in een exception met het bericht "Kan niet negatief zijn" '-1,2,-3' => 'Kan niet negatief zijn'
7. Getallen in de string groter dan 1000 worden genegeerd.

* Vervolledig  eerst de test voor requirement 1. De test moet falen.
* Implementeer req 1 tot de test lukt.
* Voor elke requirement:
  * Maak de nodige testen (die falen).
  * Implementeer deze requirement tot alle bestaande testen slagen.
  * Documenteer je testen (welke test checkt welke requirement) en je implementatie.

Implementeer exact wat gevraagd is. Niets meer of minder.

https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split#specify-multiple-separators