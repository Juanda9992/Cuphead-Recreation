using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed;

    private float playerAxis;
    void Update()
    {
        playerAxis = InputActionManager.instance.GetHorizontalAxisAction().ReadValue<float>();
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(playerAxis * movementSpeed, playerRb.velocity.y);
    }
}
