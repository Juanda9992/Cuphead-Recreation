using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        InputActionManager.instance.GetHorizontalAxisAction().started += x => SetMovingAnimation(x,true);
        InputActionManager.instance.GetHorizontalAxisAction().canceled += x => SetMovingAnimation(x, false);

        PlayerMovement.OnPlayerGroundStatus += SetJumpAnimation;
    }

    private void SetMovingAnimation(InputAction.CallbackContext callbackContext, bool isMoving)
    {
        playerAnimator.SetBool("Moving", isMoving);

        transform.localScale = new Vector2(isMoving ? callbackContext.ReadValue<float>() : transform.localScale.x, transform.localScale.y);
    }

    public void SetJumpAnimation(bool value)
    {
        playerAnimator.SetBool("Air", value);
    }
}
