using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sidewalk", menuName = "Scripts/Generation/Sidewalk")]
public class Sidewalk : ScriptableObject
{
    public GameObject sidewalk;
    public EnvironmentGeneration eg;
    [System.NonSerialized]
    GameObject go;
    float yPos = -0.32f;

    //Generate sidewalk from one point to another
    public void GenerateSidewalk(Vector2 startPoint, Vector2 endPoint)
    {
        Vector2 a = startPoint, b = endPoint;
        Vector3 _normalizedVector = new Vector3(b.x - a.x, 0, b.y - a.y).normalized;
        for (int i = 0; i <= (b - a).magnitude; i++)
        {
            go = Instantiate(sidewalk, _normalizedVector * i + new Vector3(a.x, yPos, a.y), Quaternion.LookRotation(Vector3.up, Vector3.forward));
            eg.mh.floorData.AddGO(go);
        }
    }
}
