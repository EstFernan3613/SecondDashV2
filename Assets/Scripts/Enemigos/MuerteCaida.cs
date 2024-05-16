using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCaida : MonoBehaviour
{
    public GameObject MenuDeath;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            MenuDeath.SetActive(true);
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
    }
 
}
