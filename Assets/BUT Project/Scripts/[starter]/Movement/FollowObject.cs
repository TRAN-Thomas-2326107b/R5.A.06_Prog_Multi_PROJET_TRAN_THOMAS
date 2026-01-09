using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform m_Player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = m_Player.position;
    }
}
