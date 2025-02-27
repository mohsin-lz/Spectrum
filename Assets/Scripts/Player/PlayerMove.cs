using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    [Header("Player Settings")]
    public Transform playerPosition;
    public float moveSpeed = 3.0f;
    public float leftRightSpeed = 3.0f;
    private bool isBlocked = false; // Flag to stop movement when blocked
    static public bool canPlayerMove = false;

    private void Awake() { Instance = this; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Stop moving forward if blocked
        //Vector3 currentPlayerPos = playerPosition.position;
        //Debug.Log(currentPlayerPos);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (canPlayerMove == true)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }

            }
        }
        
    }

}
