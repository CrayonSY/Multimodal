using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMe : MonoBehaviour
{

    private Transform _playerTransform;
    private GameObject _button;
    private Vector3 _pos, _playerPos;
    private Talk _talk;

    private const float DISTANCE = 10f;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _button = transform.Find("ClickButton").GetChild(0).gameObject;
        SetActiveButton(false);
        _talk = GetComponentInChildren<Talk>();
    }
    
    void Update()
    {
        if (_talk.isActive) return;
        SetActiveButton(Detect());
    }

    private bool Detect()
    {
        _pos = transform.position;
        _playerPos = _playerTransform.position;
        float distance = Mathf.Sqrt(Mathf.Pow(_pos.x - _playerPos.x, 2) + Mathf.Pow(_pos.y - _playerPos.y, 2) + Mathf.Pow(_pos.z - _playerPos.z, 2));
        if (distance < DISTANCE) return true;
        return false;
    }

    public void SetActiveButton(bool isActive)
    {
        _button.SetActive(isActive);
    }

}
