using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentGeneration", menuName = "Scripts/Generation/Environment")]
public class EnvironmentGeneration : ScriptableObject
{
    [System.NonSerialized]
    List<GameObject> cloudList = new List<GameObject>();
    [System.NonSerialized]
    GameObject go;
    [System.NonSerialized]
    bool evenWidth;
    [System.NonSerialized]
    public List<int> characterMaterialIndex = new List<int>();
    [System.NonSerialized]
    public List<GameObject> sceneObjectList = new List<GameObject>();

    public Building genBuilding;
    public Sidewalk genSidewalk;
    public Road genRoad;
    public TowerMathHelperClass mh;
    public FloorDataClass floorData;

    public List<Material> blueMaterials = new List<Material>();
    public List<Material> orangeMaterials = new List<Material>();
    public List<Material> characterMaterials = new List<Material>();
    public GameObject cloud;
    public GameObject stroller;
    public GameObject cube;
    public GameObject sphere;
    public GameObject tetrahedron;
    public GameObject cylinder;
    public GameObject shapeless;
    public GameManager testgm;
    public Text infoText;
    

    // Start is called before the first frame update
    public void OnEnable()
    {
       
    }

    public void Generate()
    {
        if (mh.evenWidth)
        {
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f), new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f - 2));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f + 2, mh.towerWidth * 0.5f - 1));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f + 1, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f + 1, -mh.towerWidth * 0.5f + 1));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f + 1, -mh.towerWidth * 0.5f), new Vector2(mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f), new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f - 30));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f - 30), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f - 30));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f-1), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f - 30));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 10));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 4));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 10));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 10), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 10));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 14), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 14));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 20), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 20));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 15), new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 19));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 15), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 19));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 24), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 24));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 30), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 30));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 25), new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 29));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 25), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 29));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 9 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 34), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth* 0.5f - 34));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f + 3, mh.towerWidth * 0.5f + 3));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f + 4), new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f + 8));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f + 9), new Vector2(mh.towerWidth * 0.5f + 9, mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f + 4 + Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(mh.towerWidth * 0.5f + 4, mh.towerWidth* 0.5f +3));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f + 4 + Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f + 4 + Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f + 4 + Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(mh.towerWidth * 0.5f + 10, mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10, mh.towerWidth * 0.5f + 3), new Vector2(-mh.towerWidth * 0.5f - 2, mh.towerWidth * 0.5f + 3));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10, mh.towerWidth * 0.5f + 9), new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 4 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f - 4 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10, mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f + 3));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f - 1));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(-mh.towerWidth * 0.5f - 9, -mh.towerWidth * 0.5f - 4));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(-mh.towerWidth * 0.5f - 3, -mh.towerWidth * 0.5f - 4));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 2, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 4));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 20));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 24), new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 34));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 15 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 20), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 20));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 15 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 24), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 24));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 16 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 19), new Vector2(mh.towerWidth * 0.5f - 16 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 20));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 16 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 24), new Vector2(mh.towerWidth * 0.5f - 16 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 25));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 14, -mh.towerWidth * 0.5f - 5), new Vector2(mh.towerWidth * 0.5f + 14, -mh.towerWidth * 0.5f + 9));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, mh.towerWidth * 0.5f + 13), new Vector2(mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f + 13));
            genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 13, mh.towerWidth * 0.5f + 4), new Vector2(-mh.towerWidth * 0.5f - 13, mh.towerWidth * 0.5f - 10));
            genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 20 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 16), new Vector2(mh.towerWidth * 0.5f - 20 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 28));
            
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 2, -mh.towerWidth * 0.5f), new Vector2(mh.towerWidth * 0.5f + 2, mh.towerWidth * 0.5f + 2));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f, mh.towerWidth * 0.5f + 1), new Vector2(-mh.towerWidth * 0.5f - 2, mh.towerWidth * 0.5f + 1));
            genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f - 1, mh.towerWidth * 0.5f - 1), new Vector2(-mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f - 3));
            genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f + 1, -mh.towerWidth * 0.5f - 2), new Vector2(mh.towerWidth * 0.5f + 3, -mh.towerWidth * 0.5f - 2));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 2, -mh.towerWidth * 0.5f - 4), new Vector2(mh.towerWidth * 0.5f + 2, -mh.towerWidth * 0.5f - 33));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 8, -mh.towerWidth * 0.5f - 1), new Vector2(mh.towerWidth * 0.5f - 8, -mh.towerWidth * 0.5f - 33));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f - 32), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f - 32));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 12), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 12));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 22), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 22));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 6, -mh.towerWidth * 0.5f - 32), new Vector2(mh.towerWidth * 0.5f, -mh.towerWidth * 0.5f - 32));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f + 2), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f + 2));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 2, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f - 2, mh.towerWidth* 0.5f + 9));
            genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - 3), new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - 3));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 12, -mh.towerWidth * 0.5f - 5), new Vector2(mh.towerWidth * 0.5f + 12, -mh.towerWidth * 0.5f + 9));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 5, mh.towerWidth * 0.5f + 11), new Vector2(mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f + 11));
            genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f - 11, mh.towerWidth * 0.5f + 4), new Vector2(-mh.towerWidth * 0.5f - 11, mh.towerWidth * 0.5f - 10));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 16 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 22), new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 22));
            genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 18 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 16), new Vector2(mh.towerWidth * 0.5f - 18 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 28));

            

            //genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f - 5), new Vector2(mh.towerWidth * 0.5f - 5, -mh.towerWidth * 0.5f - 9), orangeMaterials));

            List<Material> matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f - 1), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f - 29), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 5, -mh.towerWidth * 0.5f - 5), new Vector2(mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f - 9), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 5, -mh.towerWidth * 0.5f - 15), new Vector2(mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f - 19), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 5, -mh.towerWidth * 0.5f - 25), new Vector2(mh.towerWidth * 0.5f - 1, -mh.towerWidth * 0.5f - 29), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 10 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 35), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f - 36), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 1, mh.towerWidth * 0.5f + 8), new Vector2(mh.towerWidth * 0.5f + 9, mh.towerWidth * 0.5f + 4), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 5, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f + 5 + Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f + 8), new Vector2(mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10, mh.towerWidth * 0.5f + 4), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f + 8), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 3) * 0.1f) * 10), new Vector2(-mh.towerWidth * 0.5f - 4, -mh.towerWidth * 0.5f - 4), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 3, -mh.towerWidth * 0.5f - 5), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 9), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 15 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 10), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 19), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 15 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 25), new Vector2(mh.towerWidth * 0.5f - 11 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 34), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 15, -mh.towerWidth * 0.5f + 9), new Vector2(mh.towerWidth * 0.5f + 16, -mh.towerWidth * 0.5f - 5), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 5, mh.towerWidth * 0.5f + 15), new Vector2(mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f + 14), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 15, mh.towerWidth * 0.5f + 4), new Vector2(-mh.towerWidth * 0.5f - 14, mh.towerWidth * 0.5f - 10), matList));
            matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
            genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 22 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 16), new Vector2(mh.towerWidth * 0.5f - 21 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -mh.towerWidth * 0.5f - 28), matList));

            for (int i = 0; i < Mathf.Floor((mh.towerWidth - 3) * 0.1f); i++)
            {
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f + i * 10 + 4), new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f + i * 10 + 10));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f + i * 10 + 4), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f + i * 10 + 10));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f + i * 10 + 4), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f + i * 10 + 4));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f + i * 10 + 10), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f + i * 10 + 10));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f + 14, -mh.towerWidth * 0.5f + i * 10 + 19), new Vector2(mh.towerWidth * 0.5f + 14, -mh.towerWidth * 0.5f + i * 10 + 10));
                genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 4, -mh.towerWidth * 0.5f + i * 10 + 12), new Vector2(mh.towerWidth * 0.5f + 10, -mh.towerWidth * 0.5f + i * 10 + 12));
                genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f + 12, -mh.towerWidth * 0.5f + i * 10 + 19), new Vector2(mh.towerWidth * 0.5f + 12, -mh.towerWidth * 0.5f + i * 10 + 10));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 5, -mh.towerWidth * 0.5f + i * 10 + 9), new Vector2(mh.towerWidth * 0.5f + 9, -mh.towerWidth * 0.5f + i * 10 + 5), matList));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f + 16, -mh.towerWidth * 0.5f + i * 10 + 19), new Vector2(mh.towerWidth * 0.5f + 15, -mh.towerWidth * 0.5f + i * 10 + 10), matList));

                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - i * 10 - 4, mh.towerWidth * 0.5f + 4), new Vector2(mh.towerWidth * 0.5f - i * 10 - 4, mh.towerWidth * 0.5f + 8));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 4), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 8));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - i * 10 - 4, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 3));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - i * 10 - 4, mh.towerWidth * 0.5f + 9), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 9));
                genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - i * 10 - 19, mh.towerWidth * 0.5f + 13), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 13));
                genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - i * 10 - 12, mh.towerWidth * 0.5f + 3), new Vector2(mh.towerWidth * 0.5f - i * 10 - 12, mh.towerWidth * 0.5f + 9));
                genRoad.GenerateRoad(new Vector3(mh.towerWidth * 0.5f - i * 10 - 19, mh.towerWidth * 0.5f + 11), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 11));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - i * 10 - 9, mh.towerWidth * 0.5f + 8), new Vector2(mh.towerWidth * 0.5f - i * 10 - 5, mh.towerWidth * 0.5f + 4), matList));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - i * 10 - 19, mh.towerWidth * 0.5f + 15), new Vector2(mh.towerWidth * 0.5f - i * 10 - 10, mh.towerWidth * 0.5f + 14), matList));

                genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - i * 10 - 5), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f - i * 10 - 5));
                genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - i * 10 - 5), new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - i * 10 - 11));
                genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - i * 10 - 5), new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - i * 10 - 11));
                genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - i * 10 - 11), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f - i * 10 - 11));
                genSidewalk.GenerateSidewalk(new Vector2(-mh.towerWidth * 0.5f - 13, mh.towerWidth * 0.5f - i * 10 - 10), new Vector2(-mh.towerWidth * 0.5f - 13, mh.towerWidth * 0.5f - i * 10 - 19));
                genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f - 9, mh.towerWidth * 0.5f - i * 10 - 13), new Vector2(-mh.towerWidth * 0.5f - 3, mh.towerWidth * 0.5f - i * 10 - 13));
                genRoad.GenerateRoad(new Vector2(-mh.towerWidth * 0.5f - 11, mh.towerWidth * 0.5f - i * 10 - 10), new Vector2(-mh.towerWidth * 0.5f - 11, mh.towerWidth * 0.5f - i * 10 - 19));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 8, mh.towerWidth * 0.5f - i * 10 - 6), new Vector2(-mh.towerWidth * 0.5f - 4, mh.towerWidth * 0.5f - i * 10 - 10), matList));
                matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                genBuilding.buildings.Add(new BuildingObject(new Vector2(-mh.towerWidth * 0.5f - 15, mh.towerWidth * 0.5f - i * 10 - 10), new Vector2(-mh.towerWidth * 0.5f - 14, mh.towerWidth * 0.5f - i * 10 - 19), matList));
            }

            for (int i = 0; i < Mathf.Floor((mh.towerWidth - 10) * 0.1f); i++)
            {
                for (int j = 0; j < 3; j++) {
                    genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 15 - i * 10, -mh.towerWidth * 0.5f - 4 - j * 10), new Vector2(mh.towerWidth * 0.5f - 11 - i * 10, -mh.towerWidth * 0.5f - 4 - j * 10));
                    genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 15 - i * 10, -mh.towerWidth * 0.5f - 10 - j * 10), new Vector2(mh.towerWidth * 0.5f - 11 - i * 10, -mh.towerWidth * 0.5f - 10 - j * 10));
                    genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 16 - i * 10, -mh.towerWidth * 0.5f - 4 - j * 10), new Vector2(mh.towerWidth * 0.5f - 16 - i * 10, -mh.towerWidth * 0.5f - 10 - j * 10));
                    genSidewalk.GenerateSidewalk(new Vector2(mh.towerWidth * 0.5f - 10 - i * 10, -mh.towerWidth * 0.5f - 4 - j * 10), new Vector2(mh.towerWidth * 0.5f - 10 - i * 10, -mh.towerWidth * 0.5f - 10 - j * 10));
                    genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 18 - i * 10, -mh.towerWidth * 0.5f - 4 - j * 10), new Vector2(mh.towerWidth * 0.5f - 18 - i * 10, -mh.towerWidth * 0.5f - 13 - j * 10));
                    genRoad.GenerateRoad(new Vector2(mh.towerWidth * 0.5f - 16 - i * 10, -mh.towerWidth * 0.5f - 12 - j * 10), new Vector2(mh.towerWidth * 0.5f - 10 - i * 10, -mh.towerWidth * 0.5f - 12 - j * 10));
                    matList = Random.Range(1, 2) == 1 ? blueMaterials : orangeMaterials;
                    genBuilding.buildings.Add(new BuildingObject(new Vector2(mh.towerWidth * 0.5f - 15 - i * 10, -mh.towerWidth * 0.5f - 5 - j * 10), new Vector2(mh.towerWidth * 0.5f - 11 - i * 10, -mh.towerWidth * 0.5f - 9 - j * 10), matList));
                }
            }



            for (int i = (int)(-2 - mh.towerWidth * 0.05f); i < 4 + mh.towerWidth * 0.05f; i++)
            {
                for (int j = (int)(-4 - mh.towerWidth * 0.05f); j < 2 + mh.towerWidth * 0.05f; j++)
                {
                    GameObject go = Instantiate(cloud, new Vector3(i * 10, 17, j * 10), Quaternion.LookRotation(Vector3.up));
                    cloudList.Add(go);
                }
            }
            
            
            go = Instantiate(stroller, new Vector3(mh.towerWidth * 0.5f - 10.1f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.075f, -mh.towerWidth * 0.5f - 17), Quaternion.Euler(-90,90,90));
            characterMaterialIndex.Add(0);
            mh.floorData.goList.Add(go);
            sceneObjectList.Add(go);

            go = Instantiate(cylinder, new Vector3(mh.towerWidth * 0.5f - 9.65f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 17.37f), Quaternion.Euler(-90, 0, 180));
            go.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            characterMaterialIndex.Add(Random.Range(0, 5));
            go.GetComponent<MeshRenderer>().material = characterMaterials[characterMaterialIndex[1] * 3];
            mh.floorData.goList.Add(go);
            sceneObjectList.Add(go);

            go = Instantiate(tetrahedron, new Vector3(mh.towerWidth * 0.5f - 9.75f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.029f, -mh.towerWidth * 0.5f - 16.4f), Quaternion.Euler(-90, 180, 180));
            characterMaterialIndex.Add(Random.Range(0, 5));
            go.GetComponent<MeshRenderer>().material = characterMaterials[characterMaterialIndex[2] * 3];
            mh.floorData.goList.Add(go);
            sceneObjectList.Add(go);

            go = Instantiate(sphere, new Vector3(mh.towerWidth * 0.5f - 9.6f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.14f, -mh.towerWidth * 0.5f - 17), Quaternion.Euler(-90, 180, 180));
            go.transform.localScale = new Vector3(10f, 10f, 10f);
            characterMaterialIndex.Add(Random.Range(0, 5));
            go.GetComponent<MeshRenderer>().material = characterMaterials[characterMaterialIndex[3] * 3];
            mh.floorData.goList.Add(go);
            sceneObjectList.Add(go);

            go = Instantiate(sphere, new Vector3(mh.towerWidth * 0.5f - 18f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 1f, -mh.towerWidth * 0.5f - 27), Quaternion.Euler(-90, 180, 180));
            go.transform.localScale = new Vector3(150f, 150f, 150f);
            characterMaterialIndex.Add(Random.Range(0, 5));
            go.GetComponent<MeshRenderer>().material = characterMaterials[characterMaterialIndex[4] * 3];
            mh.floorData.goList.Add(go);
            sceneObjectList.Add(go);

            go = Instantiate(shapeless, new Vector3(mh.towerWidth * 0.5f - 18 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 3, -mh.towerWidth * 0.5f - 17), Quaternion.Euler(0, 180, 0));
            go.AddComponent<ShapelessAnimation>();
            characterMaterialIndex.Add(0);
            sceneObjectList.Add(go);
            floorData.shapeless = go;

        }
    }

    public void Update()
    {
        foreach (GameObject go in cloudList)
        {
            go.transform.position = new Vector3(go.transform.position.x, mh.floorIndex * 0.5f, go.transform.position.z);
        }
    }

    private void OnDisable()
    {
        //foreach(GameObject go in roadList)
        //{
        //    Destroy(go);
        //}
        //foreach(GameObject go in SideWalkList)
        //{
        //    Destroy(go);
        //}
    }
}
