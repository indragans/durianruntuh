using UnityEngine;

public class CorrectObject : MonoBehaviour
{
    public GameManager GM;
    public int points = 10;   // Normal=10, Emas=50
    private Transform tr;

    void Start()
    {
        tr = transform;
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 3f * Time.fixedDeltaTime, 0f);
        if (tr.position.y < -7f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket"))
        {
            Destroy(gameObject);
            GM.ScoreAdd(points);
        }
    }
}
