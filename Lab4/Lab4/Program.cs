using Lab4;

Console.WriteLine("Hello, World!");

try
{
    MatrixClass a = new MatrixClass(new int[,] { { 2, 2 }, { 2, 2 } }, 2, 2);
    MatrixClass b = new MatrixClass(new int[,] { { 3, 3 }, { 3, 3 } }, 2, 2);
    MatrixClass c;

    c = a * b;

    c.Show();
}
catch (MyException e)
{
    Console.WriteLine(e.Message);
}
