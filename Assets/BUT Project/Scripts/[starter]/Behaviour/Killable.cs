using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Killable : MonoBehaviour
{
    [Header("Respawn")]
    public bool useRespawn = true;
    public Transform respawnPoint;

    public void Kill()
    {
        Debug.Log(gameObject.name + " est mort");

        if (useRespawn && respawnPoint != null)
        {
            Respawn();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        transform.position = respawnPoint.position;

        if (cc != null)
            cc.enabled = true;
    }
}