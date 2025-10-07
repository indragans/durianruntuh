using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limitX = 2f;
    public float speed = 10f;

    // Arah input yang dipakai MovementPlayer
    public float MoveDirection { get; private set; }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleKeyboardInput();
#elif UNITY_ANDROID || UNITY_IOS
        HandleTouchInput();
#endif
    }

    void HandleKeyboardInput()
    {
        float move = 0f;
        if (Input.GetKey("right")) move = 1f;
        else if (Input.GetKey("left")) move = -1f;

        MoveDirection = move;
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = Camera.main.ScreenToWorldPoint(
                new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane)
            );

            float targetX = Mathf.Clamp(pos.x, -limitX, limitX);

            // Tentukan apakah ke kiri (-1) atau ke kanan (+1)
            if (targetX < transform.position.x - 0.01f) MoveDirection = -1f;
            else if (targetX > transform.position.x + 0.01f) MoveDirection = 1f;
            else MoveDirection = 0f;
        }
        else
        {
            MoveDirection = 0f;
        }
    }
}
