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
- I BadgemaniaAPI så har jag använt mig av SQL Server som databas.
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
Mappen innehåller 3 filer. Filerna är page.tsx, CreateBadgegroupForm.tsx och BackToBadgegroupsBtn.tsx som båda är komponenter på denna page. Här kan användaren skapa en ny badgegrupp genom att fylla i namnet på den nya gruppen och sedan trycka på Create Badgegroup-knappen. Om detta görs så kommer den nya badgegruppen att skapas och användaren blir skickad tillbaka till /badgegroups där alla badgegrupperna inklusive den nya syns. Om man inte matar in något meddelas dettao och man får försöka igen. Vill användaren gå tillbaka till /badgegroups kan man trycka på Back-knappen.

#### Badgegroup page (/badgegroups/[badgegroupsId])
Mappen innehåller 3 mappar och 5 filer. Mapparna är studens, badgetypes och badges. Filerna är page.tsx, layout.tsx, BadgegroupSelectManager.tsx, BadgegroupHeader.tsx och BadgegroupContainer.tsx. De 3 sistnämda är komponenter som används i denna nestlade layouten för att kunna finnas med på de 3 följande sidorna också. Det är endast läraren som kan växla mellan dessa sidor. Just nu så är det endast en p-tag här men i framtiden så kommer användaren kunna se en dashboard som är olika beroende på om användaren är lärare eller elev.

#### Students page (/badgegroups/[badgegroupsId]/students)
Mappen innehåller 2 filer där den ena är page.tsx och den andra är StudentsInBadgegroup.tsx som är en komponent på denna page. Komponenten visar vilka elever som tillhör denna badgegroupen. Senare så ska läraren här även kunna lägga till och ta bort elever från gruppen.

#### Badgetypes page (/badgegroups/[badgegroupsId]/badgetypes)
Mappen innehåller för tillfället endas page.tsx. Här kommer läraren senare att kunna se, lägga till, ändra och tabort badgetypes. Nu är det endast en p-tag.

#### Badges page (/badgegroups/[badgegroupsId]/badges)
Mappen innehåller för tillfället endas page.tsx. Här kommer läraren senare att kunna se, lägga till, ändra och tabort badges. Nu är det endast en p-tag. 

#### Schools page (/schools)
Mappen innehåller för tillfället endas page.tsx. Här kommer senare super admin att kunna se, lägga till, ändra och tabort skolor. Nu är det endast en Header och en p-tag. 

## `Hur startas applicationen`

### `Backend (BadgemaniaAPI)`
1. För att kunna köra backenden så öppnar man först projektet med sln-filen Badgemania.sln.
2. Eftersom projektet använder SQL Server så behöver man första gången gå in i appsettings.json och byta namn till sitt egna servernamn.
3. När det är gjort så behöver man gå till Package Manager Console och skriva in Update-Database.
4. Sedan är det bara att trycka på https-knappen (gröna play-knappen) så startas API:et och Swagger ska komma fram med alla endpoints.
5. Jag har seedat 1 av varje användare i API:et, Super Admin (admin@admin.com) kommer skapas vid första körningen för det kollas att den finns medans vagga@student1.com, vagga@teacher1.com och vagga@admin.com kommer skapas vid Update-Database.
6. Lösenordet är "Test1234" för alla.
7. I nuläget har jag inte fixat så clienten kan registrera användare men man kan enkelt göra det i Swagger med mina /api/Auth/Register... endpoints. Är man inloggad som super admin så kan man skapa schools och sedan skapa school admins till dessa. Är man inloggad som school admin så kan man skapa teachers och students till skolan som den skoladminen är kopplad till.
8. Som du kommer se så har jag byggt många fler endpoints än vad som i nuläget används av clienten, men dessa kommer så klart i framtiden att användas och fler läggs till då det behövs men alla som finns fungerar i Swagger om du vill testa dem.

### `Frontend (BadgemaniaClient)`
1. Öppna BadgemaniaClient-mappen i vscode.
2. Om det är första gången så går man till terminalen och skriver `npm install` så installeras alla filer som behövs.
3. När det är klart så skriver man `npm run dev` (se till att det körs på `https://localhost:3000` så backenden accepterar detta, detta ska vara installerat redan i mitt projekt så borde lösas automatiskt).
4. Tryck ctrl och klicka på länken https://localhost:3000 i terminalen så öpnnas webbläsaren eller skriv in adressen själv i webbläsaren.
(Vid något tillfälle då man precis hade kört npm run dev och tryckt på https://localhost:3000 så uppdaterades inte navbaren men stängde man då ner fönstret och startade om så funkade det igen och även om man stoppade med ctrl+c och sedan startade igen gick det eller att man updaterade fönstert så gick det också. Kunde inte komma på vad det beror på men gissar att det är något med uppstarten av npm run dev för det har fungerat nu för mig).

## `Reflektion och Analys`
I denna uppgift valde jag att utmana mig själv ordentligt genom att inte bara jobba i React och Next.JS som vi skulle utan också att använda TypeScript, Tailwindcss och inte minst att bygga ett eget REST API som är mycket mer komplext än vad vi har byggt tidigare i utbildningen. Bara detta gör att jag redan har förbättrat min applikation avsevärt jämfört med om jag enbart hade gjort den med JavaScript, vanlig CSS och "färdigt API". TypeScript gör ju att koden typas så att det blir säkrare och enklare att hitta eventuella fel som kan uppstå bland annat. Tailwind har varit riktigt smidigt att använda för styling och jag gillar det mycket jämfört med CSS. Det känns också som att Tailwind påminner till viss del om Bootstrap som jag använt mig av tidigare men ännu bättre vilket så klart är kanon. I mitt arbete så har jag försökt att skapa komponenter då jag upptäkt att jag upprepat mig i koden samt att jag har skapat interface för att typa t.ex. object som ska tas in eller skickas med. Jag har valt att lägga komponenter som hör till en viss sida i samma mapp som sidan själv så att man enklare ser vilken sida den hör till. Man skulle kunnat lägga alla komponenter i component-mappen också så klart. Båda har sina för och nackdelar. Jag har försökt vara så noga som möjligt med namngivningen av komponenter och variabler så att man enklare ska kunna sätta sig in i koden. Jag har flyttat om mycket kod för att ha t.ex. alla API-calls på samma ställe i utils/api.ts istället för att ha det i komponenterna så att jag endast behöver kalla på funktionen istället. Samma gäller med att hämta och sätta localstorage, det sker också på ett enda ställe i utils/auth.ts. När jag hanterar forms så finns den koden i utils/forms. Länkarna till navigeringen har jag flyttat till utils/nav.links så man enkelt kan lägga till fler senare där. Något som jag har fått kämpa mycket med är inloggningen i form av JWT och HTTP only Cookie som jag använder mellan min backend och frontend för att veta att en användare är inloggad och har t.ex. rättigheter på sin roll att utföra olika saker i applikationen. Arbetet med att bygga backenden var givande, roligt och komplext med bland annat many-to-many förhållanden som vi inte har jobbat med innan i utbildningen. Att fixa till så att olika roller fungerar tog också sin tid men var riktigt belönande när man lyckades. Man skulle kunna förbättra applikationen genom att ännu mer se över hierakin av komponenter. Går nog att dela upp i ännu fler steg, men de val som jag har gjort har jag tagit för att jag tycker att det ökar läsbarheten i koden vilket är bra för framtiden och skalbarheten. Jag är nöjd med min kod och design i nuläget om man tänker på den tid som jag haft till mitt förfogande samt att jag utmanade mig själv med TypeScript, Tailwindcss och eget REST API i ASP.NET. Vad som självklart kan förbättras i nästa steg för applikationen är att bygga vidare på den med fler endpoins som jag kallar på då i frontenden som jag nämnt i min requirements.md, se där för mer om detta. Denna uppgiften har varit mycket rolig att jobba med men också mycket utmanande, främst för att man vill göra så mycket hela tiden och ibland vet man inte vilken av sakerna som man vill göra först men man lär sig med tiden mer och mer.



