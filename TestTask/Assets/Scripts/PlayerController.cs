using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    private Quaternion _leftSideRotation;
    private Quaternion _rightSideRotation;

    private void Awake()
    {
        _leftSideRotation = new Quaternion(0, 180, 0, 0);
        _rightSideRotation = new Quaternion(0, 0, 0, 0);
    }
    void Update()
    {
        transform.position = transform.position + (Vector3)_joystick.Direction * _moveSpeed * Time.deltaTime;
        if (_joystick.Direction.x < 0) transform.rotation = _leftSideRotation;
        else if (_joystick.Direction.x > 0) transform.rotation = _rightSideRotation;
    }

}
