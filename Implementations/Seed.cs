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

        public static async Task SeedData(BookingContext context)
        {
            if (await context.Halls.AnyAsync() || await context.Shows.AnyAsync()) return;

            var genres = new List<Genre>
            {
                new Genre { Description = "Δράμα" },//0
                new Genre { Description = "Κομέντια ντελ άρτε" },//1
                new Genre { Description = "Κουκλοθέατρο" },//2
                new Genre { Description = "Μιούζικαλ" },//3
                new Genre { Description = "Μπαλέτο" },//4
                new Genre { Description = "Όπερα" },//5
                new Genre { Description = "Σάτιρα" },//6
                new Genre { Description = "Αστικό δράμα" },//7
                new Genre { Description = "Βοντβίλ" },//8
                new Genre { Description = "Επιθεώρηση" },//9
                new Genre { Description = "Κωμωδία" },//10
                new Genre { Description = "Κωμειδύλλιο" },//11
                new Genre { Description = "Μελόδραμα" },//12
                new Genre { Description = "Μονόδραμα" },//13
                new Genre { Description = "Παντομίμα" },//14
                new Genre { Description = "Ρομαντικό δράμα" },//15
                new Genre { Description = "Σωματικό θέατρο" }//16
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

            var shows = new List<Show>()
            {
                new Show()
                {
                    Title = "Βρυκόλακες",
                    Description = "Η κυρία Άλβινγκ ετοιμάζεται για τα εγκαίνια του Ιδρύματος που έφτιαξε στη μνήμη του συζύγου της. Ο γιος της Όσβαλντ, καταξιωμένος ζωγράφος που ζει από παιδί στο εξωτερικό, έχει επιστρέψει για την τελετή. Ο παλιός οικογενειακός φίλος και διαχειριστής του Ιδρύματος Πάστορας Μάντερς έχει έρθει και αυτός για να εκφωνήσει λόγο για την προσφορά του λοχαγού Άλβινγκ. Όμως, κάτω από την αψεγάδιαστη, γυαλιστερή επιφάνεια, κάτι άρρωστο και σαθρό ελλοχεύει.",
                    Actors = "Γιώργος Ζιόβας, Κατερίνα Μαούτσου, Περικλής Μουστάκης, Αργύρης Πανταζάρας, Ναταλία Τσαλίκη",
                    Directors = "Σταμάτης Φασουλής",
                    DateStart = new DateTime(2022, 10, 23),
                    DateEnd = new DateTime(2023, 04, 01),
                    TimeStart = new DateTime(2022, 04, 01, 19, 0, 0),
                    Duration = 100,
                    Hall = halls[0],
                    Genre = genres[0],
                },
                new Show()
                {
                    Title = "Ρωμαίος και Ιουλιέττα",
                    Description = "Δεν χρειάζονται συστάσεις για το ζευγάρι που γεννήθηκε από τη σαιξπηρική πένα στην εκπνοή του 16ου αιώνα και μέχρι σήμερα δεν έχει πάψει να ταυτίζεται με τον απόλυτο έρωτα. Οι ρίζες της ιστορίας με τις πολλαπλές πραγματεύσεις ανιχνεύονται πίσω στον 2ο αιώνα μ.Χ., ωστόσο είναι το έργο του Σαίξπηρ που την κατέστησε πασίγνωστη.",
                    Actors = "Κωνσταντίνος Αβαρικιώτης, Άννα Καλαϊτζίδου, Γιάννης Κλίνης, Αντώνης Κολοβός, Ιωάννης-Ραφαήλ Κόραβος, Έκτορας Λιάτσος, Άρης Μπαλής, Ηρώ Μπέζου, Άρης Νινίκας, Γιάννης Νταλιάνης, Μάνος Πετράκης, Ρένη Πιττακή, Χάρης Χαραλάμπους-Καζέπης, Ιωάννης Χαρκοφτάκης",
                    Directors = "Δημήτρης Καραντζάς",
                    DateStart = new DateTime(2022, 11, 01),
                    DateEnd = new DateTime(2023, 07, 01),
                    TimeStart = new DateTime(2023, 07, 01, 18,0, 0),
                    Duration = 90,
                    Hall = halls[0],
                    Genre = genres[7],
                },
                new Show()
                {
                    Title = "Η σπασμένη στάμνα",
                    Description = "Μια χαλκογραφία του 18ου αιώνα και το προσωπικό του στοίχημα για το αν μπορεί να συνθέσει κωμωδία στάθηκαν αφορμές για να γράψει ο Χάινριχ φον Κλάιστ τη Σπασμένη στάμνα. Το έργο, που πρωτοπαρουσίασε ο Γκαίτε το 1808 στη Βαϊμάρη, φέρνει στη σκηνή τον Αδάμ, έναν δικαστή που καλείται να διαλευκάνει ποιος έσπασε μια ιστορική στάμνα στο υπνοδωμάτιο της Εύας, ενώ ο ίδιος είναι ο βασικός ύποπτος.",
                    Actors = "Γιώργος Γιαννακάκος, Έλενα-Μαρία Ηλία, Ακύλλας Καραζήσης, Αλεξάνδρα Όσπιτση, Κίττυ Παϊταζόγλου, Παναγιώτης Παναγόπουλος, Χριστίνα-Μελίνα Πολυζώνη, Γιώργος Συμεωνίδης, Θάνος Τοκάκης, Μάρθα Φριντζήλα, Νίκος Χατζόπουλος",
                    Directors = "Ακύλλας Καραζήσης,Νίκος Χατζόπουλος",
                    DateStart = new DateTime(2022, 10, 01),
                    DateEnd = new DateTime(2023, 09, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 110,
                    Hall = halls[0],
                    Genre = genres[0],
                },
                new Show()
                {
                    Title = "ΑΝΤΙΓΟΝΗ",
                    Description = "Μετά το πρώτο ανέβασμα στο Υπόγειο του Θέατρου Τέχνης, η Μάρια Πρωτόπαππα προσεγγίζει σκηνοθετικά και ερμηνευτικά εκ νέου την «Αντιγόνη» του Ζαν Ανούιγ, σε μια παράσταση που εξελίσσει ακόμα περισσότερο την αρχική ματιά της σκηνοθέτιδος. Αναλαμβάνοντας να αρθρώσει η ίδια το μεγαλύτερο μέρος των λόγων της Αντιγόνης, η σκηνοθέτις επιχειρεί ένα σχόλιο ανάμεσα στο σημαίνον και το σημαινόμενο της ύπαρξης της ηρωίδας.",
                    Actors = "Χρήστος Στέργιογλου, Γιάννης Τσορτέκης, Δημήτρης Μαμιός, Δημήτρης Μαργαρίτης, Μαρία Πρωτόπαππα",
                    Directors = "Μαρία Πρωτόπαππα",
                    DateStart = new DateTime(2022, 10, 23),
                    DateEnd = new DateTime(2022, 11, 27),
                    TimeStart = new DateTime(2023, 09, 01, 17,0, 0),
                    Duration = 90,
                    Hall = halls[1],
                    Genre = genres[12],
                },
                new Show()
                {
                    Title = "ΤΑ ΚΑΙΝΟΥΡΓΙΑ ΡΟΥΧΑ ΤΟΥ ΑΥΤΟΚΡΑΤΟΡΑ",
                    Description = "Το έργο μιλάει για την ματαιότητα της αυταρέσκειας και της υπερβολικής ενασχόλησης με την εξωτερική μας εμφάνιση, για την κολακεία και το ψέμα, για την εξουσία. Πόσο δύσκολο είναι να πούμε την αλήθεια όταν το ψέμα «φαινομενικά» αναδεικνύει την εξυπνάδα μας στους άλλους; Πότε τελικά είναι καλό για μας και τους άλλους να λέμε – ή να μην λέμε - την αλήθεια",
                    Actors = "Κωνσταντίνος Ευστρατίου, Ιωάννα Μπιτούνη, Κωνσταντίνος Βασιλόπουλος",
                    Directors = "Κωνσταντίνος Ευστρατίου",
                    DateStart = new DateTime(2022, 09, 01),
                    DateEnd = new DateTime(2022, 12, 31),
                    TimeStart = new DateTime(2023, 09, 01, 13,0, 0),
                    Duration = 90,
                    Hall = halls[1],
                    Genre = genres[3],
                },
                new Show()
                {
                    Title = "ΟΙ ΠΑΣΤΡΙΚΕΣ",
                    Description = "Στο κέντρο της αφήγησης ξετυλίγεται ο αγώνας επιβίωσης δύο γυναικών που μετά την καταστροφή καταλήγουν η μια στον Πειραιά και η άλλη στην Θεσσαλονίκη. Η νοοτροπία, οι συνήθειες, τα όνειρα τους, θα συγκρουστούν με την άγρια πραγματικότητα που θα αντιμετωπίσουν ως πρόσφυγες αλλά και ως γυναίκες στην χρεοκοπημένη και συντηρητική Ελλάδα του ΄22",
                    Actors = "Κατερίνα Λυπηρίδου, Μαριλένα Μόσχου, Κωνσταντίνα Τάκαλου.",
                    Directors = "Μαριάννα Κάλμπαρη",
                    DateStart = new DateTime(2022, 10, 10),
                    DateEnd = new DateTime(2023, 10, 10),
                    TimeStart = new DateTime(2023, 09, 01, 13,0, 0),
                    Duration = 85,
                    Hall = halls[1],
                    Genre = genres[1],
                },
                new Show()
                {
                    Title = "Sweet Charity",
                    Description = "Το αριστούργημα του μίστερ μιούζικαλ Μπομπ Φόσι, δημιουργού του Σικάγο, Καμπαρέ αλλά και του Άλ δατ τζάζ, έρχεται στην Αθήνα! Σουίτ Τσάριτι!",
                    Actors = "Νίκος Αρβανίτης, Σταύρος Ζαλμάς, Μέμος Μπεγνής, Νάντια Μπουλέ Ντορέττα Παπαδημητρίου, Ιβάν Σβιτάιλο, Shaya",
                    Directors = "Μπομπ Φόσι",
                    DateStart = new DateTime(2022, 12, 10),
                    DateEnd = new DateTime(2023, 07, 10),
                    TimeStart = new DateTime(2023, 09, 01, 17,0, 0),
                    Duration = 85,
                    Hall = halls[2],
                    Genre = genres[4],
                },
                new Show()
                {
                    Title = "Ο Ιάσονας και το Χρυσόμαλλο Δέρας",
                    Description = "Το συναρπαστικότερο ταξίδι της ελληνικής μυθολογίας, η Αργοναυτική Εκστρατεία, γίνεται μια μεγάλη παράσταση στο Θέατρο Badminton: ο Ιάσονας και το Χρυσόμαλλο Δέρας είναι η νέα υπερπαραγωγή του Badminton, που μετά τον θρίαμβο του Θησέα και της Αριάδνης στο νησί των ταύρων",
                    Actors = "Γιάννης Στάνκογλου, Σαβίνα Γιαννάτου, Μαρίνα Σάττι",
                    Directors = "Ζαχαρίας Καρούνης",
                    DateStart = new DateTime(2022, 12, 10),
                    DateEnd = new DateTime(2023, 07, 10),
                    TimeStart = new DateTime(2023, 09, 01, 17,0, 0),
                    Duration = 85,
                    Hall = halls[2],
                    Genre = genres[2],
                },
                new Show()
                {
                    Title = "Wonderful Circus",
                    Description = "Εμπνευσμένο, φαντασμαγορικό, ποιητικό: το Wonderful Circus (Γουόντερφουλ Σίρκους), η εμβληματική παράσταση της Laterna Μagika (Λατέρνα Μάτζικα), της ομάδας που άλλαξε το πρόσωπο του τσέχικου θεάτρου, έρχεται στο Badminton",
                    Actors = "",
                    Directors = "",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 70,
                    Hall = halls[2],
                    Genre = genres[14],
                },
                new Show()
                {
                    Title = "42497",
                    Description = "Σε ένα δυστοπικό μέλλον, οι άνθρωποι ζουν κάτω από την επιφάνεια της γης, προσπαθώντας να επιβιώσουν από τις παρενέργειες των επιπόλαιων επιλογών που έκαναν επί δεκαετίες ολόκληρες. Οι ανθρώπινες σχέσεις αναπτύσσονται, καταβαραθρώνονται και επαναπροσδιορίζονται.",
                    Actors = "Δημήτρης Γκοτσόπουλος, Μιχάλης Συριόπουλος,\r\nΓιούλη Τσαγκαράκη, Ανθή Σαββάκη, Μανώλης Κλωνάρης,\r\nΑποστόλης Ψαρρός, Ειρήνη Βαλατσού",
                    Directors = "Γιώργος Καπουτζίδης",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 70,
                    Hall = halls[3],
                    Genre = genres[12],
                },
                new Show()
                {
                    Title = "Όποιος θέλει να χωρίσει... να σηκώσει το χέρι του",
                    Description = "Ένας ανομολόγητος έρωτας που κρατάει είκοσι χρόνια. Ένας γάμος που διαλύεται από μία απιστία. Κι ένας άλλος που αναβάλλεται επ’ αόριστον, αλλά κανείς δεν τολμά να το πει στον γαμπρό.",
                    Actors = "Ευθύμης Γεωργόπουλος, Μαριλού Κατσαφάδου, Γιάννης Κουκουράκης, Ανθή Σαββάκη,\r\nΓιώργος Σαββίδης, Αλεξάνδρα Ταβουλάρη, Αποστόλης Ψαρρός",
                    Directors = "Γιώργος Καπουτζίδης",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 90,
                    Hall = halls[3],
                    Genre = genres[10],
                },
                new Show()
                {
                    Title = "Μπαμπάδες με ρούμι",
                    Description = "Φυσικά έχουν μεσολαβήσει πολλά από το 1996. Μία νέα χιλιετία ξημέρωσε και μία νέα πραγματικότητα εγκαταστάθηκε ανάμεσά μας. Ανατροπές, ματαιώσεις σχεδίων, αμέτρητα νέα μέσα κοινωνικής δικτύωσης, επαναπροσδιορισμοί ζωής και πολλή αταξία.",
                    Actors = "Βίκυ Σταυροπούλου,Χρήστος Χατζηπαναγιώτης,Κώστας Κόκλας,Μαρία Λεκάκη, Σοφία Βογιατζάκη, Τζόυς Ευείδη",
                    Directors = "Γιώργος Καπουτζίδης",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 140,
                    Hall = halls[4],
                    Genre = genres[11],
                },
                new Show()
                {
                    Title = "Μπαμπάδες με ρούμι",
                    Description = "Φυσικά έχουν μεσολαβήσει πολλά από το 1996. Μία νέα χιλιετία ξημέρωσε και μία νέα πραγματικότητα εγκαταστάθηκε ανάμεσά μας. Ανατροπές, ματαιώσεις σχεδίων, αμέτρητα νέα μέσα κοινωνικής δικτύωσης, επαναπροσδιορισμοί ζωής και πολλή αταξία.",
                    Actors = "Βίκυ Σταυροπούλου,Χρήστος Χατζηπαναγιώτης,Κώστας Κόκλας,Μαρία Λεκάκη, Σοφία Βογιατζάκη, Τζόυς Ευείδη",
                    Directors = "Γιώργος Καπουτζίδης",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 140,
                    Hall = halls[4],
                    Genre = genres[11],
                },
                new Show()
                {
                    Title = "Οι Παίxτες",
                    Description = "Ζωντανή μουσική, αφηνιασμένοι ρυθμοί και σκοτεινό χιούμορ σε μια παράσταση – οφθαλμαπάτη, μια φαρσοκωμωδία καταστάσεων, για την τέχνη της εξαπάτησης",
                    Actors = "Γιάννης Νιάρρος, Βασίλης Μαγουλιώτης, Ηλίας Μουλάς, Αλέξανδρος Χρυσανθόπουλος, Γιώργος Τζαβάρας, Γιώργος Μπουκαούρης",
                    Directors = "Γιώργος Κουτλής",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 95,
                    Hall = halls[5],
                    Genre = genres[15],
                },
                new Show()
                {
                    Title = "Το Όνειρο ενός Γελοίου",
                    Description = "Η υπνωτιστική, γεμάτη πνευματική ενέργεια και συμβολισμούς παράσταση της Έφης Μπίρμπα και του Άρη Σερβετάλη «Το όνειρο ενός γελοίου» του Φιόντορ Ντοστογιέφσκι μαγνήτισε χιλιάδες θεατές αυτό το καλοκαίρι σε όλη την Ελλάδα",
                    Actors = "Άρης Σερβετάλης",
                    Directors = "Έφη Μπίρμπα",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 19,0, 0),
                    Duration = 95,
                    Hall = halls[5],
                    Genre = genres[13],
                },
                new Show()
                {
                    Title = "Ρινόκερος",
                    Description = "Καμία κοινωνία δεν κατάφερε να διώξει τη μελαγχολία μας. Κανένα πολιτικό σύστημα δεν μπορεί να μας απελευθερώσει από την οδύνη της ζωής, τον φόβο του θανάτου, τη δίψα μας για τελειότητα, την απληστία μας για υλικά αγαθά και την ανάγκη να εκλογικεύουμε τα πάντα. Πώς να αποδείξεις ένα νόημα εκεί που δεν βρίσκεις κανένα",
                    Actors = "Άρης Σερβετάλης, Έλλη Τρίγγου, Στέλιος Ιακωβίδης, Ροζαμαλία Κυρίου, Θάνος Μπίρκος, Πάνος Παπαδόπουλος, Αγγελική Τρομπούκη, Κωστής Μπούντας, Αναστασία Στυλιανίδη",
                    Directors = "Γιάννης Κακλέας",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 19,0, 0),
                    Duration = 85,
                    Hall = halls[5],
                    Genre = genres[16],
                },
                new Show()
                {
                    Title = "Ο Τσάρος με την μακριά γενειάδα",
                    Description = "Τσάρος με την μακριά γενειάδα, είναι ένα παραμύθι, που αυτή την φορά έρχεται από την μακρινή Ρωσία. Τότε που ο κόσμος του Θεού ήταν γεμάτος με μάγους και ξωτικά, ζώα με ανθρώπινη λαλιά αλλά και ποτάμια μέσα στα οποία ήταν χτισμένα παλάτια ολόκληρα με βασιλιάδες και βασίλισσες",
                    Actors = "Χάρης Αγγέλου, Κωνσταντίνα Λιναρδάτου, Ιουστίνα Μάτσιασεκ, ‘Ελενα Μιχαλάκη, Γιάννης Νικολάου, Ορφέας Τσαρέκας, Πολύκαρπος Φιλιππίδης, Ειρήνη Χρηστίδη",
                    Directors = "Κάρμεν Ρουγγέρη",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 19,0, 0),
                    Duration = 90,
                    Hall = halls[5],
                    Genre = genres[10],
                },
                new Show()
                {
                    Title = "ΠΡΑΚΤΩΡ 00ΛΕΦΤΑ",
                    Description = "Ο Μάρκος Σεφερλής για μια ακόμα καλοκαιρινή σεζόν στο θέατρο Δελφινάριο ως ΠΡΑΚΤΩΡ 00ΛΕΦΤΑ, αφουγκράζεται την ανάγκη του κόσμου για γέλιο και διασκέδαση και μένει πιστός στο ραντεβού του με το αγαπημένο του κοινό.",
                    Actors = "ΜΑΡΚΟΣ ΣΕΦΕΡΛΗΣ,ΓΙΑΝΝΗΣ ΚΑΠΕΤΑΝΙΟΣ,ΕΛΕΝΑ ΤΣΑΒΑΛΙΑ,ΑΡΕΤΗ ΖΑΧΑΡΙΑΔΟΥ,ΓΙΑΝΝΗΣ ΑΓΡΙΟΜΑΛΛΟΣ,ΑΝΑΡΓΥΡΟΣ ΒΑΖΑΙΟΣ,ΛΕΩΝΙΔΑΣ ΙΟΡΔΑΝΟΥ,ΝΙΚΟΣ ΛΑΙΟΣ,ΧΡΙΣΤΙΑΝΑ ΚΑΡΝΕΖΗ",
                    Directors = "ΜΑΡΚΟΣ ΣΕΦΕΡΛΗΣ",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 19,0, 0),
                    Duration = 90,
                    Hall = halls[6],
                    Genre = genres[9],
                },
                new Show()
                {
                    Title = "Dettolμη και Γοητεία",
                    Description = "Ο Σωτήρης Τσιόδρας, ένας άνθρωπος με τόλμη και ο Νίκος Χαρδαλιάς, ένας άνδρας με ακαταμάχητη γοητεία, ανεβαίνουν στη σκηνή και δια στόματος Μάρκου Σεφερλή, ανακοινώνουν ότι βρέθηκε επιτέλους το φάρμακο για τον Κορονοϊό, το οποίο και μοιράζεται απλόχερα από Τρίτη μέχρι Κυριακή μόνο στο ΔΕΛΦΙΝΑΡΙΟ.\r\n\r\n",
                    Actors = "ΜΑΡΚΟΣ ΣΕΦΕΡΛΗΣ,ΓΙΑΝΝΗΣ ΚΑΠΕΤΑΝΙΟΣ,ΕΛΕΝΑ ΤΣΑΒΑΛΙΑ,ΑΡΕΤΗ ΖΑΧΑΡΙΑΔΟΥ,ΖΩΖΑ ΜΕΤΑΞΑ,ΓΙΑΝΝΗΣ ΑΓΡΙΟΜΑΛΛΟΣ,ΑΝΑΡΓΥΡΟΣ ΒΑΖΑΙΟΣ,ΧΡΙΣΤΙΑΝΑ ΚΑΡΝΕΖΗ,ΛΕΩΝΙΔΑΣ ΙΟΡΔΑΝΟΥ,3ΝΙΚΟΣ ΧΑΤΖΗΠΑΠΑΣ",
                    Directors = "ΜΑΡΚΟΣ ΣΕΦΕΡΛΗΣ",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 19,0, 0),
                    Duration = 90,
                    Hall = halls[6],
                    Genre = genres[9],
                },
                new Show()
                {
                    Title = "Άλλος για Survivor",
                    Description = "Το Δελφινάριο μετακομίζει στον... Άγιο Δομίνικο και ο Μάρκος Σεφερλής γίνεται... Survivor στη μεγαλειώδη υπερπαραγωγή του καλοκαιριού!",
                    Actors = "Μάρκος Σεφερλής, Γιάννης Καπετάνιος, Έλενα Τσαβαλιά, Θοδωρής Ρωμανίδης, Βασιλική Αγγελή, Γιάννης Παπαευθυμίου, Ανάργυρος Βαζαίος, Γιάννης Αγριόμαλλος, Ηλίας Παπακωνσταντίνου, Χριστιάνα Καρνέζη, Βάσω Βίλεγγας",
                    Directors = "Μάρκος Σεφερλής",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 20,0, 0),
                    Duration = 120,
                    Hall = halls[6],
                    Genre = genres[6],
                },
                new Show()
                {
                    Title = "Πενήντα Αποχρώσεις To Greece",
                    Description = "Γέλιο μέχρι δακρύων υπόσχεται ο Μάρκος Σεφερλής με τη νέα παράσταση που ανεβάζει (4/7) φέτος το καλοκαίρι στο Δελφινάριο, ανανεώνοντας το ετήσιο ραντεβού του με το κοινό που τον ακολουθεί πιστά τα τελευταία χρόνια. ",
                    Actors = "Μάρκος Σεφερλής, Γιάννης Καπετάνιος, Θοδωρής Ρωμανίδης, Στέλιος Κρητικός, Γιάννης Ζουμπαντής, Αρετή Ζαχαριάδου, Θοδωρής Κατσικαλούδης, Γιώργος Κοντογιάννης",
                    Directors = "Μάρκος Σεφερλής",
                    DateStart = new DateTime(2022, 01, 01),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 16,0, 0),
                    Duration = 180,
                    Hall = halls[6],
                    Genre = genres[6],
                },
                new Show()
                {
                    Title = "ΝΤΟΝ ΤΖΟΒΑΝΝΙ",
                    Description = "Η αριστουργηματική όπερα του Μότσαρτ Ντον Τζοβάννι έρχεται στην Αίθουσα Σταύρος Νιάρχος της Εθνικής Λυρικής Σκηνής στο ΚΠΙΣΝ, από τις 21 Οκτωβρίου και για έξι παραστάσεις",
                    Actors = "Με την Ορχήστρα και τη Χορωδία της Εθνικής Λυρικής Σκηνής",
                    Directors = "",
                    DateStart = new DateTime(2022, 10, 23),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 16,0, 0),
                    Duration = 180,
                    Hall = halls[7],
                    Genre = genres[5],
                },
                new Show()
                {
                    Title = "Η ρομαντική μου ιστορία",
                    Description = "Τρεις ηθοποιοί ερμηνεύουν 21 ρόλους σε ένα έργο που, με όπλο το χιούμορ, καταπιάνεται με τις δύσκολες ερωτικές σχέσεις της εποχής μας",
                    Actors = ": Μ. Παπαδημητρίου, Κ. Λυπηρίδου, Σ. Κεκέ.",
                    Directors = "Β. Θεοδωρόπουλος",
                    DateStart = new DateTime(2022, 10, 23),
                    DateEnd = new DateTime(2023, 01, 01),
                    TimeStart = new DateTime(2023, 09, 01, 16,0, 0),
                    Duration = 100,
                    Hall = halls[7],
                    Genre = genres[15],
                }
            };

            foreach (Hall hall in halls)
            {

                //hall.Shows.Add(shows[0]);
                context.AddAsync(hall);
            }

            foreach (Genre genre in genres)
            {
                context.AddAsync(genre);
            }

            foreach(Show show in shows)
            {
                context.AddAsync(show);
            }

            await context.SaveChangesAsync();

            halls[0].Shows.Add(shows[0]);
            halls[0].Shows.Add(shows[1]);
            halls[0].Shows.Add(shows[2]);
            halls[1].Shows.Add(shows[3]);
            halls[1].Shows.Add(shows[4]);
            halls[1].Shows.Add(shows[5]);
            halls[2].Shows.Add(shows[6]);
            halls[2].Shows.Add(shows[7]);
            halls[2].Shows.Add(shows[8]);
            halls[3].Shows.Add(shows[9]);
            halls[3].Shows.Add(shows[10]);
            halls[4].Shows.Add(shows[11]);
            halls[4].Shows.Add(shows[12]);
            halls[5].Shows.Add(shows[13]);
            halls[5].Shows.Add(shows[14]);
            halls[5].Shows.Add(shows[15]);
            halls[5].Shows.Add(shows[16]);
            halls[6].Shows.Add(shows[17]);
            halls[6].Shows.Add(shows[18]);
            halls[6].Shows.Add(shows[19]);
            halls[6].Shows.Add(shows[20]);
            halls[7].Shows.Add(shows[21]);
            halls[7].Shows.Add(shows[22]);
            await context.SaveChangesAsync();
        }
    }
}
