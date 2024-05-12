using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private SerialReceive serialReceive;
    public float speed = 1.0f;

    private bool isGameOver = false;
    void Start()
    {
        serialReceive = GameObject.Find("SerialReceive").GetComponent<SerialReceive>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if ( this.transform.position.x < 113f && !isGameOver)
        {
            this.transform.position = new Vector3(pos.x + 0.01f * speed, serialReceive.distance * 0.01f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
        }
        if (other.gameObject.tag == "Ground")
        {
            isGameOver = true;
            Debug.Log("GameOver");
        }
    }
}
