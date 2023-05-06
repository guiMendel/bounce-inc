using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  private void Start()
  {
    GetComponent<Health>().OnDeath.AddListener(HandleDeath);
  }


  // === DEATH HANDLING

  private void HandleDeath()
  {
    // Reset level
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
