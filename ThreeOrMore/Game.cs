// Game class is reponsible for applying the rules of the game, as well as keeping the score. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreeOrMore
{
    class Game
    {
        #region Store Roll Results
        /// <summary>
        /// Player's first roll during single round.
        /// </summary>
        /// <param name="roll_results">Player die throw.</param>
        /// <returns>Dictionary with results.</returns>
        public Dictionary<int, int> Store_Roll_Results(int[] roll_results)
        {
            // Create match table and initialize the Keys.
            Dictionary<int, int> Match_Table = new Dictionary<int, int>();
            Match_Table.Add(1, 0);
            Match_Table.Add(2, 0);
            Match_Table.Add(3, 0);
            Match_Table.Add(4, 0);
            Match_Table.Add(5, 0);
            Match_Table.Add(6, 0);

            // Iterate through provided array and insert Values to coresponding Keys.
            foreach (var item in roll_results)
            {
                // Case represents Key. Each time item is found, increase Value by 1.
                switch (item)
                {
                    case 1:
                        Match_Table[1] += 1;
                        break;
                    case 2:
                        Match_Table[2] += 1;
                        break;
                    case 3:
                        Match_Table[3] += 1;
                        break;
                    case 4:
                        Match_Table[4] += 1;
                        break;
                    case 5:
                        Match_Table[5] += 1;
                        break;
                    case 6:
                        Match_Table[6] += 1;
                        break;
                    default:
                        break;
                }
            }
            return Match_Table;
        }
        #endregion

        #region Re Throw
        /// <summary>
        /// Secondary throw during single round.
        /// </summary>
        /// <param name="match_table">Results from first throw.</param>
        /// <param name="turn">Player1's turn. True or False.</param>
        /// <returns>Dictionary with results.</returns>
        public Dictionary<int,int> Re_Throw(Dictionary<int,int> match_table,bool turn)
        {
            // Create match table and initialize the Keys.
            Dictionary<int, int> Only_2oaK_rethrow = new Dictionary<int, int>();
            Only_2oaK_rethrow.Add(1, 0);
            Only_2oaK_rethrow.Add(2, 0);
            Only_2oaK_rethrow.Add(3, 0);
            Only_2oaK_rethrow.Add(4, 0);
            Only_2oaK_rethrow.Add(5, 0);
            Only_2oaK_rethrow.Add(6, 0);

            // Used to establish whether 2-of-a-kind was rolled in first throw.
            int sum = 0;

            // Check whether 2-of-a-kind was rolled in the first throw and 3-of-a-kind was not rolled out in the same session.
            if (match_table.ContainsValue(2) && !(match_table.ContainsValue(3)))
            {
                // iterate through provided result table.
                for (int i = 1; i <= match_table.Count; i++)
                {
                    // Check if it is 2-of-a-kind.
                    if (match_table[i] == 2)
                    {
                        // Save 2-of-a-kind in new Dictionary.
                        Only_2oaK_rethrow[i] = 2;
                        // Increase sum by two. 
                        sum += 2;
                    }
                }

                string re_roll = "\nPress any BUTTON to re-roll!\n\n";

                // Create new object.
                Display myDisplay = new Display();
                // Animated text display.
                myDisplay.Text_Typing_Effect(re_roll);
                // Wait for interaction to proceed.
                Console.ReadKey(true);

                // Create new object.
                Player myPlayer = new Player();
                // New array with remaining die.
                int[] rethrow = myPlayer.Player_Roll(5 - sum);

                // Elements for display table.
                Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.Write("║");

                // Puts results of the roll to second table.
                foreach (var item in rethrow)
                {
                    // If Key matches with die value, raise Value in Dictionary by 1.
                    Only_2oaK_rethrow[item] += 1;
                    // 250 miliseconds pause.
                    Thread.Sleep(250);
                    // Display die icon with coresponding value.
                    myDisplay.Dice(item);
                }
            }
            
            // Check if table doesn't contain 2-of-a-kind, 3-of-a-kind, 4-of-a-kind nor 5-of-a-kind.
            // This is for scenario when all the die values differ from each other.
            if (!(match_table.ContainsValue(2)) && !(match_table.ContainsValue(3)) && !(match_table.ContainsValue(4)) && !(match_table.ContainsValue(5)))
            {
                // Create new object.
                Player myPlayer = new Player();
                // Create new array and roll the dice.
                int[] rethrow = myPlayer.Player_Roll();

                // Iterate through array.
                foreach (var item in rethrow)
                {
                    // Assign Value equal to 1 at Key equal to item.
                    Only_2oaK_rethrow[item] += 1;
                }
            }
            return Only_2oaK_rethrow;
        }
        #endregion

        #region Re Throw CPU
        /// <summary>
        /// Secondary throw during single round.
        /// </summary>
        /// <param name="match_table">Results from first throw.</param>
        /// <param name="turn">Player1's turn. True or False.</param>
        /// <returns>Dictionary with results.</returns>
        public Dictionary<int, int> Re_Throw_CPU(Dictionary<int, int> match_table, bool turn)
        {
            // Create match table and initialize the Keys.
            Dictionary<int, int> Only_2oaK_rethrow = new Dictionary<int, int>();
            Only_2oaK_rethrow.Add(1, 0);
            Only_2oaK_rethrow.Add(2, 0);
            Only_2oaK_rethrow.Add(3, 0);
            Only_2oaK_rethrow.Add(4, 0);
            Only_2oaK_rethrow.Add(5, 0);
            Only_2oaK_rethrow.Add(6, 0);

            // Used to establish whether 2-of-a-kind was rolled in first throw.
            int sum = 0;

            // Check whether 2-of-a-kind was rolled in the first throw and 3-of-a-kind was not rolled out in the same session.
            if (match_table.ContainsValue(2) && !(match_table.ContainsValue(3)))
            {
                // iterate through provided result table.
                for (int i = 1; i <= match_table.Count; i++)
                {
                    // Check if it is 2-of-a-kind.
                    if (match_table[i] == 2)
                    {
                        // Save 2-of-a-kind in new Dictionary.
                        Only_2oaK_rethrow[i] = 2;
                        // Increase sum by two. 
                        sum += 2;
                    }
                }

                string re_roll = "\nPress any BUTTON to re-roll!\n\n";

                // Create new object.
                Display myDisplay = new Display();

                // Turn == true, means its Player1's turn.
                // Turn == false, means its Player2's turn - which is CPU.
                if (turn)
                {
                    // Animated text display.
                    myDisplay.Text_Typing_Effect(re_roll);
                    // Wait for interaction to proceed.
                    Console.ReadKey(true);
                }

                // Create new object.
                Player myPlayer = new Player();
                // New array with remaining die.
                int[] rethrow = myPlayer.Player_Roll(5 - sum);

                // Elements for display table.
                Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.Write("║");

                // Puts results of the roll to second table.
                foreach (var item in rethrow)
                {
                    // If Key matches with die value, raise Value in Dictionary by 1.
                    Only_2oaK_rethrow[item] += 1;
                    // 250 miliseconds pause.
                    Thread.Sleep(250);
                    // Display die icon with coresponding value.
                    myDisplay.Dice(item);
                }
            }

            // Check if table doesn't contain 2-of-a-kind, 3-of-a-kind, 4-of-a-kind nor 5-of-a-kind.
            // This is for scenario when all the die values differ from each other.
            if (!(match_table.ContainsValue(2)) && !(match_table.ContainsValue(3)) && !(match_table.ContainsValue(4)) && !(match_table.ContainsValue(5)))
            {
                // Create new object.
                Player myPlayer = new Player();
                // Create new array and roll the dice.
                int[] rethrow = myPlayer.Player_Roll();

                // Iterate through array.
                foreach (var item in rethrow)
                {
                    // Assign Value equal to 1 at Key equal to item.
                    Only_2oaK_rethrow[item] += 1;
                }
            }
            return Only_2oaK_rethrow;
        }
        #endregion

        #region Score It
        /// <summary>
        /// Analyze the table to find out the score.
        /// </summary>
        /// <param name="match_table">Match table</param>
        /// <returns>Final score</returns>
        public int Score_It(Dictionary<int, int> match_table)
        {
            // Variable to return.
            int final_score = 0;

            // Check if 2-of-a-kind occurs but 3-of-a-kind doesnt at the same time.
            if (match_table.ContainsValue(2) && !(match_table.ContainsValue(3)))
            {
                final_score = 0;
            }
            // 3-of-a-kind.
            else if (match_table.ContainsValue(3))
            {
                final_score = 3;
            }
            // 4-of-a-kind.
            else if (match_table.ContainsValue(4))
            {
                final_score = 6;
            }
            // 5-of-a-kind.
            else if (match_table.ContainsValue(5))
            {
                final_score = 12;
            }
            else
            {
                final_score = 0;
            }
            return final_score;
        }
        #endregion

        #region Score It (with Messages display)
        /// <summary>
        /// Analyze the table to find out the score.
        /// </summary>
        /// <param name="match_table">Match table</param>
        /// <returns>Final score</returns>
        public int Score_It_wMessages(Dictionary<int, int> match_table)
        {
            // Variable
            int final_score = 0;

            // Check if 2-of-a-kind occurs but 3-of-a-kind doesnt at the same time.
            if (match_table.ContainsValue(2) && !(match_table.ContainsValue(3)))
            {
                final_score = 0;
                string message = ("\t2-of-a-kind! You gain 0 points!");
                foreach (var letter in message)
                {
                    Thread.Sleep(30);
                    Console.Write(letter);
                }
            }
            // 3-of-a-kind.
            else if (match_table.ContainsValue(3))
            {
                final_score = 3;
                string message = ("\t3-of-a-kind! You gain 3 points!");
                foreach (var letter in message)
                {
                    Thread.Sleep(30);
                    Console.Write(letter);
                }
            }
            // 4-of-a-kind.
            else if (match_table.ContainsValue(4))
            {
                final_score = 6;
                string message = ("\t4-of-a-kind! You gain 6 points!");
                foreach (var letter in message)
                {
                    Thread.Sleep(30);
                    Console.Write(letter);
                }
            }
            // 5-of-a-kind.
            else if (match_table.ContainsValue(5))
            {
                final_score = 12;
                string message = ("\t5-of-a-kind! You gain 12 points!");
                foreach (var letter in message)
                {
                    Thread.Sleep(30);
                    Console.Write(letter);
                }
            }
            else
            {
                final_score = 0;
                string message = ("\tNo luck... You gain 0 points!  ");
                foreach (var letter in message)
                {
                    Thread.Sleep(30);
                    Console.Write(letter);
                }
            }
            return final_score;
        }
        #endregion

        #region History
        /// <summary>
        /// Save results.
        /// </summary>
        /// <param name="First_Throw">First throw table</param>
        /// <param name="Re_Throw">Second throw table</param>
        /// <param name="turn">Player1 turn - True or False.</param>
        /// <param name="round">Round</param>
        /// <returns>Array with results.</returns>
        public string[] History_entry(Dictionary<int,int> First_Throw, Dictionary<int,int> Re_Throw, bool turn, int round)
        {
            // Create new string array.
            string[] entry = new string[7];
            // Counter starts at 2, as two first values are provided as arguments in a method.
            int counter=2;

            // Turn == true, means its Player1's turn.
            // Turn == false, means its Player2's turn.
            if (turn)
            {
                // Put string to an array at index = 0.
                entry[0] = "Player1";
            }
            if (turn==false)
            {
                // Put string to an array at index = 0.
                entry[0] = "Player2";
            }

            // Entry at index = 1 is the round (provided as argument in a method).
            entry[1] = "Round"+round.ToString();

            // Check if first roll provides with 3-of-a-kind, 4-of-a-kind, 5-of-a-kind or just one value each.
            // So basicaly, every other scenario than 2-of-a-kind. Which is when you can re throw remaining die.
            if (First_Throw.Values.Contains(3) || First_Throw.Values.Contains(4) || First_Throw.Values.Contains(5) || First_Throw.Values.Max()==1)
            {
                // Iterate through first table(Dictionary).
                foreach (var item in First_Throw)
                {
                    // Check if Value is other than 0.
                    if (item.Value!=0)
                    {
                        // If value occurs at least once, put Key in to the entry.
                        entry[counter] = item.Key.ToString();
                        // Check if it appears more than once.
                        if (item.Value > 1)
                        {
                            // If it does, increase the counter, to move one index up.
                            counter++;
                            // Once more, store Key in that entry.
                            entry[counter] = item.Key.ToString();
                            // Check if Value appears more than twice.
                            if (item.Value > 2)
                            {
                                // If it does, increase the counter, to move one index up.
                                counter++;
                                // Store Key in that entry.
                                entry[counter] = item.Key.ToString();
                                // Check if Value appears more than three times.
                                if (item.Value > 3)
                                {
                                    // If it does, increase the counter, to move one index up.
                                    counter++;
                                    // Store Key in that entry.
                                    entry[counter] = item.Key.ToString();
                                    if (item.Value > 4)
                                    {
                                        // If it does, increase the counter, to move one index up.
                                        counter++;
                                        // Store Key in that entry.
                                        entry[counter] = item.Key.ToString();
                                    }
                                }
                            }
                        }
                        // Sets counter to increase, for next entry.
                        counter++;
                    }
                }
            }
            // Else is only going to be the case if you roll out one or two 2-of-a-kind.
            else
            {
                // Iterate through second table(Dictionary).
                foreach (var item in Re_Throw)
                {
                    // Check if Value is other than 0.
                    if (item.Value != 0)
                    {
                        // If value occurs at least once, put Key in to the entry.
                        entry[counter] = item.Key.ToString();
                        // Check if it appears more than once.
                        if (item.Value > 1)
                        {
                            // If it does, increase the counter, to move one index up.
                            counter++;
                            // Once more, store Key in that entry.
                            entry[counter] = item.Key.ToString();
                            if (item.Value > 2)
                            {
                                // If it does, increase the counter, to move one index up.
                                counter++;
                                // Store Key in that entry.
                                entry[counter] = item.Key.ToString();
                                // Check if Value appears more than three times.
                                if (item.Value > 3)
                                {
                                    counter++;
                                    entry[counter] = item.Key.ToString();
                                    if (item.Value > 4)
                                    {
                                        // If it does, increase the counter, to move one index up.
                                        counter++;
                                        // Store Key in that entry.
                                        entry[counter] = item.Key.ToString();
                                    }
                                }
                            }
                        }
                        // Sets counter to increase, for next entry.
                        counter++;
                    }
                }
            }
            return entry;
        }
        #endregion
    }
}
