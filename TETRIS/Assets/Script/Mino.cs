using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    private static int width = 10;
    private static int height = 20;

    private static Transform[,] grid = new Transform[width, height];

    private static int addition = 0;

    public int total = 0;

    public float previousTime;

    public float fallTime = 1f;

    public Vector3 rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MinoMovement();
    }

    // minoà⁄ìÆèàóù
    private void MinoMovement()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!ValidMovement())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMovement())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time-previousTime >= fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMovement())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                FindObjectOfType<SpawnMino>().NewMino();
            }
            previousTime = Time.time;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }
    }

    /*public void CheckBlocks()
    {
        for(int i = height - 1; i >= 0; i--)
        {
            for(int j = 0; j < width; j++)
            {
                if(grid[j,i] != null)
                {
                    addition = gameObject.GetComponentInChildren<RandomNum>().randomNum;
                }
            }
        }
    }*/

    public void CheckLines()
    {
        for(int i = height -1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if(grid[j,i] == null)
            {
                return false;
            }
        }

        FindObjectOfType<GameManager>().AddScore();

        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    public void RowDown(int i)
    {
        for(int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if(grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach(Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;

            if (roundY >= height - 1)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }

    // à⁄ìÆîÕàÕÇÃêßå‰
    bool ValidMovement()
    {
        foreach(Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            if(roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }
            if(grid[roundX,roundY] != null)
            {
                return false;
            }
        }
        return true;
    }
}