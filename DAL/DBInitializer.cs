using Emp.Model;
using System;
using System.Linq;

namespace Emp.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(EmpDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pozicie.Any())
            {
                return;   // DB has been seeded
            }

            var pozicie = new Pozicia[]
            {
            new Pozicia{Nazov="Tester",Vymazana=false},
            new Pozicia{Nazov="Programator",Vymazana=false},
            new Pozicia{Nazov="Support",Vymazana=false},
            new Pozicia{Nazov="Analytik",Vymazana=false},
            new Pozicia{Nazov="Obchodnik",Vymazana=false},
            new Pozicia{Nazov="Ine",Vymazana=false},
            };
            foreach (Pozicia p in pozicie)
            {
                context.Pozicie.Add(p);
            }

            context.SaveChanges();

            var zamestnanci = new Zamestnanec[] {
            new Zamestnanec{ Meno = "Peter", Priezvisko="Povysil", Adresa="Zahumenice 13, 821 06  Bratislava", DatumNarodenia=DateTime.Parse ("1982-09-10")},
            new Zamestnanec{ Meno = "Jano", Priezvisko="Ukoncil", Adresa="Veterna 1, 820 06  Bratislava", DatumNarodenia=DateTime.Parse ("1983-10-01")},
            new Zamestnanec{ Meno = "Eva", Priezvisko="Vytrvala", Adresa="Dolna 135, 821 06  Bratislava", DatumNarodenia=DateTime.Parse ("1985-12-11")},
            new Zamestnanec{ Meno = "Lenka", Priezvisko="Pasierova", Adresa="Horna 113, 831 06  Bratislava", DatumNarodenia=DateTime.Parse ("1992-06-07")},
            new Zamestnanec{ Meno = "Jaro", Priezvisko="Zbojnik", Adresa="Polna 7, 841 03  Bratislava", DatumNarodenia=DateTime.Parse ("1999-02-03")},
            new Zamestnanec{ Meno = "Michal", Priezvisko="Kovac", Adresa="Tehelna 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1972-07-04")},
            new Zamestnanec{ Meno = "Fedor", Priezvisko="Fokac", Adresa="Betliarska 5, 821 06  Bratislava", DatumNarodenia=DateTime.Parse ("1982-10-01")},
            new Zamestnanec{ Meno = "Eva", Priezvisko="Letna", Adresa="Rustaveliho 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1972-07-04")},
            new Zamestnanec{ Meno = "Lenka", Priezvisko="Zimna", Adresa="Plickova 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1980-05-04")},
            new Zamestnanec{ Meno = "Peter", Priezvisko="Jarny", Adresa="Rakuska 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1982-01-04")},
            new Zamestnanec{ Meno = "Juraj", Priezvisko="Zachar", Adresa="Bratislavska 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1992-02-04")},
            new Zamestnanec{ Meno = "Ivana", Priezvisko="Biela", Adresa="Pohranicna 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1962-03-04")},
            new Zamestnanec{ Meno = "Lucia", Priezvisko="Cerna", Adresa="Cierna 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1973-04-04")},
            new Zamestnanec{ Meno = "Eleanor", Priezvisko="Bleda", Adresa="Horna 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1942-01-04")},
            new Zamestnanec{ Meno = "Pavla", Priezvisko="Tmava", Adresa="Dolna 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1977-02-04")},
            new Zamestnanec{ Meno = "Petra", Priezvisko="Zbojna", Adresa="Lava 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1978-05-04")},
            new Zamestnanec{ Meno = "Jezi", Priezvisko="Baba", Adresa="Prava 3, 821 04  Bratislava", DatumNarodenia=DateTime.Parse ("1974-04-04")},
            };
            foreach (Zamestnanec z in zamestnanci)
            {
                context.Zamestnanci.Add(z);
            }

            context.SaveChanges();

            var evidenciaZamestnanca = new EvidenciaZamestnanca[]
            {
            new EvidenciaZamestnanca{ZamestnanecID=1, PoziciaID = 5, DatumNastupu=DateTime.Parse ("2017-02-03"), DatumUkoncenia=DateTime.Parse ("2017-10-10"), Plat=2500.50f},
            new EvidenciaZamestnanca{ZamestnanecID=1, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2017-10-10"), DatumUkoncenia=null, Plat=3500.20f},
            new EvidenciaZamestnanca { ZamestnanecID = 2, PoziciaID = 2, DatumNastupu = DateTime.Parse("2017-09-03"), DatumUkoncenia = DateTime.Parse("2018-01-01"), Plat = 1500.50f },
            new EvidenciaZamestnanca{ZamestnanecID=3, PoziciaID = 1, DatumNastupu=DateTime.Parse ("2017-02-03"), DatumUkoncenia=null, Plat=2200.60f},
            new EvidenciaZamestnanca{ZamestnanecID=4, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2016-02-03"), DatumUkoncenia=null, Plat=3700.50f},
            new EvidenciaZamestnanca{ZamestnanecID=5, PoziciaID = 3, DatumNastupu=DateTime.Parse ("2016-02-03"), DatumUkoncenia=DateTime.Parse ("2017-10-10"), Plat=2500.50f},
            new EvidenciaZamestnanca{ZamestnanecID=6, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2018-02-01"), DatumUkoncenia=null, Plat=2800.50f},
            new EvidenciaZamestnanca{ZamestnanecID=7, PoziciaID = 5, DatumNastupu=DateTime.Parse ("2017-12-03"), DatumUkoncenia=null, Plat=2200.50f},
            new EvidenciaZamestnanca{ZamestnanecID=8, PoziciaID = 1, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=600.50f},
            new EvidenciaZamestnanca{ZamestnanecID=8, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2015-12-03"), DatumUkoncenia=DateTime.Parse ("2016-12-03"), Plat=700.50f},
            new EvidenciaZamestnanca{ZamestnanecID=9, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=700.50f},
            new EvidenciaZamestnanca{ZamestnanecID=9, PoziciaID = 3, DatumNastupu=DateTime.Parse ("2015-12-03"), DatumUkoncenia=DateTime.Parse ("2016-12-03"), Plat=800.50f},
            new EvidenciaZamestnanca{ZamestnanecID=9, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2016-12-03"), DatumUkoncenia=null, Plat=900.50f},
            new EvidenciaZamestnanca{ZamestnanecID=10, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=500.50f},
            new EvidenciaZamestnanca{ZamestnanecID=10, PoziciaID = 3, DatumNastupu=DateTime.Parse ("2015-12-03"), DatumUkoncenia=DateTime.Parse ("2016-12-03"), Plat=800.50f},
            new EvidenciaZamestnanca{ZamestnanecID=10, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2016-12-03"), DatumUkoncenia=null, Plat=1000.50f},
            new EvidenciaZamestnanca{ZamestnanecID=11, PoziciaID = 5, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=5000.50f},
            new EvidenciaZamestnanca{ZamestnanecID=11, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2015-12-03"), DatumUkoncenia=null, Plat=1700.50f},
            new EvidenciaZamestnanca{ZamestnanecID=12, PoziciaID = 3, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=700.50f},
            new EvidenciaZamestnanca{ZamestnanecID=13, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=400.50f},
            new EvidenciaZamestnanca{ZamestnanecID=14, PoziciaID = 1, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=null, Plat=755.50f},
            new EvidenciaZamestnanca{ZamestnanecID=15, PoziciaID = 2, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=null, Plat=544.50f},
            new EvidenciaZamestnanca{ZamestnanecID=16, PoziciaID = 3, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=DateTime.Parse ("2015-12-03"), Plat=600.50f},
            new EvidenciaZamestnanca{ZamestnanecID=16, PoziciaID = 4, DatumNastupu=DateTime.Parse ("2015-12-03"), DatumUkoncenia=DateTime.Parse ("2016-12-03"), Plat=500.50f},
            new EvidenciaZamestnanca{ZamestnanecID=16, PoziciaID = 5, DatumNastupu=DateTime.Parse ("2016-12-03"), DatumUkoncenia=null, Plat=50.10f},
            new EvidenciaZamestnanca{ZamestnanecID=17, PoziciaID = 1, DatumNastupu=DateTime.Parse ("2014-12-03"), DatumUkoncenia=null, Plat=850f},
            };

            foreach (EvidenciaZamestnanca e in evidenciaZamestnanca)
            {
                context.EvidenciaZamestnancov.Add(e);
            }
            context.SaveChanges();
        }
    }
}