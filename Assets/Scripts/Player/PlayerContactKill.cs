using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContactKill : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Safe") == false)
      GetComponent<Health>().Kill();
  }
}
