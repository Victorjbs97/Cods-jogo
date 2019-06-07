using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player; // pega o objeto player
    public float cameraDistance = 30.0f; // distancia da camera

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance); // calcula para a distancia da camera 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z); // para camera seguir o player
    }
}
