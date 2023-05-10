using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningBehavior : MonoBehaviour
{
    private Transform _cameraTransform;
    private Rigidbody _rigidBody;
    private float _speed = 400f;
    private float _gravity = -100f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalInput = _cameraTransform.forward * InputManager.Instance.PlayerGetDirection().y * _speed;
        var verticalInput = _cameraTransform.right * InputManager.Instance.PlayerGetDirection().x * _speed;
        var move = (horizontalInput + verticalInput);
        move.y = _gravity;
        _rigidBody.velocity = move * Time.deltaTime;


    }
}
