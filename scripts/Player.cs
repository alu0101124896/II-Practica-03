using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  void Start() {
    GameController.MovePlayerEvent += MovePlayer;
  }

  void FixedUpdate() {}

  void MovePlayer(Vector3 movement) {
    this.GetComponent<Rigidbody>()
        .MovePosition(this.transform.position + movement * Time.fixedDeltaTime);
  }

  void OnDisable() {
    GameController.MovePlayerEvent -= MovePlayer;
  }
}
