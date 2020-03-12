using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerMathHelper", menuName = "Scripts/Math Helpers/TowerMathHelper")]
public class TowerMathHelperClass : ScriptableObject
{
    public StepDataClass stepData;
    public FloorDataClass floorData;
    public Slider slider;
    public Text towerWidthValueText;
    GameObject go;
    Renderer rend;

    public GameObject blueBox, greenBox, redBox, yellowBox, baseWall, baseWindow1, baseWindow2, baseDoor1, baseDoor2;

    //Tower Generation Variables
    [System.NonSerialized]
    public int towerWidth = 14;
    [System.NonSerialized]
    public int score = 0;
    [System.NonSerialized]
    int stepXPos, stepZPos, stepXOffset = -1, stepZOffset = 0, stepXDirection = 1, stepZDirection = -1;
    [System.NonSerialized]
    public List<GameObject> stepList = new List<GameObject>();
    private Vector3 wallScale = new Vector3(1, 0.5f, 1);

    //Environment generator
    public EnvironmentGeneration eg;

    //Math helper variables
    [System.NonSerialized]
    public float speed = 4, baseSpeed = 4, jumpTick;
    [System.NonSerialized]
    public List<string> inputQueue = new List<string>();
    [System.NonSerialized]
    public Vector3 playerPos, playerBasePos;
    [System.NonSerialized]
    public int floorIndex = 0, playerIndex = -1, wallPieces = 0;
    [System.NonSerialized]
    public bool playerAlive = true;
    [System.NonSerialized]
    public bool evenWidth;


    public void Prepare()
    {
        // Set starting position with respect to towerWidth
        stepXPos = (int)((towerWidth - (towerWidth % 2)) * 0.5f);
        stepZPos = -stepXPos;
        evenWidth = towerWidth % 2 == 0 ? true : false;
    }
    
    public void CreateStep()
    {
        // Change direction in which the steps grows on the XZ-plane
        if (floorIndex % (towerWidth - 1) == 0)
        {
            if (stepXOffset == 0)
            {
                stepXOffset -= stepXDirection;
                stepXDirection *= -1;
            }
            else
            {
                stepXOffset -= stepXOffset;
            }
            if (stepZOffset == 0)
            {
                stepZOffset -= stepZDirection;
                stepZDirection *= -1;
            }
            else
            {
                stepZOffset -= stepZOffset;
            }
        }

        // Increment position with respect to direction
        stepXPos += stepXOffset;
        stepZPos += stepZOffset;

        // Change material of step
        //rend = go.GetComponent<Renderer>();
        int rnd = Random.Range(0, 64);
        rnd %= 4;
        stepData.order.Add(stepData.materials[rnd].name);
        
        //rend.material = stepData.materials[rnd];



        // Create and position step
        switch (rnd)
        {
            case 0:
                go = Instantiate(blueBox);
                break;
            case 1:
                go = Instantiate(greenBox);
                break;
            case 2:
                go = Instantiate(redBox);
                break;
            case 3:
                go = Instantiate(yellowBox);
                break;
        }

        go.AddComponent<Step>();
        go.transform.position = new Vector3(stepXPos, floorIndex * 0.5f, stepZPos);
        //go.transform.localScale = stepScale;

        
        // Add step to list of floor game objects
        floorData.AddGO(go);
        // Add step to list of steps
        stepList.Add(go);
    }

    public void GenerateTowerFloor()
    {
        // Set starting position with respect to towerWidth
        int towerXPos = (int)(((towerWidth - 2) - ((towerWidth-2) % 2)) * 0.5f);
        int towerZPos = -towerXPos;
        // Generate floor
        for (int i = 0, towerXOffset = 1, towerZOffset = 0, towerXDirection = 1, towerZDirection = -1; i < (towerWidth-2) * 4 - 4; i++)
        {
            // Change direction in which the walls grow on the XZ-plane
            if(i % (towerWidth - 3) == 0)
            {
                if(towerXOffset == 0)
                {
                    towerXOffset -= towerXDirection;
                    towerXDirection *= -1;

                    if ((floorIndex) % 3 == 0)
                        go = Instantiate(baseWindow1);
                    else if ((floorIndex - 1) % 3 == 0)
                        go = Instantiate(baseWindow2);
                    else
                        go = Instantiate(baseWall);

                    go.transform.SetPositionAndRotation(new Vector3(towerXPos, floorIndex * 0.5f, towerZPos + towerZDirection * 0.5f), Quaternion.LookRotation(new Vector3(0, 0, -towerXOffset)));
                    floorData.AddGO(go);
                }
                else
                {
                    towerXOffset -= towerXOffset;
                }
                if(towerZOffset == 0)
                {
                    towerZOffset -= towerZDirection;
                    towerZDirection *= -1;

                    if ((floorIndex) % 3 == 0)
                        go = Instantiate(baseWindow1);
                    else if ((floorIndex - 1) % 3 == 0)
                        go = Instantiate(baseWindow2);
                    else
                        go = Instantiate(baseWall);

                    go.transform.SetPositionAndRotation(new Vector3(towerXPos + towerXDirection * 0.5f, floorIndex * 0.5f, towerZPos/* - towerZOffset * 0.5f*/), Quaternion.LookRotation(new Vector3(towerZOffset, 0, 0)));
                    floorData.AddGO(go);
                }
                else
                {
                    towerZOffset -= towerZOffset;
                }
            }

            // Increment position of wall piece with respect to direction
            towerXPos += towerXOffset;
            towerZPos += towerZOffset;

            // Create and position wall piece
            if ((floorIndex) % 3 == 0)
                go = Instantiate(baseWindow1);
            else if ((floorIndex - 1) % 3 == 0)
                go = Instantiate(baseWindow2);
            else
                go = Instantiate(baseWall);
            go.transform.SetPositionAndRotation(new Vector3(towerXPos + towerZOffset * 0.5f, floorIndex * 0.5f, towerZPos - towerXOffset * 0.5f), Quaternion.LookRotation(new Vector3(towerZOffset, 0, -towerXOffset)));

            // Add wall piece to list of floor game objects
            floorData.AddGO(go);
        }
    }

    public void GenerateFirstFloor()
    {
        // Set starting position with respect to towerWidth
        int towerXPos = (int)(((towerWidth - 2) - ((towerWidth - 2) % 2)) * 0.5f);
        int towerZPos = -towerXPos;
        // Generate floor
        while (floorIndex < 3)
        {
            for (int i = 0, towerXOffset = 1, towerZOffset = 0, towerXDirection = 1, towerZDirection = -1; i < (towerWidth - 2) * 4 - 4; i++)
            {
                // Change direction in which the walls grow on the XZ-plane
                if (i % (towerWidth - 3) == 0)
                {
                    if (towerXOffset == 0)
                    {
                        towerXOffset -= towerXDirection;
                        towerXDirection *= -1;

                        
                        if ((floorIndex) % 3 == 0)
                        {
                            go = Instantiate(baseWindow1);
                        }
                        else if ((floorIndex - 1) % 3 == 0)
                        {
                            go = Instantiate(baseWindow2);
                        }
                        else
                        {
                            go = Instantiate(baseWall);
                        }
                        //go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        go.transform.SetPositionAndRotation(new Vector3(towerXPos, floorIndex * 0.5f, towerZPos + towerZDirection * 0.5f), Quaternion.LookRotation(new Vector3(0, 0, -towerXOffset)));
                        //go.transform.localScale = wallScale;
                        floorData.AddGO(go);
                        wallPieces++;
                    }
                    else
                    {
                        towerXOffset -= towerXOffset;
                    }
                    if (towerZOffset == 0)
                    {
                        towerZOffset -= towerZDirection;
                        towerZDirection *= -1;

                        
                        if ((floorIndex) % 3 == 0)
                        {
                            go = Instantiate(baseWindow1);
                        }
                        else if ((floorIndex - 1) % 3 == 0)
                        {
                            go = Instantiate(baseWindow2);
                        }
                        else
                        {
                            go = Instantiate(baseWall);
                        }
                        
                        //go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        go.transform.SetPositionAndRotation(new Vector3(towerXPos + towerXDirection * 0.5f, floorIndex * 0.5f, towerZPos), Quaternion.LookRotation(new Vector3(towerZOffset, 0, 0)));
                        //go.transform.localScale = wallScale;
                        floorData.AddGO(go);
                        wallPieces++;
                    }
                    else
                    {
                        towerZOffset -= towerZOffset;
                    }
                }

                // Increment position of wall piece with respect to direction
                towerXPos += towerXOffset;
                towerZPos += towerZOffset;

                
                //Check if even amount of width
                if (towerWidth % 2 == 0)
                {
                    if ((wallPieces == (towerWidth - 2) * 0.5f))
                    {
                        go = Instantiate(baseDoor1);
                    }
                    else if (wallPieces == (towerWidth - 2) * 0.5f + (towerWidth - 2) * 4)
                    {
                        go = Instantiate(baseDoor2);
                    }
                    else if ((floorIndex) % 3 == 0)
                    {
                        go = Instantiate(baseWindow1);
                    }
                    else if ((floorIndex - 1) % 3 == 0)
                    {
                        go = Instantiate(baseWindow2);
                    }
                    else
                    {
                        go = Instantiate(baseWall);
                    }

                }
                else
                {
                    if (wallPieces == (towerWidth - 3) * 0.5f)
                    {
                        go = Instantiate(baseDoor1);
                    }
                    else if (wallPieces == (towerWidth - 3) * 0.5f + (towerWidth - 2) * 4)
                    {
                        go = Instantiate(baseDoor2);
                    }
                    else if ((floorIndex) % 3 == 0)
                    {
                        go = Instantiate(baseWindow1);
                    }
                    else if ((floorIndex - 1) % 3 == 0)
                    {
                        go = Instantiate(baseWindow2);
                    }
                    else
                    {
                        go = Instantiate(baseWall);
                    }
                }


                go.transform.SetPositionAndRotation(new Vector3(towerXPos + towerZOffset * 0.5f, floorIndex * 0.5f, towerZPos - towerXOffset * 0.5f), Quaternion.LookRotation(new Vector3(towerZOffset, 0, -towerXOffset)));


                // Create and position wall piece
                //go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                //go.transform.SetPositionAndRotation(new Vector3(towerXPos + towerZOffset * 0.5f, floorIndex * 0.5f, towerZPos - towerXOffset * 0.5f), Quaternion.LookRotation(new Vector3(-towerZOffset, 0, towerXOffset)));
                //go.transform.localScale = wallScale;

                // Add wall piece to list of floor game objects
                floorData.AddGO(go);
                wallPieces++;
            }
            CreateStep();
            floorData.SaveFloor();
            IncrementFloor();
        }
    }

    public void IncrementFloor()
    {
        floorIndex++;
    }

    public void UpdateTowerWidth()
    {
        towerWidth = (int)(slider.value - (slider.value % 2));
        towerWidthValueText.text = towerWidth.ToString();
    }
}
