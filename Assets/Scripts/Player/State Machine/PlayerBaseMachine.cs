using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseMachine : MonoBehaviour
{
    public abstract void OnEnter(PlayerStateMachine _machine);
    public abstract void OnExit(PlayerStateMachine _machine);
    public abstract void OnUpdate(PlayerStateMachine _machine);

}
