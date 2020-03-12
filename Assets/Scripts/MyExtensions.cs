using UnityEngine;

public static class MyExtensions
{ 
    public static float Round(this float f, int decimals)
    {
        return (float)System.Math.Round(f, decimals);
    }
}
