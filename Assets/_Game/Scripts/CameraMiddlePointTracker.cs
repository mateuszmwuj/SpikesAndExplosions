using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiddlePointTracker : MonoBehaviour
{
    public List<PlayerMovement> _listOfPlayers = new List<PlayerMovement>();
    public float minPosY = -7.4f;

    private void Update()
    {
        FindPlayers();

        if (_listOfPlayers.Count > 0)
        {
            if (_listOfPlayers.Count == 1)
            {
                transform.position = _listOfPlayers[0].transform.position;
            }
            else if (_listOfPlayers.Count == 2)
            {
                transform.position = Vector3.Lerp(_listOfPlayers[0].transform.position, _listOfPlayers[1].transform.position, 0.5f);
            }
            if (transform.position.y < minPosY)
                transform.position = new Vector3(transform.position.x, minPosY, transform.position.z);
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
