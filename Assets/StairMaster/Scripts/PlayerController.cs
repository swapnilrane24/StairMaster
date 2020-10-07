using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script which controls the Player logic
/// </summary>
public class PlayerController : MonoBehaviour
{
    //referenc to stair prefab
    [SerializeField] private GameObject stairPrefab;
    //Move speed in z axis 
    [SerializeField] private float zMoveSpeed = 3f;
    //timer to check the up push count per second
    [SerializeField] private float timer = 0.1f;

    //variable to store reference to GameManager
    private GameManager gameManager;
    //a bool
    private bool goUp = false;
    //keep track of timer
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //we get the GameManager and store it in gameManager variable
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //we check if gameManager is not null and gameStatus is Playing
        if (gameManager && gameManager.gameStatus == GameStatus.Playing)
        {
            //if we tap
            if (Input.GetMouseButtonDown(0))
            {
                goUp = true;                                //set goUp to true
            }
            else if (Input.GetMouseButtonUp(0))             //if we release tap
            {
                currentTime = 0;                            //set the currentTime to 0
                goUp = false;                               //set the goUp to false
            }

            if (goUp)                                       //if goUp is true
            {
                //Time.deltaTime is time passed between the current and previous frame
                currentTime -= Time.deltaTime;              //reduce the currentTime by Time.deltaTime

                if (currentTime <= 0)                       //if currentTime is 0
                {
                    currentTime = timer;                    //reset the currentTime to timer
                    SpawnStair();                           //and Spawn the stair
                }   
            }

            //each frame keep moving the player in forward direction

            transform.Translate(Vector3.forward * zMoveSpeed * Time.deltaTime);
        }
    }

    //Method used to spawn the Stair and move character Up
    void SpawnStair()
    {
        //we add vector to the player position
        transform.position += new Vector3(0, 0.5f, 0.5f);
        //And then we spawn a stairPrefab below player 
        Instantiate(stairPrefab, transform.position - Vector3.up * 0.25f, Quaternion.identity);
    }

    //Unity Method to detect collision between 2 object where 1 object must have Rigidbody attached
    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager)                                    //if gameManager is not null
        {
            if (collision.collider.tag == "Enemy")                  //if the tag is Enemy
            {
                gameManager.gameStatus = GameStatus.Failed;     //set the gameManager gameStatus to Failed
                gameManager.GameIsOver();                       //and call the GameIsOver method of gameManager


            }
            else if (collision.collider.tag == "Win")           //if the tag is Win
            {
                gameManager.gameStatus = GameStatus.Completed;  //set the gameManager gameStatus to Completed
                gameManager.GameIsOver();                       //and call the GameIsOver method of gameManager
            }   
        }
    }


}
