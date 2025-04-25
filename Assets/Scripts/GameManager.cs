using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject planePrefab;

    Vector3 planePos;

    void Awake() {
        instance = this;

        planePos = Vector3.zero;

        SpawnPlane();
        SpawnPlayer();
    }

    void SpawnPlayer() {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 1, 0);
    }

    public void SpawnPlane() {
        GameObject plane = Instantiate(planePrefab);
        plane.transform.position = planePos;

        planePos.x += Random.Range(3f, 7f);
    }
}