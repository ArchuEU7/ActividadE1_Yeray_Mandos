
using UnityEngine;
using TMPro;

public class Monedas : MonoBehaviour
{
    public GameObject MuerteP;
    public TextMeshProUGUI scoreTexto;

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
            }
        }
    }

    private void ActualizarScore()
    {
        scoreTexto.text = "Score: " + score;
    }
}
