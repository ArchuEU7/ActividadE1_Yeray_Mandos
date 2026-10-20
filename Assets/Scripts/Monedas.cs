
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monedas : MonoBehaviour
{
    public GameObject MuerteP;
    public TextMeshProUGUI scoreTexto;
    public TextMeshProUGUI victoriaT;
    [SerializeField] float tiempoReinicio = 3f;
    [SerializeField] GameObject PauseButton;

    private int score = 0;
    private bool objetivoCompletado = false;

    private void Start()
    {
        MuerteP.SetActive(false);
        ActualizarScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda") && !objetivoCompletado)
        {
            Destroy(other.gameObject);

            score++;
            ActualizarScore();

            if (score >= 3)
            {
                objetivoCompletado = true;
                MuerteP.SetActive(true);
                scoreTexto.gameObject.SetActive(false);
                victoriaT.gameObject.SetActive(true);
                Invoke(nameof(ganastelol), tiempoReinicio);
                PauseButton.SetActive(false);
            }
        }
    }

    private void ActualizarScore()
    {
        scoreTexto.text = " " + score;
    }

    public void ganastelol()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex

        );
    }
}
