// See https://aka.ms/new-console-template for more information
using lab5;

try
{
    SimpleFractionClass f = new SimpleFractionClass(1, 5);
    SimpleFractionClass f2 = new SimpleFractionClass(2, 5);
    SimpleFractionClass outn;

    outn = f + f2;

    outn.Show();

    Console.WriteLine(outn.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}