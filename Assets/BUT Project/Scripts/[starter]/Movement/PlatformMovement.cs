using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 1f; 

    private Vector3 target;
    private float waitTimer;

    private void Start()
    {
        if (pointA != null)
        {
            transform.position = pointA.position;
            target = pointB.position;
        }
    }

    private void Update()
    {
        if (pointA == null || pointB == null)
            return;

        
        if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            waitTimer = waitTime;

            target = (target == pointA.position)
                ? pointB.position
                : pointA.position;
        }
    }
}
