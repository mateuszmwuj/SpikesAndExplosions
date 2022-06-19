using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DummiesManager : MonoBehaviour
{
    [SerializeField] private GameObject _DummiesContainer;
    [SerializeField] private GameObject _MiddlePosition;
    [SerializeField] private GameObject _CameraColliders;
    [SerializeField] private List<PlayerDummyMovement> _listOfPlayerDummies;
    [SerializeField] private float _distance = 40;

    [Button]
    public void AllDummiesGoesDown()
    {
        _CameraColliders.SetActive(false);

        foreach (var dummy in _listOfPlayerDummies)
        {
            dummy.Suicide();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(_DummiesContainer.transform.position, _MiddlePosition.transform.position) < _distance)
        {
            _DummiesContainer.SetActive(true);
        }
    }
}
