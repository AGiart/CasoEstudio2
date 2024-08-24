using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableController : MonoBehaviour
{
    [SerializeField]
    private float vida = 100f;  

    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.SetMaxHealth(vida);
        }
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;  

        if (healthController != null)
        {
            healthController.DecreaseHealth(damage); 
        }

        if (vida <= 0) 
        {

            Destroy(gameObject);
        }
        

    }
}
