using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorData", menuName = "Scripts/Data/FloorData")]
public class FloorDataClass : ScriptableObject
{
    // Lists that holds each floor piece and each floor respectively
    [System.NonSerialized]
    public List<GameObject> goList = new List<GameObject>();
    [System.NonSerialized]
    public List<List<GameObject>> floorList = new List<List<GameObject>>();
    public GameObject shapeless;
    [System.NonSerialized]
    int index = 0;
    

    // Destroy the lowest most generated floor currently in the game.
    public void DestroyEldestFloor()
    {
        if (index * 0.5f < shapeless.transform.position.y)
        {
            foreach (var go in floorList[0])
            {
                Destroy(go);
            }
            floorList.RemoveAt(0);
            index++;
        }
    }

    public void AddGO(GameObject go)
    {
        goList.Add(go);
    }

    // Save current and prepare next floor
    public void SaveFloor()
    {
        floorList.Add(new List<GameObject>(goList));
        goList.Clear();
    }
}
