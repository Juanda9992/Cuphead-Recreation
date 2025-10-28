using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        InputActionManager.instance.GetHorizontalAxisAction().started += x => SetMovingAnimation(x,true);
        InputActionManager.instance.GetHorizontalAxisAction().canceled+= x => SetMovingAnimation(x,false);
    }

    private void SetMovingAnimation(InputAction.CallbackContext callbackContext,bool isMoving)
    {
        playerAnimator.SetBool("Moving", isMoving);

        transform.localScale = new Vector2(callbackContext.ReadValue<float>(), transform.localScale.y);
    }
}
