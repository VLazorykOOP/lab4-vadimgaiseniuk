namespace Lab4CSharp;

public class VectorUInt
{
    private uint[] _uIntArray;
    private uint _size;
    private int _errorCode;
    private static uint _vecAmount;

    public uint Size => _size;
    
    public int ErrorCode
    {
        get => _errorCode;
        set => _errorCode = value;
    }

    public uint VecAmount => _vecAmount;

    public uint this[int i]
    {
        get
        {
            if (i < 0 || i > _size)
            {
                _errorCode = -1;
                return 0;
            }

            return _uIntArray[i];
        }

        set
        {
            if (i < 0 || i > _size)
                _errorCode = -1;
        }
    }

    public VectorUInt()
    {
        _size = 1;
        _uIntArray = new uint[_size];
        _uIntArray[0] = 0;
        IncrementVectorAmount();
    }

    public VectorUInt(uint size)
    {
        _size = size;
        _uIntArray = new uint[_size];

        for (int i = 0; i < _size; i++)
            _uIntArray[i] = 0;

        IncrementVectorAmount();
    }

    public VectorUInt(uint size, uint value)
    {
        _size = size;
        _uIntArray = new uint[_size];

        for (int i = 0; i < _size; i++)
            _uIntArray[i] = value;

        IncrementVectorAmount();
    }

    ~VectorUInt()
    {
        Console.WriteLine("Object destroyed");
        _vecAmount--;
    }

    public void InputVectorElements()
    {
        for (int i = 0; i < _size; i++)
        {
            Console.Write($"Enter {i + 1} element of the vector: ");
            _uIntArray[i] = Convert.ToUInt32(Console.ReadLine());
        }
    }

    public void PrintVectorElements()
    {
        Console.WriteLine("Vector elements:");
        for (int i = 0; i < _size; i++)
            Console.Write($"{_uIntArray[i]} ");

        Console.WriteLine("\n");
    }

    public void SetVectorElements(uint value)
    {
        for (int i = 0; i < _size; i++)
            _uIntArray[i] = value;
        
        PrintVectorElements();
    }

    public void SetVectorElement(int index, uint value)
    {
        _uIntArray[index] = value;
        
        PrintVectorElements();
    }


    public static void IncrementVectorAmount() => _vecAmount++;

    public static VectorUInt operator ++(VectorUInt vector)
    {
        var temp = new VectorUInt(vector.Size);

        for (int i = 0; i < vector.Size; i++)
            temp._uIntArray[i] = vector._uIntArray[i] + 1;

        return temp;
    }

    public static VectorUInt operator --(VectorUInt vector)
    {
        var temp = new VectorUInt(vector.Size);

        for (int i = 0; i < vector.Size; i++)
            temp._uIntArray[i] = vector._uIntArray[i] - 1;

        return temp;   
    }
    
    public static bool operator true(VectorUInt vector)
    {
        if (vector.Size == 0)
            return false;
        
        foreach (var element in vector._uIntArray)
        {
            if (element == 0)
                return false;
        }

        return true;
    }

    public static bool operator false(VectorUInt vector)
    {
        if (vector.Size != 0)
            return true;

        foreach (var element in vector._uIntArray)
        {
            if (element != 0)
                return true;
        }
        
        return false;
    }

    public static bool operator !(VectorUInt vector)
    {
        if (vector.Size == 0)
            return false;

        foreach (var element in vector._uIntArray)
        {
            if (element == 0)
                return false;
        }

        return true;
    }

    public static byte[] operator ~(VectorUInt vector)
    {
        var temp = new byte[vector.Size];
        
        for (int i = 0; i < vector.Size; i++)
        {
            var tempElement = (byte)~vector._uIntArray[i];
            temp[i] = tempElement;
        }

        return temp;
    }

    public static VectorUInt operator +(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] + b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator +(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] + value;
        }

        return temp;
    }
    
    public static VectorUInt operator -(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] - b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator -(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] - value;
        }

        return temp;
    }
    
    public static VectorUInt operator *(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] * b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator *(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] * value;
        }

        return temp;
    }
    
    public static VectorUInt operator /(VectorUInt a, VectorUInt b)
    {
        var condition = !b;
        var size = a.Size <= b.Size ? a.Size : b.Size;

        if (!condition)
            throw new Exception("Some vector element has value of 0. Cannot divide by zero");

        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] / b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator /(VectorUInt a, uint value)
    {
        if (value == 0)
            throw new Exception("Value is zero. Cannot divide by zero");
        
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] / value;
        }

        return temp;
    }
    
    public static VectorUInt operator %(VectorUInt a, VectorUInt b)
    {
        var condition = !b;
        var size = a.Size <= b.Size ? a.Size : b.Size;

        if (!condition)
            throw new Exception("Some vector element has value of 0. Cannot divide by zero");

        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] % b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator %(VectorUInt a, uint value)
    {
        if (value == 0)
            throw new Exception("Value is zero. Cannot divide by zero");
        
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] % value;
        }

        return temp;
    }
    
    public static VectorUInt operator |(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] | b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator |(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] | value;
        }

        return temp;
    }
    
    public static VectorUInt operator &(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] & b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator &(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] & value;
        }

        return temp;
    }
    
    public static VectorUInt operator ^(VectorUInt a, VectorUInt b)
    {
        var size = a.Size <= b.Size ? a.Size : b.Size;
        var temp = new VectorUInt(size);

        for (int i = 0; i < size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] ^ b._uIntArray[i];
        }

        return temp;
    }
    
    public static VectorUInt operator ^(VectorUInt a, uint value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] ^ value;
        }

        return temp;
    }

    public static VectorUInt operator >>(VectorUInt a, int value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] >> value;
        }

        return temp;
    }
    
    public static VectorUInt operator <<(VectorUInt a, int value)
    {
        var temp = new VectorUInt(a.Size);

        for (int i = 0; i < a.Size; i++)
        {
            temp._uIntArray[i] = a._uIntArray[i] << value;
        }

        return temp;
    }

    public static bool operator ==(VectorUInt a, VectorUInt b)
    {
        if (a.Size != b.Size)
            return false;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] != b._uIntArray[i])
                return false;
        }

        return true;
    }
    
    public static bool operator !=(VectorUInt a, VectorUInt b)
    {
        if (a.Size == b.Size)
            return false;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] == b._uIntArray[i])
                return false;
        }

        return true;
    }

    public static bool operator >(VectorUInt a, VectorUInt b)
    {
        if (a.Size < b.Size)
            return false;

        if (a.Size > b.Size)
            return true;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] <= b._uIntArray[i])
                return false;
        }

        return true;
    }

    public static bool operator <(VectorUInt a, VectorUInt b)
    {
        if (a.Size < b.Size)
            return true;

        if (a.Size > b.Size)
            return false;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] >= b._uIntArray[i])
                return false;
        }

        return true;
    }
    
    public static bool operator >=(VectorUInt a, VectorUInt b)
    {
        if (a.Size < b.Size)
            return false;

        if (a.Size > b.Size)
            return true;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] < b._uIntArray[i])
                return false;
        }

        return true;
    }

    public static bool operator <=(VectorUInt a, VectorUInt b)
    {
        if (a.Size < b.Size)
            return true;

        if (a.Size > b.Size)
            return false;

        for (int i = 0; i < a.Size; i++)
        {
            if (a._uIntArray[i] > b._uIntArray[i])
                return false;
        }

        return true;
    }
}