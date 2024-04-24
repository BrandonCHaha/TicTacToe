namespace TicTacToe {
    internal class Program {
        static void Main(string[] args) {

            bool tieBroke = false;

            while (tieBroke == false) {

                    string[,] board = NewBoard();
                    int xLoc      =  0;
                    int yLoc      =  0;
                    int turn      =  1;
                    bool gameOver    =  false;
                    bool isValid     =  false;

                while (gameOver == false) {


                    while (isValid == false) {
                        DrawBoard(board);

                        Console.WriteLine("\n\t\tP-1 (X)");
                        xLoc = PromptInt("\nX-location: ");
                        yLoc = PromptInt("\nY-location: ");

                        if (xLoc > 3 || yLoc > 3 || xLoc < 1 || yLoc < 1) {
                            Console.WriteLine("Please enter a dimension within the bounds of the board.");
                        } else if (PlaceMarker(board, "X", xLoc, yLoc) == true) {
                            isValid = true;
                        } else {
                            Console.WriteLine("Please input a (x, y) location that isn't taken.");
                        }//END PLACE VALIDATION

                    }//END PLAYER 1 VALIDATION

                    if (WinCheck(board, turn) == 1) {
                        DrawBoard(board);
                        Console.WriteLine("Player 1 Wins!!!");
                        isValid  = true;
                        tieBroke = true;
                        gameOver = true;

                    } else if (WinCheck(board, turn) == 0) {
                        DrawBoard(board);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**STALEMATE** INITIALIZING ROUND 2");
                        Thread.Sleep(1000);
                        isValid = true;
                        gameOver = true;

                    } else {
                        turn++;
                        isValid = false;
                    }//END WINCHECK 1

                    while (isValid == false) {
                        DrawBoard(board);

                        Console.WriteLine("\n\t\tP-2 (O)");
                        xLoc = PromptInt("\nX-location: ");
                        yLoc = PromptInt("\nY-location: ");

                        if (xLoc > 3 || yLoc > 3 || xLoc < 1 || yLoc < 1) {
                            Console.WriteLine("Please enter a dimension within the bounds of the board.");
                        } else if (PlaceMarker(board, "O", xLoc, yLoc) == true) {
                            isValid = true;
                        } else {
                            Console.WriteLine("Please input a (x, y) location that isn't taken.");
                        }//END PLACE VALIDATION

                    }//END PLAYER 2 VALIDATION

                    if (WinCheck(board, turn) == 2) {
                        DrawBoard(board);
                        Console.WriteLine("Player 2 Wins!!!");
                        isValid = true;
                        tieBroke = true;
                        gameOver = true;
                    } else if (WinCheck(board, turn) == 0) {
                        DrawBoard(board);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**STALEMATE** INITIALIZING ROUND 2");
                        Thread.Sleep(2000);
                        isValid = true;
                        gameOver = true;
                    } else {
                        turn++;
                        isValid = false;
                    }//END WINCHECK 2

                }//END GAME LOOP
            }//END TIE BREAK LOOP



        }//END MAIN

        static bool PlaceMarker(string[,] board, string marker, int xLoc, int yLoc) {
            bool isEmpty = false;
            xLoc--;
            yLoc--;
            if (board[xLoc, yLoc] == "*") {
                board[xLoc, yLoc] = marker;
                isEmpty = true;
            }//END IF

            return isEmpty;
        }//END PLACE MARKER

        static void DrawBoard(string[,] board) {

            Console.Clear();
            /*for (int y = 0;  y < board.GetLength(0); y++) {
                Console.Write("\n\n\n\t");
                for (int x = 0; x < board.GetLength(1); x++) {
                    Console.Write($"\t{board[x, y]}");
                }
            }
            */
            Console.WriteLine($"\n\n\t\t         |         |       ");
            Console.WriteLine($"\t\t    {board[0,0]}    |    {board[1,0]}    |    {board[2,0]}    ");
            Console.WriteLine($"\t\t         |         |       ");
            Console.WriteLine($"\t\t---------|---------|--------");
            Console.WriteLine($"\t\t         |         |       ");
            Console.WriteLine($"\t\t    {board[0,1]}    |    {board[1,1]}    |    {board[2,1]}    ");
            Console.WriteLine($"\t\t         |         |       ");
            Console.WriteLine($"\t\t---------|---------|--------");
            Console.WriteLine($"\t\t         |         |       ");
            Console.WriteLine($"\t\t    {board[0,2]}    |    {board[1,2]}    |    {board[2,2]}    ");
            Console.WriteLine($"\t\t         |         |       ");
            Console.WriteLine("\n");

        }//END DRAW FUNCTION

        static int WinCheck(string[,] board, int turn) {
            int result = 3;

            for (int y = 0; y < board.GetLength(1); y++) {
                if (board[0, y] == "X" && board[1, y] == "X" && board[2, y] == "X") {
                    result = 1;
                }
            }// END "X", X WIN CHECK

            for (int x = 0; x < board.GetLength(0); x++) {
                if (board[x, 0] == "X" && board[x, 1] == "X" && board[x, 2] == "X") {
                    result = 1;
                }
            }//END "X", Y WIN CHECK

            if (board[0, 0] == "X" && board[1, 1] == "X" && board[2, 2] == "X") {
                result = 1;
            } if (board[2, 0] == "X" && board[1, 1] == "X" && board[0, 2] == "X") {
                result = 1;
            }//END "X", DIAGONAL WIN CHECK

            for (int y = 0; y < board.GetLength(1); y++) {
                if (board[0, y] == "O" && board[1, y] == "O" && board[2, y] == "O") {
                    result = 2;
                }
            }// END "O", X WIN CHECK

            for (int x = 0; x < board.GetLength(0); x++) {
                if (board[x, 0] == "O" && board[x, 1] == "O" && board[x, 2] == "O") {
                    result = 2;
                }
            }//END "O", Y WIN CHECK

            if (board[0, 0] == "O" && board[1, 1] == "O" && board[2, 2] == "O") {
                result = 2;
            }
            if (board[2, 0] == "O" && board[1, 1] == "O" && board[0, 2] == "O") {
                result = 2;
            }//END "O", DIAGONAL WIN CHECK

            if (turn == 9) { result = 0; }

            return result;
        }//END WIN CHECK

        static string[,] NewBoard() {

            string[,] board = new string[3, 3];

            for (int y = 0; y < board.GetLength(0); y++) {
                for (int x = 0; x < board.GetLength(1); x++) {
                    board[x, y] = "*";
                }
            }

            return board;
        }//END NEW BOARD

        #region HELPER FUNCTIONS
        static void Fancify(string text) {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("**##=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=##**");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t--->>\\{text}/<<---");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("**##=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=##**");

            Console.ResetColor();

        }//END FANCIFY
        static string Prompt(string request) {
            //Variables
            string userInput = "";

            //Request Information From User
            Console.Write(request);

            //Receive Response
            userInput = Console.ReadLine();

            return userInput;

        }//END PROMPT HELPER
        static int PromptInt(string request) {

            int userInput = 0;
            bool isValid = false;

            Console.Write(request);
            isValid = int.TryParse(Console.ReadLine(), out userInput);

            while (isValid == false) {

                Console.WriteLine("ERROR: NO REAL NUMBER");
                Console.Write(request);
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            }//END WHILE

            return userInput;

        }//END PROMPT TRY INT
        static double PromptDouble(string request) {

            double userInput = 0;
            bool isValid = false;

            Console.Write(request);
            isValid = double.TryParse(Console.ReadLine(), out userInput);

            while (isValid == false) {

                Console.WriteLine("ERROR: NO REAL NUMBER");
                Console.Write(request);
                isValid = double.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;

        }//END PROMPT DOUBLE
        #endregion
    }//END CLASS
}//END NAMESPACE
