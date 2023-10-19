using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _follow;
    [SerializeField] private Camera _cam;

    private void Update()
    {
        Vector3 newPos = new Vector3(_follow.position.x, _follow.position.y, transform.position.z);
        _cam.transform.position = newPos;
    }

}
