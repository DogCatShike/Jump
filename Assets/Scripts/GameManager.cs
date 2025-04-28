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
    public Text txt_Score;

    public Text txt_GameScore;

    List<GameObject> planes;
    GameObject nowPlane;

    int score;

    void Awake() {
        instance = this;

        planePos = Vector3.zero;

        btn_Reset.onClick.AddListener(() => {
            score = 0;
            txt_GameScore.text = score.ToString();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        planes = new List<GameObject>();

        SpawnPlane();
        SpawnPlayer();

        score = 0;
    }

    void SpawnPlayer() {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 1, 0);
    }

    public void SpawnPlane() {
        GameObject plane = Instantiate(planePrefab);
        plane.transform.position = planePos;

        planePos.x += Random.Range(3f, 7f);

        if (planes.Count < 3) {
            planes.Add(plane);
        } else {
            Destroy(planes[0]);
            planes.RemoveAt(0);
            planes.Add(plane);
        }
    }

    public void GameOver() {
        txt_Score.text = "分数: " + score.ToString();
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

    public void AddScore() {
        score += 1;
        txt_GameScore.text = score.ToString();
    }
}