using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityOrb : MonoBehaviour
{
  // === GRAVITY SWITCH
  [Header("GRAVITY SWITCH")]

  [Tooltip("Modifier to apply to speed on contact")]
  [Range(0.1f, 2f)]
  public float speedModify = 1f;

  private void OnTriggerEnter2D(Collider2D other)
  {
    Rigidbody2D body = other.GetComponent<Rigidbody2D>();

    Helper.AssertNotNull(body);

    body.gravityScale = -body.gravityScale;
    body.velocity = body.velocity * speedModify;

    // Disappear
    Destroy(gameObject);
  }
}
