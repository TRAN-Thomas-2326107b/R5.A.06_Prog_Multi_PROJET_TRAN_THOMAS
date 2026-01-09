using UnityEngine;

public class OnTriggerKill : MonoBehaviour
{
    [SerializeField] private float stompTolerance = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        Killable victim = other.GetComponent<Killable>();
        if (victim == null)
            return;

        Transform victimRoot = other.transform.root;

        float victimBottomY = victimRoot.position.y;

        CharacterController cc = victimRoot.GetComponent<CharacterController>();
        if (cc != null)
        {
            victimBottomY = victimRoot.position.y + cc.center.y - cc.height * 0.5f;
        }
        else
        {
            Collider col = victimRoot.GetComponent<Collider>();
            if (col != null)
                victimBottomY = col.bounds.min.y;
        }

        float thisTopY = GetComponent<Collider>().bounds.max.y;

        if (victimBottomY > thisTopY - stompTolerance)
            return;

        victim.Kill();
    }
}
