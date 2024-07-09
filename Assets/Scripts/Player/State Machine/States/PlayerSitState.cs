using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitState : PlayerBaseMachine
{
    //variables publicas
    public CameraMovement cameraMovement;
    public Interactor interactor;
    public override void OnEnter(PlayerStateMachine _machine)
    {
        
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        cameraMovement.CameraRotation();
        interactor.Interaction();
    }
}
