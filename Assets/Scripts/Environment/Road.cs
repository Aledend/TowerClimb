using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Road", menuName = "Scripts/Generation/Road")]
public class Road : ScriptableObject
{
    public GameObject road;
    public EnvironmentGeneration eg;
    [System.NonSerialized]
    GameObject go;
    
    [System.NonSerialized]
    float yPos = -0.46f;
    //Generates road from point a to point b
    public void GenerateRoad(Vector2 a, Vector2 b)
    {
        Vector3 _normalizedVector = new Vector3(b.x - a.x, 0, b.y - a.y).normalized;
        for (int i = 0; i <= (b - a).magnitude; i++)
        {
            go = Instantiate(road, _normalizedVector * i + new Vector3(a.x, yPos, a.y) + ((new Vector3(-_normalizedVector.z, 0, -_normalizedVector.x))), Quaternion.LookRotation(Vector3.up, Vector3.forward));
            eg.mh.floorData.AddGO(go);
            go = Instantiate(road, _normalizedVector * i + new Vector3(a.x, yPos, a.y), Quaternion.LookRotation(Vector3.up, Vector3.forward));
            eg.mh.floorData.AddGO(go);
            go = Instantiate(road, _normalizedVector * i + new Vector3(a.x, yPos, a.y) + ((new Vector3(_normalizedVector.z, 0, _normalizedVector.x))), Quaternion.LookRotation(Vector3.up, Vector3.forward));
            eg.mh.floorData.AddGO(go);
        }
    }
    
}
