# Djupgående Dokumentation, Reflektion och Analys av Alexander Välitalos: Inlämningsuppgift 6: Bygg din egen idé med React

## `Dokumentation`

### Allmänt om mitt arbete
- Denna applikation `BadgemaniaClient` är byggd med React, Next.JS och använder mitt egna REST API `BadgemaniaAPI` som jag byggt med ASP.NET. API:et innehåller många fler endpoints än vad som används just nu av klienten men är förberett för kommande "fetcher" senare.
- Applikationen använder sig av SPA (single page application) så den inte behöver ladda om då man går till olika "pages".
- Med Next.JS så används server-side rendering och static site generation för att leverera sidor snabbt, vilket förbättrar användarupplevelsen och prestandan.
- Det ger även SEO-optimering då innehållet direkt blir tillgängligt för sökmotorer om sidan tas i produktion.
- Det blir bättre produktivitet med automatisk routing och hot reloading för utvecklingsprocessen.
- En annan fördel är hög skalbarhet.
- I mitt projekt har jag även använt TypeScript för att kunna ha typade variabler och lättare felsökning om något skulle gå fel.
- I mitt projekt har jag även använt mig utav Tailwindcss för att enklare kunna styla element och komponenter som jag vill, samt för responsiv design.
- I mitt projekt har jag även använt mig utav EsLint för att hitta fel som kan uppstå i koden.
- I projektet så använder jag JWT-token som accesstoken och HTTP only Cookie för att kunna refresha accesstoken och för att endast backenden ska kunna komma åt den så det blir säkrare. 

### `Komponenter som används på flera ställen i min applikation`

#### Header
Header är en komponent består av en yttre div som innehåller en Image med badgemanias logga och en h1 som informerar vilken sida man är på
 
#### NavigationLink
NavigationLink är en komponent som består av en Link och en h2 som byggs upp av informationen från link-propen som är av typen NavigationLinkProps, link i sin tur är av typen RouteLink som jag har definierat i en egen fil under mappen interfaces. Denna information kommer ifrån Navigation-komponenten.
Hur Link ska designas bestäms av vilken sida man befinner sig på i nuläget då den jämför sidans namn med hjälp av usePathname som importeras från next/navigation samt att den hämtar första delen av pathname om man "dykt" ner djupare i applikationen.

#### Navigation
Navigation är en komponent som bygger upp alla NavigationLink:ar genom att ha informationen till varje i en object-array `UN_AUTH_LINKS, SUPER_ADMIN_LINKS, TEACHER_LINKS eller STUDENT_LINKS` beroende på om man är inloggad och vilken roll man har. Dessa är av typen RouteLink och sparas i en hook `links` för att kunna renderas rätt. `links` lopas igenom med .map och skapar en ny NavigationLink för varje object i arrayen. Det skapas även en `Logout` knapp om användaren är inloggad.

#### Refresher
Refresher är en komponent som kollar om det är dags att göra en ny JWT-token (och ny Refresh-token) varje gång som användaren går till en ny page. Detta gör den genom utils/api och utils/auth. Om det är första renderingen så pushar vi om sidan för att se till så att navigeringen renderas rätt.

### `Layouts` i applikationen

#### Root Layouten
Root Layouten använder Refresher och Navigation komponenterna utöver children propsen så att de finns i hela applikationen

#### Layout i badgegroupId
Layouten i badgegroupId används för att kunna ha en gemensam BadgegroupHeader och en BadgegroupContainer på sidorna badgegroupID, badgegroupID/students, badgegroupID/badgetypes och badgegroupID/badges då en lärare ska kunna växla mellan dessa utan behöva lägga in en BadgegroupHeader och en BadgegroupContainer på varje sida av dessa.

### `Sidor (pages) i applikationen`

#### Home page (/)
Home sidan använder komponenten Navigation och inuti den så finns ett mainelement som innehåller en Image, h1 och en h2
Home sidan välkomnar användaren och förklarar kort vad Badgemania gör.

#### Solutions page (/solutions)
Mappen solutions innehåller 2 filer där den ena är page.tsx och den andra är en komponent Solution.tsx som används på denna page.tsx.
Solution är en komponent som tar in solutionText som SolutionProps. SolutionProps är ett interface som talar om att solutionText är av typen SolutionList. solutionText får sin information av page.tsx och med hjälp av den så bygger den upp en div som innehåller en h2 med texten för aktuell solution och därefter en ul.lista med li-element skapas med hjälp av solutionText.text med .map. 
Solution page har listan med SOLUTIONS som skickas till komponenten Solution. Solution page bygger sidan genom att använda komponenten Navigation som innehåller ett main-element som i sin tur innehåller komponenten Header och en div som mappar igenom SOLUTIONS-object-arrayen och skapar en Solutionskomponent för varje object i arrayen.

#### Pricing page (/pricing)
Mappen pricing innehåller 2 filer där den ena är page.tsx och den andra är en komponent PriceTable.tsx som används på denna page.tsx. 
PriceTable är en komponent som tar in priceInfoText som PriceTableProps. PriceTableProps är ett interface som talar om att priceInfoText är av typen PriceInfoList. priceInfoText får sin information av page.tsx och med hjälp av den så bygger den upp en div som innehåller en h2 med titeltexten på det aktuella prispaketet, en p med priset och en ul-lista med information om vad som ingår i det prispaketet. 
Pricing page har listan med PRICEINFO som skickas till komponenten PriceTable genom .map. Pricing har alltså en Navigation-komponent som innehåller en main som i sin tur innehåller komponenten Header följt av en div som tar PRICEINFO-listan och bygger vadera PriceTable med som sagt .map

#### About page (/about)
Mappen about innehåller page.tsx filen. About page byggs upp med hjälp av string-listan ABOUTS. Sidan har en Navigation-komponent som innehåller en main som i sin tur innehåller en Header-komponent och en div som kör .map på ABOUTS-listan för att bygga upp en div och en p för varje element i arrayen.

#### Contact page (/contact)
Mappen contact innehåller page.tsx filen. Contact page byggs upp med hjälp av Navigation-komponenten som innehåller en main som i sin tur innehåller Header-komponenten följt av en div. Denna div innehåller en annan div som har 4 stycken p med contactinformation och uppmaning om att företaget gärna tar emot feedback. Den andra p innehåller även en mail-länk som i nuläget fungerar men inte är kopplad till en riktig mail för visning.

#### Login page (/login)
Mappen innehåller 2 filer där den ena är page.tsx och den andra är en komponent LoginForm.tsx som används på denna page. Denna sida innehåller även komponenten Header. På denna sidan kan användaren logga in genom att fylla i epost och lösenord och sedan trycka på Login-knappen. Om det är korrekt så loggas användaren in och kommer till home-sidan och ser att navbaren ändras med länkar till det som användarens roll har tillgång till samt att en logout-knapp finns istället för login-knapp. Matar användaren in fel så kommer ett meddelande fram och man får försöka igen. Man blir även meddeladd om ett fält är tomt när man trycker på Login-knappen.

#### Badgegroups page (/badgegroups)
Mappen innehåller 2 mappar och 4 filer. Mapparna är badgegroupId och create. Filerna är page.tsx, BadgegroupBtn.tsx, Badgegroups.tsx och CreateBadgegroupBtn.tsx. De 3 sistnämda är komponenter på denna page. På denna sidan så ser användaren sina badgegrupper som den tillhör. Är användaren en lärare så syns även en Create Badgegroup-knapp. Om användaren trycker på en grupp så kommer man till den gruppens sida (badgegroup/badgegroupId). Trycker användaren på Create Badgegroup-knappen så kommer man till badgegroups/create sidan.

#### Create Badgegroup page (/badgegroups/create)
Mappen innehåller 3 filer. Filerna är page.tsx, CreateBadgegroupForm och BackToBadgegroupsBtn som båda är komponenter på denna page. Här kan användaren skapa en ny badgegrupp genom att fylla i namnet på den nya gruppen och sedan trycka på Create Badgegroup-knappen. Om detta görs så kommer den nya badgegruppen att skapas och användaren blir skickad tillbaka till /badgegroups där alla badgegrupperna inklusive den nya syns. Om man inte matar in något meddelas dettao och man får försöka igen. Vill användaren gå tillbaka till /badgegroups kan man trycka på Back-knappen.

## `Hur startas applicationen`

## `Reflektion och Analys`
I denna uppgift valde jag att utmana mig själv ordentligt genom att inte bara jobba i React och Next.JS som vi skulle utan också att använda TypeScript och Tailwindcss. Bara detta gör att jag redan har förbättrat min applikation avsevärt jämfört med om jag enbart hade gjort den med JavaScript och vanlig CSS. TypeScript gör ju att koden typas så att det blir säkrare och enklare att hitta eventuella fel som kan uppstås bland annat. Tailwind har varit riktigt smidigt att använda för styling och jag gillar det mycket jämfört med CSS. Det känns också som att Tailwind påminner till viss del om Bootstrap som jag använt mig av tidigare men ännu bättre vilket så klart är kanon. I mitt arbete så har jag försökt att skapa komponenter då jag upptäkt att jag upprepat mig i koden samt att jag har skapat interface för att typa t.ex. object som ska tas in eller skickas med. Man skulle kunna förbättra applikationen genom att ännu mer se över hierakin av komponenter. Går nog att dela upp i ännu fler steg, men de val som jag har gjort har jag tagit för att jag tycker att det ökar läsbarheten i koden vilket är bra för framtiden och skalbarheten. Jag är nöjd med min kod och design i nuläget om man tänker på den tid som jag haft till mitt förfogande samt att jag utmanade mig själv med TypeScript och Tailwindcss. Vad som självklart kan förbättras i nästa steg för applikationen är att bygga vidare på den med framförallt möjlighet till att kunna logga in som olika sorters användare som student, lärare, skol admin och super admin och att dessa då har olika funktioner som de kan utföra (se min requirements.md för mer information om detta).



