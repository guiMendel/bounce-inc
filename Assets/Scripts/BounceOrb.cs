using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceOrb : MonoBehaviour
{
  // === BOUNCE
  [Header("BOUNCE")]

  [Tooltip("Force to apply upwards on contact")]
  public float bounceImpulse = 10f;

  private void OnTriggerEnter2D(Collider2D other)
  {
    Rigidbody2D body = other.GetComponent<Rigidbody2D>();

    Helper.AssertNotNull(body);

    // Reset y speed
    body.velocity = new Vector2(body.velocity.x, 0);

    // Add force
    body.AddForce(Vector2.up * bounceImpulse, ForceMode2D.Impulse);

    // Disappear
    Destroy(gameObject);
  }
}
