public static class FrontierGenerator
{

    public static List<Pos> Generate(int currentX, OccupiedPositions occupiedPositions, int n)
    {
        //if the X is already ocuppied there is no need to check all the values
        if (occupiedPositions.X_Axis.IsInTheDicc(currentX))
        {
            return null;
        }
        var res = new List<Pos>();
        for (var i = 1; i <= n; i++)
        {
            //if i is not in occupied we add to the posible values of Y axis
            if (!occupiedPositions.Y_Axis.IsInTheDicc(i))
            {
                if (!occupiedPositions.Z.IsInTheDicc(currentX + i) && !occupiedPositions.Z.IsInTheDicc(currentX - i))
                {
                    res.Add(new Pos(currentX, i));
                }
            }
        }
        return res;
    }


    private static bool IsInTheDicc(this Dictionary<int, bool> dic, int val)
    {
        return dic.ContainsKey(val) && dic[val];
    }
}