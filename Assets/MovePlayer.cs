using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;

    public bool isJumping;
    public bool isGrounded;

    public SpriteRenderer sprite;

    public Transform groundRight;
    public Transform groundLeft;
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundLeft.position, groundRight.position);

        float horizontalmouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Regard(body.velocity.x);

        PlayerMovement(horizontalmouvement);
        
    }
    void PlayerMovement(float horizontalmouvement)
    {
        Vector3 targetVelocity = new Vector3(horizontalmouvement, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
        
        if(isJumping == true) {

            body.AddForce(new Vector2 (0f, jumpForce));
            isJumping= false;
        }

    }

    void Regard(float regard)
    {
        if (regard > 0.1f)

        {
            sprite.flipX = false;

        }
        else if (regard < -0.1f)

        {
            sprite.flipX = true;
        }

    }
}
