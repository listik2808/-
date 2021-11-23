using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _trnsitionRang;
    [SerializeField] private float _rangetSpread;

    private void Start()
    {
        _trnsitionRang += Random.Range(-_rangetSpread, _rangetSpread);
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position,Target.transform.position) < _trnsitionRang)
        {
            NeedTransit = true;
        }
    }
}
