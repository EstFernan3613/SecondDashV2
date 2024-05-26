using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{


    [SerializeField] private GameObject marcaDialogo;
    private bool isPlayerRange;
    
    [SerializeField] private TMP_Text dialogoTexto;
 
    [SerializeField] private GameObject dialogoPanel;


    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;
    // Start is called before the first frame update

    private bool elDialogoInicio;
    private int numeroLinea;

    private float tiempoEscritura = 0.05f;

    void Update()
    {
        if(isPlayerRange && Input.GetKeyDown(KeyCode.M))
        {
            if(!elDialogoInicio)
            {
                IniciarDialogo();
            }
            else if(dialogoTexto.text == lineasDialogo[numeroLinea])
            {
                SiguienteLineaDialogo();
            }

            else
            {
                StopAllCoroutines();
                dialogoTexto.text = lineasDialogo[numeroLinea];
            }     
        }
    }

    private void IniciarDialogo()
    {
        elDialogoInicio = true;
        dialogoPanel.SetActive(true);
        marcaDialogo.SetActive(false);
        numeroLinea = 0;
        StartCoroutine(MostrarLinea());
    }

    private void SiguienteLineaDialogo()
    {
        numeroLinea++;
        if(numeroLinea < lineasDialogo.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            elDialogoInicio = false;
            dialogoPanel.SetActive(false);
            marcaDialogo.SetActive(true);
        }
    }


    private IEnumerator MostrarLinea()
    {
        dialogoTexto.text = string.Empty;
        foreach(char ch in lineasDialogo[numeroLinea])
        {
            dialogoTexto.text += ch;
            yield return new WaitForSeconds(tiempoEscritura);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {

            marcaDialogo.SetActive(true);
            isPlayerRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            marcaDialogo.SetActive(false);
            isPlayerRange = false; 
        }
        
    }



}
