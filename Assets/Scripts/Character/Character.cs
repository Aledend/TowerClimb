using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool jumping = false;
    public float jumpTick;
    public TowerMathHelperClass mh;
    public SceneController sceneController;
    
    // Variables needed for player movement when jumping
    float xPos, zPos, yPos, xPosBase, zPosBase, yPosBase;
    int xOffset = 1, zOffset = 0, xDirection = 1, zDirection = -1;

    public delegate void Del();
    List<Del> functionList = new List<Del>();
    List<Del> functionTempList = new List<Del>();

    void Start()
    {
        //Initiate values
        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;
        yPos = gameObject.transform.position.y;
        xPosBase = xPos;
        zPosBase = zPos;
        yPosBase = yPos - 0.3f;
        
        functionList.Add(InputListener);
        functionList.Add(FirstJump);
        functionList.Add(UpdatePlayerPos);
    }

    void Update()
    {
        Debug.Log(mh.playerIndex);
        
        //InputListener();
        //Control what is updated through methods
        functionTempList = new List<Del>(functionList);
        foreach (Del f in functionTempList)
            f();
    }

    // Update following values in TowerMathHelperClass
    void UpdatePlayerPos()
    {
        mh.playerPos = new Vector3(xPos, yPos, zPos);
        mh.playerBasePos = new Vector3(xPosBase, yPosBase, zPosBase);
        mh.jumpTick = jumpTick;
    }


    // Change jump direction at corners
    void JumpDirection()
    {
        if (mh.playerIndex % (mh.towerWidth - 1)  == 0)
        {
            if(xOffset == 0)
            {
                xOffset -= xDirection;
                xDirection *= -1;
            }
            else
                xOffset -= xOffset;
            if (zOffset == 0)
            {
                zOffset -= zDirection;
                zDirection *= -1;
            }
            else
                zOffset -= zOffset;
        }
    }

    // Perform Jump
    void Jumping()
    {
        // Change position (Jump location + Expression)
        xPos = xPosBase + Mathf.Sin((jumpTick * 4 * (Mathf.PI)) / 2) * xOffset;
        zPos = zPosBase + Mathf.Sin((jumpTick * 4 * (Mathf.PI)) / 2) * zOffset;
        yPos = yPosBase + Mathf.Sin((jumpTick * 4 * (5 * Mathf.PI)) / 6) + 0.2f;

        // Increase the variable used in expressions above.
        jumpTick += 0.75f * (mh.speed / mh.baseSpeed) * Time.deltaTime;
        jumpTick.Round(2);
        if (jumpTick > 0.25)
        {
            jumpTick = 0.25f;
            jumping = false;
            JumpEnd();
        }
        gameObject.transform.position = new Vector3(xPos, yPos, zPos);
    }

    void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            mh.inputQueue.Add("RedStep");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            mh.inputQueue.Add("GreenStep");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            mh.inputQueue.Add("BlueStep");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            mh.inputQueue.Add("YellowStep");
        }
        // Initiate jump
        if(!jumping && mh.inputQueue.Count > 0)
        {
            jumping = true;
            mh.playerIndex++;
            JumpDirection();
            functionList.Add(Jumping);

            // Remove last step
            if(mh.playerIndex > 0)
            { 
                mh.stepList[0].GetComponent<Step>().Kill();
                mh.stepList.RemoveAt(0);
            }
        }
    }

    void JumpEnd()
    {
        // Run through last iteration of jump
        xPos = xPosBase + Mathf.Sin((jumpTick * 4 * (Mathf.PI)) / 2) * xOffset;
        zPos = zPosBase + Mathf.Sin((jumpTick * 4 * (Mathf.PI)) / 2) * zOffset;
        yPos = yPosBase + Mathf.Sin((jumpTick * 4 * (5 * Mathf.PI)) / 6) + 0.2f;

        xPosBase = xPos;
        zPosBase = zPos;
        yPosBase = yPos - 0.2f;
        jumpTick = 0;

        // Check if block matches input
        if (mh.stepData.order[0] == mh.inputQueue[0])
        {
            mh.score++;
            sceneController.infoText.text = "Score: " + mh.score.ToString();
            sceneController.infoText.color = Color.white;
            mh.stepData.order.RemoveAt(0);
            mh.inputQueue.RemoveAt(0);
        }
        else
        {
            // Kill player
            mh.inputQueue.Clear();
            Die();
            mh.stepList[0].GetComponent<Step>().Kill();
            mh.stepList.RemoveAt(0);
        }
        functionList.Remove(Jumping);  
    }

    // Disables player input and kills
    public void Die()
    {
        functionList.Remove(InputListener);
        gameObject.AddComponent<Rigidbody>();
        gameObject.transform.rotation = Random.rotation;
        mh.playerAlive = false; 
        Destroy(gameObject, 2);
    }

    void FirstJump()
    {
        if(mh.inputQueue.Count > 0)
        {
            sceneController.ResumeUpdate();
            gameObject.GetComponent<Transform>().transform.rotation = Quaternion.Euler(Vector3.zero);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0, 0.23f, 0);
            functionList.Add(FixPosition);
            functionList.Remove(FirstJump);
        }
    }
    void FixPosition()
    {
        if (!jumping)
        {
            gameObject.transform.position = new Vector3(mh.towerWidth / 2, gameObject.transform.position.y, -mh.towerWidth / 2 + 1);
            functionList.Remove(FixPosition);
        }
    }
}
