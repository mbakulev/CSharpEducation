namespace TicTacToe;

class Program
{
	public string xWin = "X Win";
	public string oWin = "O Win";
	public int firstIndex = 0;
	public int lastIndex = 2;

	public string rulesCoordinates = "Нужно ввести данные в правильном формате  \"x y\"";

    static void ShowBoard(ref char[,] array)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(array[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    static bool CheckVictory(char[,] array)
    {
        for (int i = 0; i < 3; i++)
        {
            if (array[i, 0] == array[i, 1] && array[i, 1] == array[i, 2] && array[i, 2] == 'X')
            {
                Console.WriteLine(xWin);
                return true;
            }

            if (array[i, 0] == array[i, 1] && array[i, 1] == array[i, 2] && array[i, 2] == 'O')
            {
                Console.WriteLine(oWin);
                return true;
            }
    
            if (array[0, i] == array[1, i] && array[1, i] == array[2, i] && array[2, i] == 'X')
            {
                Console.WriteLine(xWin);
                return true;
            }

            if (array[0, i] == array[1, i] && array[1, i] == array[2, i] && array[2, i] == 'O')
            {
                Console.WriteLine(oWin);
                return true;
            }
        }

        if (array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2] && array[2, 2] == 'X')
        {
            Console.WriteLine(xWin);
            return true;
        }

        if (array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2] && array[2, 2] == 'O')
        {
            Console.WriteLine(oWin);
            return true;
        }

        if (array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0] && array[2, 0] == 'X')
        {
            Console.WriteLine(xWin);
            return true;
        }

        if (array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0] && array[2, 0] == 'O')
        {
            Console.WriteLine(oWin);
            return true;
        }

        return false;
    }
    
    // Если нельзя делать ход, то возвращает false. Если ход можно делать то true
    static bool IsMoveAble(ref char[,] array, int x, int y)
    {
        Console.WriteLine(x + " " + y + " ");
        if ((x < 0 || x > 2) || (y < 0 || y > 2)) return false;
        return array[x, y] == '_' ? true : false;
    }
    
    // Если не сделан ход, то возвращает false. Если ход сделан то true
    static bool MakeMove(ref char[,] array, int x, int y, char symbol)
    {
        if (IsMoveAble(ref array, x, y))
        {
            array[x, y] = symbol;
            return true;
        }

        return false;
    }
    
    static void InputMoveCoordinates(out int x, out int y)
    {
        
        string coordinateString = null;
        bool isCoordinatesCorrect = true;
        string[] corrdinates;
        x = -1;
        y = -1;
        while(true)
        {
            Console.WriteLine("Введи ход в формате \"x y\"");
            coordinateString = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(coordinateString))
            {
                Console.WriteLine(rulesCoordinates);
                continue;
            }
            
            corrdinates = coordinateString.Split(' ');
            if (corrdinates.Length != 2)
            {
                Console.WriteLine(rulesCoordinates);
                continue;
            }
            
            Console.WriteLine($"Координаты хода: x = {x}, y = {y}");

            x = int.Parse(corrdinates[0]);
            y = int.Parse(corrdinates[1]);
            
            if (x < firstIndex || x > lastIndex || y < firstIndex || y > lastIndex)
            {
                Console.WriteLine("Координаты должны быть в диапазоне от 0 до 2.");
                continue;
            }
            
            break;
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Привет. Это игра крестики нолики!");
        
        string playerOne = "X";
        string playerTwo = "Y";
        
        while (playerOne == null || playerOne == "")
        {
            Console.WriteLine("Введи имя первого игрока");
            playerOne = Console.ReadLine();
        }
        
        while (playerTwo == null || playerTwo == "")
        {
            Console.WriteLine("Введи имя второго игрока");
            playerTwo = Console.ReadLine();
        }
        
        Console.WriteLine("Игрок 1 = " + playerOne);
        Console.WriteLine("Игрок 2 = " + playerTwo);
        
        // Очередность хода. true - первый, false - второй
        bool order = true;
        char xSymbol = 'X';
        char oSymbol = 'O';
        byte turnNumber = 0;
        bool isGameFinished = false;
        bool isTurnFinished = false;
        char[,] board = new char[3, 3]
        {
            { '_', '_', '_' },
            { '_', '_', '_' },
            { '_', '_', '_' }
        };
        
        while (!isGameFinished && turnNumber < 9)
        {
            if (order) Console.WriteLine("Ходит игрок " + playerOne);
            if (!order) Console.WriteLine("Ходит игрок " + playerTwo);
            int x = -1;
            int y = -1;
            
            InputMoveCoordinates(out x, out y);
            Console.WriteLine(x + " " + y);

            if (order)
            {
                isTurnFinished = MakeMove(ref board, x, y, xSymbol);
            }
            else
            {
                isTurnFinished = MakeMove(ref board, x, y, oSymbol);
            }

            if (!isTurnFinished)
            {
                Console.WriteLine("Выбериете пустую клетку");
                continue;
            }

            ShowBoard(ref board);
            order = !order;
            isGameFinished = CheckVictory(board);
            turnNumber++;
        }
        if (turnNumber == 9 && !isGameFinished) Console.WriteLine("НИЧЬЯ");
    }
}