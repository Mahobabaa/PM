using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.35f;
    private Vector2 termi = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        termi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, termi, speed);
        GetComponent<Rigidbody2D>().MovePosition(temp);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            termi = (Vector2)transform.position + Vector2.up;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            termi = (Vector2)transform.position + Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            termi = (Vector2)transform.position + Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            termi = (Vector2)transform.position + Vector2.right;
        }
    }
}
