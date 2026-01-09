using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public AudioClip collectSound;
    public float rotationSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        CoinCounter counter = other.GetComponent<CoinCounter>();
        if (counter == null) return;

        counter.AddCoins(value);

        AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
