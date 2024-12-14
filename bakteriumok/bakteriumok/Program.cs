#region Files
string[] meres = File.ReadAllLines("meres.txt");

int sor = 50;
int oszlop = 50;

int[,] adat = new int[sor, oszlop];

for (int i = 0; i < sor; i++)
{
    string[] adatok = meres[i].Split('\t');
    for (int j = 0; j < oszlop; j++)
    {
        if (adatok[j] != "")
        {
            adat[i, j] = int.Parse(adatok[j]);
        }
        else
        {
            adat[i, j] = 0;
        }
    }
}

Console.WriteLine("");
#endregion

#region 1.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"1. Feladat");
Console.ResetColor();

Console.Write($"Adj meg egy számot 1 és 50 között: ");
int szam = int.Parse(Console.ReadLine()!);

bool keres_szam = false;

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] == szam)
        {
            keres_szam = true;
            break;
        }
    }
    if (keres_szam)
    {
        break;
    }
}

if (keres_szam)
{
    Console.WriteLine($"A megadott szám szerepel a táblában.");
}
else
{
    Console.WriteLine($"A megadott szám nem szerepel a táblában.");
}
#endregion

Pause();

#region 2.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"2. Feladat");
Console.ResetColor();

int osszes_bakterium = 0;
int[] bakterium_szamok = new int[51];

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] != 0 && bakterium_szamok[adat[i, j]] == 0)
        {
            bakterium_szamok[adat[i, j]] = 1;
            osszes_bakterium++;
        }
    }
}

Console.WriteLine($"Összesen {osszes_bakterium} baktérium van a képen.");
#endregion

Pause();

#region 3.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"3. Feladat");
Console.ResetColor();

int[] terulet = new int[51];

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] != 0)
        {
            terulet[adat[i, j]]++;
        }
    }
}

int max_terulet = 0;
int max_bakterium = 0;

for (int i = 1; i <= 50; i++)
{
    if (terulet[i] > max_terulet)
    {
        max_terulet = terulet[i];
        max_bakterium = i;
    }
}

Console.WriteLine($"A(z) {max_bakterium}. baktérium foglalja el a legnagyobb területet, amely {max_terulet} cellából áll.");
#endregion

Pause();

#region 4.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"4. Feladat");
Console.ResetColor();

Console.WriteLine($"Baktériumok színezett megjelenítése:");

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] != 0)
        {
            Console.ForegroundColor = (ConsoleColor)((adat[i, j] % 14) + 1);
            Console.Write($"{adat[i, j].ToString().PadLeft(3)}");
        }
        else
        {
            Console.ResetColor();
            Console.Write($"  .");
        }
    }
    Console.WriteLine();
    Console.ResetColor();
}
#endregion

Pause();

#region 5.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"5. Feladat");
Console.ResetColor();

int bal = oszlop, jobb = 0, felso = sor, also = 0;

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] != 0)
        {
            if (j < bal) bal = j;
            if (j > jobb) jobb = j;
            if (i < felso) felso = i;
            if (i > also) also = i;
        }
    }
}

int szelesseg = jobb - bal + 1;
int magassag = also - felso + 1;

Console.WriteLine($"A minimális téglalap méretei:");
Console.WriteLine($"Szélesség: {szelesseg}, Magasság: {magassag}");
#endregion

Pause();

#region 6.feladat
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"6. Feladat");
Console.ResetColor();

bool erintkezes = false;

for (int i = 0; i < sor; i++)
{
    for (int j = 0; j < oszlop; j++)
    {
        if (adat[i, j] != 0)
        {
            int aktualis = adat[i, j];
            if (i > 0 && adat[i - 1, j] != 0 && adat[i - 1, j] != aktualis) erintkezes = true;
            if (i < sor - 1 && adat[i + 1, j] != 0 && adat[i + 1, j] != aktualis) erintkezes = true;
            if (j > 0 && adat[i, j - 1] != 0 && adat[i, j - 1] != aktualis) erintkezes = true;
            if (j < oszlop - 1 && adat[i, j + 1] != 0 && adat[i, j + 1] != aktualis) erintkezes = true;

            if (erintkezes)
            {
                Console.WriteLine($"Érintkező baktériumok: {aktualis} és {adat[i, j]}");
                break;
            }
        }
    }
    if (erintkezes) break;
}

if (!erintkezes)
{
    Console.WriteLine($"Nincsenek egymással érintkező baktériumok.");
}
#endregion

void Pause()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Nyomj entert a továbblépéshez!");
    while (Console.ReadKey().Key != ConsoleKey.Enter)
    {
        //asd
    }
    Console.WriteLine($"1 másodperc...");
    Thread.Sleep(1000);
    Console.ResetColor();
}