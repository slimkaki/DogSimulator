using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{   
    GameManager gm;
    [SerializeField]
    public AudioSource points;
    void Start()
    {
        gm = GameManager.GetInstance();   
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "BallBody") {
            points.Play();
        }
    }
}
