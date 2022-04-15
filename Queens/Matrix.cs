public class Matrix : ICloneable
{
    public Matrix(int n)
    {
        N = n;
        Table = new int[n, n];
    }

    public int N { get; set; }
    public int[,] Table { get; set; }

    public object Clone()
    {
        var martrix = new Matrix(N);
        martrix.Table = (int[,])Table.Clone();
        return martrix;
    }

    public bool IsTheTableCompleted()
    {
        int total = 0;

        for (int x = 0; x < N; x++)
        {

            for (int y = 0; y < N; y++)
            {
                total += Table[x, y];
            }
        }
        //If the number of queens we have found (total) is equal to the size of the table (N) there is the maximum number of Queens on the table
        return total == N;
    }
}