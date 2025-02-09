using System.Reflection.Metadata;

class Program {
    public static void Main(string[] args) {
        //Created a 2d array called Board to store board state in table format.
        string[,] Board = new string[8, 8];
        //max # of rows
        int rows = 8;
        //max nuber of columns
        int columns = 8; 
        //player variables to make detirming which symbol to use on game board simple.
        string player1 = "x";
        string player2 = "o";
        Console.WriteLine("Checkers Board:");

        Setupgame(Board, rows, columns, player1, player2);
        printBoard(Board, rows, columns);

        //loop to checks if player a player has won. If not keep playing. (remake this to call gameover inside to allow for game to be restarted)
        while (!GameOver(Board, rows, columns, player1, player2)) {
            PlayGame(Board, rows, columns, player1, player2);
        }
    }

    //function that will fill up the 2d array with an empty
    public static void Setupgame(string[,] Board, int rows, int columns, string player1, string player2) {
        //create new board to be printed by create board
        for (var i = 0; i < rows; i++) {
            for (var o = 0; o < columns; o++) {
                //Console.WriteLine(o);
                if (i == 0 && o%2 == 1){
                    Board[i,o] = "O";
                }  
                else if (i == rows - 1 && o%2 != 1){
                    Board[i,o] = "x";
                }
                else {
                    Board[i,o] = ".";
                }
            }
        }
    }

    //function that will take in 2 int varibles to print the tic tac toe board. Should allow for the board to be scaled to any size if I have the time for that.
    public static void printBoard(string[,] Board, int rows, int columns) {
        //print board with player changes
        for (var i = 0; i < rows; i++) {
            for (var o = 0; o < columns; o++) {
                Console.Write(Board[i,o]);
            }
            Console.WriteLine();
        }
    }

    //function that will take in all needed info & use call functions needed to run the game loop
    public static void PlayGame(string[,] Board, int rows, int columns, string player1, string player2) {
        //get player 1 turn, print their change. Then do that for player 2.
        SetPosition(Board, player1, player2);
        printBoard(Board, rows, columns);
        SetPosition(Board, player2, player1);
        printBoard(Board, rows, columns);
    }

    //function that will ask the current play the index of the row & colomn of the spot they want to pick & set that spot to their symbol
    public static void SetPosition(string[,] Board, string player, string other_player) {
        bool turn = true;
        
        //Get row & column indexs of spot they want to pick
        Console.WriteLine("please pick the pick you want to move");
        Console.WriteLine($"player {player} choose a row (1-8):");
        int playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"player {player} choose a column (1-8):");
        int playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
        //use row index & column index in 2d array to change player choose spot on board to player symbol
        while (turn == true) {
            if (player == "o")
                //check if player picked a spot with their piece
                if (Board[playerRow, playerColumn] == player) {
                    Board[playerRow, playerColumn] = ".";
                    //check if player can take a piece
                    if (((Board[playerRow + 1, playerColumn + 1] == other_player) 
                    && (Board[playerRow + 2, playerColumn + 2] == "."))
                    || ((Board[playerRow + 1, playerColumn - 1] == other_player) 
                    && (Board[playerRow + 2, playerColumn - 2] == "."))) {

                        Console.WriteLine("You can take a piece!");
                        Console.WriteLine("would you like to move left or right? l/r");
                        string move;
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        move = Console.ReadLine();
                        if (move == "l") {
                            Board[playerRow + 1, playerColumn - 1] = ".";
                            Board[playerRow + 2, playerColumn - 2] = player;
                        }
                        else {
                            Board[playerRow + 1, playerColumn - 1] = ".";
                            Board[playerRow + 2, playerColumn - 2] = player;
                        }
                    }
                    else {
                        Console.WriteLine("would you like to move left or right? l/r");
                        string move;
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        move = Console.ReadLine();
                        if (move == "l") {
                            Board[playerRow + 1, playerColumn - 1] = player;
                        }
                        else {
                            Board[playerRow + 1, playerColumn - 1] = player;
                        }
                        turn = false;
                    }
                }
                else {
                    Console.WriteLine("error, that is not your space");
                    //Get row & column indexs of spot they want to pick
                    Console.WriteLine("please pick the pick you want to move");
                    Console.WriteLine($"player {player} choose a row (1-8):");
                    playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine($"player {player} choose a column (1-8):");
                    playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
                }
            else {
                //check if player picked a spot with their piece
                if (Board[playerRow, playerColumn] == player) {
                    Board[playerRow, playerColumn] = ".";
                    //check if player can take a piece
                    if (((Board[playerRow - 1, playerColumn + 1] == other_player) 
                    && (Board[playerRow - 2, playerColumn + 2] == "."))
                    || ((Board[playerRow - 1, playerColumn - 1] == other_player) 
                    && (Board[playerRow - 2, playerColumn - 2] == "."))) {

                        Console.WriteLine("You can take a piece!");
                        Console.WriteLine("would you like to move left or right? l/r");
                        string move;
                        move = Console.ReadLine();
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        if (move == "l") {
                            Board[playerRow - 1, playerColumn - 1] = ".";
                            Board[playerRow - 2, playerColumn - 2] = player;
                        }
                        else {
                            Board[playerRow - 1, playerColumn - 1] = ".";
                            Board[playerRow - 2, playerColumn - 2] = player;
                        }
                    }
                    else {
                        Console.WriteLine("would you like to move left or right? l/r");
                        string move;
                        move = Console.ReadLine();
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        if (move == "l") {
                            Board[playerRow - 1, playerColumn - 1] = player;

                        }
                        else {
                            Board[playerRow - 1, playerColumn - 1] = player;
                        }
                        turn = false;
                    }
                }
                else {
                    Console.WriteLine("error, that is not your space");
                    Console.WriteLine("please pick the pick you want to move");
                    Console.WriteLine($"player {player} choose a row (1-8):");
                    playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine($"player {player} choose a column (1-8):");
                    playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
                }
            }
        }
    }

    //function that will read game board & check all posibles areas to see if a player is no longer on the board.    
    public static bool GameOver(string[,] Board, int rows, int columns, string player, string other_player) {
        //counter varibles that increase if player is still on board
        int x_on_board = 0;
        int o_on_board = 0;
        //loop through board
        for (var i = 0; i < rows; i++) {
            for (var o = 0; o < columns; o++) {
                if (Board[i,o] == "x") {
                    x_on_board += 1;
                }
                if (Board[i,o] == "o") {
                    o_on_board += 1;
                }
            }
        }
        //check if a player is no longer on the board and say the winner
        if (x_on_board == 0 && o_on_board == 0) {
            if (x_on_board == 0) {
                Console.WriteLine($"player 2 wins!");
            }
            else {
                Console.WriteLine($"player 1 wins!");
            }
            //end game
            return true;
        }
        else {
            return false;
        }
    }
}