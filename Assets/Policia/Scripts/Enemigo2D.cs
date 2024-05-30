using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("PersonajeOfi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
