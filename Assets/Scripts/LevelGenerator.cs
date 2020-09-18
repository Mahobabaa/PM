using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects;
    private GameObject[,] topLeft = new GameObject[10, 11];
    private GameObject[,] bottomLeft = new GameObject[10, 11];
    private GameObject[,] topRight = new GameObject[10, 11];
    private GameObject[,] bottomRight = new GameObject[10, 11];
    private GameObject[] Q = new GameObject[1];
    private int rows, columns;

    private void Awake()
    {
        rows = topLeft.GetLength(0);
        columns = topLeft.GetLength(1);
        EmptyGameObject();
        Quadrants();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EmptyGameObject()
    {
        for (int i = 0; i < 2; i++)
        {
            Q[i] = new GameObject();
            Q[i].transform.SetParent(this.transform);
            Q[i].name = $"Quandrant {i + 1}";
        }

        Q[0].transform.position = new Vector3(3.55f, 4.5f, 0.0f);
        Q[1].transform.position = new Vector3(-3.55f, 4.5f, 0.0f);
        Q[2].transform.position = new Vector3(-3.55f, -4.5f, 0.0f);
        Q[3].transform.position = new Vector3(3.55f, -4.5f, 0.0f);
    }

    private void Quadrants()
    {
        Quadrant2();

        for (int i = 0; i < rows; i++)
        {
            for (int n = 0; n < columns; n++)
            {
                if (topLeft[i, n] != null)
                {
                    Quadrant1(i, n);
                    Quadrant3(i, n);
                    Quadrant4(i, n);
                }
            }
        }
    }

    private void Quadrant1(int i, int n)
    {
        topRight[i, n] = Instantiate(topLeft[i, n], new Vector3(-topLeft[i, n].transform.position.x, topLeft[i, n].transform.position.y, 0), Quaternion.Euler(topLeft[i, n].transform.rotation.x, 180.0f, topLeft[i, n].transform.rotation.eulerAngles.z));
        topRight[i, n].transform.SetParent(Q[0].transform);
    }
    private void Quadrant2()
    {
        Line1();
        Line2();
        for (int i = 0; i < rows; i++)
        {
            for (int n = 0; n < columns; n++)
            {
                if (topLeft[i, n] != null)
                {
                    topLeft[i, n].transform.SetParent(Q[1].transform);
                }
            }
        }
    }
    private void Quadrant3(int i, int n)
    {
        bottomLeft[i, n] = Instantiate(topLeft[i, n], new Vector3(topLeft[i, n].transform.position.x, -topLeft[i, n].transform.position.y, 0), Quaternion.Euler(180.0f, topLeft[i, n].transform.rotation.y, topLeft[i, n].transform.rotation.eulerAngles.z));
        bottomLeft[i, n].transform.SetParent(Q[2].transform);
    }
    private void Quadrant4(int i, int n)
    {
        bottomRight[i, n] = Instantiate(topLeft[i, n], new Vector3(-topLeft[i, n].transform.position.x, -topLeft[i, n].transform.position.y, 0), Quaternion.Euler(180.0f, 180.0f, topLeft[i, n].transform.rotation.eulerAngles.z));
        bottomRight[i, n].transform.SetParent(Q[3].transform);
    }
   

    private void Line1()
    {
        topLeft[0, 0] = Instantiate(gameObjects[1], new Vector3(-13f, 13.5f, 0.0f), Quaternion.identity);

        for (int i = 1; i < 10; i++)
        {
            topLeft[0, i] = Instantiate(gameObjects[2], new Vector3(i - 11.5f, 11.5f, 0.0f), Quaternion.identity);
        }
        topLeft[0, 13] = Instantiate(gameObjects[7], new Vector3(-1f, 11.5f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }

    private void Line2()
    {
        topLeft[1, 0] = Instantiate(gameObjects[2], new Vector3(-10f, 10.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f));
        for (int i = 1; i < 10; i++)
        {
            topLeft[1, i] = Instantiate(gameObjects[5], new Vector3(i - 11.5f, 11.0f, 0.0f), Quaternion.identity);
        }
        topLeft[1, 13] = Instantiate(gameObjects[4], new Vector3(-0f, 10.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f));
    }
}

   