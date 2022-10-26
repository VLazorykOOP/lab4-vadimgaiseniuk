namespace Lab4CSharp;

public class MatrixUInt
{
    private uint[,] _uIntMatrix;
    private int _rows, _cols;
    private int _errorCode;
    private static int _matrixAmount;

    public int Rows => _rows;
    public int Cols => _cols;
    public int ErrorCode
    {
        get => _errorCode;
        set => _errorCode = value;
    }

    public int MatrixAmount => _matrixAmount;

    public uint this[int i, int j]
    {
        get
        {
            if ((i < 0 || i > _rows) && (j < 0 || j > _cols))
            {
                _errorCode = -1;
                return 0;
            }

            return _uIntMatrix[i, j];
        }

        set
        {
            if ((i < 0 || i > _rows) && (j < 0 || j > _cols))
                _errorCode = -1;
        }
    }

    public MatrixUInt()
    {
        _uIntMatrix = new uint[1, 1];
        _uIntMatrix[0, 0] = 0;

        IncrementMatrixAmount();
    }

    public MatrixUInt(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        _uIntMatrix = new uint[_rows, _cols];

        for (int i = 0; i < _rows; i++)
            for (int j = 0; j < _cols; j++)
                _uIntMatrix[i, j] = 0;
        
        IncrementMatrixAmount();
    }

    public MatrixUInt(int rows, int cols, uint value)
    {
        _rows = rows;
        _cols = cols;
        _uIntMatrix = new uint[_rows, _cols];

        for (int i = 0; i < _rows; i++)
            for (int j = 0; j < _cols; j++)
                _uIntMatrix[i, j] = value;
        
        IncrementMatrixAmount();
    }

    ~MatrixUInt()
    {
        Console.WriteLine("Object destroyed");
        _matrixAmount--;
    }

    public void InputMatrixElements()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Console.Write($"Enter [{i + 1}, {j + 1}]: ");
                _uIntMatrix[i, j] = Convert.ToUInt32(Console.ReadLine());
            }
        }
    }

    public void PrintMatrixElements()
    {
        Console.WriteLine("Matrix elements: ");
        
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Console.Write($"{_uIntMatrix[i, j]} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("\n");
    }

    public void SetMatrixElements(uint value)
    {
        for (int i = 0; i < _rows; i++)
            for (int j = 0; j < _cols; j++)
                _uIntMatrix[i, j] = value;
    }

    public void SetMatrixElement(int row, int col, uint value) => _uIntMatrix[row, col] = value;

    public static void IncrementMatrixAmount() => _matrixAmount++;

    public static MatrixUInt operator ++(MatrixUInt matrix)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);

        for (int i = 0; i < temp._rows; i++)
            for (int j = 0; j < temp._cols; j++)
                temp[i, j] = matrix[i, j] + 1;

        return temp;
    }

    public static MatrixUInt operator --(MatrixUInt matrix)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);

        for (int i = 0; i < temp._rows; i++)
            for (int j = 0; j < temp._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] - 1;

        return temp;        
    }

    public static bool operator true(MatrixUInt matrix)
    {
        if (matrix._rows == 0 || matrix._cols == 0)
            return false;
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                if (matrix._uIntMatrix[i, j] == 0)
                    return false;

        return true;
    }

    public static bool operator false(MatrixUInt matrix)
    {
        if (matrix._rows != 0 || matrix._cols != 0)
            return true;
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                if (matrix._uIntMatrix[i, j] != 0)
                    return true;

        return false;
    }

    public static bool operator !(MatrixUInt matrix)
    {
        if (matrix._rows == 0 || matrix._cols == 0)
            return false;

        foreach (var element in matrix._uIntMatrix)
        {
            if (element == 0)
                return false;
        }

        return true;
    }

    public static byte[,] operator ~(MatrixUInt matrix)
    {
        var temp = new byte[matrix._rows, matrix._cols];
        
        for (int i = 0; i < matrix._rows; i++)
        {
            for (int j = 0; j < matrix._cols; j++)
            {
                var tempElement = (byte)~matrix._uIntMatrix[i, j];
                temp[i, j] = tempElement;
            }
        }

        return temp;
    }

    public static MatrixUInt operator +(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._rows != b._rows || matrix._cols != b._cols)
            return matrix;

        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] + b._uIntMatrix[i, j];

        return temp;
    }
    
    public static MatrixUInt operator +(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] + value;

        return temp;
    }
    
    public static MatrixUInt operator -(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._rows != b._rows || matrix._cols != b._cols)
            return matrix;

        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] - b._uIntMatrix[i, j];

        return temp;
    }
    
    public static MatrixUInt operator -(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] - value;

        return temp;
    }
    
    public static MatrixUInt operator *(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._cols != b._rows)
            throw new Exception("Multiplication of matrices is not possible");

        var temp = new MatrixUInt(matrix._rows, b._cols);

        for (int i = 0; i < matrix._rows; i++)
        {
            for (int j = 0; j < matrix._cols; j++)
            {
                var result = 0u;
                
                for (int k = 0; k < matrix._cols; k++)
                    result += matrix._uIntMatrix[i, j] + b._uIntMatrix[i, j];

                temp._uIntMatrix[i, j] = result;
            }
        }

        return temp;
    }
    
    public static MatrixUInt operator *(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] * value;

        return temp;
    }
    
    public static MatrixUInt operator /(MatrixUInt matrix, uint value)
    {
        if (value == 0)
            throw new Exception("Value is 0. Cannot divide by zero");
        
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] / value;

        return temp;
    }
    
    public static MatrixUInt operator %(MatrixUInt matrix, uint value)
    {
        if (value == 0)
            throw new Exception("Value is 0. Cannot divide by zero");
        
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] % value;

        return temp;
    }
    
    public static MatrixUInt operator |(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._rows != b._rows || matrix._cols != b._cols)
            return matrix;

        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] | b._uIntMatrix[i, j];

        return temp;
    }
    
    public static MatrixUInt operator |(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] | value;

        return temp;
    }
    
    public static MatrixUInt operator &(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._rows != b._rows || matrix._cols != b._cols)
            return matrix;

        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] & b._uIntMatrix[i, j];

        return temp;
    }
    
    public static MatrixUInt operator &(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] & value;

        return temp;
    }
    
    public static MatrixUInt operator ^(MatrixUInt matrix, MatrixUInt b)
    {
        if (matrix._rows != b._rows || matrix._cols != b._cols)
            return matrix;

        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] ^ b._uIntMatrix[i, j];

        return temp;
    }
    
    public static MatrixUInt operator ^(MatrixUInt matrix, uint value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] ^ value;

        return temp;
    }

    public static MatrixUInt operator >>(MatrixUInt matrix, int value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] >> value;

        return temp;
    }
    
    public static MatrixUInt operator <<(MatrixUInt matrix, int value)
    {
        var temp = new MatrixUInt(matrix._rows, matrix._cols);
        
        for (int i = 0; i < matrix._rows; i++)
            for (int j = 0; j < matrix._cols; j++)
                temp._uIntMatrix[i, j] = matrix._uIntMatrix[i, j] << value;

        return temp;
    }

    public static bool operator ==(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows != b._rows || a._cols != b._cols)
            return false;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] != b._uIntMatrix[i, j])
                    return false;

        return true;
    }

    public static bool operator !=(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows == b._rows || a._cols == b._cols)
            return false;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] == b._uIntMatrix[i, j])
                    return false;

        return true;
    }

    public static bool operator >(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows < b._rows && a._cols < b._cols)
            return false;

        if (a._rows > b._rows && a._cols > b._cols)
            return true;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] <= b._uIntMatrix[i, j])
                    return false;

        return true;
    }

    public static bool operator <(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows < b._rows && a._cols < b._cols)
            return true;

        if (a._rows > b._rows && a._cols > b._cols)
            return false;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] >= b._uIntMatrix[i, j])
                    return false;

        return true;
    }
    
    public static bool operator >=(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows < b._rows && a._cols < b._cols)
            return false;

        if (a._rows > b._rows && a._cols > b._cols)
            return true;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] < b._uIntMatrix[i, j])
                    return false;

        return true;
    }

    public static bool operator <=(MatrixUInt a, MatrixUInt b)
    {
        if (a._rows < b._rows && a._cols < b._cols)
            return true;

        if (a._rows > b._rows && a._cols > b._cols)
            return false;
        
        for (int i = 0; i < a._rows; i++)
            for (int j = 0; j < a._cols; j++)
                if (a._uIntMatrix[i, j] > b._uIntMatrix[i, j])
                    return false;

        return true;
    }
}