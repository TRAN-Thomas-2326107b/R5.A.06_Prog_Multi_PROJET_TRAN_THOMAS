using UnityEngine;
using TMPro;

public class FriendlySnowman : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private int cost = 10;

    [Header("Target")]
    [SerializeField] private Killable giantSnowman;

    [Header("UI")]
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private string notEnoughText = "Pas assez de pièces !";

    private CoinCounter playerCounter;
    private bool playerInside;

    private void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerCounter = other.transform.root.GetComponent<CoinCounter>();
        if (playerCounter == null) return;

        playerInside = true;

        if (interactText != null)
            interactText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!playerInside) return;

        if (other.transform.root.GetComponent<CoinCounter>() != playerCounter)
            return;

        playerInside = false;
        playerCounter = null;

        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!playerInside || playerCounter == null)
            return;

        if (Input.GetKeyDown(interactKey))
        {
            if (playerCounter.SpendCoins(cost))
            {
                if (interactText != null)
                    interactText.gameObject.SetActive(false);

                if (giantSnowman != null)
                {
                    giantSnowman.useRespawn = false;
                    giantSnowman.Kill();
                }
            }
            else
            {
                if (interactText != null)
                {
                    interactText.text = notEnoughText;
                    CancelInvoke();
                    Invoke(nameof(ResetText), 1.5f);
                }
            }
        }
    }

    private void ResetText()
    {
        if (interactText != null)
            interactText.text = $"Appuie sur E ({cost} pièces)";
    }
}
