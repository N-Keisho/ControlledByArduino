using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContraller : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Witch");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
}
