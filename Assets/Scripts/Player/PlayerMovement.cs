using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed;

    [Header("Jump Settings")]
    [SerializeField] private Transform jumpDetectionPos;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpDetectionRadius;
    [SerializeField] private float jumpHeight;
    private bool canJump;
    public static event Action<bool> OnPlayerGroundStatus;

    private float playerAxis;

    void Start()
    {
        InputActionManager.instance.GetJumpAction().started += _=>Jump();
    }

    void Update()
    {
        playerAxis = InputActionManager.instance.GetHorizontalAxisAction().ReadValue<float>();

        OnPlayerGroundStatus?.Invoke(!canJump);
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(playerAxis * movementSpeed, playerRb.velocity.y);

        canJump = Physics2D.OverlapCircle(jumpDetectionPos.position, jumpDetectionRadius, groundLayer);
    }
    private void Jump()
    {
        if (canJump)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
        }
    }
}
