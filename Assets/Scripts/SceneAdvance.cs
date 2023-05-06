using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdvance : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

    SceneManager.LoadScene(nextScene);
  }
}
