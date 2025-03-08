using Microsoft.VisualBasic;

class Game_board {
    private int _playergame;
    private int _rows;
    private int _columns; 
    private string _player1;
    private string _player2;
    private string[,] _Board;
    public Game_board() {
        _playergame = 1;
        _rows = 0;
        _columns = 0;
        _player1 = "x";
        _player2 = "o";
    }
    public int Set_up() {
        Console.WriteLine("Please chose a game and input the number of the game you wish to play");
        Console.WriteLine("1: tic tack toe");
        Console.WriteLine("2: Checkers");
        Console.WriteLine("3: chess");
        _playergame = Convert.ToInt32(Console.ReadLine());
        if (_playergame == 1){
            //vars to be filled when game is picked
            _player1 = "x";
            _player2 = "o";
            _rows = 3;
            _columns = 3; 
            //Created a 2d array called Board to store board state in table format.
            _Board = new string[_rows, _columns];
            for (var i = 0; i < _rows; i++) {
                for (var o = 0; o < _columns; o++) {
                    _Board[i,o] = ".";
                }
            }
            return _playergame;
        }
        else  if(_playergame == 2){
            //vars to be filled when game is picked
            _player1 = "x";
            _player2 = "o";
            _rows = 8;
            _columns = 8; 
            //Created a 2d array called Board to store board state in table format.
            _Board = new string[_rows, _columns];
            for (var i = 0; i < _rows; i++) {
                for (var o = 0; o < _columns; o++) {
                    //Console.WriteLine(o);
                    if (i == 0 && o%2 == 1){
                        _Board[i,o] = "O";
                    }  
                    else if (i == _rows - 1 && o%2 != 1){
                        _Board[i,o] = "x";
                    }
                    else {
                        _Board[i,o] = ".";
                    }
                }
            }
            return _playergame;
        }
        else  if(_playergame == 3){
            //vars to be filled when game is picked
            _player1 = "1";
            _player2 = "2";
            _rows = 8;
            _columns = 8; 
            //Created a 2d array called Board to store board state in table format.
            _Board = new string[_rows, _columns];
            return _playergame;
        }
        else {
            return _playergame;
        }
    }
    
    //function that will take in 2 int varibles to print theboard.
    public void printBoard() {
        //print board with player changes
        for (var i = 0; i < _rows; i++) {
            for (var o = 0; o < _columns; o++) {
                Console.Write(_Board[i,o]);
            }
            Console.WriteLine();
        }
    }
    public string[,] return_Board() {
        return _Board;
    }
    public int return_rows() {
        return _rows;
    }
    public int return_columns() {
        return _columns;
    }
    public string return_player() {
        return _player1;
    }
    public string return_other_player() {
        return _player2;
    }
    
}