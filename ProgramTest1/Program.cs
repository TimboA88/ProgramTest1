using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace Program
{
    public class TicTacToe
    {
        // Just to create an empty space for the board
        public static string slot = "-";
        // The list containing all slots for the board
        public static List<String> slots = new List<string>();
        // Bool for if the game is over or not.
        public static bool GameOver = false;
        public static bool Stalemate = false;
        // A string to determine whos turn is it
        public static string playerTurn = "x";
        
        public static void Main()
        {
            CreateList();
            DrawScreen();
            while (!GameOver)
            {
                PlayerTurn(playerTurn);
                FlipPlayer();
                CheckVictory();
            }
            if (!Stalemate)
            {
                FlipPlayer();
                Console.WriteLine("Player " + playerTurn + " wins!");
            }
            else
            {
                Console.WriteLine("Stalemate, no one wins.");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        // Adds 9 items to the list.
        public static void CreateList()
        {
            for (int i = 0; i < 9; i++)
            {
                slots.Add(slot);
            }
        }
        
        // Draws the board
        public static void DrawScreen()
        {
            int counter = 0;
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(slots[counter] + "|" + slots[counter + 1] + "|" + slots[counter + 2]);
                counter = counter + 3;
            }
        }
        public static void PlayerTurn(string turn)
        {
            //TODO: Check if Valid Function and Loop
            // Varriables
            ConsoleKeyInfo cki;
            int inputed;

        
            // Player Input
            Console.WriteLine("Player " + turn + "'s turn");
            cki = Console.ReadKey();

            // Try to parse
            try
            {
                int.Parse(cki.KeyChar.ToString());
            }
            catch
            {
                Console.WriteLine("Invalid Key Pressed, press key 1-9");
                PlayerTurn(turn);
                return;
            }
            // Converts the Player Input to an Int to lookup an item in the list
            inputed = int.Parse(cki.KeyChar.ToString());
            // check if the slot is valid, also make sure the selected is not 0
            if (inputed == 0 | !(slots[inputed - 1] == "-"))
            {
                Console.WriteLine("Invalid Key Pressed, press key 1-9");
                PlayerTurn(turn);
                return;
            }

            //replaces the inputed item with an X.
            slots[inputed - 1] = turn;
            DrawScreen();
        }
        // Flip which players turn it is.
        public static void FlipPlayer()
        {
            if (playerTurn == "x")
            {
                playerTurn = "o";
            }
            else if (playerTurn == "o")
            {
                playerTurn = "x";
            }
        }
        // Checks the current board for a possible victory
        public static void CheckVictory()
        {
            // Check TL to BR Cross
            if ((slots[0] == slots[4] && slots[0] == slots[8]) && !(slots[0] == "-"))
            {
                GameOver = true;
            }
            
            // Check TR to BL Cross
            else if ((slots[2] == slots[4] && slots[2] == slots[6]) && !(slots[2] == "-"))
            {
                GameOver = true;
            }
           
            // Check Horizontal Lines
            else if (CheckHorizontal())
            {
                GameOver = true;
            }
            
            // Check Veritcal Lines
            else if (CheckVertical())
            {
                GameOver = true;
            }
            // Checks if any slot is still open
            else if (CheckStaleMate())
            {
                GameOver = true;
                Stalemate = true;
            }
            
        }
        public static bool CheckHorizontal()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((slots[i * 3] == slots[i * 3 + 1] && slots[i * 3] == slots[i * 3 + 2]) && !(slots[i * 3] == "-"))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckVertical()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((slots[i] == slots[i + 3] && slots[i] == slots[i + 6]) && !(slots[i] == "-"))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckStaleMate()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i] == "-")
                {
                    return false;
                }
            }
            return true;
        }
    }

}