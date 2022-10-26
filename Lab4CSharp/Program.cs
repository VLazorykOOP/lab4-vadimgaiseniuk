namespace Lab4CSharp;

public class Program
{
    public static void Main()
    {
        // Task 1
        Console.WriteLine("Task 1");
        
        Triangle triangle = new Triangle(7, 10, 6, 100);

        int a = triangle[0];
        Console.WriteLine(a);
        
        triangle.PrintTriangleSideValues();
        Console.WriteLine(triangle.CalculatePerimeter());
        Console.WriteLine(triangle.CalculateSquare());

        triangle = ++triangle;
        triangle *= a;
        
        triangle.PrintTriangleSideValues();
        Console.WriteLine(triangle.CalculatePerimeter());
        Console.WriteLine(triangle.CalculateSquare());

        if (triangle)
            Console.WriteLine("Triangle can exist");
        else 
            Console.WriteLine("Triangle cannot exist");

        Console.WriteLine("Task 2");
        
        // Task 2

        VectorUInt vectorOne = new VectorUInt(6, 34);
        VectorUInt vectorTwo = new VectorUInt(6);
        
        vectorTwo.InputVectorElements();
        vectorOne.PrintVectorElements();
        vectorTwo.PrintVectorElements();
        
        vectorOne.SetVectorElement(4, vectorTwo[0]);

        vectorOne += vectorTwo;
        vectorOne.PrintVectorElements();

        vectorTwo *= vectorOne;
        vectorTwo.PrintVectorElements();

        VectorUInt vectorThree = new VectorUInt(6);

        vectorThree = (vectorOne * vectorTwo) / (vectorOne - vectorThree);
        vectorThree.PrintVectorElements();

        vectorThree = vectorOne | vectorTwo;
        vectorThree.PrintVectorElements();

        vectorThree = vectorOne & vectorTwo;
        vectorThree.PrintVectorElements();

        Console.WriteLine($"vectorOne > vectorThree: {vectorOne > vectorThree}");
        Console.WriteLine($"vectorTwo < vectorThree: {vectorTwo < vectorThree}");
        
        Console.WriteLine($"Amount of vectors: {vectorOne.VecAmount}");

        // Task 3
        
        Console.WriteLine("Task 3");

        MatrixUInt matrixOne = new MatrixUInt(3, 3, 4);
        MatrixUInt matrixTwo = new MatrixUInt(3, 3);
        
        matrixTwo.InputMatrixElements();
        
        matrixOne.PrintMatrixElements();
        matrixTwo.PrintMatrixElements();

        matrixOne.SetMatrixElements(matrixTwo[2, 1]);

        matrixOne *= matrixTwo;
        
        matrixOne.PrintMatrixElements();

        MatrixUInt matrixThree = (matrixOne + matrixTwo) * (matrixOne / 2);
        
        matrixThree.PrintMatrixElements();

        matrixThree = (matrixOne & matrixTwo) | matrixThree;
        
        matrixThree.PrintMatrixElements();
        
        Console.WriteLine($"matrixThree == matrixTwo: {matrixThree == matrixTwo}");
        Console.WriteLine($"matrixOne >= matrixTwo: {matrixOne >= matrixTwo}");

        Console.WriteLine($"The amount of matrices: {matrixOne.MatrixAmount}");
    }
}