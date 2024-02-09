# CV_storage
This exercise was made for ASP.NET Core MVC practice. Made on Microsoft Visual Studio 2022 with .net 7

## To Run
Clone the repository. Activate the **CV_storage.sln** (it is located at CV_storage folder) solution file using Windows Visual Studio. Press the **F5** button or click the **run/debug** button to launch the project. It will run the application where it is possible to add a new cv, delete or edit an already made one.

## Description
There are four main views available:
- Index => it shows a table of all created cv’s.
- Create => can be opened by clicking the button “create” located at the index page. There we can create a new CV, add as many as needed job experiences, education, language knowledge and gained skills (also possible to remove them if not needed).
- Edit => accessed at the index page for each individual CV. There it is possible to change any value, add or remove job experiences, education, language knowledge and gained skills as needed.
- Print => on index page for each individual CV. It is a rough representation of how a CV might look on the page with A4 layout.

The validations are implemented using the FluentValidation tool. Validations check CV when the button “create” or “update” gets pressed in Create or Edit view respectively. If any of the validations does not pass, then the error message will be displayed at the top of the page.

## The Task
Izveidot Programmu CV datu glabašanai

### FRONTEND
Nepieciešami vismaz tris skati:
- Saraksts ar ievaditajiem CV (dzest, rediget, pievienot CV)
- Viena CV redigešanas skats (pievienot, rediget datus)
- Viena CV apskates skats (CV datu attelošana, ta ka to butu jadruka ara) CV sastav no vismaz tris dalam:
- Pamatdati
- Izglitiba
- Darba pieredze
- Vizualais noformejums, izmantotas tehnologijas – iespeja izveleties pec saviem ieskatiem.

### BACKEND
Nepieciešama aplikacijas sasaiste ar paša izveidotu datubazi.
Izmantota programmešanas valoda PHP.
- CV Pamatdati (Vards, Uzvards, talrunis, e-pasts, …)
- Izglitibas iestades(Nosaukums, fakultate, studiju virziens, izglitibas limenis, statuss – macibas pabeigtas, partrauktas, macas, macibas pavaditais laiks, …)
- Darba vietas(Nosaukums, ienemamais amats, slodzes apmers ,darba stažs – darba pavaditais laiks, …)
- Darba vietas pielietotas prasmes vai sasniegumi(apraksts, veids – pamatdarbs, sasniegums, papildus prasme …)
- Adreses (Valsts, indekss, pilseta, iela, numurs, …)
- Iespejams pievienot papildus tabulas un datus pec saviem ieskatiem, ka, piemeram, citas prasmes, valodu prasmes, intereses …
