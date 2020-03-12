using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Scripts/Generation/Building")]
public class Building : ScriptableObject
{
    public List<Material> door1List;
    public List<Material> door2List;
    public List<Material> window1List;
    public List<Material> window2List;
    public List<GameObject> wall;
    public TowerMathHelperClass mh;

    public GameObject baseWall, baseWindow1, baseWindow2, baseDoor1, baseDoor2;
    [System.NonSerialized]
    GameObject wallPiece, go;
    
    [System.NonSerialized]
    public List<BuildingObject> buildings = new List<BuildingObject>();
    //Generates a building from provided opposite corners positions 
    public void GenerateFloors(/*Vector2 startPoint, Vector2 oppositePoint, */)
    {
        foreach (BuildingObject building in buildings)
        {
            Vector2 a = building.position1, b = building.position2;

            if ((mh.floorIndex) % 3 == 0)
            {
                wallPiece = baseWindow1;
                //wallPiece.GetComponent<MeshRenderer>().material = building.matList[0];
            }
            else if ((mh.floorIndex - 1) % 3 == 0)
            {
                wallPiece = baseWindow2;
                //wallPiece.GetComponent<MeshRenderer>().material = building.matList[1];
            }
            else
            {
                wallPiece = baseWall;
                //wallPiece.GetComponent<MeshRenderer>().material = building.matList[4];
            }

            Vector3 _normalizedVector = new Vector3(b.x - a.x, 0, 0).normalized;
            for (int i = 0; i <= Mathf.Abs(b.x - a.x); i++)
            {
                go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, mh.floorIndex * 0.5f, a.y) + new Vector3(0, 0, a.y - b.y).normalized * 0.5f, Quaternion.LookRotation(new Vector3(0, 0, a.y - b.y).normalized, Vector3.up));
                mh.floorData.AddGO(go);
                //go.GetComponent<MeshRenderer>().material = building.matList[0];
            }
            //_normalizedVector = new Vector3(a.x - b.x, 0, 0).normalized;
            for (int i = 0; i <= Mathf.Abs(b.x - a.x); i++)
            {
                go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, mh.floorIndex * 0.5f, b.y) + new Vector3(0, 0, b.y - a.y).normalized * 0.5f, Quaternion.LookRotation(new Vector3(0, 0, b.y - a.y).normalized, Vector3.up));
                mh.floorData.AddGO(go);
                //go.GetComponent<MeshRenderer>().material = building.matList[1];
            }

            _normalizedVector = new Vector3(0, 0, b.y - a.y).normalized;
            for(int i = 0; i <= Mathf.Abs(b.y - a.y); i++)
            {
                go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, mh.floorIndex * 0.5f, a.y) + new Vector3(a.x - b.x, 0, 0).normalized * 0.5f, Quaternion.LookRotation(new Vector3(a.x - b.x, 0, 0), Vector3.up));
                mh.floorData.AddGO(go);
                //go.GetComponent<MeshRenderer>().material = building.matList[2];
            }
            for (int i = 0; i <= Mathf.Abs(b.y - a.y); i++)
            {
                go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(b.x, mh.floorIndex * 0.5f, a.y) + new Vector3(b.x - a.x, 0, 0).normalized * 0.5f, Quaternion.LookRotation(new Vector3(b.x - a.x, 0, 0), Vector3.up));
                mh.floorData.AddGO(go);
                //go.GetComponent<MeshRenderer>().material = building.matList[3];
            }
        }
    }

    public void GenerateFirstFloors()
    {
        float increment = 0;
        while(increment < 3)
        {
            foreach (BuildingObject building in buildings)
            {
                Vector2 a = building.position1, b = building.position2;

                //if ((increment) % 3 == 0)
                //{
                //    wallPiece = baseWindow1;
                //    //wallPiece.GetComponent<MeshRenderer>().material = building.matList[0];
                //}
                //else if ((increment - 1) % 3 == 0)
                //{
                //    wallPiece = baseWindow2;
                //    //wallPiece.GetComponent<MeshRenderer>().material = building.matList[1];
                //}
                //else
                //{
                //    wallPiece = baseWall;
                //    //wallPiece.GetComponent<MeshRenderer>().material = building.matList[4];
                //}

                Vector3 _normalizedVector = new Vector3(b.x - a.x, 0, 0).normalized;
                for (int i = 0; i <= Mathf.Abs(b.x - a.x); i++)
                {
                    wallPiece = i == Mathf.Round(Mathf.Abs(b.x - a.x) * 0.5f) ? increment % 3 == 0 ? baseDoor1 : (increment - 1 % 3) == 0 ? baseDoor2 : baseWall : increment % 3 == 0 ? baseWindow1 : (increment - 1) % 3 == 0 ? baseWindow2 : baseWall;
                    go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, increment * 0.5f, a.y) + new Vector3(0, 0, a.y - b.y).normalized * 0.5f, Quaternion.LookRotation(new Vector3(0, 0, a.y - b.y).normalized, Vector3.up));
                    mh.floorData.AddGO(go);
                    //go.GetComponent<MeshRenderer>().material = building.matList[0];
                }
                //_normalizedVector = new Vector3(a.x - b.x, 0, 0).normalized;
                for (int i = 0; i <= Mathf.Abs(b.x - a.x); i++)
                {
                    wallPiece = i == Mathf.Round(Mathf.Abs(b.x - a.x) * 0.5f) ? increment % 3 == 0 ? baseDoor1 : (increment - 1 % 3) == 0 ? baseDoor2 : baseWall : increment % 3 == 0 ? baseWindow1 : (increment - 1) % 3 == 0 ? baseWindow2 : baseWall;
                    go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, increment * 0.5f, b.y) + new Vector3(0, 0, b.y - a.y).normalized * 0.5f, Quaternion.LookRotation(new Vector3(0, 0, b.y - a.y).normalized, Vector3.up));
                    mh.floorData.AddGO(go);
                    //go.GetComponent<MeshRenderer>().material = building.matList[1];
                }

                _normalizedVector = new Vector3(0, 0, b.y - a.y).normalized;
                for (int i = 0; i <= Mathf.Abs(b.y - a.y); i++)
                {
                    wallPiece = i == Mathf.Round(Mathf.Abs(b.y - a.y) * 0.5f) ? increment % 3 == 0 ? baseDoor1 : (increment - 1 % 3) == 0 ? baseDoor2 : baseWall : increment % 3 == 0 ? baseWindow1 : (increment - 1) % 3 == 0 ? baseWindow2 : baseWall;
                    go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(a.x, increment * 0.5f, a.y) + new Vector3(a.x - b.x, 0, 0).normalized * 0.5f, Quaternion.LookRotation(new Vector3(a.x - b.x, 0, 0), Vector3.up));
                    mh.floorData.AddGO(go);

                    //go.GetComponent<MeshRenderer>().material = building.matList[2];
                }
                for (int i = 0; i <= Mathf.Abs(b.y - a.y); i++)
                {
                    wallPiece = i == Mathf.Round(Mathf.Abs(b.y - a.y) * 0.5f) ? increment % 3 == 0 ? baseDoor1 : (increment - 1 % 3) == 0 ? baseDoor2 : baseWall : increment % 3 == 0 ? baseWindow1 : (increment - 1) % 3 == 0 ? baseWindow2 : baseWall;
                    go = Instantiate(wallPiece, _normalizedVector * i + new Vector3(b.x, increment * 0.5f, a.y) + new Vector3(b.x - a.x, 0, 0).normalized * 0.5f, Quaternion.LookRotation(new Vector3(b.x - a.x, 0, 0), Vector3.up));
                    mh.floorData.AddGO(go);
                    //go.GetComponent<MeshRenderer>().material = building.matList[3];
                }
            }
            increment += 1;
        }
    }
}
