using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class ShapelessAnimation : MonoBehaviour
{
    float blendShapeValue = 0.0f, min = 0.0f, max = 100.0f;
    int direction = 1;
    [SerializeField]
    SkinnedMeshRenderer smr;
    // Start is called before the first frame update
    void Start()
    {
        smr = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        smr.SetBlendShapeWeight(0, blendShapeValue);
        blendShapeValue += 40f * Time.deltaTime * direction;
        if(blendShapeValue > 100.0f)
        {
            direction *= -1;
            blendShapeValue = 100.0f;
        }
        else if (blendShapeValue < 0)
        {
            direction *= -1;
            blendShapeValue = 0.0f;
        }

        //gameObject.transform.Rotate(new Vector3(0, 0, 40 * Time.deltaTime));
    }

    
}
