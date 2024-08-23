using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    string target;

    [SerializeField]
    float damage;

    [SerializeField]
    bool selfDestruct;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(target))
        {
            if (selfDestruct)
            {
                Destroy(gameObject);
            }
        }
    }
}
