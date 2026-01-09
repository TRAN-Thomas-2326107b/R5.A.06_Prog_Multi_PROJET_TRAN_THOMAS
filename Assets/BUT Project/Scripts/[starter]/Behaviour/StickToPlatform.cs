using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private Transform platform;

    private void Awake()
    {
        platform = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Transform playerRoot = other.transform.root;
        playerRoot.SetParent(platform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Transform playerRoot = other.transform.root;

        if (playerRoot.parent == platform)
            playerRoot.SetParent(null);
    }
}
