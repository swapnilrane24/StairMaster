using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to track Game status
/// </summary>
public class GameManager : MonoBehaviour
{
    //Variable to store reference on UIManager
    [SerializeField] private UIManager uIManager;

    //GameStatus variable
    public GameStatus gameStatus = GameStatus.None;

    //method called when game is over
    public void GameIsOver()
    {
        uIManager.GameIsOver(); //we call the UIManager GameIsOver method
    }
}

//enum for Game status
public enum GameStatus
{
  None,
  Playing,
  Completed,
  Failed
}