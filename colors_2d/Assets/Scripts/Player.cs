using UnityEngine;
using Enumerators;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid_body_;
    [SerializeField] private SpriteRenderer sprite_renderer_;
    [SerializeField] private Color[] colors = new Color[4];
    [SerializeField] private GameManager gameManager;
    private float jumpForce = 10f;
    private bool mInputJump;
    private bool firstTouch;
    private Colors currentCol;

    // Use this f[or initialization
    void Start()
    {
        // Set the player still while waiting for first touch:
        firstTouch = true;
        rigid_body_.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
        MovePlayer();
    }

    private void GetUserInput()
    {
        mInputJump = Input.GetKeyDown("space") || Input.GetMouseButtonDown(0);

        if (mInputJump && firstTouch)
        {
            firstTouch = false;
            rigid_body_.gravityScale = 3;
        }
    }

    private void MovePlayer()
    {
        // Move the player according to the user's input:

        if (mInputJump)
        {
            rigid_body_.velocity = Vector2.up * jumpForce;
            AudioSource soundv = GetComponent<AudioSource>();
            soundv.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.OnCollisionFlow(ref collision, currentCol);

    }

    public Colors GetCurrentColor()
    {
        return currentCol;
    }
    public void SetColor(Colors col)
    {
        currentCol = col;
        sprite_renderer_.color = colors[(int)col];
    }


}
