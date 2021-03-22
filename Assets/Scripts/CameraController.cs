using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public bool IsAvailable;
    private float _zoomSize;
    private Camera _camera;
    [SerializeField] private float minZoomValue, maxZoomValue;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        IsAvailable = true;
    }

    private void Start()
    {
        _zoomSize = GetComponent<Camera>().orthographicSize;
    }

    //Zoom Control
    private void FixedUpdate()
    {
        if (!IsAvailable) return;
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _zoomSize>minZoomValue)
            _camera.orthographicSize = _zoomSize--;
        else if(Input.GetAxis("Mouse ScrollWheel") < 0 && _zoomSize<maxZoomValue)
            _camera.orthographicSize = _zoomSize++;
    }
}
