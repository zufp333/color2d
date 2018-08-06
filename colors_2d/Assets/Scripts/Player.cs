using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool input_jump = false;
    private bool first_touch_ = true;
    private string current_color_ = null;

    [SerializeField] float jump_force_ = 10f;
    [SerializeField] Rigidbody2D rigid_body_;
    [SerializeField] SpriteRenderer sprite_renderer_;

    public Color color_cyan;
    public Color color_yellow;
    public Color color_magenta;
    public Color color_pink;

    // Use this for initialization
    void Start()
    {
        // At start, choose a random color to the player:
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {

        GetUserInput();
        MovePlayer();
    }

    private void GetUserInput()
    {
        // Read user input:
        input_jump = Input.GetKeyDown("space") || Input.GetMouseButtonDown(0);
       
        if (input_jump && first_touch_)
        {
            rigid_body_.gravityScale = 3f;
            first_touch_ = false;
        }
    }

    private void MovePlayer()
    {
        // Move the player according to the user's input:

        if (input_jump)
            rigid_body_.velocity = Vector2.up * jump_force_;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag != current_color_) {

        }
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        current_color_ = GetColorByIndex(index);
        SetSpriteRendererColorByIndex(index);

    }

    private string GetColorByIndex(int index)
    {
        string chosen_color = null;

        switch (index)
        {
            case 0:
                chosen_color = "Cyan";
                break;
            case 1:
                chosen_color = "Yellow";
                break;
            case 2:
                chosen_color = "Magenta";
                break;
            case 3:
                chosen_color = "Pink";
                break;
            default:
                Debug.Log("Invalid color index.");
                break;
        }

        return chosen_color;
    }

    private void SetSpriteRendererColorByIndex(int index) {
        switch (index)
        {
            case 0:
                sprite_renderer_.color = color_cyan;
                break;
            case 1:
                sprite_renderer_.color = color_yellow;
                break;
            case 2:
                sprite_renderer_.color = color_magenta;
                break;
            case 3:
                sprite_renderer_.color = color_pink;
                break;
            default:
                Debug.Log("Invalid color index to render.");
                break;
        }
    }
}
