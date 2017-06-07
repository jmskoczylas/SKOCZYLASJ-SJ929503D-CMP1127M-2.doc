//Main class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreeOrMore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Objects
            Display myDisplay = new Display();
            Player myPlayer = new Player();
            Game myGame = new Game();
            LinkedList<string[]> History = new LinkedList<string[]>();
            #endregion

            #region Variables
            int score_PL1 = 0;
            int score_PL2 = 0;
            string press_Start = "\t\t\t    Press any button to START!\n";
            string press_Button = "\nPress any BUTTON to roll the dice!\n\n";
            int round = 1;
            bool turn_PL1 = true;
            #endregion

            #region Player vs Player [method]
            
            void Play(int point_cap)
            {
                Console.Clear();

                // Loop stops when either player reaches point_cap.
                while ((score_PL1 < point_cap) || (score_PL2 > point_cap))
                {
                    // Display scoreboard at the top.
                    myDisplay.Scoreboard(score_PL1, score_PL2, round, turn_PL1);

                    // Display instructions for player and wait for interaction.
                    myDisplay.Text_Typing_Effect(press_Button);
                    Console.ReadKey(true);

                    // Player rolls the die. Store results in array.
                    int[] first_roll = myPlayer.Player_Roll();

                    // Part of visual display.
                    Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.Write("║");

                    // Iterate through array with roll results.
                    foreach (var item in first_roll)
                    {
                        // Take a pause and display die icon coresponding to item.
                        Thread.Sleep(200);
                        myDisplay.Dice(item);
                    }

                    // Create Dictionary object.
                    Dictionary<int, int> Store_Roll_Results = new Dictionary<int, int>();
                    // Put roll results into Dictionary.
                    Store_Roll_Results = myGame.Store_Roll_Results(first_roll);

                    // Display message with score.
                    Thread.Sleep(1000);
                    myGame.Score_It_wMessages(Store_Roll_Results);

                    // Part of visual display.
                    Console.Write("                       ║");
                    Console.WriteLine("\n╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                    // New Dictionary object for secondary throw.
                    Dictionary<int, int> Only_2oaK = new Dictionary<int, int>();

                    // Check if 2-of-a-kind was rolled.
                    if (Store_Roll_Results.Values.Contains(2))
                    {
                        // Secondary roll.
                        Only_2oaK = myGame.Re_Throw(Store_Roll_Results, turn_PL1);
                    }

                    // If secondary result table is not empty (meaning, secondary roll happened).
                    if (Only_2oaK.Values.Sum() != 0)
                    {
                        // Pause.
                        Thread.Sleep(1000);
                        // Display score for secondary table.
                        myGame.Score_It_wMessages(Only_2oaK);
                        // Part of visual display.
                        Console.WriteLine("\n╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    }

                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // Add score to global variables.
                        score_PL1 += myGame.Score_It(Store_Roll_Results);
                        score_PL1 += myGame.Score_It(Only_2oaK);
                    }
                    else
                    {
                        // Add score to global variables.
                        score_PL2 += myGame.Score_It(Store_Roll_Results);
                        score_PL2 += myGame.Score_It(Only_2oaK);
                    }

                    // Variable for end of turn display.
                    int end_Turn_Score = 0;

                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // If its Player1's turn, put their score into variable.
                        end_Turn_Score = score_PL1;
                    }
                    else
                    {
                        // If its Player2's turn, put their score into variable.
                        end_Turn_Score = score_PL2;
                    }

                    // Add entry with this round's results.
                    History.AddLast(myGame.History_entry(Store_Roll_Results, Only_2oaK, turn_PL1, round));

                    // First increment round count after Player2's turn.
                    if (turn_PL1 == false)
                    {
                        round++;
                    }

                    // Display end of turn summary.
                    myDisplay.End_Of_Turn(end_Turn_Score, round, turn_PL1);
                    string proceed = "      ║ Press any BUTTON to proceed... ║";
                    myDisplay.Text_Typing_Effect(proceed);
                    Console.WriteLine("\n      ╚════════════════════════════════╝");
                    Console.ReadKey(true);

                    // Swap.
                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // If current round is Player1's. Change it to false.
                        turn_PL1 = false;
                    }
                    else
                    {
                        // If current round is Player2's. Change it to true.
                        turn_PL1 = true;
                    }

                    Console.Clear();

                    // When either player reaches the point cap.
                    if ((point_cap <= score_PL1) || (point_cap <= score_PL2))
                    {
                        // Display the winner.
                        myDisplay.End_Game(score_PL1, score_PL2);

                        // History
                        Console.WriteLine("\n\t\t\tHistory:\n");

                        // Iterate through the History(LinkedList).
                        foreach (var entry in History)
                        {
                            for (int i = 0; i < entry.Length; i++)
                            {
                                // Display each entry in the list.
                                Console.Write("\t" + entry[i]);
                            }
                            Console.WriteLine();
                        }

                        myDisplay.Text_Typing_Effect("\n\t\t\tPress any BUTTON to proceed");
                        Console.ReadKey(true);

                        Console.Clear();

                        // Reset variables.
                        score_PL1 = 0;
                        score_PL2 = 0;
                        round = 1;
                        turn_PL1 = true;
                        History.Clear();

                        // Looped Menu.
                        myDisplay.Menu();
                        Menu();
                    }
                }
            }
            #endregion

            #region Player vs CPU [method]
            void Play_CPU(int point_cap)
            {
                Console.Clear();

                // Loop stops when either player reaches point_cap.
                while ((score_PL1 < point_cap) || (score_PL2 > point_cap))
                {
                    // Display scoreboard at the top.
                    myDisplay.Scoreboard(score_PL1, score_PL2, round, turn_PL1);

                    // Only at Player1's turn.
                    if (turn_PL1)
                    {
                        // Display instructions for player and wait for interaction.
                        myDisplay.Text_Typing_Effect(press_Button);
                        Console.ReadKey(true);
                    }

                    // Player rolls the die. Store results in array.
                    int[] first_roll = myPlayer.Player_Roll();

                    // Part of visual display.
                    Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.Write("║");

                    // Iterate through array with roll results.
                    foreach (var item in first_roll)
                    {
                        // Take a pause and display die icon coresponding to item.
                        Thread.Sleep(200);
                        myDisplay.Dice(item);
                    }

                    // Create Dictionary object.
                    Dictionary<int, int> Store_Roll_Results = new Dictionary<int, int>();
                    // Put roll results into Dictionary.
                    Store_Roll_Results = myGame.Store_Roll_Results(first_roll);

                    // Display message with score.
                    Thread.Sleep(1000);
                    myGame.Score_It_wMessages(Store_Roll_Results);

                    // Part of visual display.
                    Console.Write("                       ║");
                    Console.WriteLine("\n╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                    // New Dictionary object for secondary throw.
                    Dictionary<int, int> Only_2oaK = new Dictionary<int, int>();

                    // Check if 2-of-a-kind was rolled.
                    if (Store_Roll_Results.Values.Contains(2))
                    {
                        // Secondary roll.
                        Only_2oaK = myGame.Re_Throw_CPU(Store_Roll_Results, turn_PL1);
                    }

                    // If secondary result table is not empty (meaning, secondary roll happened).
                    if (Only_2oaK.Values.Sum() != 0)
                    {
                        // Pause.
                        Thread.Sleep(1000);
                        // Display score for secondary table.
                        myGame.Score_It_wMessages(Only_2oaK);
                        // Part of visual display.
                        Console.WriteLine("\n╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    }

                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // Add score to global variables.
                        score_PL1 += myGame.Score_It(Store_Roll_Results);
                        score_PL1 += myGame.Score_It(Only_2oaK);
                    }
                    else
                    {
                        // Add score to global variables.
                        score_PL2 += myGame.Score_It(Store_Roll_Results);
                        score_PL2 += myGame.Score_It(Only_2oaK);
                    }

                    // Variable for end of turn display.
                    int end_Turn_Score = 0;

                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // If its Player1's turn, put their score into variable.
                        end_Turn_Score = score_PL1;
                    }
                    else
                    {
                        // If its Player2's turn, put their score into variable.
                        end_Turn_Score = score_PL2;
                    }

                    // Add entry with this round's results.
                    History.AddLast(myGame.History_entry(Store_Roll_Results, Only_2oaK, turn_PL1, round));

                    // First increment round count after Player2's turn.
                    if (turn_PL1 == false)
                    {
                        round++;
                    }

                    // Display end of turn summary.
                    myDisplay.End_Of_Turn(end_Turn_Score, round, turn_PL1);
                    string proceed = "      ║ Press any BUTTON to proceed... ║";
                    myDisplay.Text_Typing_Effect(proceed);
                    Console.WriteLine("\n      ╚════════════════════════════════╝");
                    Console.ReadKey(true);

                    // Swap.
                    // Turn_PL1 == true, Player1's turn.
                    // Turn_PL2 == false, Player2's turn.
                    if (turn_PL1)
                    {
                        // If current round is Player1's. Change it to false.
                        turn_PL1 = false;
                    }
                    else
                    {
                        // If current round is Player2's. Change it to true.
                        turn_PL1 = true;
                    }

                    Console.Clear();

                    // When either player reaches the point cap.
                    if ((point_cap <= score_PL1) || (point_cap <= score_PL2))
                    {
                        // Display the winner.
                        myDisplay.End_Game(score_PL1, score_PL2);

                        // History.
                        Console.WriteLine("\n\t\t\tHistory:\n");

                        // Iterate through the History(LinkedList).
                        foreach (var item in History)
                        {
                            for (int i = 0; i < item.Length; i++)
                            {
                                // Display each entry in the list.
                                Console.Write("\t" + item[i]);
                            }
                            Console.WriteLine();
                        }

                        myDisplay.Text_Typing_Effect("\n\t\t\tPress any BUTTON to proceed");
                        Console.ReadKey(true);

                        Console.Clear();

                        // Reset variables.
                        score_PL1 = 0;
                        score_PL2 = 0;
                        round = 1;
                        turn_PL1 = true;
                        History.Clear();

                        // Looped menu.
                        myDisplay.Menu();
                        Menu();
                    }
                }
            }
            #endregion

            #region Menu [method]
            void Menu()
            {
                var menu_choice = Console.ReadKey(true);

                switch (menu_choice.KeyChar)
                {
                    default:
                    case '1':
                        Play(50);
                        break;
                    case '2':
                        Play(25);
                        break;
                    case '3':
                        Play(12);
                        break;
                    case '4':
                        Play_CPU(50);
                        break;
                    case '5':
                        Play_CPU(25);
                        break;
                    case '6':
                        Play_CPU(12);
                        break;
                    case '7':
                        Environment.Exit(0);
                        break;
                }
            }
#endregion

            // First screen - logo and rules.
            Thread.Sleep(500);
            myDisplay.Logo();
            Thread.Sleep(500);
            myDisplay.Rules();

            myDisplay.Text_Typing_Effect(press_Start);
            Console.ReadKey(true);
            Thread.Sleep(500);
            Console.Clear();

            // Draw menu.
            myDisplay.Menu();

            try
            {
                Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! Something is wrong!");
            }
        }
    }
}
