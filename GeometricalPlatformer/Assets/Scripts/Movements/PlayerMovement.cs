using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Player Variables
    public PlayerController controller;

    public float runSpeed = 40f;
    #endregion

    #region Movement Variables
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    #endregion

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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
