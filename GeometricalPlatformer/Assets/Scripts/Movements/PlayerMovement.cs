using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Player Variables
    public PlayerController controller;

    public float runSpeed = 40f;
    [Range(0, 1)]
    public float shortJumpRatio = 1;
    #endregion

    #region Movement Variables
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    #endregion

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (controller.GetJumpBufferCount() >= 0 && controller.hangCounter > 0)
        {
            jump = true;
            controller.ResetJumpBufferCount();
        }

        // Release jump when jump not over : short jump
        if (Input.GetButtonUp("Jump") && controller.GetRigidbody2D().velocity.y > 0)
        {
            controller.GetRigidbody2D().velocity = new Vector2(controller.GetRigidbody2D().velocity.x, controller.GetRigidbody2D().velocity.y * shortJumpRatio);
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
