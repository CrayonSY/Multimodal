using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDirection : MonoBehaviour
{ 
    public GameObject goal;
    [SerializeField] private GameObject _arrow;

    void Start()
    {
        
    }
    
    void Update()
    {
        var aim = goal.transform.position - transform.position;
        _arrow.transform.rotation = Quaternion.LookRotation(aim);
    }
}
