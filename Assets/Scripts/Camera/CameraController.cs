using UnityEngine;

public class CameraController : MonoBehaviour
{
    public TowerMathHelperClass mh;
    Vector3 newPos;
    float deltaSpeed;
    float tick = 0;

    // Set camera starting values
    void Start()
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(((new Vector3(mh.towerWidth * 0.5f, 0.4f, -mh.towerWidth * 0.5f)) - gameObject.transform.position)), 100000);
    }

    void Update()
    {
        if (mh.playerAlive)
            UpdateCamera();
        else
            FollowPlayer();
    }

    // Update camera position and rotation in relation to the player
    void UpdateCamera()
    {
        deltaSpeed = (mh.speed / mh.baseSpeed) * Time.deltaTime;

        newPos = new Vector3(mh.playerPos.x * 1.8f / Mathf.Log10(mh.towerWidth), mh.playerIndex * 0.5f + 1.2f + (mh.jumpTick * 2), mh.playerPos.z * 1.8f / Mathf.Log10(mh.towerWidth));
        gameObject.transform.Translate(new Vector3((newPos.x - gameObject.transform.position.x) * (deltaSpeed*2), (newPos.y - gameObject.transform.position.y) * deltaSpeed, (newPos.z - gameObject.transform.position.z) * (deltaSpeed*2)), Space.World);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(new Vector3(mh.playerPos.x, mh.playerBasePos.y + mh.jumpTick / 0.5f, mh.playerPos.z) - gameObject.transform.position), deltaSpeed*2);
    }

    // Camera stands still and rotates towards the player on loss.
    void FollowPlayer()
    {
        tick += Time.deltaTime;
        deltaSpeed = (mh.speed / mh.baseSpeed) * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(new Vector3(mh.playerPos.x, mh.playerPos.y - (7f * Mathf.Pow(tick, 2)), mh.playerPos.z) - gameObject.transform.position), deltaSpeed * 100);
    }
}
