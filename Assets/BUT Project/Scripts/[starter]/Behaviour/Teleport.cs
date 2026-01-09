using UnityEngine;
using TMPro;

public class PortalInteractTeleporter : MonoBehaviour
{
    [Header("Teleport")]
    [SerializeField] private Transform destination;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private string playerTag = "Player";

    [Header("UI")]
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private string promptText = "Appuie sur E pour te téléporter";

    private Transform playerRoot;
    private CharacterController playerCC;

    private void Start()
    {
        if (interactText != null)
        {
            interactText.text = promptText;
            interactText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag(playerTag)) return;

        playerRoot = other.transform.root;
        playerCC = playerRoot.GetComponent<CharacterController>();

        if (interactText != null)
        {
            interactText.text = promptText;
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerRoot == null) return;
        if (other.transform.root != playerRoot) return;

        playerRoot = null;
        playerCC = null;

        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerRoot == null) return;
        if (destination == null) return;

        if (Input.GetKeyDown(interactKey))
        {
            if (playerCC != null) playerCC.enabled = false;

            playerRoot.position = destination.position;
            playerRoot.rotation = destination.rotation; 

            if (playerCC != null) playerCC.enabled = true;

            if (interactText != null)
                interactText.gameObject.SetActive(false);
        }
    }
}
