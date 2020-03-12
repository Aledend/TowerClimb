using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StepData", menuName = "Scripts/Data/StepData")]
public class StepDataClass : ScriptableObject
{
    
    public Material[] materials;

    // Order in which colors come in steps
    [System.NonSerialized] 
    public List<string> order = new List<string>();

    private void Awake()
    {
        materials = Resources.LoadAll<Material>("Materials/StepColors");
    }
}
