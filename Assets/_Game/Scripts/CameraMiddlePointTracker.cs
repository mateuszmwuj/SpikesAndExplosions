using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiddlePointTracker : MonoBehaviour
{
    public List<PlayerMovement> _listOfPlayers = new List<PlayerMovement>();

    private void Update()
    {
        FindPlayers();

        if (_listOfPlayers.Count > 0)
        {
            Vector3 player1Pos = _listOfPlayers[0].transform.position;
            Vector3 player2Pos = _listOfPlayers.Count>=2 ?  _listOfPlayers[1].transform.position : _listOfPlayers[0].transform.position;
            transform.position = Vector3.Lerp(player1Pos, player2Pos, 0.5f);
        }
    }

    private void FindPlayers()
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            if (!_listOfPlayers.Contains(playerMovement))
            {
                _listOfPlayers.Add(playerMovement);
            }
        }
    }
}
