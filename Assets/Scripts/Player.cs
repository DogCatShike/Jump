using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    bool canJump;
    float jumpForce;
    public float jumpMag;
    public float scaleMag;

    CameraFollow cam;

    void Start() {
        rb = GetComponent<Rigidbody>();

        canJump = true;
        jumpForce = 0;

        cam = Camera.main.GetComponent<CameraFollow>();
    }

    void Update() {
        float dt = Time.deltaTime;

        GetKey(dt);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Plane") {
            canJump = true;
            jumpForce = 0;

            GameManager.instance.SpawnPlane();
        }
    }

    void OnCollisionStay(Collision collision) {
        cam.Follow();
    }

    void GetKey(float dt) {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) {
            if (canJump) {
                if (jumpForce >= 10) {
                    jumpForce = 10;
                    return;
                }

                jumpForce += jumpMag * dt;
                transform.localScale -= new Vector3(0, scaleMag * dt, 0);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0)) {
            Jump();
        }
    }

    void Jump() {
        if (canJump) {
            rb.velocity = new Vector3(jumpForce, jumpForce, 0);
            canJump = false;
            transform.localScale = Vector3.one;
        }
    }
}
