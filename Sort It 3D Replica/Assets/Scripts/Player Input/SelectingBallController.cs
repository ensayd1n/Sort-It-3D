using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingBallController : MonoBehaviour
{
    [SerializeField] private LayerMask TubeLayerMask;
    [SerializeField] private LayerMask NullLayerMask;
    private Ray mousePosition;
    RaycastHit hit;

    private bool _selectinglock=false;

    private GameObject _selectedBall;
    private GameObject _selectedTube;
    private void SelectTube()
    {
        mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosition, out hit, Mathf.Infinity, TubeLayerMask) && Input.GetMouseButtonDown(0))
        {
            _selectedTube = hit.collider.gameObject;
            TubeController _tubeController = _selectedTube.GetComponent<TubeController>();

            _selectedBall = _tubeController.TubeList[_tubeController.TubeList.Count-1];

            BallMovementController _ballMovementController = _selectedBall.GetComponent<BallMovementController>();
             
            _ballMovementController.SelectedBall();
            _tubeController.ReduceListBall();

            _selectinglock = true;
        }
    }

    private void ResetSelectingCube()
    {
        mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosition, out hit, Mathf.Infinity, NullLayerMask) && Input.GetMouseButtonDown(0))
        {
            BallMovementController _ballMovementController = _selectedBall.GetComponent<BallMovementController>();
            
            _ballMovementController.ResetSelectedBall();
            
            _selectedTube.GetComponent<TubeController>().AddListBall(_selectedBall);

            _selectedTube = null;

            _selectinglock = false;
        }
    }

    private void CarrySelect()
    {
        mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosition, out hit, Mathf.Infinity, TubeLayerMask) && Input.GetMouseButtonDown(0))
        {
            TubeController _tubeController = hit.collider.gameObject.GetComponent<TubeController>();
            BallMovementController _ballMovementController = _selectedBall.GetComponent<BallMovementController>();
            _tubeController.AddListBall(_selectedBall);

            _ballMovementController.BallPositionChangeToTube(hit.collider.gameObject);

            _selectinglock = false;

            _selectedBall = null;

            ComplatedGameController _complatedGameController = gameObject.GetComponent<ComplatedGameController>();
            _complatedGameController.CheckUpCompalatedGame();
        }
    }

    private void Update()
    {
        if (_selectinglock == false)
        {
            SelectTube();
                                                
        }

        else if (_selectinglock != false)
        {
            ResetSelectingCube();
            CarrySelect();
        }
    }
}
