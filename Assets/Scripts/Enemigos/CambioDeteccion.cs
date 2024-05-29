using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (other.CompareTag("Player") || other.CompareTag("InvisiblePlayer"))
        {
            panelController.SetPlayerDetected(false);
        }
    }
}
