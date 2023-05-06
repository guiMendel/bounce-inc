using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  // === REFS

  Rigidbody2D body;


  private void Awake()
  {
    body = GetComponent<Rigidbody2D>();

    Helper.AssertNotNull(body);

    initialGravity = body.gravityScale;
  }

  private void FixedUpdate()
  {
    body.velocity = new Vector2(moveDirection * speed, body.velocity.y);

    AdjustGravityScale();
  }


  // === MOVEMENT
  [Header("MOVEMENT")]

  [Tooltip("Speed of x-movement")]
  public float speed = 2f;

  float moveDirection = 0f;


  void Move(float direction) => moveDirection = Mathf.Sign(direction);

  private void Halt() => moveDirection = 0;


  // === JUMPING
  [Header("JUMPING")]

  [Tooltip("Force of jump")]
  public float jumpForce = 10f;

  [Tooltip("Continuous jump frame force")]
  public float jumpContinuousForce = 2f;

  [Tooltip("Max duration to apply jump force")]
  public float maxJumpDuration = 1f;

  [Tooltip("Modifier to gravity scale when rising in the air")]
  public float raisingGravityModifier = 0.8f;


  float initialGravity;

  Coroutine jumpCoroutine;


  // Adjust gravity scale: lower when rising in the air
  void AdjustGravityScale()
  {
    if (body.velocity.y > 0 && body.gravityScale == initialGravity)
      body.gravityScale = initialGravity * raisingGravityModifier;

    else if (body.velocity.y < 0 && body.gravityScale != initialGravity)
      body.gravityScale = initialGravity;
  }

  IEnumerator Jump()
  {
    // Apply y-speed
    body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    // Count duration
    float duration = 0;

    var waitFixedUpdate = new WaitForFixedUpdate();

    yield return waitFixedUpdate;

    while (duration < maxJumpDuration)
    {
      body.AddForce(Vector2.up * jumpContinuousForce, ForceMode2D.Force);

      yield return waitFixedUpdate;

      duration += Time.deltaTime;
    }
  }

  private void StartJump()
  {
    print("jump");

    StopJump();
    jumpCoroutine = StartCoroutine(Jump());
  }

  private void StopJump()
  {
    if (jumpCoroutine != null)
      StopCoroutine(jumpCoroutine);
  }


  // === INPUT CALLBACKS

  public void Move(InputAction.CallbackContext value)
  {
    // Move on x axis
    if (value.phase == InputActionPhase.Performed) Move(value.ReadValue<Vector2>().x);

    // Stop movement when released
    else if (value.phase != InputActionPhase.Started) Halt();
  }

  public void Jump(InputAction.CallbackContext value)
  {
    // Start jump
    if (value.phase == InputActionPhase.Performed) StartJump();

    // Stop jump when released
    else if (value.phase != InputActionPhase.Started) StopJump();
  }
}
