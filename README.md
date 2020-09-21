Projekt do VIS (autobazar)


Využití MVC
  - Vrstvy Data, Domain a prezentační(WebApp a DesktopApp(WinForms))
  
Využití tableDataGateway, mapování objektů a DTO
  
Knihovna lib obsahuje první dvě vrstvy MVC(Data a Domain)
  - Datová vrstva je řešená pomocí tableDataGateway
  - Domain vrstva obsahuje jednotlivé třídy, které se mapují na záznamy v databázi
  
Projekt "Salary Plugin" obsahuje plugin pro počítání mzdy zaměstnanců, tento plugin je potom načítán pomocí assembly v SalaryClculatoru(DomainLayer).

V třídě SalaryCalculator se počítá mzda zaměstnánců (káždý zaměstnanec se počítá v samostatném Threadu pomocí funkce z pluginu načténeho v assembly).
