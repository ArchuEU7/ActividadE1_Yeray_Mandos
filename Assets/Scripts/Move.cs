
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject MuerteP;
    public TextMeshProUGUI textoMP;

    [SerializeField] float speed = 5f;
    [SerializeField] float tiempoReinicio = 3f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private bool terminado = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        MuerteP.SetActive(false);
        textoMP.gameObject.SetActive(false);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!terminado)
        {
            rb.linearVelocity = movement * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !terminado)
        {
            terminado = true;

            MuerteP.SetActive(true);
            textoMP.gameObject.SetActive(true);

            Invoke(nameof(muerteups), tiempoReinicio);
        }
    }

    public void muerteups()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
