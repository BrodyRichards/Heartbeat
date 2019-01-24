using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCs : MonoBehaviour
{
    Vector3 target;
    private GameObject area;   //quad
    private int areaX, areaY; //get the size of the quad
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        area = GameObject.Find("Quad");
        areaX = ((int)area.transform.localScale.x) / 2;
        areaY = ((int)area.transform.localScale.y) / 2;
        int ranX = Random.Range(-areaX, areaX);
        int ranY = Random.Range(-areaY, areaY);
        target = new Vector3(ranX, ranY, -1);
        //create a random point on the quad and have the NPC move towards that location
        //once it reaches that location a new random point is made and the NPC moves towards that
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            int ranX = Random.Range(-areaX, areaX);
            int ranY = Random.Range(-areaY, areaY);
            target = new Vector3(ranX, ranY, -1);
        }
    }
}
