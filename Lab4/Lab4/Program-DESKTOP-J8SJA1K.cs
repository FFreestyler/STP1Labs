using Lab4;

Console.WriteLine("Hello, World!");

try
{
    MatrixClass a = new MatrixClass(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, 3, 3);
    MatrixClass c;

    c = a.Transpose();

    c.Show();
}
catch (MyException e)
{
    Console.WriteLine(e.Message);
}
