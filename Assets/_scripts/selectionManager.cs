// Utilizamos o tutorial 'Selecting Objects with Raycast - Unity Tutorial': https://www.youtube.com/watch?v=_yf5vzZ2sYE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "BallBody";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private float maxDistToBall;
    

    private Transform _selection;
    private GameObject player;
    private GameObject bola;


    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (_selection != null) {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {    
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) {
                var selectionRender = selection.GetComponent<Renderer>();
                bola = GameObject.FindWithTag(selectableTag);
                float dist = Vector3.Distance(player.transform.position, bola.transform.position);
                // Debug.Log($"dist = {dist}");
                if(selectionRender != null && dist < maxDistToBall)
                {
                    selectionRender.material = highlightMaterial;
                    player.GetComponent<playerController>().canGrab = true;
                } else {
                    player.GetComponent<playerController>().canGrab = false;
                }
                _selection = selection;
            }
        }
    }
} 
