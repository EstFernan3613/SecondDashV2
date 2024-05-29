using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float vidaDuracion = 2f; // Duración antes de destruir la bala
    public float pushForce = 5f;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.2f;

    private Rigidbody2D rb;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    private Color originalColor; // Almacenar el color original del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidad;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        originalColor = playerSpriteRenderer.color; // Guardar el color original del jugador

        Destroy(gameObject, vidaDuracion); // Destruir la bala después de un tiempo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reducir la vida del jugador
            GameManager.Instance.perderVida();

            // Empujar al jugador hacia atrás
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

            // Cambiar el color del jugador temporalmente

            Destroy(gameObject); // Destruir la bala al impactar
        }
    }

 
}
