using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject planePrefab;

    Vector3 planePos;

    public GameObject Panel_GameOver;
    public Button btn_Reset;

    List<GameObject> planes;
    GameObject nowPlane;

    void Awake() {
        instance = this;

        planePos = Vector3.zero;

        btn_Reset.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        planes = new List<GameObject>();

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

        if (planes.Count <= 5) {
            planes.Add(plane);
        } else {
            Destroy(planes[0]);
            planes.RemoveAt(0);
            planes.Add(plane);
        }
    }

    public void GameOver() {
        Panel_GameOver.SetActive(true);
    }

    public bool IsNewPlane(GameObject plane) {
        if (nowPlane == null) {
            nowPlane = plane;
            return true;
        } else if (nowPlane != plane) {
            nowPlane = plane;
            return true;
        } else {
            return false;
        }
    }
}