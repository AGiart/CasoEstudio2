using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniMapController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    private void LateUpdate()
    {
        transform.position = 
            new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
