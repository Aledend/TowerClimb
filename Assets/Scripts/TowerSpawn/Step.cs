using UnityEngine;

public class Step : MonoBehaviour
{
    public void Kill()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.transform.rotation = Random.rotation;
        Destroy(gameObject, 2);
    }
}
