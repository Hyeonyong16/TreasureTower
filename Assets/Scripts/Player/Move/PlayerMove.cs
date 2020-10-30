using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;

    private Transform playerTransform;
    private Rigidbody playerRigidbody;

    Vector3 movement;           //이동값 받을 벡터변수
    float h, v;                 //h = horizontal, v = vertical


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.Set(h, 0, v);
        movement.Normalize();

        //카메라가 보는 방향으로 이동
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0; //카메라가 위를 본다고 위로 이동하지는 않으므로 y는 0으로 설정

        movement = movement * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }
}
