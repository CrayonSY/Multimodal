using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{

    private Vector2 _initialPosition = new Vector2(0, 0);
    private RectTransform _rectTransform;
    private Vector2 _globalPosition;
    private KeyMotions _keyMotions;
    private bool isCorrectStart;

    private const float MAX_OFFSET = 25;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _globalPosition = _rectTransform.position;
        _keyMotions = GameObject.Find("Player").GetComponent<KeyMotions>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isCorrectStart = CheckCorrectMoveStart();
        MoveStickAtMousePos();
        if (Input.GetMouseButtonUp(0)) isCorrectStart = false;

        _keyMotions.animationId = isCorrectStart ? 0 : 1;
    }

    private void MoveStickAtMousePos()
    {
        if (!isCorrectStart) return;
        if(Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            float x = pos.x - _globalPosition.x;
            float y = pos.y - _globalPosition.y;

            // radian angle
            float angle = Mathf.Atan(y / x);
            if (x < 0) angle += Mathf.PI;
            _rectTransform.localPosition = new Vector2(MAX_OFFSET*Mathf.Cos(angle), MAX_OFFSET*Mathf.Sin(angle));
            _keyMotions.StickMoves(angle);
        }
        else
        {
            _rectTransform.localPosition = _initialPosition;
        }
    }

    private bool CheckCorrectMoveStart()
    {
        Vector3 pos = Input.mousePosition;
        float x = pos.x - _globalPosition.x;
        float y = pos.y - _globalPosition.y;

        float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        if (distance > 50) return false;
        return true;
    }
}
