using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapelessController : MonoBehaviour
{
    public TowerMathHelperClass mh;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * mh.speed * Time.deltaTime / mh.baseSpeed, Space.World);

        if(player != null)
            if(gameObject.transform.position.y > player.transform.position.y - 0.23f)
                player.GetComponent<Character>().Die();
    }
}
