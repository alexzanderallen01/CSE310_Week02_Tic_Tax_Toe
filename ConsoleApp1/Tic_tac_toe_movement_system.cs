class Tic_tac_toe_movement_system : Basic_movement_system {
    private string _other_player;
    public Tic_tac_toe_movement_system(string other_player) : Basic_movement_system(string[,] Board, int rows, int columns, string player) {
        _other_player = other_player;

    }
    public override void standard_move_pick() {
        Console.WriteLine($"please pick where to place your {_player}");
        Console.WriteLine($"Choose a row (1-{_rows}):");
        int _playerRow = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine($"Choose a column (1-{_columns}):");
        int _playerColumn = Convert.ToInt32(Console.ReadLine()) - 1;
    }
    public static void tic_tac_toe_movement() {
        standard_move_pick();
        if (_Board[_playerRow, _playerColumn] != ".") {
            _Board[_playerRow, _playerColumn] = _player;
        }
        else {
            Console.WriteLine("error. That spot is taken");
            tic_tac_toe_movement();
        }
        
    }
    //function that will read game board & check all posibles areas to see if a player has won.
    public override bool GameOver()
    {
        //every variable need to check every winniable area by pulling all indexes that would effect that area of win.
        string TopRow = _Board[0, 0] + _Board[0, 1] + _Board[0, 2];
        string MiddleRow = _Board[1, 0] + _Board[1, 1] + _Board[1, 2];
        string BottomRow = _Board[2, 0] + _Board[2, 1] + _Board[2, 2];
        string FirstColomn = _Board[0, 0] + _Board[1, 0] + _Board[2, 0];
        string SecondColpmn = _Board[0, 1] + _Board[1, 1] + _Board[2, 1];
        string ThirdColomn = _Board[0, 2] + _Board[1, 2] + _Board[2, 2];
        string Diagon = _Board[0, 0] + _Board[1, 1] + _Board[2, 2];
        string OtherDiagon = _Board[0, 2] + _Board[1, 1] + _Board[2, 0];

        string playerWinCondition = _player + _player + _player;
        //Look to see if a cat has happened
        int open_space = 0;
        foreach (string i in _Board) {
            if (i == ".") {
                open_space += 1;
            }
        }
        //Check every spot a player can win to see if they have won
        if (TopRow == playerWinCondition || 
        MiddleRow == playerWinCondition || 
        BottomRow == playerWinCondition || 
        FirstColomn == playerWinCondition || 
        SecondColpmn == playerWinCondition || 
        ThirdColomn == playerWinCondition || 
        Diagon == playerWinCondition || 
        OtherDiagon == playerWinCondition) {
            Console.WriteLine($"player {_player} wins!");
            return true;
        }
        //end game if cat
        else if (open_space == 0) {
            Console.WriteLine($"Game Over. CAT");
            return true;
        }
        //Continue game
        else {
            return false;
        }
    }
}