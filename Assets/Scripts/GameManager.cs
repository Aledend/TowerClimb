using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public TowerMathHelperClass mh;
    public TowerSpawn towerSpawn;
    public SceneController sceneController;

    private readonly float charDimension = 0.4f;

    public delegate void Del();
    public List<Del> functionList = new List<Del>();
    List<Del> tempList = new List<Del>();
    public Text infoText;
    public EnvironmentGeneration testEG;
    public Text loadingScreenPercentage;
    public List<RawImage> loadingBarList = new List<RawImage>();
    public GameObject loadingScreen;
    public GameObject menu;
    public Slider slider;
    public Text towerWidthValueText;


    void Start()
    {
        mh.slider = slider;
        mh.towerWidthValueText = towerWidthValueText;
        testEG.infoText = infoText;
        
	}
	
	// Accelerate game pace
	void Update () {

        tempList = new List<Del>(functionList);
        foreach (Del f in tempList)
            f();
        
    }

    void UpdateLoadingScreenPercentage()
    {
        if ((float)mh.floorIndex / (mh.playerIndex + mh.towerWidth * 2) < 1)
        {
            loadingScreenPercentage.text =(Mathf.Round((float)mh.floorIndex / (mh.playerIndex + mh.towerWidth * 2) * 100)).ToString() + "%";
            for(int i = 0; i <= Mathf.FloorToInt((float)mh.floorIndex / (mh.playerIndex + mh.towerWidth * 2) * 20); i++)
                loadingBarList[i].enabled = true;
        }
        else
        {
            functionList.Remove(UpdateLoadingScreenPercentage);
        }
    }

    void DestroyLoadingScreen()
    {
        Destroy(loadingScreen);
    }
    
    public void StartGame()
    {
        mh.Prepare();
        loadingScreenPercentage.text = (mh.floorIndex / (mh.playerIndex + mh.towerWidth * 2)).ToString();
        towerSpawn.Prepare();
        functionList.Add(UpdateLoadingScreenPercentage);
        functionList.Add(towerSpawn.Loop);
        functionList.Add(IncreaseSpeed);
        Destroy(menu);
    }

    void IncreaseSpeed()
    {
        mh.speed += 0.05f * Time.deltaTime;
    }
}
