using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScene2 : MonoBehaviour
{
    public GameObject end;

    public float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.end.transform.position, speed);

    }
}
