using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    public Vector2 maximo;
    public Vector2 minimo;
    public float suavizado;
    Vector2 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX, minimo.x, maximo.x), Mathf.Clamp(posY, minimo.y, maximo.y), transform.position.z);
    }
}
