using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfRoom;
    public float speed = 1;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.middleOfRoom.SetActive(false);

        this.turnOffExits();

       
        print("turned off");
        //not our first scene
        if (!singleton.currentDirection.Equals("?"))
        {
            if (singleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
            else if (singleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
            }
            else if (singleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
            }
            else if (singleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
            }
            StartCoroutine(turnOnMiddle());
        }
       
    }

    IEnumerator turnOnMiddle()
    {
        yield return new WaitForSeconds(1);
        this.middleOfRoom.SetActive(true);
        print("turned on middle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Second");
        }
        else if (other.CompareTag("MiddleOfTheRoom") && !singleton.currentDirection.Equals("?")) ;
        {
            print("at middle of Room");
            this.amAtMiddleOfRoom = true;
            singleton.currentDirection = "middle";
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(singleton.currentDirection);
        
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            singleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            singleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            singleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            singleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

        }

        //make the player move in the current direction
        if (singleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (singleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (singleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (singleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
    }
}