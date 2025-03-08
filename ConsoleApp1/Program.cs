using System.Linq.Expressions;
using System.Reflection.Metadata;

class Program {
    public static void Main(string[] args) {
        Game_board game_Board = new Game_board();
        int playergame = game_Board.Set_up();
        PlayGame(game_Board, playergame);

    }

    

    //function that will handle all needed info loops & call classes needed to run game loop for chosen game
    public static void PlayGame(Game_board game_Board, int playergame) {
        string[,] Board = game_Board.return_Board();
        int rows = game_Board.return_rows();
        int columns = game_Board.return_columns();
        string player = game_Board.return_player();
        string other_player = game_Board.return_other_player();

        if (playergame == 1) {
            Tic_tac_toe_movement_system tic_Tac_Toe_Movement_System = new Tic_tac_toe_movement_system(Board,rows,columns,player,other_player);
            game_Board.printBoard();
            while (true) {
                tic_Tac_Toe_Movement_System.tic_tac_toe_movement(player);
                game_Board.printBoard();
                if (tic_Tac_Toe_Movement_System.GameOver() == true) {
                    break;
                }
                tic_Tac_Toe_Movement_System.tic_tac_toe_movement(other_player);
                game_Board.printBoard();
                if (tic_Tac_Toe_Movement_System.GameOver() == true) {
                    break;
                }
            }
        }
        // else if (playergame == 2) {              //Other game types. Commented out due to them not being finished & not letting the program run due to errors
        //     Checkers_movement_system checkers_Movement_System = new Checkers_movement_system();
        //     game_Board.printBoard();
            
        // }
        // else {
        //     Chess_movement_system chess_Movement_System = new Chess_movement_system();
        //     game_Board.printBoard(); 
        // }
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