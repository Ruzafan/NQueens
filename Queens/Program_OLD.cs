// See https://aka.ms/new-console-template for more information
/*using System.Drawing;

Console.WriteLine("How big has to be the table?");
var size = Console.ReadLine();
int n = int.Parse(size);
var table = new int[n, n];
int retires = 0;
Dictionary<int, bool> occupiedX = new Dictionary<int, bool>();
Dictionary<int, bool> occupiedDiagonals = new Dictionary<int, bool>();
while (main(table) < n && retires < n * 1000)
{
    retires++;
    //Console.WriteLine(retires);
    //PrintMatrix(table);
    //Console.ReadLine();
    table = new int[n, n];
    occupiedX = new Dictionary<int, bool>();
    occupiedDiagonals = new Dictionary<int, bool>();
}
Console.WriteLine(retires);
if (retires >= n * 1000)
{
    Console.WriteLine("Not found");
}
else
{
    PrintMatrix(table);
}

int main(int[,] matrix)
{
    int spotsOccupied = 0;
    for (int y = 1; y <= n; y++)
    {
        int x = GetFreeXSpot(y);
        if (x > -1)
        {
            matrix[y - 1, x - 1] = 1;
            spotsOccupied++;
        }
        else
        {
            break;
        }
    }
    return spotsOccupied;
}

int GetFreeXSpot(int y)
{
    var spots = new List<int>();
    for (int x = 1; x <= n; x++)
    {
        if (!occupiedX.ContainsKey(x) && !occupiedDiagonals.ContainsKey(y + x) && !occupiedDiagonals.ContainsKey(y - x))
        {
            spots.Add(x);
        }
    }
    if (spots.Any())
    {
        Random random = new Random();
        int pos = random.Next(0,spots.Count-1);
        var spot = spots[pos];
        occupiedX[spot] = true;
        occupiedDiagonals[y + spot] = true;
        occupiedDiagonals[y - spot] = true;
        return spot;
    }
    return -1;
}

void PrintMatrix(int[,] matrix)
{
    for (int y = 0; y < n; y++)
    {
        string line = String.Empty;
        for (int x = 0; x < n; x++)
        {
            if (matrix[x, y] == 0)
                line += "▄  ";
            else
                line += "*  ";
        }
        Console.WriteLine(line + "\n");
    }
}*/