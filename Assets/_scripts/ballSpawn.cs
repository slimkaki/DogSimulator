using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawn : MonoBehaviour {

    GameManager gm;
    [SerializeField]
    public GameObject bola;
    private GameObject player;

    void Start() {
        gm = GameManager.GetInstance();
        player = GameObject.FindWithTag("Player");
        Spawn();
    }


    void Update() {
        if (gm.gameState == GameManager.GameState.MENU) {
            Destroy(GameObject.FindWithTag("BallBody"));
            Spawn();
        }
    }

    public void Spawn() {
        Vector3 pos = new Vector3(0f, 0f, 0f);
        while (Vector3.Distance(player.transform.position, pos) < 100f) {
            float x = Random.Range(10f, 305f);
            float z = Random.Range(10f, 300f);
            pos = new Vector3(x, 45f, z);
        }
        Instantiate(bola, pos, Quaternion.identity);
    }

}
// 