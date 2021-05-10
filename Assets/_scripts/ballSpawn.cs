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
        }
        if (gm.gameState == GameManager.GameState.GAME && GameObject.FindWithTag("BallBody") == null) {
            Spawn();
        }
    }


    public void Spawn() {
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        while (Vector3.Distance(player.transform.position, pos) < 50f) {
            float x = Random.Range(80f, 320f);
            float z = Random.Range(60f, 292f);
            pos = new Vector3(x, 60f, z);
        }
        Instantiate(bola, pos, Quaternion.identity);
    }

}
// 