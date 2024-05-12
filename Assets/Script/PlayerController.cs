using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    private SerialReceive serialReceive;
    private bool isGameOver = true;
    private bool isGoal = false;
    private Vector3 initialPosition;
    private TextMeshProUGUI text;
    void Start()
    {
        serialReceive = GameObject.Find("SerialReceive").GetComponent<SerialReceive>();
        initialPosition = this.transform.position;
        text = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
        StartCoroutine("FirstStart");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if (this.transform.position.x < 113f && !isGameOver)
        {
            this.transform.position = new Vector3(pos.x + speed * Time.deltaTime, serialReceive.distance * 0.01f, 0);
        }
        else if(!isGameOver && !isGoal)
        {
            isGoal = true;
            text.text = "GAME CLEAR!!";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGameOver = true;
            StartCoroutine("Restart");
        }
    }

    IEnumerator FirstStart()
    {
        text.text = "GAME START!!";
        yield return new WaitForSeconds(1f);
        text.text = "";
        isGameOver = false;
    }

    IEnumerator Restart()
    {
        text.text = "Ops! Restart...";
        yield return new WaitForSeconds(0.5f);
        this.transform.position = initialPosition;
        yield return new WaitForSeconds(0.5f);
        text.text = "";
        isGameOver = false;
    }
}
