using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObject
{
    public Vector2 position1;
    public Vector2 position2;
    public List<Material> matList;

    public BuildingObject(Vector2 startPoint, Vector2 oppositePoint, List<Material> matList)
    {
        position1 = startPoint;
        position2 = oppositePoint;
        this.matList = new List<Material>(matList);
    }
}
