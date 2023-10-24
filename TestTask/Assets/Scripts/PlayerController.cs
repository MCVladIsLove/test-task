using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [Inject] private Joystick _joystick;

    private Quaternion _leftSideRotation;
    private Quaternion _rightSideRotation;

    private void Awake()
    {
        _leftSideRotation = new Quaternion(0, 180, 0, 0);
        _rightSideRotation = new Quaternion(0, 0, 0, 0);
    }
    void Update()
    {
        // transform.position = transform.position + (Vector3)_joystick.Direction * _moveSpeed * Time.deltaTime;
        transform.Translate(_joystick.Direction * _moveSpeed * Time.deltaTime, Space.World);
        if (_joystick.Direction.x < 0) transform.rotation = _leftSideRotation;
        else if (_joystick.Direction.x > 0) transform.rotation = _rightSideRotation;
    }

}
