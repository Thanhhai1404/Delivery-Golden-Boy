using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunerChat : MonoBehaviour
{
    public GameObject chatPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chatPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chatPanel.SetActive(false);
        }
    }
}