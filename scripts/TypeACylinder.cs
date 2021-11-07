using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeACylinder : MonoBehaviour {
  public delegate void OnCollisionDelegate(Collision other);
  public static event OnCollisionDelegate OnCollisionAddForceEvent;
  public delegate void OnProximityDelegate(bool playerIsCloseToA);
  public static event OnProximityDelegate OnProximityAlertEvent;
  float minPlayerDistance;

  void Start() {
    TypeBCylinder.OnCollisionLogEvent += OnCollisionLog;
    minPlayerDistance = 3.0f;
  }

  void FixedUpdate() {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    float playerDistance =
        Vector3.Distance(this.transform.position, player.transform.position);
    if (OnProximityAlertEvent != null) {
      OnProximityAlertEvent(playerDistance < minPlayerDistance);
    }
  }

  void OnCollisionLog() {
    Debug.Log("Collision on Type B Cylinder detected.");
  }

  void OnCollisionEnter(Collision other) {
    if (other.gameObject.name == "Player" && OnCollisionAddForceEvent != null) {
      OnCollisionAddForceEvent(other);
    }
  }

  void OnDisable() {
    TypeBCylinder.OnCollisionLogEvent -= OnCollisionLog;
  }
}
