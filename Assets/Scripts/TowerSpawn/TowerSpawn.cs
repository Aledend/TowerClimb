using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{

    public TowerMathHelperClass mh;
    public SceneController sceneController;

    // Create a delegate list
    public delegate void Del();
    List<Del> floorGenerator = new List<Del>();
    
    // Gather functions to be looped
    public void Prepare () {
        mh.GenerateFirstFloor();
        mh.eg.Generate();
        mh.eg.genBuilding.GenerateFirstFloors();
        floorGenerator.Add(mh.CreateStep);
        floorGenerator.Add(mh.GenerateTowerFloor);
        floorGenerator.Add(mh.eg.genBuilding.GenerateFloors);
        floorGenerator.Add(mh.IncrementFloor);
        floorGenerator.Add(mh.floorData.SaveFloor);
        floorGenerator.Add(CheckIfBeginDestroyFloors);
        floorGenerator.Add(mh.eg.Update);
        floorGenerator.Add(CheckLevelGenerated);
    }
	
	public void Loop () {
        // Keep 17 floors generated above player

        if (mh.floorIndex < mh.playerIndex + mh.towerWidth * 2)
        {
            List<Del> tempList = new List<Del>(floorGenerator);
            foreach (Del f in tempList)
            {
                f();
            }
        }
    }

    public void CheckIfBeginDestroyFloors()
    {
        
        if (mh.playerIndex > 9)
        {
            floorGenerator.Remove(CheckIfBeginDestroyFloors);
            floorGenerator.Add(mh.floorData.DestroyEldestFloor);
        }
    }

    public void CheckLevelGenerated()
    {
        if(mh.floorIndex >= mh.playerIndex + mh.towerWidth * 2)
        {
            floorGenerator.Remove(CheckLevelGenerated);
            gameObject.GetComponent<GameManager>().functionList.Add(sceneController.Loop);
            Destroy(gameObject.GetComponent<GameManager>().loadingScreen);
            sceneController.Prepare();
        }
    }
}
