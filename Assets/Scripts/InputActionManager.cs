using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    [SerializeField] private InputActionReference horizontalAxis;
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
}
