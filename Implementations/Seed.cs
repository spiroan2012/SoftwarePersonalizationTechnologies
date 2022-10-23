using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Implementations
{
    public class Seed
    {
        public static async Task SeedRolesAndAdmin(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Moderator"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                DateOfBirth = DateTime.Now,
                FirstName = "admin",
                LastName = "admin",
                Gender = "male",
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRoleAsync(admin, "Admin");
        }


        public static async Task SeedCategories(BookingContext context)
        {
            if (await context.Genres.AnyAsync()) return;

            var genres = new List<Genre>
            {
                new Genre{Description = "Δράμα"},
                new Genre{Description = "Κομέντια ντελ άρτε"},
                new Genre{Description = "Κουκλοθέατρο"},
                new Genre{Description = "Μιούζικαλ"},
                new Genre{Description = "Μπαλέτο"},
                new Genre{Description = "Όπερα"},
                new Genre{Description = "Σάτιρα"},
                new Genre{Description = "Αστικό δράμα"},
                new Genre{Description = "Βοντβίλ"},
                new Genre{Description = "Επιθεώρηση"},
                new Genre{Description = "Κωμωδία"},
                new Genre{Description = "Κωμειδύλλιο"},
                new Genre{Description = "Μελόδραμα"},
                new Genre{Description = "Μονόδραμα"},
                new Genre{Description = "Παντομίμα"},
                new Genre{Description = "Ρομαντικό δράμα"},
                new Genre{Description = "Σωματικό θέατρο"}
            };

            foreach(Genre genre in genres)
            {
                context.AddAsync(genre);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedHallsAndShows(BookingContext context)
        {
            if (await context.Halls.AnyAsync() || await context.Shows.AnyAsync()) return;

            var shows = new List<Show>()
            {
                new Show()
                {

                }
            };

            var halls = new List<Hall>()
            {
               new Hall()
               {
                   Title = "Εθνικό Θέατρο",
                   Description = "Το Εθνικό θέατρο είναι μια από τις πιο σημαντικές θεατρικές σκηνές στην Ελλάδα. Η ιστορία του έχει ταυτιστεί με την ανάπτυξη του μοντέρνου θεάτρου στη χώρα, καθώς η ίδρυση του απετέλεσε την αφορμή για την αλματώδη πρόοδο της δραματουργίας και την εμφάνιση νέων θεατρικών σχημάτων και ειδών.",
                   Capacity = 250,
                   Phone = "210 5288170",
                   EmailAddress = "ethniko@gmail.com",
                   Address = "Αγίου Κωνσταντίνου 22-24",
                   Area = "Athens",
                   Latitude  = 23.725303 ,
                   Longitude = 37.985078

               },
               new Hall()
               {
                   Title = "Θέατρο Τέχνης Κάρολος Κουν",
                   Description = "Το Θέατρο Τέχνης είναι συνυφασμένο με την αισθητική και την ποιότητα των έργων και των ηθοποιών που το απαρτίζουν.\r\n\r\nΕίναι μια από τις πιο σημαντικές θεατρικές σκηνές της Αθήνας, που καθιέρωσε μεγάλα ονόματα της Τέχνης στην Ελλάδα και που έχει παρουσιάσει μερικά από τα πιο σημαντικά έργα της ελληνικής και παγκόσμιας δραματουργίας.",
                   Capacity = 200,
                   Phone = "2103228706",
                   EmailAddress = "ethniko@gmail.com",
                   Address = "Πεσμαζόγλου 5, Αθήνα",
                   Area = "Athens",
                   Latitude  = 23.731158 ,
                   Longitude = 37.981112
               },
               new Hall()
               {
                   Title = "Θέατρο Badminton",
                   Description = "Το θέατρο Badminton είναι μια από τις πιο σημαντικές θεατρικές σκηνές της Αθήνας. Εγκαινιάστηκε πριν από λίγα χρόνια, όταν το κτίριο στο Γουδί ολοκλήρωσε τις υποχρεώσεις του στους Ολυμπιακούς Αγώνες της Αθήνας, αφού φιλοξενούσε τους αγώνες badminton το 2004.",
                   Capacity = 300,
                   Phone = "210 88 40 600",
                   EmailAddress = "badminton@gmail.com",
                   Address = "Ολυμπιακά Ακίνητα Γουδή, 157 73, Αθήνα",
                   Area = "Athens",
                   Latitude  = 23.775346 ,
                   Longitude = 37.986083
               },
               new Hall()
               {
                   Title = "Θέατρο ΗΒΗ",
                   Description = "Το Θέατρο ΗΒΗ στο ιστορικό κέντρο της Αθήνας στη συνοικία Ψυρρή, με την ιδιαίτερη διατηρητέα πρόσοψη και τη βιομηχανική αισθητική, έχει μέσα στα 20 χρόνια λειτουργίας του καθιερωθεί ως ένα θέατρο επιτυχιών.",
                   Capacity = 150,
                   Phone = "2103639343",
                   EmailAddress = "tickets@theatrikesskines.gr",
                   Address = "Αμερικής 9",
                   Area = "Athens",
                   Latitude  = 23.722492 ,
                   Longitude = 37.978965
               },
               new Hall()
               {
                   Title = "Θέατρο Αλίκη",
                   Description = "Το θέατρο Αλίκη, αποτελεί έναν ξεχωριστό ιστορικό χώρο της Αθήνας και είναι ένα από τα πιο σημαντικά, κεντρικά θέατρα στην καρδιά της πρωτεύουσας. Το 1935 άρχισε να λειτουργεί ως χορευτικό κέντρο και αργότερα, το 1949 μετατράπηκε σε κινηματογράφο.",
                   Capacity = 180,
                   Phone = "210 3210021",
                   EmailAddress = "aliki@gmail.com",
                   Address = "Αμερικής 4, Αθήνα",
                   Area = "Athens",
                   Latitude  = 23.734433413606965 ,
                   Longitude = 37.97768068069991
               },
               new Hall()
               {
                   Title = "θέατρο Κιβωτός",
                   Description = "Το θέατρο Κιβωτός βρίσκεται στην περιοχή «Γκάζι» λίγο πιο κάτω από την Τεχνόπολη του Δήμου Αθηναίων επί της οδού Πειραιώς. Η περιοχή Γκάζι πήρε το όνομά της από το αθηναϊκό εργοστάσιο της Γαλλικής Εταιρείας Αεριόφωτος που ιδρύθηκε το 1857.",
                   Capacity = 100,
                   Phone = "210 3417000",
                   EmailAddress = "kivotos@gmail.com",
                   Address = "Πειραιώς 115",
                   Area = "Athens",
                   Latitude  = 23.7112438115542 ,
                   Longitude = 37.976082881556685
               },
               new Hall()
               {
                   Title = "Δελφινάριο",
                   Description = "Θέατρο του Μάρκου Σεφερλή στον Πειραιά",
                   Capacity = 100,
                   Phone = "210 4176402",
                   EmailAddress = "delfinario@gmail.com",
                   Address = "Μικρολίμανο (παραπλεύρως Σταδίου Ειρήνης και Φιλίας)",
                   Area = "Athens",
                   Latitude  = 23.662891255732806 ,
                   Longitude = 37.94168018071739
               },
               new Hall()
               {
                   Title = "Θέατρο Πάνθεον",
                   Description = "Θέτρο διαφόρων παραστάσεων στην Πάτρα",
                   Capacity = 250,
                   Phone = "2610 325778",
                   EmailAddress = "pantheon@gmail.com",
                   Address = "Λεωφόρος Γούναρη 34, Πάτρα",
                   Area = "Patra",
                   Latitude  = 21.733710126367257 ,
                   Longitude = 38.243762378787196
               },
               new Hall()
               {
                   Title = "Θέατρο Αμαλία",
                   Description = "Θέατρο στην Θεσσαλονίκη.",
                   Capacity = 280,
                   Phone = "2310888894",
                   EmailAddress = "amalia@gmail.com",
                   Address = "Αμαλίας 71, Θεσσαλονίκη",
                   Area = "Thessaloniki",
                   Latitude  = 22.95756858277664,
                   Longitude = 40.61631644997455
               }
            };

            foreach (Hall hall in halls)
            {

                hall.Shows.Add(n)
                context.AddAsync(hall);
            }

            await context.SaveChangesAsync();
        }
    }
}
