using lab6;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var first = new Complex(-32, 16);
var second = new Complex(-2, 16);

var third = first / second;

var test = new Complex(3840, 2048);
var kek = test.Root(2, 0);
kek.Show();