using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        transform.Translate(_joystick.Direction * _moveSpeed * Time.deltaTime);
    }
}
