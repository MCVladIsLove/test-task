using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [Inject] private Player _follow;
    [SerializeField] private Camera _cam;

    private void Update()
    {
        Vector3 newPos = new Vector3(_follow.transform.position.x, _follow.transform.position.y, transform.position.z);
        _cam.transform.position = newPos;
    }

}
