using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePathVolume : CommonObject
{
    [SerializeField] BezierPath bezierPath;
    private BezierPath previousBezierPath;

    private void Start()
    {
        OnPlayerTriggerEnter.AddListener(Enter);
        OnPlayerTriggerExit.AddListener(Exit);
    }
    public void Enter()
    {
        previousBezierPath = player.pathHelper;
        player.pathHelper = bezierPath;
    }

    public void Exit()
    {
        player.pathHelper = previousBezierPath;              
    }
}
