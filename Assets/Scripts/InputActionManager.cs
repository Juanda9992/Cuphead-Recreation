using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    [SerializeField] private InputActionReference horizontalAxis,verticalAxis, jumpAction, dashAction, shootAction;
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

    public InputAction GetVerticalAxisAction()
    {
        return verticalAxis;
    }

    public InputAction GetJumpAction()
    {
        return jumpAction;
    }

    public InputAction GetDashAction()
    {
        return dashAction;
    }
    public InputAction GetShootAction()
    {
        return shootAction;
    }
}
