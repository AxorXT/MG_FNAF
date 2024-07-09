using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonitorState : PlayerBaseMachine
{
    public override void OnEnter(PlayerStateMachine _machine)
    {
        Monitor.Instance.SetIsActive(true);
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        Monitor.Instance.SetIsActive(false);
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {

    }
}
