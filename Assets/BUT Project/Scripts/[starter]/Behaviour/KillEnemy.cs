using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float volume = 1.5f;

    private Transform enemyRoot;

    private void Awake()
    {
        enemyRoot = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("Player"))
            return;

        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, enemyRoot.position, volume);

        Destroy(enemyRoot.gameObject);
    }
}
