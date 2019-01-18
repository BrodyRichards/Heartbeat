using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform bushes;
    Transform bush;
    public GameObject obj;

    private float speed = 8f;
    private int choice;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0, -10);
        choice = obj.GetComponent<characterSwitcher>().getChar(); 
        bush = bushes.GetChild(choice);
        transform.position = bush.position + offset;
    }

    void LateUpdate()
    {
        choice = obj.GetComponent<characterSwitcher>().getChar();
        bush = bushes.GetChild(choice);
        if (Vector3.Distance(transform.position, bush.position) > 5f)
        {
            Vector3 target = bush.position + offset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            transform.position = bush.position + offset;
        }

    }
}
