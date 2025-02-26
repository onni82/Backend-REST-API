# REST-API f�r CV-hantering

---
# Vad du ska g�ra

**Databasen**

Du ska designa och skapa en databas som lagrar information om en persons utbildning och arbetslivserfarenhet.

- [ ]  **Personlig information**
    - Namn, beskrivning, kontaktuppgifter.
- [ ]  **Utbildningar**
    - Skola, examen, st art- och slutdatum.
- [ ]  **Arbetserfarenhet**
    - Jobbtitel, f�retag, beskrivning och �r.

- [ ]  Designa ett **ER-diagram** som visar hur tabellerna �r relaterade.
- [ ]  Skapa databasen med **Entity Framework Core** genom **Code-First**.
- [ ]  L�gg upp en bild av ditt **ER-diagram** i **README-filen** i ditt Git-repo.

---

**Skapa ett REST-API**

Ditt API ska g�ra det m�jligt att hantera information om en persons utbildningar och arbetslivserfarenhet.

Anropen till databasen ska l�sas genom Entity Framework.

- [ ]  **H�mta all data** (alla personer, utbildningar och jobberfarenheter).
- [ ]  **H�mta en specifik post** baserat p� dess ID.
- [ ]  **L�gga till ny utbildning eller jobberfarenhet**.
- [ ]  **Uppdatera befintlig information** (t.ex. �ndra jobbtitel eller examens�r).
- [ ]  **Ta bort en utbildning eller jobberfarenhet**.

---

**Integrera ett externt API**

F�r att inkludera anrop till externa API:er ska du:

- [ ]  Implementera en endpoint d�r en anv�ndare kan **ange sitt GitHub-anv�ndarnamn**.
- [ ]  N�r anv�ndarnamnet anges ska API:et h�mta **en lista �ver personens publika GitHub-repositories** via GitHub API.
- [ ]  Returnera **minst** f�ljande information:
    - Repository-namn.
    - Spr�k som anv�nds i repot (om inget spr�k anges, returnera �ok�nt� som v�rde).
    - Beskrivning av repot (om finns, annars �saknas� som v�rde).
    - L�nk till repot.

---

**S�kerhet & validering**

F�r att s�kerst�lla att API:et �r robust och s�kert ska du:

- [ ]  Implementera **validering** f�r att f�rhindra att ogiltiga eller tomma f�lt skickas in.
- [ ]  S�kerst�ll att API:et returnerar **relevanta status koder** vid olika typer av anrop.
- [ ]  F�rhindra att anv�ndare kan �ndra eller ta bort data som de inte sj�lva har skapat.
