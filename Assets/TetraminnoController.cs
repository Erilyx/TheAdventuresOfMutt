using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TetraminnoController : MonoBehaviour
{

    public Vector3 rotationPoint;
    public float fallTime = 0.6f;
    private float previousTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

           
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
                        
        }
        else if (Input.GetKeyDown(KeyCode.S) || (Time.time - previousTime > fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //rotate
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3 (0, 0, 1), 90);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "game_map")
        {
            Debug.Log("Tetramino hits game_map");
            //gameObject.layer = 9;
            FindObjectOfType<Latiku_controller>().spawnTetramino();
            transform.gameObject.name = "game_map";  //this makes other tetraminos die when they hit it
            this.enabled = false;
            
            isGameOver();
        }



        /*   hold on, don't do this... let the tetraminos turn INTO floor one they hit.....
         *   
        if (collision.gameObject.tag == "tetramino")
        {
            Debug.Log("Tetramino hits other tetramino");

            FindObjectOfType<Latiku_controller>().spawnTetramino();

            this.enabled = false;

        }
        */
    }

    private bool isGameOver()
    {
        //how to figure out the game is over...
    }
}
