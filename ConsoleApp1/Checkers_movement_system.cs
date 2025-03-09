class Checkers_movement_system : Basic_movement_system {
    public Checkers_movement_system(string[,] Board, int rows, int columns, string player) : base(Board, rows, columns, player) {

    }
    //Main function to handle movement & call other functions relating to movement
    public void checkers_movement(string current_player) {
        standard_move_pick();
        Console.WriteLine($"{_playerRow}, {_playerColumn}");
        if (current_player == "x") {
            if (_Board[_playerRow, _playerColumn] == "X"){
                Queen_move(current_player);
            }
            else {
                move_up(current_player);
            }
        }
        else {
            if (_Board[_playerRow, _playerColumn] == "O"){
                Queen_move(current_player);
            }
            else {
                move_down(current_player);
            } 
        }
            
            

    }
    private void move_up(string current_player){
        Console.WriteLine("would you like to move left or right? l/r: ");
            string? move = Console.ReadLine();
            //Console.WriteLine($"{_playerRow}, {_playerColumn}");
        try {
            if (move == "l") {
                if (_Board[_playerRow - 1, _playerColumn - 1] != "." && _Board[_playerRow - 2, _playerColumn - 2] == ".") {
                    _Board[_playerRow - 2, _playerColumn - 2] = current_player;
                    _Board[_playerRow - 1, _playerColumn - 1] = ".";
                }
                else {
                    _Board[_playerRow - 1, _playerColumn - 1] = current_player;
                } 
            }
            else {
                if (_Board[_playerRow - 1, _playerColumn + 1] != "." && _Board[_playerRow - 2, _playerColumn + 2] == ".") {
                    _Board[_playerRow - 2, _playerColumn + 2] = current_player;
                    _Board[_playerRow - 1, _playerColumn + 1] = ".";
                }
                else {
                    _Board[_playerRow - 1, _playerColumn + 1] = current_player;
                }
            }
            _Board[_playerRow, _playerColumn] = ".";
        }
        catch{
            try {
                if (move == "l") {
                    _Board[_playerRow - 1, _playerColumn - 1] = current_player;
                }
                else {
                    _Board[_playerRow - 1, _playerColumn + 1] = current_player;
                }
                _Board[_playerRow, _playerColumn] = ".";
            }
            catch {
                Console.WriteLine("error, move not avaible");
                checkers_movement(current_player);
            }
        }
    }
    private void move_down(string current_player){
        Console.WriteLine("would you like to move left or right? l/r: ");
            string? move = Console.ReadLine();
            Console.WriteLine($"{_playerRow}, {_playerColumn}");
        try {
            if (move == "l") {
                if (_Board[_playerRow + 1, _playerColumn - 1] != "." && _Board[_playerRow - 2, _playerColumn - 2] == ".") {
                    _Board[_playerRow + 2, _playerColumn - 2] = current_player;
                    _Board[_playerRow + 1, _playerColumn - 1] = ".";
                }
                else {
                    _Board[_playerRow + 1, _playerColumn - 1] = current_player;
                } 
            }
            else {
                if (_Board[_playerRow + 1, _playerColumn + 1] != "." && _Board[_playerRow - 2, _playerColumn + 2] == ".") {
                    _Board[_playerRow + 2, _playerColumn + 2] = current_player;
                    _Board[_playerRow + 1, _playerColumn + 1] = ".";
                }
                else {
                    _Board[_playerRow + 1, _playerColumn + 1] = current_player;
                }
            }
            _Board[_playerRow, _playerColumn] = ".";
        }
        catch{
            try {
                if (move == "l") {
                    _Board[_playerRow + 1, _playerColumn - 1] = current_player;
                }
                else {
                    _Board[_playerRow + 1, _playerColumn + 1] = current_player;
                }
                _Board[_playerRow, _playerColumn] = ".";
            }
            catch {
                Console.WriteLine("error, move not avaible");
                checkers_movement(current_player);
            }
        }
    }
    private static void Queen_move(string current_player){

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