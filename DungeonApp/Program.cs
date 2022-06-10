using DungeonLibrary;

namespace DungeonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF DOOM";
            Console.WriteLine("Your journey begins...\n");

            int score = 0;//declare this running variable outside of the main do while loop. It can then be displayed inside of the menu (Player Info option) or at the end of the game (exit or die).

            #region Player Creation

            Weapon sword = new Weapon(1, 8, "Long Sword", 10, false, WeaponType.Sword);
            /*
            //Possible Expansion: 
            //Allow player to define chatacter name
            Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome, {0}! Your journey begins...", userName);
            Console.ReadKey();
            Console.Clear();
            */
            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Elf, sword);
            #endregion



            bool exit = false;// both loops
            do
            {
                //create a monster -- random monster generator in the Monster class; creates a list of 4 different monsters and randomly selects one of them.
                Monster monster = Monster.GetMonster();
                //create a room
                Console.WriteLine(GetRoom() + $"\nIn this room: {monster.Name}");


                bool reload = false;//inner loop (menu) -- when set to true, will 'reload' a new room with a new monster.

                #region MENU
                //Could extract this into another class library (like an Engine - a class library that houses basic functionality not specific to any datatype class)

                do
                {
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    string choice = Console.ReadKey(true).Key.ToString().ToLower();
                    Console.Clear();

                    switch (choice)
                    {
                        case "a":
                            Console.WriteLine("Attack!");
                            //TODO Combat functionality
                            //If the player wins, leave the inner loop (repeat the outer loop)
                            //If the monster wins, you're dead (leave both loops)
                            break;

                        case "r"://leave the inner loop (into the outer loop)
                            Console.WriteLine("Run away!!!!");
                            reload = true;//UPDATE
                            break;

                        case "p":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;
                        case "m":
                            Console.WriteLine("Monster Info");
                            //Print monster info
                            Console.WriteLine(monster);
                            break;

                        case "x":
                        case "e":
                        case "escape":
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;//UPDATE -- leave both loops
                            break;
                        default:
                            Console.WriteLine(choice);
                            Console.WriteLine("Input not understood, please try again");
                            break;
                    }//end switch
                } while (!reload && !exit); //if either reload or exit become true, it will exit the inner loop (menu).
                                            //reload == false, != true, !reload

                #endregion

            } while (!exit);// while exit is NOT TRUE, keep looping
            Console.WriteLine("Thanks for playing! Final score: " + score);
        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = new string[]
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

            //return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()
    }//end class
}//end namespace