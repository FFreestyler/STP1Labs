using lab5;

Console.WriteLine("Hello, World!");

try
{
    SimpleFractionClass a = new SimpleFractionClass("1/5");

    SimpleFractionClass.Minus(a);

    a.Show();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
