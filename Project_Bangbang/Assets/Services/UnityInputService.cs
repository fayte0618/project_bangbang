﻿using UnityEngine;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField]
    private Camera _camera;

    private Vector2 _delta = Vector2.zero;
    private Vector2 _direction = Vector2.zero;
    private Vector2 _initPos = Vector2.zero;
    private Vector2 _prevPos = Vector2.zero;
    private Vector2 _currPos = Vector2.zero;

    public Vector2 Delta
    {
        get { return _delta; }
    }

    public Vector2 Direction
    {
        get { return _direction; }
    }

    void Update ()
    {
        //INIT
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        if (Input.GetMouseButtonDown(0))
        {
            _initPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _prevPos = _initPos;
            _currPos = _initPos;
        }
#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            _initPos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            _prevPos = _initPos;
            _currPos = _initPos;
        }
#endif

        //CALCULATIONS
        _delta = _currPos - _prevPos;
        _direction = (_currPos - _initPos).normalized;


        //UPDATE
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        if (Input.GetMouseButton(0))
        {
            _prevPos = _currPos;
            _currPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _initPos = Vector3.zero;
            _prevPos = Vector3.zero;
            _currPos = Vector3.zero;
        }
#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            _prevPos = _currPos;
            _currPos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        if (Input.touchCount == 0)
        {
            _initPos = Vector3.zero;
            _prevPos = Vector3.zero;
            _currPos = Vector3.zero;
        }
#endif
    }
}