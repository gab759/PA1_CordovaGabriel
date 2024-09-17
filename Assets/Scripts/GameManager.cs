using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> players; 
    private int currentPlayerIndex = 0; 

    private void Start()
    {
        ActivatePlayer(currentPlayerIndex); 
    }

    public void SwitchPlayerRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count; 
            ActivatePlayer(currentPlayerIndex);
        }
    }

    public void SwitchPlayerLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentPlayerIndex = (currentPlayerIndex - 1 + players.Count) % players.Count; 
            ActivatePlayer(currentPlayerIndex);
        }
    }

    private void ActivatePlayer(int playerIndex)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SetActive(i == playerIndex);
        }
    }
}