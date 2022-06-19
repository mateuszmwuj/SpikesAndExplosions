using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DummiesManager : MonoBehaviour
{
    [SerializeField] private GameObject _CameraColliders;
    [SerializeField] private List<PlayerDummyMovement> _listOfPlayerDummies;

    [Button]
    public void AllDummiesGoesDown()
    {
        _CameraColliders.SetActive(false);
        
        foreach (var dummy in _listOfPlayerDummies)
        {
            dummy.Suicide();
        }
    }
}
