class Basic_movement_system {
    protected string[,] _Board;
    protected int _rows;
    protected int _columns;
    protected string _player;
    public Basic_movement_system(string[,] Board, int rows, int columns, string player) {
        _Board = Board;
        _rows = rows;
        _columns = columns;
        _player = player;
    }

    public virtual void standard_move_pick() {
        Console.WriteLine("please pick the place you want to move");
        Console.WriteLine($"player {_player} choose a row (1-{_rows}):");
        int _playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"player {_player} choose a column (1-{_columns}):");
        int _playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
    }
    public virtual bool Valid_move_checker () {
        return false;
    }
    public virtual bool GameOver() {
        return false;
    }
     
}