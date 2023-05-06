using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBounds : MonoBehaviour
{
  private void OnTriggerExit2D(Collider2D other)
  {
    // Reset level
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
