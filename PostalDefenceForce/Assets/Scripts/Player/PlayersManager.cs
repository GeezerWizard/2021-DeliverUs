using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager
{
    private static PlayersManager _instance;
    public static PlayersManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayersManager();
            }
            return _instance;
        }
    }
    public int numOfPlayers;
    public List<PlayerControls> controls;
    public void AddPlayer()
    {
        if (numOfPlayers != 4)
        {
            numOfPlayers++;
            //enable player
            //assign player an available control scheme
        }
    }
    public void RemovePlayer()
    {
        if (numOfPlayers != 1)
        {
            numOfPlayers--;
            //disable player
        }
    }
}
