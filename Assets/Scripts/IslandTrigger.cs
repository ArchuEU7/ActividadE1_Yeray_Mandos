using UnityEngine;

public class IslandTrigger : MonoBehaviour
{
    [SerializeField] private float gravedadCaer = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null) return;

        // El jugador está dentro de la isla
        rb.gravityScale = 0f;

        // Detener la caída vertical
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            0f
        );
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null) return;

        // El jugador salió de la isla
        rb.gravityScale = gravedadCaer;
    }
}