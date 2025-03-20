using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] Transform hand;
    [SerializeField] Camera playerCamera;
    public override void InstallBindings()
    {
        Container.BindInstance(hand).WithId("Hand");
        Container.BindInstance(playerCamera);
    }
}
