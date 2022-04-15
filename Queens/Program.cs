// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Drawing;
using System.Linq;

Console.WriteLine("How big has to be the table?");
var size = Console.ReadLine();
int n = int.Parse(size);
var matrix = new Matrix(n);
int retires = 0;
new List<Pos>();
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    retires++;
    //Console.WriteLine(retires);
    //PrintMatrix(table);
    //Console.ReadLine();
    matrix.Table = new int[n, n];
    var ocuppiedPositions = new OccupiedPositions();
    var frontier = FrontierGenerator.Generate(1, ocuppiedPositions, n);
    while (frontier != null && frontier.Any())
    {
        var pos = frontier[0];
        frontier.RemoveAt(0);
        SetValuesTo(ocuppiedPositions, matrix, pos, true);
        var (newMatrix, newOccupiedPositons) = CheckNextPosition(pos.X + 1, matrix, ocuppiedPositions);
        if (newMatrix != null && newOccupiedPositons != null)
        {
            matrix = newMatrix;
            ocuppiedPositions = newOccupiedPositons;
            break;
        }
        else
        {
            SetValuesTo(ocuppiedPositions, matrix, pos, false);
        }
    }
    stopwatch.Stop();
    PrintTable(matrix.Table);
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    Console.ReadLine();
}



(Matrix, OccupiedPositions) CheckNextPosition(int x, Matrix matrix, OccupiedPositions occupiedPositions)
{
    var newOccupiedPositions = (OccupiedPositions)occupiedPositions.Clone();
    var newMatrix = (Matrix)matrix.Clone();
    var frontier = FrontierGenerator.Generate(x, newOccupiedPositions, n);
    while (frontier != null && frontier.Any())
    {
        var pos = frontier[0];
        frontier.RemoveAt(0);
        SetValuesTo(newOccupiedPositions, newMatrix, pos, true);
        if(newMatrix.IsTheTableCompleted())
        {
            return (newMatrix, newOccupiedPositions);
        }
        var (newnewMatrix, newnewOccupiedPositons) = CheckNextPosition(pos.X + 1, newMatrix, newOccupiedPositions);
        if (newnewMatrix != null && newnewOccupiedPositons != null)
        {
            return (newnewMatrix, newnewOccupiedPositons);
        }
        else
        {
            SetValuesTo(newOccupiedPositions, newMatrix, pos, false);
        }
    }
    return (null, null);
}

void SetValuesTo(OccupiedPositions? occupiedPositions, Matrix? matrix, Pos? pos, bool value)
{
    occupiedPositions.X_Axis[pos.X] = value;
    occupiedPositions.Y_Axis[pos.Y] = value;
    matrix.Table[pos.Y - 1, pos.X-1] = value ? 1 : 0;
    occupiedPositions.Z[pos.X + pos.Y] = value;
    occupiedPositions.Z[pos.X - pos.Y] = value;
}

void PrintTable(int[,] matrix)
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
}