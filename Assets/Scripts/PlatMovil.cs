
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatMovil : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private float elapsedTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        // Se mueve desde la posición inicial hacia la derecha
        // y regresa continuamente.
        float offset = Mathf.PingPong(elapsedTime * speed, distance);

        Vector2 targetPosition =
            startPosition + Vector2.right * offset;

        rb.MovePosition(targetPosition);
    }
}

