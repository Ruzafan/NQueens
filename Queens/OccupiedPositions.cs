public class OccupiedPositions : ICloneable
{
    public Dictionary<int, bool> X_Axis { get; set; }
    public Dictionary<int, bool> Y_Axis { get; set; }
    public Dictionary<int, bool> Z { get; set; }
    public OccupiedPositions()
    {
        X_Axis = new Dictionary<int, bool>();
        Y_Axis = new Dictionary<int, bool>();
        Z = new Dictionary<int, bool>();
    }

    public void RefreshOccupiedPositions(Matrix matrix)
    {
        X_Axis = new Dictionary<int, bool>();
        Y_Axis = new Dictionary<int, bool>();
        Z = new Dictionary<int, bool>();
        for (int x = 0; x < matrix.N; x++)
        {

            for (int y = 0; y < matrix.N; x++)
            {
                if (matrix.Table[x, y] == 1)
                {
                    X_Axis[x] = true;
                    Y_Axis[y] = true;
                    Z[x + y] = true;
                    Z[x - y] = true;
                }
            }
        }
    }

    public object Clone()
    {
        var occupiedPosition = new OccupiedPositions();
        occupiedPosition.X_Axis = new Dictionary<int, bool>(X_Axis);
        occupiedPosition.Y_Axis = new Dictionary<int, bool>(Y_Axis);
        occupiedPosition.Z = new Dictionary<int, bool>(Z);
        return occupiedPosition;
    }
}