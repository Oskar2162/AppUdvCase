using ServerApp.Model;
using ServerApp.Repositories;

namespace ServerApp;

internal class Program

{
    /*
1.  Create one single Lokalitet
2.  Add 2 annoncer to this lokalitet
3.  Get details of a specific annonce within a location
4.  Create 3 Users
5.  Add some bookings (Kategorier) for a user
*/

    private static void Main()
    {
        // for at kunne kalde til ropositories, skal man have et repository objekt
        LokaliteterRepository lRepo = new LokaliteterRepository();
        AnnonceRepository aRepo = new AnnonceRepository();
        UsersRepository uRepo = new UsersRepository();
        TAnnonceRepository tRepo = new TAnnonceRepository();
        
        lRepo.DeleteAll();
        aRepo.DeleteAll();
        uRepo.DeleteAll();
        tRepo.DeleteAll();

        // 1. opretter 1 lokation
        Console.WriteLine("------------------ single lokalitet ------------");
        // Du vil indsætte en ny lokalitet, så du skal først oprette et objekt
        Lokalitet lokalitet = new Lokalitet()
        {
            lokalitetid = 1,
            LName = "Lokale A1.06"
        };

        // kald metoden der gemmer lokaliteten i MongoDB
        lRepo.newLokalitet(lokalitet);

        // 2. tilføj 2 annoncer ttil denne lokalitet
        Console.WriteLine("------------------ 2 annoncer ------------");
        var annonce1 = new Annonce()
        {
            annonceid =  1,
            price = 500,
            title = "Brugt stol",
            description = "Sort kontorstol i god stand",
            lid = lokalitet.lokalitetid,
            Status = "aktiv"
        };

        var annonce2 = new Annonce()
        {
            annonceid = 2,
            price = 750,
            title = "Bordlampe",
            description = "Hvid lampe, næsten som ny",
            lid = lokalitet.lokalitetid,
            Status = "aktiv"
        };
        
        // 2.1 Her gør vi brug af en tidligere annonce, som bliver vist i compass
        Console.WriteLine("------------------ tannoncer ------------");
        var tannonce = new Tannonce()
        {
            tannonceid = 1,
            price = 240,
            title = "Brugt gamerstol",
            description = "små revner, men stabil",
            lid = lokalitet.lokalitetid,
            Status = "solgt"
        };

        tRepo.CreateTAnnonce(tannonce);  // gemmes i collection "tannoncer"

        var annoncer = new List<Annonce>() { annonce1, annonce2 };

        aRepo.CreateAnnoncer(annoncer);  // gemmes i collection "annoncer"

        // 3. får detaljerne af en specifik annonce i en lokation
        Console.WriteLine("------------------ details of an annonce ------------");
        int aid = 1;
        var foundAnnonce = aRepo.GetAnnonceById(aid);
        Console.WriteLine("display annonce1");
        Console.WriteLine($"Title: {foundAnnonce.title}, Price: {foundAnnonce.price}, Description: {foundAnnonce.description}, Status: {foundAnnonce.Status}, Lid: {foundAnnonce.lid}");

        // 4. Create 3 Users
        Console.WriteLine("------------------ 3 users ------------");
        var user1 = new User() { userid = 1, Name = "Mohamed", Password = "mohamed123",Email = "mohamed@eaaa.dk",   role = "student" };
        var user2 = new User() { userid = 2, Name = "Simon", Password = "simon123", Email = "simon@eaaa.dk",    role = "student" };
        var user3 = new User() { userid = 3, Name = "Oskar", Password = "oskar123",Email = "oskar@eaaa.dk",  role = "student"   };

        var users = new List<User>() { user1, user2, user3 };
        uRepo.CreateUsers(users);

        // 5. Add some bookings for a user (Kategorier = booking)
        Console.WriteLine("------------------ add booking to user ------------");
        var booking1 = new Kategorier()
        {
            kategorierid = 1,
            Now = DateTime.Today,
            NumSeats = 1,
            Annonce = annonce1
        };

        var booking2 = new Kategorier()
        {
            kategorierid = 2,
            Now = DateTime.Today.AddDays(3),
            NumSeats = 1,
            Annonce = annonce2
        };

        int userid = 1; // vi giver booking til user1
        uRepo.Addbookings(userid, booking1);
        uRepo.Addbookings(userid, booking2);

        Console.WriteLine("------------------ færdig demo ------------");
        Console.WriteLine("Tjek MongoDB/Compass for at se lokalitet, annoncer, users og bookings.");
        Console.ReadKey();
    }
}