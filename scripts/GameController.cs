using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
  public static GameController controller;
  public float movementVelocity;

  void Start() {
    movementVelocity = 5.0f;
  }

  void FixedUpdate() {
    float xAxis = Input.GetAxis("xAxis"); // d(positive) - a(negative)
    float zAxis = Input.GetAxis("zAxis"); // w(positive) - s(negative)
    Vector3 movement = new Vector3(xAxis, 0.0f, zAxis) * movementVelocity;
    this.GetComponent<Rigidbody>()
        .MovePosition(this.transform.position + movement * Time.fixedDeltaTime);
  }

  void Awake() {
    if(controller == null) {
      controller = this;
      DontDestroyOnLoad(this);
    } else if (controller != this) {
      Destroy(gameObject);
    }
  }
}
