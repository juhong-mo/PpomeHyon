using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private const float DirectionForceReduceRate = 0.935f;
    private const float DirectionForceMin = 0.001f;

    private bool _userMoveInput;
    private Vector3 _startPosition;
    private Vector3 _directionForce;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "ToyBox")
        {
            ControlCameraPosition();
            ReduceDirectionForce();
            UpdateCameraPosition();
        }
    }


    public Vector3 getPosition()
    {
        return transform.position;
    }

    private void ControlCameraPosition()
    {
        var mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            CameraPositionMoveStart(mouseWorldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            CameraPositionMoveProgress(mouseWorldPosition);
        }
        else
        {
            CameraPositionMoveEnd();
        }
    }

    private void CameraPositionMoveStart(Vector3 startPosition)
    {
        _userMoveInput = true;
        _startPosition = startPosition;
        _directionForce = Vector2.zero;
    }

    private void CameraPositionMoveProgress(Vector3 targetPosition)
    {
        if (!_userMoveInput)
        {
            CameraPositionMoveStart(targetPosition);
            return;
        }

        _directionForce = _startPosition - targetPosition;
    }

    private void CameraPositionMoveEnd()
    {
        _userMoveInput = false;
    }

    private void ReduceDirectionForce()
    {
        if (_userMoveInput)
        {
            return;
        }

        _directionForce *= DirectionForceReduceRate;

        if(_directionForce.magnitude < DirectionForceMin)
        {
            _directionForce = Vector3.zero;
        }
    }

    private void UpdateCameraPosition()
    {
        if(_directionForce == Vector3.zero)
        {
            return;
        }

        var currentPos = transform.position;
        var targetPos = new Vector3(currentPos.x + _directionForce.x, currentPos.y, currentPos.z);

        float minX = -100;
        float maxX = 100;

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);

        transform.position = Vector3.MoveTowards(currentPos, targetPos, 0.5f);
    }
}
