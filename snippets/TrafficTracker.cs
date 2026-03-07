/*
Name:  Traffic Tracker
Author:  SweptThrone (sweptthr.one)
Description:  A console app that again parses access logs
              for my website.  This one was made to track
              how many views my Garry's Mod addons are
              receiving.
Config:  .NET Framework 10.0, C# 14.0, compiler version 5.0.0-2.25612.105 (44525024)
*/

namespace TrafficTracker {
    internal class TrafficTracker {
        // in:  path to file to parse
        // out:  null, creates a file named ".addonvisits" which is a newline-separated file of addon names and visits

        static void Main( string[] args ) {
            string myIP = "XXX.XXX.XXX.XXX";

            Dictionary<string, string> addonLookup = new() {
                { "909154852", "(SweptThrone Catalogue)" },

                { "796204036", "The Cigarevolver" },
                { "835424331", "HowToBasic SWep" },
                { "845880568", "RP_Subterranean_ST" },
                { "867753256", "Swept's Radios" },
                { "872953684", "TFA HL2 Weapons" },
                { "873278665", "Khonjin Guns" },
                { "873323715", "Stealth Weapons" },
                { "875672849", "CS:S Edited Weapons" },
                { "886286413", "CoD DoD:S Weapons" },
                { "886352286", "CS:S Worldmodel Weapons" },
                { "887978248", "E-11D Blaster" },
                { "904065607", "STMagazines Rewrite" },
                { "904065713", "STM HL2 Weapons" },
                { "904065809", "STM CS:S Weapons" },
                { "904636721", "Rage Deagle" },
                { "908557582", "The Consonance" },
                { "908574236", "Slumber Gun" },
                { "919899774", "The Fish LMG" },
                { "921195220", "TFA CS:S Weapons" },
                { "921461719", "Literal Banana Mag" },
                { "921509375", "Banana Pistol" },
                { "927747286", "The Cap Guns" },
                { "927747307", "The M24-9" },
                { "930254241", "The BEagle" },
                { "936470673", "The Dueling Gun" },
                { "946969193", "The Disarmer" },
                { "946969272", "The Tagging Device" },
                { "947014763", "Weapon Thief" },
                { "958568178", "More CS:S Edits" },
                { "961810362", "CS:S M4A4" },
                { "1076728678", "Legacy TFA Heavies" },
                { "1076729422", "Legacy TFA Assault" },
                { "1076730705", "Legacy TFA Small Arms" },
                { "1088642054", "Rebel Wardrobe" },
                { "1088642559", "Medical Closet" },
                { "1117098363", "Jetpack Joyride SWep" },
                { "1117098663", "Force Lightning SWep" },
                { "1118654574", "STBitMiners" },
                { "1124122444", "STDrugs" },
                { "1127700427", "STGraveRobbing" },
                { "1131037159", "STFood" },
                { "1131037279", "STPottery" },
                { "1138492091", "STCoffeeShop" },
                { "1142439959", "CS:S Checker" },
                { "1148138889", "Ting Go Skrra Glock" },
                { "1151775024", "STRaidKit" },
                { "1172717349", "TCoBooks" },
                { "1173343926", "STStorage" },
                { "1175351971", "CS:GO Site Remover" },
                { "1175594193", "STBrewery" },
                { "1184142400", "Ting Go Skrra Glock 2" },
                { "1190519666", "\"140\" Weapons" },
                { "1196540264", "Hexadecimal Color Command" },
                { "1209534355", "Battlefield-ish Suppression" },
                { "1213134986", "TTT Radio Vocal Callouts" },
                { "1232772885", "TTT Jury-Rigged Crossbow" },
                { "1235086839", "Stealth Weapons 2" },
                { "1253500227", "The Horse Gun" },
                { "1260753513", "Bob's TDMRP Tribute Pack" },
                { "1296149270", "Swept's Deathmatch" },
                { "1302607111", "Future Weapons Pack" },
                { "1302607212", "Tribal Weapon Pack" },
                { "1319694388", "RP_Subterranean_ST2" },
                { "1362343274", "The IR-25" },
                { "1364042820", "The Atomic Assault" },
                { "1365361426", "Make it Rain SWep" },
                { "1367136333", "The Sniper Rifle" },
                { "1368958015", "Swept's Radios 2" },
                { "1369616803", "Global's 12Ga M249" },
                { "1370301663", "STCheese" },
                { "1371161504", "STRaidKit Redux Rewrite" },
                { "1371819070", "Payday 2 Cook Off" },
                { "1372581446", "Medicine Jars" },
                { "1373580329", "STCasinoSuite" },
                { "1387634332", "This Is America Guns" },
                { "1388240144", "CS:S Damage Sounds" },
                { "1388910984", "Death Grave Spawns" },
                { "1397977042", "Virus Survival Classic" },
                { "1402756514", "Player Flinching" },
                { "1403637447", "Better FA:S2 Ammo Boxes" },
                { "1409496044", "Bored Guns" },
                { "1410144460", "Hidey Closet" },
                { "1412744156", "Simple Jump Pads" },
                { "1424655528", "TFA Silly's Weapons" },
                { "1429883149", "CS:S Nerf Sounds" },
                { "1449037590", "STStamina" },
                { "1450525030", "Player Stats" },
                { "1484379645", "The Gun Gun" },
                { "1484841371", "The Bullet Betty" },
                { "1486060280", "STHUD" },
                { "1491950332", "Bodygroup Wardrobe" },
                { "1528202466", "Grudge Drugs" },
                { "1547284605", "Wick Contractor Neu" },
                { "1547289250", "Chicken-O-Meter" },
                { "1582003556", "UnnamedHUD" },
                { "1606237140", "DarkRP Reaping Module" },
                { "1699205374", "Minecraft Chat Format" },
                { "1704554596", "Disable Karma System" },
                { "1779355433", "STBakery" },
                { "1788775018", "STBitMining 2" },
                { "1806495989", "STFishing" },
                { "1810335038", "STMining" },
                { "1811193405", "STNarcotics" },
                { "1812072977", "Better Shipment Box" },
                { "1813537241", "Better FA:S Attachments" },
                { "1814329736", "TTT Adhesion Grenade" },
                { "1946774950", "Location Pinging" },
                { "1949278839", "STBankRobbery" },
                { "1950477462", "STCounterfeit" },
                { "1970062059", "Simple Halo Killstreaks" },
                { "1985122716", "TCo-Brand Stim Pistol" },
                { "1985123197", "Frenzy Weapons" },
                { "1985123242", "Elemental Kriegs" },
                { "1995228401", "Medichemistry" },
                { "2073195865", "Sniper Glint" },
                { "2151694210", "Long Use Entity Base" },
                { "2151694266", "Stealthy Door Opening" },
                { "2185918541", "Hunt Health" },
                { "2215911461", "Infoboards" },
                { "2306680642", "Sea of Thieves Kill Sounds" },
                { "2803058028", "Virus Survival" },
                { "2859295251", "STStamina Neu" },
                { "2873371862", "SweptTTT Crossbow" },
                { "2982856517", "GTA Online Player List" },
                { "2982856554", "GTA V-ish HUD" },
                { "2982856579", "STFood Neu" },
                { "3221437966", "SysClock" },
                { "3225198325", "Hunt Fatigue" },
                { "3227812235", "RP_Downtown_STRP" },
                { "3232001140", "STFood Neu STRP Edition" },
                { "3233724652", "STDope" },
                { "3237110733", "STChef" },
                { "3239434905", "VA-11 Hall-A Bartending" },
                { "3242398000", "KeypAdder" },
                { "3244480000", "STCuffs" },
                { "3631137542", "Hot Dog Cart" },
                { "3632159415", "AnkoHUD" },
                { "3632159454", "RTCWHUD" },
                { "3632937426", "STCoffeeShop Neu" },
                { "3633645992", "The Contact" },
                { "3634799896", "STSilk" },
                { "3635451973", "STCrypto" },
                { "3636169533", "STHackerWar" },
                { "3636745788", "STMoonshine" },
                { "3637802612", "STPowder" },
                { "3638675626", "STGunrunning" },
                { "3639230317", "STOilMogul" },
                { "3640287574", "STFishing Neu" }
            };

            string? line;
            string lineOut;
            string? fileName;

            if ( args.Length == 0 ) {
                Console.Write( "Enter access log file name > " );
                fileName = Console.ReadLine();
            } else {
                fileName = args[ 0 ];
            }

            if ( fileName == null ) {
                Console.WriteLine( "No filename was provided...quitting..." );
                return;
            }
            StreamReader reader = new StreamReader( fileName );
            StreamWriter writer = new StreamWriter( ".addonvisits" );
            line = reader.ReadLine();

            Dictionary< string, int > visits = [];

            while ( line != null ) {
                if ( line.Contains( "/img/neucontact.png?a=" ) && line.Substring( 0, myIP.Length ) != myIP ) {

                    lineOut = line.Substring( line.IndexOf( "/img/neucontact.png?a=" ) + "/img/neucontact.png?a=".Length, line.IndexOf( " HTTP/1.1" ) - line.IndexOf( "/img/neucontact.png?a=" ) - "/img/neucontact.png?a=".Length );
                    if ( visits.ContainsKey( lineOut ) ) {
                        visits[ lineOut ]++;
                    } else {
                        visits[ lineOut ] = 1; 
                    }
                }
                line = reader.ReadLine();
            }

            var sortedVisitors = from kvPair in visits orderby kvPair.Value descending select kvPair;

            foreach ( KeyValuePair< string, int > kv in sortedVisitors ) {
                writer.WriteLine( addonLookup[ kv.Key ] + ": " + kv.Value );
                writer.Flush();
            }
        }
    }
}

