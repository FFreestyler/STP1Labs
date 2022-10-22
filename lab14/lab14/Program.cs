using lab14;

var polynomialL = new Polynomial(2, 2);
polynomialL.Add(1, 1);
var polynomialR = new Polynomial(2, 2);
polynomialR.Add(1, 1);
var polynomialS = polynomialL * polynomialR;


var expected = polynomialS.Calculation(2);

Console.WriteLine(expected);