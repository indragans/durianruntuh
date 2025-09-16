using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongObject : MonoBehaviour
{
    private GameManager GM;   // tidak perlu drag di Inspector
    private Transform tr;
   

    void Start()
    {
        tr = GetComponent<Transform>();
        GM = FindObjectOfType<GameManager>(); // otomatis cari GameManager di scene
    }

    
    void FixedUpdate()
    {
        // Gerakin object turun
        tr.position -= new Vector3(0f, 3f * Time.fixedDeltaTime, 0f);
        if (tr.position.y < -7f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah tabrakan dengan Basket
        if (collision.CompareTag("Basket"))
        {
            Destroy(gameObject);
            if (GM != null)
            {
                GM.TriggerGameOver(); // Panggil GameOver di GameManager
            }
        }
    }
}
