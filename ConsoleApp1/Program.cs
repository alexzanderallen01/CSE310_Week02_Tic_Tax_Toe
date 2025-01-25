class Program {
    public static void Main(string[] args) {
        //Created a 2d array called Board to store board state in table format.
        string[,] Board = new string[3, 3];
        //max # of rows
        int rows = 3;
        //max nuber of columns
        int columns = 3; 
        //player variables to make detirming which symbol to use on game board simple.
        string player1 = "x";
        string player2 = "o";
        Console.WriteLine("Tic Tac Toe Board:");

        Setupgame(Board, rows, columns, player1, player2);
        printBoard(Board, rows, columns);

        //loop to checks if player a player has won. If not keep playing. (remake this to call gameover inside to allow for game to be restarted)
        while (!GameOver(Board, player1) && !GameOver(Board, player2)) {
            PlayGame(Board, rows, columns, player1, player2);
        }
    }

    //function that will fill up the 2d array with an empty
    public static void Setupgame(string[,] Board, int rows, int columns, string player1, string player2) {
        //create out empty board to be printed by create board
        for (var i = 0; i < rows; i++) {
            for (var o = 0; o < columns; o++) {
                Board[i,o] = ".";
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
        SetPosition(Board, player1);
        printBoard(Board, rows, columns);
        SetPosition(Board, player2);
        printBoard(Board, rows, columns);
    }

    //function that will ask the current play the index of the row & colomn of the spot they want to pick & set that spot to their symbol
    public static void SetPosition(string[,] Board, string player) {
        //Get row & column indexs of spot they want to pick
        Console.WriteLine($"player {player} choose a row (1-3):");
        int playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"player {player} choose a column (1-3):");
        int playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
        //use row index & column index in 2d array to change player choose spot on board to player symbol
        Board[playerRow, playerColumn] = player;
    }

    //function that will read game board & check all posibles areas to see if a player has won.
    //currently does not work for game over "cat". Need to re make this to take in both players & check if there is no more "." on the game board
    public static bool GameOver(string[,] Board, string player) {
        //every variable need to check every winniable area by pulling all indexes that would effect that area of win.
        string TopRow = Board[0, 0] + Board[0, 1] + Board[0, 2];
        string MiddleRow = Board[1, 0] + Board[1, 1] + Board[1, 2];
        string BottomRow = Board[2, 0] + Board[2, 1] + Board[2, 2];
        string FirstColomn = Board[0, 0] + Board[1, 0] + Board[2, 0];
        string SecondColpmn = Board[0, 1] + Board[1, 1] + Board[2, 1];
        string ThirdColomn = Board[0, 2] + Board[1, 2] + Board[2, 2];
        string Diagon = Board[0, 0] + Board[1, 1] + Board[2, 2];
        string OtherDiagon = Board[0, 2] + Board[1, 1] + Board[2, 0];

        string playerWinCondition = player + player + player;

        //Check every spot a player can win to see if they have won
        if (TopRow == playerWinCondition || 
        MiddleRow == playerWinCondition || 
        BottomRow == playerWinCondition || 
        FirstColomn == playerWinCondition || 
        SecondColpmn == playerWinCondition || 
        ThirdColomn == playerWinCondition || 
        Diagon == playerWinCondition || 
        OtherDiagon == playerWinCondition) {
            if (player == "x") {
                Console.WriteLine($"player 1 wins!");
            }
            else {
                Console.WriteLine($"player 2 wins!");
            }
            
            return true;
        }
        else {
            return false;
        }
    }
}