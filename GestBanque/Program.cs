using Models;

void AfficheDetailCompte(Courant c)
{
    Console.WriteLine($"Detail du compte : {c.Numero}");
    Console.WriteLine($" - Titlaire : {c.Titulaire.NomComplet}");
    Console.WriteLine($" - Solde : {c.Solde}");
}

Personne p1 = new Personne();
p1.Prenom = "Della";
p1.Nom = "Duck";
p1.DateNaiss = new DateTime(1990, 5, 10);

Courant c1 = new Courant();
c1.Titulaire = p1;
c1.Numero = "BE13 1234 5678 1472";
c1.LigneDeCredit = 1_000;
c1.Depot(10_000);
c1.Depot(0.1);
c1.Depot(0.2);

AfficheDetailCompte(c1);
Console.WriteLine();

Console.WriteLine("Retrait de 999.95 dans le compte c1");
c1.Retrait(999.95);

AfficheDetailCompte(c1);
Console.WriteLine();

//*******************************************************************
Banque bdn = new Banque();
bdn.Nom = "Banque des nuages";

bdn.Ajouter(c1);
Console.WriteLine("Ajout du compte c1");

Courant c2 = new Courant();
c2.Numero = "BE13 1234 5678 8532";
c2.LigneDeCredit = 500;
c2.Titulaire = p1;
c2.Depot(1_000);

bdn.Ajouter(c2);
Console.WriteLine("Ajout du compte c2");

Personne p2 = new Personne();
p2.Prenom = "Balthazar";
p2.Nom = "Picsou";
p2.DateNaiss = new DateTime(1966, 12, 3);

Courant c3 = new Courant();
c3.Numero = "BE13 1001 5678 4123";
c3.LigneDeCredit = 1_000_000;
c3.Depot(3_102_201_001.42);
c3.Titulaire = p2;

bdn.Ajouter(c3);
Console.WriteLine("Ajout du compte c3");
Console.WriteLine();


Console.WriteLine("Depot d'argent sur le compte « BE13 1001 5678 4123 »");

double s1 = bdn["BE13 1001 5678 4123"]!.Solde;
Console.WriteLine($" - Solde initial : {s1}");

Courant? temp = (Courant)bdn["BE13 1001 5678 4123"];
if(temp is not null)
{
    temp.Depot(5_000_420.01);

    double s2 = temp.Solde;
    Console.WriteLine($" - Solde final : {s2}");
}
Console.WriteLine();


//*******************************************************************
Personne della = new Personne();
della.Prenom = "Della";
della.Nom = "Duck";
della.DateNaiss = new DateTime(1990, 5, 10);

double avoirDella = bdn.AvoirDesComptes(della);
Console.WriteLine($"Avoir des comptes de \"Della\" : {avoirDella}");

//*******************************************************************

Epargne e1 = new Epargne();
e1.Numero = "BE14 2563 5558 1963";
e1.Depot(100);
e1.Titulaire = p2;

Console.WriteLine($"Solde sur le e1 {e1.Solde}");
e1.AppliquerInteret();
Console.WriteLine($"Solde sur le e1 après interet {e1.Solde}");

Courant c4 = new Courant();
c4.Numero = "BE14 2263 5348 1964";
c4.Depot(100);
c4.Titulaire = p2;

Console.WriteLine($"Solde sur le c4 {c4.Solde}");
c4.AppliquerInteret();
Console.WriteLine($"Solde sur le c4 après interet {c4.Solde}");