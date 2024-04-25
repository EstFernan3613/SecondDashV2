using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    public void cambiarNivel(string nombre)
    {
        SceneManager.LoadScene(nombre);

    }

    public void Salir()
    {
        Debug.Log("Salir ...");
        Application.Quit();
    }


}
