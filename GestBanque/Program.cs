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
