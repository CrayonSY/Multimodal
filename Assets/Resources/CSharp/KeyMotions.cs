using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMotions : MonoBehaviour
{

    public bool isActive = true;
    public int animationId;

    private string[] _animationClips = { "Run", "Dizzy" };
    private Animation _animation;
    private int dash = 1;

    private const float SPEED = 0.06f;
    [SerializeField] private GameObject _textSpace, _centerTextSpace;

    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        KeyMoves();
        _animation.clip = _animation.clip = _animation.GetClip(_animationClips[animationId]);
        _animation.Play();
    }

    private void KeyMoves()
    {
        if (!isActive) return;
        if (_textSpace.active) return;
        if (_centerTextSpace.active) return;

        dash = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 2 : 1;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * SPEED * dash;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * SPEED * dash;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.5f, 0);
        }
        
    }

    public void StickMoves(float angle)
    {
        if (!isActive) return;
        if (_textSpace.active) return;
        if (_centerTextSpace.active) return;

        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);


        transform.position += transform.forward * SPEED * y * 2;
        transform.Rotate(0, x*0.5f, 0);
    }

}