class Basic_movement_system {
    protected string[,] _Board;
    protected int _rows;
    protected int _columns;
    protected string _player;
    protected int _playerRow;
    protected int _playerColumn;
    public Basic_movement_system(string[,] Board, int rows, int columns, string player) {
        _Board = Board;
        _rows = rows;
        _columns = columns;
        _player = player;
    }

    public virtual void standard_move_pick() {
        Console.WriteLine("please pick the piece you want to move");
        Console.WriteLine($"player {_player} choose a row (1-{_rows}):");
        _playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"player {_player} choose a column (1-{_columns}):");
        _playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
        //Console.WriteLine($"in picker: {_playerRow}, {_playerColumn}");
    }
    public virtual bool Valid_move_checker () {
        return false;
    }
    public virtual bool GameOver() {
        return false;
    }
    public void printBoard() {
        //print board with player changes
        for (int j = 0; j <= _rows; j++){
            Console.Write(j);
        }
        Console.WriteLine();
        for (var i = 0; i < _rows; i++) {
            for (var o = 0; o < _columns; o++) {
                
                if (o == 0){
                    Console.Write(i+1);
                    Console.Write(_Board[i,o]);
                }
                else {
                    Console.Write(_Board[i,o]);
                }
            }
            Console.WriteLine();
        }
    }
     
}