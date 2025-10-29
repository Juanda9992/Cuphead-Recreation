using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    [SerializeField] private InputActionReference horizontalAxis, jumpAction;
    public static InputActionManager instance;
    void Awake()
    {
        instance = this;

        inputActions.Enable();
    }

    public InputAction GetHorizontalAxisAction()
    {
        return horizontalAxis;
    }

    public InputAction GetJumpAction()
    {
        return jumpAction;
    }
}
