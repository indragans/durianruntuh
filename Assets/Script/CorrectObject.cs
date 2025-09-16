using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectObject : MonoBehaviour
{
    public GameManager GM;
    Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 3f * Time.fixedDeltaTime, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Basket")
        {
            Destroy(this.gameObject);
            GM.ScoreAdd();
        }
    }
}
