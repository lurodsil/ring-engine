using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicCollider : PlayerCollider
{
    void StateBoostStart()
    {
        ExpandItemTrigger();
    }
    void StateBoostEndStart()
    {
        ColapseItemTrigger();
    }
    void StateRollStart()
    {
        SquatCollider();
    }
    void StateRollEnd()
    {
        StandCollider();
    }
    void StateSquatStart()
    {
        SquatCollider();
    }
    void StateSquatEnd()
    {
        StandCollider();
    }
    void StateSlidingStart()
    {
        SquatCollider();
    }
    void StateSlidingEnd()
    {
        StandCollider();
    }
    void StateCrawlingStart()
    {
        SquatCollider();
    }
    void StateCrawlingEnd()
    {
        StandCollider();
    }
    void StateStompStart()
    {
        ExpandItemTrigger();
    }
    void StateStompEnd()
    {
        ColapseItemTrigger();
    }
}
