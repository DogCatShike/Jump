using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Transform player;
    Vector3 offset;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    public void Follow() {
        Vector3 dis = player.position + offset;
        dis.y = transform.position.y;

        Vector3 newPos = Vector3.Lerp(transform.position, dis, 0.1f);
        transform.position = newPos;
    }
}