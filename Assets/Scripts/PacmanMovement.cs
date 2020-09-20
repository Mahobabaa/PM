using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.35f;
    private Vector2 termi = Vector2.zero;
    public int[,] AllVec = { { 1,1},{ 1,6},{5,6 },{5,1 } };

    int ThisCount;
    // Start is called before the first frame update
    void Start()
    {
        termi = transform.position;
        ThisCount = 1;


    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetComponent<Animator>().SetInteger("MoveDir", ThisCount);
        if (ThisCount == 0)
        {
            termi= new Vector3(-14 * 0.45f * 0.7f + AllVec[0,1] * 0.45f * 0.7f, 14 * 0.45f * 0.7f - AllVec[0, 0] * 0.45f * 0.7f, 0);
        }
        if (ThisCount == 1)
        {
            termi = new Vector3(-14 * 0.45f * 0.7f + AllVec[1, 1] * 0.45f * 0.7f, 14 * 0.45f * 0.7f - AllVec[1, 0] * 0.45f * 0.7f, 0);
        }
        if (ThisCount == 2)
        {
            termi = new Vector3(-14 * 0.45f * 0.7f + AllVec[2, 1] * 0.45f * 0.7f, 14 * 0.45f * 0.7f - AllVec[2, 0] * 0.45f * 0.7f, 0);
        }
        if (ThisCount == 3)
        {
            termi = new Vector3(-14 * 0.45f * 0.7f + AllVec[3, 1] * 0.45f * 0.7f, 14 * 0.45f * 0.7f - AllVec[3, 0] * 0.45f * 0.7f, 0);
        }
        this.transform.position = Vector2.Lerp(this.transform.position, termi, Time.deltaTime);
        if (Vector2.Distance(this.transform.position, termi) <= 0.1f)
        {
            ThisCount++;
            if (ThisCount > 3)
            {
                ThisCount = 0;
            }
        }
    }
}
