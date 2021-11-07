using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
  void Start() {
    TypeACylinder.OnProximityAlertEvent += OnProximityChangeDirection;
  }

  void FixedUpdate() {}

  void OnProximityChangeDirection(bool playerIsCloseToA) {
    if (playerIsCloseToA) {
      GameObject target = GameObject.FindGameObjectWithTag("Target To Look");
      this.transform.LookAt(target.transform);

      // Vector3 targetDirection =
      //     target.transform.position - this.transform.position;
      // Debug.DrawRay(this.transform.position, targetDirection, Color.red);
    }
  }

  void OnDisable() {
    TypeACylinder.OnProximityAlertEvent -= OnProximityChangeDirection;
  }
}
