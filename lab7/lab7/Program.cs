using lab7;

PNumber a = new PNumber(2, 2, 3);
PNumber b = new PNumber(5, 2, 3);

PNumber c = PNumber.Revers(a);
PNumber d = new PNumber(1.0 / 2, 2, 3);

a.SetBase(13);

c.Show();
d.Show();