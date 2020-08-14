using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class TetraminnoController : MonoBehaviour
{

    public Vector3 rotationPoint;
    public float fallTime = 0.6f;
    public float fallCheckY;
    private float previousTime;

    public static Transform[,] grid = new Transform[180, 100];

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
            if(!ValidMove())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || (Time.time - previousTime > fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;

            if (!ValidMove())
            {
                transform.position += new Vector3(0, 1, 0);
                AddToGrid();
                Debug.Log("Tetramino hits game_map");
                FindObjectOfType<Latiku_controller>().spawnTetramino();
                this.enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3 (0, 0, 1), 90);
        }
    }


    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }

    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if ((roundedX < 0) || (roundedY < 0))
            {
                return false;
            }

            if(grid[roundedX, roundedY] != null)
            {
                return false;
            }
          
        }
        return true;
    }

}
