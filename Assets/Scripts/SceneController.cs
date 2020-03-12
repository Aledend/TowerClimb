using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public EnvironmentGeneration eg;
    public TowerMathHelperClass mh;
    public FloorDataClass floorData;
    GameObject player;
    GameObject playerMesh;
    GameObject camera;
    Vector3 vector;
    int stage = 0;
    int run = 1;
    float tick = 0;
    float playerJumpValue = 0.0f;
    float shapelessZRot = 0.0f;
    float shapelessMultiplier = 1.0f;
    float cameraMultiplier = 1.0f;
    int playerJumpDirection = 1;
    int playerPathIndex = 0;
    int spherePathIndex = 0;
    int shapelessPathIndex = 0;
    int cameraPathIndex = 2;
    int playerMaterialIndex;
    List<Vector3> shapelessPathList = new List<Vector3>();
    List<Vector3> playerPathList = new List<Vector3>();
    List<Vector3> cameraPathList = new List<Vector3>();
    List<Vector3> spherePathList = new List<Vector3>();
    public GameObject testCam;
    public GameObject enterButton;
    public Text infoText;
    public List<GameObject> controlList = new List<GameObject>();

    public delegate void Del();
    List<Del> functionList = new List<Del>();
    List<Del> functionTempList;
    List<Del> holdUpdateList;


    // Start is called before the first frame update
    public void Prepare()
    {
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f - 18 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 3, -mh.towerWidth * 0.5f - 18));
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f - 18 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 3, -mh.towerWidth * 0.5f - 22));
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f - 8 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 3, -mh.towerWidth * 0.5f - 22));
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f - 8 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.2f, -mh.towerWidth * 0.5f - 12));
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f + 2, 0.2f, -mh.towerWidth * 0.5f - 12));
        shapelessPathList.Add(new Vector3(mh.towerWidth * 0.5f + 2, 0.2f, -mh.towerWidth * 0.5f - 2));
        shapelessPathList.Add(new Vector3(0, 0.2f, 0));

        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10,
            0.01f, -mh.towerWidth * 0.5f - 27));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f,
            -mh.towerWidth * 0.5f - 24));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.14f,
            -mh.towerWidth * 0.5f - 23));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.14f,
            -mh.towerWidth * 0.5f - 21));


        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 20));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 17));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 14));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 5 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.14f, -mh.towerWidth * 0.5f - 13));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - 1 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, -0.14f, -mh.towerWidth * 0.5f - 11));
        for (int i = 0; i < Mathf.Floor((mh.towerWidth - 10) * 0.1f); i++)
        {
            playerPathList.Add(new Vector3(mh.towerWidth * 0.5f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 10 * i, 0.01f, -mh.towerWidth * 0.5f - 10));
            playerPathList.Add(new Vector3(mh.towerWidth * 0.5f + 1 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 10 * i, -0.14f, -mh.towerWidth * 0.5f - 10));
            playerPathList.Add(new Vector3(mh.towerWidth * 0.5f + 3 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 10 * i, -0.14f, -mh.towerWidth * 0.5f - 10));
            playerPathList.Add(new Vector3(mh.towerWidth * 0.5f + 4 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 10 * i, 0.01f, -mh.towerWidth * 0.5f - 10));
        }
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f, 0.01f, -mh.towerWidth * 0.5f - 10));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f, 0.01f, -mh.towerWidth * 0.5f - 4));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f, -0.14f, -mh.towerWidth * 0.5f - 3));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f, -0.14f, -mh.towerWidth * 0.5f - 1));
        playerPathList.Add(new Vector3(mh.towerWidth * 0.5f, 0.01f, -mh.towerWidth * 0.5f));

        cameraPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.5f, -mh.towerWidth * 0.5f - 25));
        cameraPathList.Add(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 12));
        cameraPathList.Add(Vector3.zero);
        cameraPathList.Add(new Vector3(mh.towerWidth * 0.5f - 4 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.5f, -mh.towerWidth * 0.5f - 11));
        cameraPathList.Add(new Vector3(mh.towerWidth * 0.5f + 3, 0.5f, -mh.towerWidth * 0.5f - 11));
        cameraPathList.Add(new Vector3(mh.towerWidth * 0.5f + 3, 0.8f, -mh.towerWidth * 0.5f));

        spherePathList.Add(new Vector3(mh.towerWidth * 0.5f - 18f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 1f, -mh.towerWidth * 0.5f - 27));
        spherePathList.Add(new Vector3(mh.towerWidth * 0.5f - 18f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 1f, -mh.towerWidth * 0.5f - 16));
        spherePathList.Add(new Vector3(mh.towerWidth * 0.5f - 18f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 1f, -mh.towerWidth * 0.5f - 22));
        spherePathList.Add(new Vector3(mh.towerWidth * 0.5f - 3f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 1f, -mh.towerWidth * 0.5f - 22));


        player = new GameObject();
        player.transform.position = new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 27);
        player.name = "player";
        playerMesh = Instantiate(eg.cylinder, Vector3.zero, Quaternion.Euler(-90, 180, 0));
        playerMesh.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        playerMesh.name = "playerMesh";
        playerMesh.transform.parent = player.transform;
        playerMesh.transform.localPosition = Vector3.zero;
        playerMaterialIndex = (Random.Range(0, 5));
        playerMesh.GetComponent<MeshRenderer>().material = eg.characterMaterials[playerMaterialIndex * 3];

        Destroy(testCam);
        camera = new GameObject();
        camera.name = "Main Camera";
        camera.AddComponent<Camera>();
        camera.transform.SetPositionAndRotation(new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.5f, -mh.towerWidth * 0.5f - 25), Quaternion.Euler(10, -180, 0));


        functionList.Add(PlayerJump);
        functionList.Add(PlayerController);
        functionList.Add(SphereController);
        functionList.Add(CutScenePart1);
        functionList.Add(Tick);
        functionList.Add(CheckSkip);
    }

    // Update is called once per frame
    public void Loop()
    {
        functionTempList = new List<Del>(functionList);
        foreach (Del f in functionTempList)
            f();
    }

    void PlayerJump()
    {
        playerJumpValue += Time.deltaTime * playerJumpDirection * run;

        if (playerJumpValue > 0.5f / run)
        {
            playerJumpValue = 0.5f / run - (playerJumpValue - 0.5f / run);
            playerJumpDirection *= -1;
        }
        else if (playerJumpValue < 0)
        {
            playerJumpDirection *= -1;
            playerJumpValue = 0;
        }
        playerMesh.transform.localPosition = new Vector3(0, playerJumpValue, 0);
    }

    void PlayerController()
    {
        
        if (playerPathIndex < playerPathList.Count - 1)
        {
            //Creates a vector between the points and moves the player at one unit per second
            vector = playerPathList[playerPathIndex + 1] - playerPathList[playerPathIndex];
            player.transform.Translate(vector / vector.magnitude * Time.deltaTime, Space.World);


            if ((playerPathList[playerPathIndex + 1] - player.transform.position).magnitude < 0.1f)
            {
                playerPathIndex++;

                if (playerPathIndex == 4)
                {
                    if (functionList.Contains(CameraController))
                    {
                        functionList.Remove(CameraController);
                    }
                }
                else if (playerPathIndex == 9 + Mathf.FloorToInt((mh.towerWidth - 10) * 0.1f) * 4)
                {
                    functionList.Remove(CheckSkip);
                    Destroy(enterButton);
                    infoText.text = "";
                }
                else if (playerPathIndex == 5 && functionList.Contains(CutScenePart1))
                {
                    functionList.Remove(PlayerJump);
                    functionList.Remove(CutScenePart1);
                    functionList.Add(CutScenePart2);
                    functionList.Remove(PlayerController);
                    playerMesh.transform.localPosition = new Vector3(0, 0.1f,0);
                    playerJumpValue = 0;
                    tick = 0;
                }
                else if (playerPathIndex == 5)
                {
                    player.transform.rotation = Quaternion.LookRotation((playerPathList[playerPathIndex + 1] - playerPathList[playerPathIndex]).normalized);
                }
                else if (!(playerPathIndex == playerPathList.Count - 1))
                {
                    player.transform.rotation = Quaternion.LookRotation((playerPathList[playerPathIndex + 1] - playerPathList[playerPathIndex]).normalized);

                }
                else
                {
                    functionList.Remove(PlayerController);
                    functionList.Remove(PlayerJump);
                    HoldUpdate();
                }
            }
        }


    }


    void SphereController()
    {
        if (spherePathIndex < spherePathList.Count - 1)
        {
            vector = spherePathList[spherePathIndex + 1] - spherePathList[spherePathIndex];
            eg.sceneObjectList[4].transform.Translate(vector / vector.magnitude * 1.5f * Time.deltaTime, Space.World);
            eg.sceneObjectList[4].transform.Rotate(new Vector3(vector.normalized.z, -vector.normalized.x, 0) * 60 * Time.deltaTime);
            if ((spherePathList[spherePathIndex + 1] - eg.sceneObjectList[4].transform.position).magnitude < 0.1f)
            {
                spherePathIndex++;
                if (spherePathIndex == 1)
                {
                    functionList.Add(ShapelessController);
                }
                if (playerPathIndex == playerPathList.Count - 1)
                {
                    playerPathIndex = playerPathList.Count;
                }
            }
        }
    }

    void ShapelessController()
    {
        shapelessZRot += 40 * Time.deltaTime;
        if (shapelessPathIndex < shapelessPathList.Count - 1)
        {
            vector = shapelessPathList[shapelessPathIndex + 1] - shapelessPathList[shapelessPathIndex];
            eg.sceneObjectList[5].transform.Translate(vector.normalized * shapelessMultiplier * Time.deltaTime, Space.World);
            if (shapelessPathIndex != 5)
                eg.sceneObjectList[5].transform.rotation = Quaternion.RotateTowards(eg.sceneObjectList[5].transform.rotation, Quaternion.Euler(0, Quaternion.LookRotation(vector).eulerAngles.y, shapelessZRot), 60 * Time.deltaTime);
            else
                eg.sceneObjectList[5].transform.rotation = Quaternion.RotateTowards(eg.sceneObjectList[5].transform.rotation, Quaternion.Euler(-90, 0, shapelessZRot), 60 * Time.deltaTime);
            if ((shapelessPathList[shapelessPathIndex + 1] - eg.sceneObjectList[5].transform.position).magnitude < 0.1f)
            {
                shapelessPathIndex++;
                if (shapelessPathIndex == 3)
                {
                    shapelessMultiplier = 1.35f - (0.12f * Mathf.Floor((mh.towerWidth - 10) * 0.1f));
                }
                if (shapelessPathIndex == shapelessPathList.Count - 3)
                {
                    shapelessMultiplier = 1.8f;
                }
                else if (shapelessPathIndex == shapelessPathList.Count - 1)
                {
                    shapelessPathIndex = shapelessPathList.Count;
                    eg.sceneObjectList[5].AddComponent<ShapelessController>();
                    eg.sceneObjectList[5].GetComponent<ShapelessController>().mh = mh;
                    eg.sceneObjectList[5].GetComponent<ShapelessController>().player = player;
                }
            }
            if (shapelessPathIndex == shapelessPathList.Count - 2)
            {
                if (eg.sceneObjectList[5].transform.localScale.magnitude < 10000)
                {
                    eg.sceneObjectList[5].transform.localScale = eg.sceneObjectList[5].transform.localScale * (1 + Time.deltaTime);
                }
                
            }
        }
        else if (eg.sceneObjectList[5].transform.localScale.magnitude < 10000)
        {
            eg.sceneObjectList[5].transform.localScale = eg.sceneObjectList[5].transform.localScale * (1 + Time.deltaTime);
        }
        else
        {
            Destroy(eg.sceneObjectList[5].GetComponent<ShapelessAnimation>());
            functionList.Remove(ShapelessController);
        }

    }

    void CameraController()
    {
        //Debug.Log((cameraPathList[cameraPathIndex + 1] - camera.transform.position).magnitude);
        if (cameraPathIndex < cameraPathList.Count - 1)
        {
            vector = cameraPathList[cameraPathIndex + 1] - cameraPathList[cameraPathIndex];
            camera.transform.Translate(vector / vector.magnitude * cameraMultiplier * Time.deltaTime, Space.World);
            if ((cameraPathList[cameraPathIndex + 1] - camera.transform.position).magnitude < 0.1f)
            {
                cameraPathIndex++;
                if (cameraPathIndex == cameraPathList.Count - 1)
                {
                    cameraPathIndex = cameraPathList.Count;
                }
            }
        }
    }

    void CutScenePart1()
    {
        if (tick < 2)
        {
            camera.transform.position = player.transform.position + (cameraPathList[1] - cameraPathList[0]).normalized * 2 + Vector3.up * 0.3f * tick;

        }
        else if (tick < 2.5f)
        {
            camera.transform.position = player.transform.position + (cameraPathList[1] - cameraPathList[0]).normalized * 2 + Vector3.up * 0.6f;
        }
        else if (tick < 7f)
        {
            camera.transform.position = player.transform.position + Vector3.up * 0.6f + Vector3.right * 2;
            camera.transform.rotation = Quaternion.LookRotation(eg.sceneObjectList[4].transform.position - camera.transform.position);
        }
        else if (tick < 9)
        {
            camera.transform.position = new Vector3(mh.towerWidth * 0.5f - 5.5f - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.6f, -mh.towerWidth * 0.5f - 17);
            camera.transform.rotation = Quaternion.LookRotation(Vector3.left);

        }
        else if (tick < 11)
        {
            camera.transform.position = new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 17) + new Vector3(-1, 0.6f, 1);
            camera.transform.rotation = Quaternion.LookRotation(player.transform.position - camera.transform.position);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(Vector3.left), 60 * Time.deltaTime);

        }
    }
    void CutScenePart2()
    {
        if (tick < 1)
        {
            playerMesh.GetComponent<MeshRenderer>().material = eg.characterMaterials[playerMaterialIndex * 3 + 1];
            camera.transform.position = player.transform.position + new Vector3(-1, 0.6f, 1);
            camera.transform.rotation = Quaternion.LookRotation(player.transform.position - camera.transform.position);
            //camera.transform.position = new Vector3(mh.towerWidth * 0.5f - 6 - Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10, 0.01f, -mh.towerWidth * 0.5f - 17) + new Vector3(-1, 0.6f, 1);
            //camera.transform.rotation = Quaternion.LookRotation(player.transform.position - camera.transform.position);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(Vector3.left), 60 * Time.deltaTime);
        }
        else if (tick < 2)
        {
            camera.transform.position = eg.sceneObjectList[0].transform.position + new Vector3(1.5f, 0.6f, -1.5f);
            camera.transform.rotation = Quaternion.LookRotation((eg.sceneObjectList[2].transform.position) - camera.transform.position);
        }
        else if (tick < 3)
        {
            eg.sceneObjectList[2].GetComponent<MeshRenderer>().material = eg.characterMaterials[eg.characterMaterialIndex[2] * 3 + 2];
        }
        else if (tick < 4)
        {
            camera.transform.rotation = Quaternion.LookRotation(player.transform.position - camera.transform.position);
            camera.transform.position = player.transform.position + new Vector3(-1, 0.6f, 1);
        }
        else if (tick < 4.2f)
        {
            playerMesh.GetComponent<MeshRenderer>().material = eg.characterMaterials[playerMaterialIndex * 3 + 2];
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(Vector3.back), 60 * Time.deltaTime);
        }
        else if (tick < 12f)
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.LookRotation((camera.transform.position + new Vector3(-3, 0, -5)) - camera.transform.position), 40 * Time.deltaTime);
        }
        else if (tick < 15f)
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.LookRotation(Vector3.back, Vector3.up), 40 * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(Vector3.forward, Vector3.up), 40 * Time.deltaTime);
            if (!functionList.Contains(CameraController))
            {
                functionList.Add(CameraController);
                cameraPathList[2] = camera.transform.position;
            }
        }
        else if (tick < 20 + (Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10))
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.LookRotation(Vector3.left, Vector3.up), 40 * Time.deltaTime);
            if (!functionList.Contains(PlayerController))
            {
                functionList.Add(PlayerController);
                functionList.Add(PlayerJump);
                run = 2;
            }
        }
        else if(tick < 20 + Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 20)
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.LookRotation(player.transform.position - camera.transform.position, Vector3.up), 40 * Time.deltaTime);
            cameraMultiplier = 2.0f;
        }

    }

    void Tick()
    {
        tick += Time.deltaTime;
    }

    void Skip()
    {
        playerPathIndex = 9 + Mathf.FloorToInt((mh.towerWidth - 10) * 0.1f) * 4;
        player.transform.SetPositionAndRotation(new Vector3(mh.towerWidth * 0.5f, 0.01f, -mh.towerWidth * 0.5f - 10), Quaternion.LookRotation(Vector3.forward, Vector3.up));
        shapelessPathIndex = 4;
        shapelessMultiplier = 0.7f;
        eg.sceneObjectList[5].transform.SetPositionAndRotation(new Vector3(mh.towerWidth * 0.5f + 2, 0.2f, -mh.towerWidth * 0.5f - 12), Quaternion.LookRotation(Vector3.forward, Vector3.up));
        cameraPathIndex = 4;
        camera.transform.SetPositionAndRotation(new Vector3(mh.towerWidth * 0.5f + 3, 0.5f, -mh.towerWidth * 0.5f - 11), Quaternion.LookRotation(camera.transform.position - player.transform.position, Vector3.up));
        functionList.Remove(CheckSkip);
        run = 2;
        if (!functionList.Contains(CutScenePart2))
        {
            functionList.Remove(CutScenePart1);
            functionList.Add(CutScenePart2);
        }
        tick = 20 + Mathf.Floor((mh.towerWidth - 10) * 0.1f) * 10 + 10;

        if (!functionList.Contains(CameraController))
            functionList.Add(CameraController);

        if (!functionList.Contains(PlayerController))
            functionList.Add(PlayerController);

        if (!functionList.Contains(ShapelessController))
            functionList.Add(ShapelessController);

        if (!functionList.Contains(PlayerJump))
            functionList.Add(PlayerJump);
        playerMesh.GetComponent<MeshRenderer>().material = eg.characterMaterials[playerMaterialIndex * 3 + 2];

        Destroy(enterButton);
        infoText.text = "";
    }
    void CheckSkip()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Skip();
        }
    }

    void HoldUpdate()
    {
        holdUpdateList = new List<Del>(functionList);
        functionList.Clear();
        player.AddComponent<Character>();
        player.GetComponent<Character>().mh = mh;
        player.GetComponent<Character>().sceneController = this;

        foreach (GameObject go in controlList)
            go.GetComponent<RawImage>().enabled = true;
    }

    public void ResumeUpdate()
    {
        functionList = new List<Del>(holdUpdateList);
        functionList.Remove(CameraController);

        camera.AddComponent<CameraController>();
        camera.GetComponent<CameraController>().mh = mh;
    }
}
