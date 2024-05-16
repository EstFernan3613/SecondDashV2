using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AvisoEscondite : MonoBehaviour
{
    public GameObject texto;
    public bool Adentro1;



    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            texto.SetActive(true);
            Adentro1 = true;
            
        }
    }


    void Update()
    {
        if(Adentro1 == true && Input.GetKeyDown(KeyCode.Z))
        {
            texto.gameObject.SetActive(false);
        }
    }

}
