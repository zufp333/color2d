using UnityEngine;
using Enumerators;

public class Player : MonoBehaviour {

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
        // The player is still until first click:
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
            //gameObject.SetActive(true);
            firstTouch = false;
        }
    }

    private void MovePlayer()
    {
        // Move the player according to the user's input:

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            rigid_body_.velocity = Vector2.up * jumpForce;
            AudioSource soundv = GetComponent<AudioSource>();
            soundv.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameManager.collided(ref collision, currentCol);
            
    }

    public Colors getCurrentColor()
    {
        return currentCol;
    }
    public void setColor(Colors col)
    {
        currentCol = col;
        sprite_renderer_.color = colors[(int) col];
    }

    
}
