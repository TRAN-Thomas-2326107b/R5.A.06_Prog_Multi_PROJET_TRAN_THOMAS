using UnityEngine;

public class GiftEndGame : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("UI")]
    [SerializeField] private GameObject interactText; 
    [SerializeField] private GameObject winPanel;    

    private Transform player;
    private bool finished;

    private void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
        if (interactText != null) interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("Player")) return;

        player = other.transform.root;
        if (!finished && interactText != null) interactText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root != player) return;

        player = null;
        if (interactText != null) interactText.SetActive(false);
    }

    private void Update()
    {
        if (finished || player == null) return;

        if (Input.GetKeyDown(interactKey))
        {
            Finish();
        }
    }

    private void Finish()
    {
        finished = true;

        if (interactText != null) interactText.SetActive(false);
        if (winPanel != null) winPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
