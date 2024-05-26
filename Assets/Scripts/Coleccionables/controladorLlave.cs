using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controladorLlave : MonoBehaviour
{
   public bool Adentro;
    public Canvas activarCanvas;
    public GameObject llave;
    public Animator puertaAnimator;

    // Referencia al TextMeshProUGUI para mostrar el contador de llaves
    public TextMeshProUGUI contadorLlavesText;

    // Contador de llaves
    private int contadorLlaves = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "InvisiblePlayer")
        {
            Adentro = true;
            Debug.Log("estamos dentro");
            activarCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "InvisiblePlayer")
        {
            Adentro = false;
            Debug.Log("Estamos fuera");
            activarCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(Adentro && Input.GetKeyDown(KeyCode.C))
        {
            Destroy(this.gameObject);
            Debug.Log("llave recogida");

            // Incrementar el contador de llaves
            contadorLlaves++;

            // Actualizar el contador de llaves en el texto
            UpdateLlavesText();

            if (puertaAnimator != null)
            {
                puertaAnimator.SetBool("AbrirPuerta", true);
            }
        }
    }

    // Método para actualizar el texto del contador de llaves
    void UpdateLlavesText()
    {
        if (contadorLlavesText != null)
        {
            contadorLlavesText.text = "Llaves: " + contadorLlaves.ToString();
        }
    }


}
