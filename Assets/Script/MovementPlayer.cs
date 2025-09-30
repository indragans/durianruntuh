using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    Transform tr;
    Animator anim;
    private Vector3 movement;

    public float limitX = 2f;   // batas kanan-kiri
    public float speed = 10f;   // kecepatan gerak
    

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();   // ambil animator di player
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE   // kalau dijalankan di PC
        HandleKeyboardMovement();
        HandleMouseMovement(); // tambahin kontrol mouse
#elif UNITY_ANDROID || UNITY_IOS       // kalau di Android/iOS
        HandleTouchMovement();
#endif
    }

    // --- FUNGSI UNTUK PC (Keyboard) ---
    void HandleKeyboardMovement()
    {
        float move = 0f;

        if (Input.GetKey("right"))
            move = 1f;
        else if (Input.GetKey("left"))
            move = -1f;

        // geser player
        tr.position += new Vector3(move * speed * Time.deltaTime, 0f, 0f);

        // clamp biar gak keluar batas
        tr.position = new Vector3(Mathf.Clamp(tr.position.x, -limitX, limitX), tr.position.y, tr.position.z);

        // animasi jalan
        anim.SetBool("WalkLeft", move < 0);
        anim.SetBool("WalkRight", move > 0);
    }

    // --- FUNGSI UNTUK PC (Mouse) ---
    void HandleMouseMovement()
    {
        if (Input.GetMouseButton(0)) // klik kiri ditekan
        {
            // ambil jarak z antara kamera dan player
            float zDist = Camera.main.WorldToScreenPoint(tr.position).z;

            Vector3 pos = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDist)
            );

            float targetX = Mathf.Clamp(pos.x, -limitX, limitX);

            // smooth lerp biar halus
            Vector3 newPos = Vector3.Lerp(
                tr.position,
                new Vector3(targetX, tr.position.y, tr.position.z),
                Time.deltaTime * speed
            );

            // update posisi
            tr.position = newPos;

            // animasi
            anim.SetBool("WalkLeft", newPos.x < tr.position.x);
            anim.SetBool("WalkRight", newPos.x > tr.position.x);
        }
    }

    // --- FUNGSI UNTUK ANDROID (Touch) ---
    void HandleTouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float zDist = Camera.main.WorldToScreenPoint(tr.position).z;
            Vector3 pos = Camera.main.ScreenToWorldPoint(
                new Vector3(touch.position.x, touch.position.y, zDist)
            );

            float targetX = Mathf.Clamp(pos.x, -limitX, limitX);

            // smooth lerp biar halus
            Vector3 newPos = Vector3.Lerp(
                tr.position,
                new Vector3(targetX, tr.position.y, tr.position.z),
                Time.deltaTime * speed
            );

            tr.position = newPos;

            anim.SetBool("WalkLeft", newPos.x < tr.position.x);
            anim.SetBool("WalkRight", newPos.x > tr.position.x);
        }
        else
        {
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }
    }
}
