// Display class is responsible for visuals in the game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ThreeOrMore
{
    class Display
    {
        #region Logo
        /// <summary>
        /// Logo.
        /// </summary>
        public void Logo()
        {
            Console.WriteLine("\n  _______ _    _ _____  ______ ______    ____  _____    __  __  ____  _____  ______ ");
            Thread.Sleep(100);
            Console.WriteLine(" |__   __| |  | |  __ \\|  ____|  ____|  / __ \\|  __ \\  |  \\/  |/ __ \\|  __ \\|  ____|");
            Thread.Sleep(100);
            Console.WriteLine("    | |  | |__| | |__) | |__  | |__    | |  | | |__) | | \\  / | |  | | |__) | |__   ");
            Thread.Sleep(100);
            Console.WriteLine("    | |  |  __  |  _  /|  __| |  __|   | |  | |  _  /  | |\\/| | |  | |  _  /|  __|  ");
            Thread.Sleep(100);
            Console.WriteLine("    | |  | |  | | | \\ \\| |____| |____  | |__| | | \\ \\  | |  | | |__| | | \\ \\| |____ ");
            Thread.Sleep(100);
            Console.WriteLine("    |_|  |_|  |_|_|  \\_\\______|______|  \\____/|_|  \\_\\ |_|  |_|\\____/|_|  \\_\\______|\n");
        }
        #endregion

        #region Rules
        /// <summary>
        /// Game rules.
        /// </summary>
        public void Rules()
        {
            Console.WriteLine("\n************************************************************************************");
            Console.WriteLine("* 1. Players take turns rolling five dice and score for three-of-a-kind or better. *");
            Console.WriteLine("* 2. If a player only has two-ofa-kind,they may re - throw the remaining dice in   *\n*    an attempt to improve the remaining dice values.\t\t\t\t   *");
            Console.WriteLine("* 3. If no matching numbers are rolled after two rolls, the player scores 0.       *");
            Console.WriteLine("************************************************************************************\n");
        }
        #endregion

        #region Menu
        /// <summary>
        /// Menu.
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("\n ███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗");
            Thread.Sleep(100);
            Console.WriteLine(" ████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║");
            Thread.Sleep(100);
            Console.WriteLine(" ██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║");
            Thread.Sleep(100);
            Console.WriteLine(" ██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║");
            Thread.Sleep(100);
            Console.WriteLine(" ██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝");
            Thread.Sleep(100);
            Console.WriteLine(" ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝\n");
            Thread.Sleep(100);
            Console.WriteLine("\n*************************************************************************");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t1. Player vs Player (50 or more, wins)\t\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t2. Player vs Player (25 or more, wins)\t\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t3. Player vs Player (12 or more, wins)\t\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t4. Player vs Computer (50 or more, wins)\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t5. Player vs Computer (25 or more, wins)\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*\t\t6. Player vs Computer (12 or more, wins)\t\t*");
            Thread.Sleep(100);            
            Console.WriteLine("*\t\t7. Exit\t\t\t\t\t\t\t*");
            Thread.Sleep(100);
            Console.WriteLine("*************************************************************************");
        }
        #endregion

        #region Dice
        /// <summary>
        /// Visual representation of the dice.
        /// </summary>
        /// <param name="dice_roll_result">Value rolled out.</param>
        public void Dice(int dice_roll_result)
        {
            switch (dice_roll_result)
            {
                case 1:
                    Console.Write("\t[ . ]");
                    break;
                case 2:
                    Console.Write("\t[ : ]");
                    break;
                case 3:
                    Console.Write("\t[...]");
                    break;
                case 4:
                    Console.Write("\t[.:.]");
                    break;
                case 5:
                    Console.Write("\t[.::]");
                    break;
                case 6:
                    Console.Write("\t[:::]");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Typing Effect
        /// <summary>
        /// Text typing effect.
        /// </summary>
        /// <param name="any_Text">String value.</param>
        public void Text_Typing_Effect (string any_Text)
        {
            foreach (var item in any_Text)
            {
                Thread.Sleep(30);
                Console.Write(item);
            }
        }
        #endregion
        
        #region Scoreboard
        /// <summary>
        /// Scoreboard.
        /// </summary>
        /// <param name="score_PL1">Player1's score</param>
        /// <param name="score_PL2">Player2's score</param>
        /// <param name="round">Round count</param>
        /// <param name="turn">Player's turn (bool)</param>
        public void Scoreboard (int score_PL1,int score_PL2, int round, bool turn)
        {
            string player_Turn = "";
            if (turn)
            {

                player_Turn = "Player1's turn";
                Console.WriteLine("SCOREBOARD\t\tROUND{0}\t\tPLAYER1 score:{1}\t\tPLAYER2 score:{2}\t\t{3}", round, score_PL1, score_PL2, player_Turn);
            }
            if (turn==false)
            {
                player_Turn = "Player2's turn";
                Console.WriteLine("SCOREBOARD\t\tROUND{0}\t\tPLAYER1 score:{1}\t\tPLAYER2 score:{2}\t\t{3}", round, score_PL1, score_PL2, player_Turn);
            }

        }
        #endregion

        #region End of Turn
        /// <summary>
        /// End of turn.
        /// </summary>
        /// <param name="score">Total score</param>
        /// <param name="round">Round count</param>
        /// <param name="turn_PL1">Player's round(bool)</param>
        public void End_Of_Turn (int score, int round, bool turn_PL1)
        {
            string c_Turn = "      ║ Player2's turn!                ║\n";
            string p_Turn = "      ║ Player1's turn!                ║\n";

            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Thread.Sleep(100);
            Console.WriteLine("║    ███████╗███╗   ██╗██████╗      ██████╗ ███████╗    ████████╗██╗   ██╗██████╗ ███╗   ██╗          ║");
            Thread.Sleep(100);
            Console.WriteLine("║    ██╔════╝████╗  ██║██╔══██╗    ██╔═══██╗██╔════╝    ╚══██╔══╝██║   ██║██╔══██╗████╗  ██║          ║");
            Thread.Sleep(100);
            Console.WriteLine("║    █████╗  ██╔██╗ ██║██║  ██║    ██║   ██║█████╗         ██║   ██║   ██║██████╔╝██╔██╗ ██║          ║");
            Thread.Sleep(100);
            Console.WriteLine("║    ██╔══╝  ██║╚██╗██║██║  ██║    ██║   ██║██╔══╝         ██║   ██║   ██║██╔══██╗██║╚██╗██║          ║");
            Thread.Sleep(100);
            Console.WriteLine("║    ███████╗██║ ╚████║██████╔╝    ╚██████╔╝██║            ██║   ╚██████╔╝██║  ██║██║ ╚████║          ║");
            Thread.Sleep(100);
            Console.WriteLine("║    ╚══════╝╚═╝  ╚═══╝╚═════╝      ╚═════╝ ╚═╝            ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝          ║");
            Thread.Sleep(100);
            Console.WriteLine("╚═════╦════════════════════════════════╦══════════════════════════════════════════════════════════════╝");

            // Display score at the end of round.
            if (score>9)
            {
                Thread.Sleep(50);
                Console.WriteLine("      ║ Your score after this turn: {0}!║", score);
                Thread.Sleep(50);
                Console.WriteLine("      ╠════════════════════════════════╣");
            }
            else
            {
                Thread.Sleep(50);
                Console.WriteLine("      ║ Your score after this turn: {0}! ║", score);
                Thread.Sleep(50);
                Console.WriteLine("      ╠════════════════════════════════╣");
            }

            // Display turn. 
            // Check if its Player1's turn.
            if (turn_PL1)
            {
                Text_Typing_Effect(c_Turn);
                Thread.Sleep(50);
                Console.WriteLine("      ╠════════════════════════════════╣");

            }
            // Player2's turn.
            else if (turn_PL1==false)
            {
                Text_Typing_Effect(p_Turn);
                Thread.Sleep(50);
                Console.WriteLine("      ╠════════════════════════════════╣");
            }
        }
        #endregion

        #region End_Game
        /// <summary>
        /// Final display, winner and roll history.
        /// </summary>
        /// <param name="score_PL1">Score Player1</param>
        /// <param name="score_CP">Score Player2</param>
        public void End_Game(int score_PL1, int score_CP)
        {
            // If Player one wins.
            if (score_PL1>score_CP)
            {
                Console.WriteLine("\n  ██▓███   ██▓    ▄▄▄     ▓██   ██▓▓█████  ██▀███      ▒█████   ███▄    █ ▓█████ ");
                Thread.Sleep(100);
                Console.WriteLine(" ▓██░  ██▒▓██▒   ▒████▄    ▒██  ██▒▓█   ▀ ▓██ ▒ ██▒   ▒██▒  ██▒ ██ ▀█   █ ▓█   ▀ ");
                Thread.Sleep(100);
                Console.WriteLine(" ▓██░ ██▓▒▒██░   ▒██  ▀█▄   ▒██ ██░▒███   ▓██ ░▄█ ▒   ▒██░  ██▒▓██  ▀█ ██▒▒███   ");
                Thread.Sleep(100);
                Console.WriteLine(" ▒██▄█▓▒ ▒▒██░   ░██▄▄▄▄██  ░ ▐██▓░▒▓█  ▄ ▒██▀▀█▄     ▒██   ██░▓██▒  ▐▌██▒▒▓█  ▄ ");
                Thread.Sleep(100);
                Console.WriteLine(" ▒██▒ ░  ░░██████▒▓█   ▓██▒ ░ ██▒▓░░▒████▒░██▓ ▒██▒   ░ ████▓▒░▒██░   ▓██░░▒████▒");
                Thread.Sleep(100);
                Console.WriteLine(" ▒▓▒░ ░  ░░ ▒░▓  ░▒▒   ▓▒█░  ██▒▒▒ ░░ ▒░ ░░ ▒▓ ░▒▓░   ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░░ ▒░ ░");
                Thread.Sleep(100);
                Console.WriteLine(" ░▒ ░     ░ ░ ▒  ░ ▒   ▒▒ ░▓██ ░▒░  ░ ░  ░  ░▒ ░ ▒░     ░ ▒ ▒░ ░ ░░   ░ ▒░ ░ ░  ░");
                Thread.Sleep(100);
                Console.WriteLine(" ░░         ░ ░    ░   ▒   ▒ ▒ ░░     ░     ░░   ░    ░ ░ ░ ▒     ░   ░ ░    ░   ");
                Thread.Sleep(100);
                Console.WriteLine("              ░  ░     ░  ░░ ░        ░  ░   ░            ░ ░           ░    ░  ░");
                Thread.Sleep(100);
                Console.WriteLine("                           ░ ░                                                   \n");
                Thread.Sleep(100);
                Console.WriteLine("\n\t\t  █     █░ ██▓ ███▄    █   ██████  ▐██▌");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ▓█░ █ ░█░▓██▒ ██ ▀█   █ ▒██    ▒  ▐██▌ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒░ ▓██▄    ▐██▌ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░█░ █ ░█ ░██░▓██▒  ▐▌██▒  ▒   ██▒ ▓██▒ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░░██▒██▓ ░██░▒██░   ▓██░▒██████▒▒ ▒▄▄  ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░ ░▀▀▒ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t   ▒ ░ ░   ▒ ░░ ░░   ░ ▒░░ ░▒  ░ ░ ░  ░ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t   ░   ░   ▒ ░   ░   ░ ░ ░  ░  ░      ░ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t      ░     ░           ░       ░   ░    ");
            }
            // If Player2 wins.
            else
            {
                Console.WriteLine("\n  ██▓███   ██▓    ▄▄▄     ▓██   ██▓▓█████  ██▀███     ▄▄▄█████▓ █     █░ ▒█████  ");
                Thread.Sleep(100);
                Console.WriteLine(" ▓██░  ██▒▓██▒   ▒████▄    ▒██  ██▒▓█   ▀ ▓██ ▒ ██▒   ▓  ██▒ ▓▒▓█░ █ ░█░▒██▒  ██▒");
                Thread.Sleep(100);
                Console.WriteLine(" ▓██░ ██▓▒▒██░   ▒██  ▀█▄   ▒██ ██░▒███   ▓██ ░▄█ ▒   ▒ ▓██░ ▒░▒█░ █ ░█ ▒██░  ██▒");
                Thread.Sleep(100);
                Console.WriteLine(" ▒██▄█▓▒ ▒▒██░   ░██▄▄▄▄██  ░ ▐██▓░▒▓█  ▄ ▒██▀▀█▄     ░ ▓██▓ ░ ░█░ █ ░█ ▒██   ██░");
                Thread.Sleep(100);
                Console.WriteLine(" ▒██▒ ░  ░░██████▒▓█   ▓██▒ ░ ██▒▓░░▒████▒░██▓ ▒██▒     ▒██▒ ░ ░░██▒██▓ ░ ████▓▒░");
                Thread.Sleep(100);
                Console.WriteLine(" ▒▓▒░ ░  ░░ ▒░▓  ░▒▒   ▓▒█░  ██▒▒▒ ░░ ▒░ ░░ ▒▓ ░▒▓░     ▒ ░░   ░ ▓░▒ ▒  ░ ▒░▒░▒░ ");
                Thread.Sleep(100);
                Console.WriteLine(" ░▒ ░     ░ ░ ▒  ░ ▒   ▒▒ ░▓██ ░▒░  ░ ░  ░  ░▒ ░ ▒░       ░      ▒ ░ ░    ░ ▒ ▒░ ");
                Thread.Sleep(100);
                Console.WriteLine(" ░░         ░ ░    ░   ▒   ▒ ▒ ░░     ░     ░░   ░      ░        ░   ░  ░ ░ ░ ▒  ");
                Thread.Sleep(100);
                Console.WriteLine("              ░  ░     ░  ░░ ░        ░  ░   ░                     ░        ░ ░  ");
                Thread.Sleep(100);
                Console.WriteLine("                           ░ ░                                                   \n");
                Thread.Sleep(100);
                Console.WriteLine("\n\t\t  █     █░ ██▓ ███▄    █   ██████  ▐██▌");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ▓█░ █ ░█░▓██▒ ██ ▀█   █ ▒██    ▒  ▐██▌ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒░ ▓██▄    ▐██▌ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░█░ █ ░█ ░██░▓██▒  ▐▌██▒  ▒   ██▒ ▓██▒ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░░██▒██▓ ░██░▒██░   ▓██░▒██████▒▒ ▒▄▄  ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t ░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░ ░▀▀▒ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t   ▒ ░ ░   ▒ ░░ ░░   ░ ▒░░ ░▒  ░ ░ ░  ░ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t   ░   ░   ▒ ░   ░   ░ ░ ░  ░  ░      ░ ");
                Thread.Sleep(100);
                Console.WriteLine("\t\t      ░     ░           ░       ░   ░    ");
            }
        }
#endregion
    }
}
