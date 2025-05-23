Finns det någon risk med att vem som helst kan skicka anrop till ert API?
-De kan manipulera eller ta bort vår data, vilket kan leda till att vi får felaktig information eller skadlig kod i vår databas och 
att vi inte kan lita på den informationen samt att det kan göra våra users sårbara för attacker.

Vad skulle ni kunna göra för att minska den risken?
-Vi kan implementera CSP för att inaktivera inline scripts, inline eventhandlers och eval() i vår kod samt sanera och validera all användarinmatning.

Finns det någon personuppgift i projektet?
- För närvarande så har vi inga direkta eller indirekta personuppgifter i projektet då vi inte har någon inloggning eller registrering.
- Det är något vi hade med som eventuell vidareutveckling.

Om ja – vad behöver ni tänka på när ni hanterar den?
-Om vi hade haft inloggning/registrering i projektet så hade vi behövt informera användaren om att nödvändiga personuppgifter sparas och varför samt vilka rättigheter de har angående deras personuppgifter.
-Vid hanteringen så hade vi behövt vidta åtgärder för att skydda personuppgifterna/datan från obehöriga och samtidigt följa GDPR. 
-T.ex. genom att använda HTTPS för att skydda datan under överföringen och kryptering av datan i databasen, samt HTTPOnly för att skydda mot sessionskapningar.