using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private SerialReceive serialReceive;
    void Start()
    {
        serialReceive = GameObject.Find("SerialReceive").GetComponent<SerialReceive>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, serialReceive.distance * 0.01f, 0);
    }
}
