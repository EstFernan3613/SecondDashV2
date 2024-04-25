using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puas : MonoBehaviour
{
// Fuerza del empujón hacia atrás
    public float pushForce = 5f;

    // Color del jugador al chocar con las puas
    public Color hitColor = Color.red;

    // Duración del efecto de cambio de color
    public float hitColorDuration = 0.2f;

    // Referencia al componente Rigidbody2D del jugador
    private Rigidbody2D playerRigidbody;

    // Referencia al componente SpriteRenderer del jugador
    private SpriteRenderer playerSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener referencias a los componentes del jugador
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Reducir la vida del jugador
            GameManager.Instance.perderVida();

            // Empujar al jugador hacia atrás
            Vector2 pushDirection = (other.transform.position - transform.position).normalized;
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

            // Cambiar el color del jugador temporalmente
            StartCoroutine(ChangePlayerColor(hitColor, hitColorDuration));
        }
    }

    IEnumerator ChangePlayerColor(Color targetColor, float duration)
    {
        // Cambiar el color del jugador
        playerSpriteRenderer.color = targetColor;

        // Esperar la duración especificada
        yield return new WaitForSeconds(duration);

        // Restaurar el color original del jugador
        playerSpriteRenderer.color = Color.white; // O el color original del jugador
    }

}
