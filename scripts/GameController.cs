using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
  public static GameController controller;
  public delegate void DelegateMovement(Vector3 movement);
  public static event DelegateMovement MovePlayerEvent;
  public float playerMovementVelocity;

  void Start() {
    playerMovementVelocity = 5.0f;
  }

  void FixedUpdate() {
    float xAxis = Input.GetAxis("xAxis"); // d(positive) - a(negative)
    float zAxis = Input.GetAxis("zAxis"); // w(positive) - s(negative)
    Vector3 movement = new Vector3(xAxis, 0.0f, zAxis) * playerMovementVelocity;
    MovePlayerEvent(movement);
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
