using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] 
    private Transform player;   
    
    [SerializeField] 
    private float chaseRange = 10f;  

    [SerializeField] 
    private float moveSpeed = 3.5f;  

    [SerializeField] 
    private float stopDistance = 0.1f; 

    private Animator animator;                        

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange && distanceToPlayer > stopDistance)
        {
            
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.LookAt(player); 
            animator.SetBool("isWalking", true); 
        }
        else if (distanceToPlayer <= stopDistance)
        {

            animator.SetBool("isWalking", false);
            animator.SetTrigger("Attack");
        }
        else
        {
            
            animator.SetBool("isWalking", false);
        }
    }
}
