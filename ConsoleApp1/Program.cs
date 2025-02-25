using System.Linq.Expressions;
using System.Reflection.Metadata;

class Program {
    public static void Main(string[] args) {
        Game_board game_Board = new Game_board();
        int playergame = game_Board.Set_up();
        PlayGame(game_Board, playergame);

        //OLD GAME LOOP. Remove once new classes handle game overs
        //loop to checks if player a player has won. If not keep playing. (remake this to call gameover inside to allow for game to be restarted)
        // while (!GameOver(Board, rows, columns, player1, player2)) {
        //     PlayGame(Board, rows, columns, player1, player2);
        // }
    }

    

    //function that will handle all needed info loops & call classes needed to run game loop for chosen game
    public static void PlayGame(Game_board game_Board, int playergame) {
        if (playergame == 1) {
            Tic_tac_toe_movement_system tic_Tac_Toe_Movement_System = new Tic_tac_toe_movement_system();
            game_Board.printBoard();
        }
        else if (playergame == 2) {
            Checkers_movement_system checkers_Movement_System = new Checkers_movement_system();
            game_Board.printBoard();
            
        }
        else {
            Chess_movement_system chess_Movement_System = new Chess_movement_system();
            game_Board.printBoard();
            
        }
        //OLD TURN SYSTEM. Example only. Remove after PlayGame fully works
        //get player 1 turn, print their change. Then do that for player 2.
        // SetPosition(Board, player1, player2, rows, columns);
        // printBoard(Board, rows, columns);
        // SetPosition(Board, player2, player1, rows, columns);
        // printBoard(Board, rows, columns);
    }
    //OLD CHECKERS MOVEMENT SYSTEM. DO NOT USE. remove after new movement class is done.
    //function that will ask the current play the index of the row & colomn of the spot they want to pick & set that spot to their symbol
    public static void SetPosition(string[,] Board, string player, string other_player, int rows, int columns) {
        bool turn = true;
        
        //Get row & column indexs of spot they want to pick
        Console.WriteLine("please pick the pick you want to move");
        Console.WriteLine($"player {player} choose a row (1-{rows}):");
        int playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"player {player} choose a column (1-{columns}):");
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
                        Console.WriteLine("would you like to move left or right? l/r: ");
                        
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        string? move = Console.ReadLine();
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
                        //use row index & column index in 2d array to change player choose spot on board to player symbol
                        string? move = Console.ReadLine();
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
                        string? move = Console.ReadLine();
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
                        string? move = Console.ReadLine();
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
}