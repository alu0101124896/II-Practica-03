using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBCylinder : MonoBehaviour{
  public delegate void OnCollisionDelegate();
  public static event OnCollisionDelegate OnCollisionLogEvent;
  public float force;
  public Color pink;
  public Color green;

  void Start() {
    TypeACylinder.OnCollisionAddForceEvent += OnCollisionAddForce;
    force = 10.0f;
    TypeACylinder.OnProximityAlertEvent += OnProximityChangeColor;
    pink = this.GetComponent<Renderer>().material.color;
    green = new Color(1, 1, 1) - pink;
  }

  void FixedUpdate() {}

  void OnCollisionEnter(Collision other) {
    if (other.gameObject.name == "Player" && OnCollisionLogEvent != null) {
      OnCollisionLogEvent();
    }
  }

  void OnCollisionAddForce(Collision other) {
    Vector3 direction = this.transform.position - other.transform.position;
    this.GetComponent<Rigidbody>().AddForce(direction * this.force);
  }

  void OnProximityChangeColor(bool playerIsCloseToA) {
    if (playerIsCloseToA &&
        this.GetComponent<Renderer>().material.color == pink) {
      this.GetComponent<Renderer>().material.color = green;
    }
    if (!playerIsCloseToA &&
        this.GetComponent<Renderer>().material.color == green) {
      this.GetComponent<Renderer>().material.color = pink;
    }
  }

  void OnDisable() {
    TypeACylinder.OnCollisionAddForceEvent -= OnCollisionAddForce;
    TypeACylinder.OnProximityAlertEvent -= OnProximityChangeColor;
  }
}
