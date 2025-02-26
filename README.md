# REST-API för CV-hantering

---
# Vad du ska göra

**Databasen**

Du ska designa och skapa en databas som lagrar information om en persons utbildning och arbetslivserfarenhet.

- [ ]  **Personlig information**
    - Namn, beskrivning, kontaktuppgifter.
- [ ]  **Utbildningar**
    - Skola, examen, st art- och slutdatum.
- [ ]  **Arbetserfarenhet**
    - Jobbtitel, företag, beskrivning och år.

- [ ]  Designa ett **ER-diagram** som visar hur tabellerna är relaterade.
- [ ]  Skapa databasen med **Entity Framework Core** genom **Code-First**.
- [ ]  Lägg upp en bild av ditt **ER-diagram** i **README-filen** i ditt Git-repo.

---

**Skapa ett REST-API**

Ditt API ska göra det möjligt att hantera information om en persons utbildningar och arbetslivserfarenhet.

Anropen till databasen ska lösas genom Entity Framework.

- [ ]  **Hämta all data** (alla personer, utbildningar och jobberfarenheter).
- [ ]  **Hämta en specifik post** baserat på dess ID.
- [ ]  **Lägga till ny utbildning eller jobberfarenhet**.
- [ ]  **Uppdatera befintlig information** (t.ex. ändra jobbtitel eller examensår).
- [ ]  **Ta bort en utbildning eller jobberfarenhet**.

---

**Integrera ett externt API**

För att inkludera anrop till externa API:er ska du:

- [ ]  Implementera en endpoint där en användare kan **ange sitt GitHub-användarnamn**.
- [ ]  När användarnamnet anges ska API:et hämta **en lista över personens publika GitHub-repositories** via GitHub API.
- [ ]  Returnera **minst** följande information:
    - Repository-namn.
    - Språk som används i repot (om inget språk anges, returnera “okänt” som värde).
    - Beskrivning av repot (om finns, annars “saknas” som värde).
    - Länk till repot.

---

**Säkerhet & validering**

För att säkerställa att API:et är robust och säkert ska du:

- [ ]  Implementera **validering** för att förhindra att ogiltiga eller tomma fält skickas in.
- [ ]  Säkerställ att API:et returnerar **relevanta status koder** vid olika typer av anrop.
- [ ]  Förhindra att användare kan ändra eller ta bort data som de inte själva har skapat.
