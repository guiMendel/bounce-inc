using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
  private void Awake()
  {
    Lives = maxLives;
  }

  // === LIVES
  [Header("Lives")]

  [Tooltip("How many hits this character can take before dying")]
  public int maxLives = 1;

  [Tooltip("Raised when character dies")]
  public UnityEvent OnDeath;


  public int Lives { get; private set; }

  public bool Alive => Lives > 0;
  public bool Dead => Alive == false;


  public void TakeDamage()
  {
    if (Dead) return;

    Lives--;

    if (Dead) OnDeath.Invoke();
  }

  public void Kill()
  {
    if (Dead) return;

    Lives = 0;

    OnDeath.Invoke();
  }
}
