using lab11;

Console.WriteLine("Hello, World!");


var exp = new lab11.Memory<int>();
exp.Storage(2);

Console.WriteLine(exp.GetType());
Console.WriteLine(exp.GetNumber());
