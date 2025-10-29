using System;
using System.Collections;
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

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private bool isDashing;
    public static event Action<bool> OnPlayerGroundStatus;
    public static event Action<bool> OnPlayerDashStatusUpdated;

    private float playerAxis;
    private float defaultGravity;

    void Start()
    {
        defaultGravity = playerRb.gravityScale;

        InputActionManager.instance.GetJumpAction().started += _=>Jump();
        InputActionManager.instance.GetDashAction().started += _=>Dash();
    }

    void Update()
    {
        playerAxis = InputActionManager.instance.GetHorizontalAxisAction().ReadValue<float>();

        OnPlayerGroundStatus?.Invoke(!canJump);
    }

    void FixedUpdate()
    {
        if(isDashing)
        {
            return; 
        }
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

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            playerRb.velocity = new Vector2(dashSpeed * playerAxis, 0);
            playerRb.gravityScale = 0;
            OnPlayerDashStatusUpdated?.Invoke(true);
            StartCoroutine("ResetDash");
        }
    }
    
    private IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        playerRb.gravityScale = defaultGravity;
        OnPlayerDashStatusUpdated?.Invoke(false);
    }
}
