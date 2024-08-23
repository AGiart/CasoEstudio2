using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField]
    Vector3 rotation;

    [SerializeField]
    float speed;

    private void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
