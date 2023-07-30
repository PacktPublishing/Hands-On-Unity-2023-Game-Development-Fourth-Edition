using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Update()
    {
        if(PlayerManager.instance == null) return;

        var playerPos = PlayerManager.instance.transform.position;
        transform.forward = playerPos - transform.position;
    }
}