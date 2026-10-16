
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatMovilUp : MonoBehaviour
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
        float offset = (1f - Mathf.Cos(elapsedTime * speed)) * 0.5f * distance;

        Vector2 targetPosition =
            startPosition + Vector2.up * offset;

        rb.MovePosition(targetPosition);
    }
}

