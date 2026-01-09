using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;

    [Header("Rotation")]
    public float rotationSpeed = 5f;

    [Header("Pause")]
    public float waitTime = 1f;

    int currentPoint = 0;
    bool isWaiting = false;

    void Update()
    {
        if (points.Length == 0 || isWaiting) return;

        Transform target = points[currentPoint];

        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        currentPoint++;
        if (currentPoint >= points.Length)
            currentPoint = 0;

        isWaiting = false;
    }
}

