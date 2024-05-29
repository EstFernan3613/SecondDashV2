using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeteccion : MonoBehaviour
{
    public Transform player;
    public PanelController panelController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panelController.SetPlayerDetected(true);
            Debug.Log("Player detected");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panelController.SetPlayerDetected(false);
            Debug.Log("Player exited detection zone");
        }
        else if (other.CompareTag("InvisiblePlayer"))
        {
            panelController.SetPlayerDetected(false);
            Debug.Log("Invisible Player exited detection zone");
        }
    }
}
