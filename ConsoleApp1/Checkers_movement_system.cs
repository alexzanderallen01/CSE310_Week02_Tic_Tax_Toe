class Checkers_movement_system : Basic_movement_system {
    public Checkers_movement_system() : Basic_movement_system(string[,] Board, int rows, int columns, string player) {

    }
    public static void checkers_movement() {

    }
    //function that will read game board & check all posibles areas to see if a player is no longer on the board.  
    public override bool GameOver() {
        int x_on_board = 0;
        int o_on_board = 0;
        //loop through board & count x & o
        for (var i = 0; i < _rows; i++) {
            for (var o = 0; o < _columns; o++) {
                if (_Board[i,o] == "x") {
                    x_on_board += 1;
                }
                if (_Board[i,o] == "o") {
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