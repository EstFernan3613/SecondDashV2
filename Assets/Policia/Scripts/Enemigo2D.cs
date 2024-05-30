using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{
  
     public float speed = 5f; // Velocidad de movimiento del enemigo
    public Transform player; // Referencia al transform del jugador
    private Animator animator;
    private bool isChasing = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            animator.SetBool("estaCazando", isChasing);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
            animator.SetBool("estaCazando", isChasing);
        }
    }

    private void Update()
    {
        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // Ajusta la rotación del enemigo para que mire hacia el jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Mueve al enemigo hacia el jugador
            transform.position += direction * speed * Time.deltaTime;
        }
    }


}
