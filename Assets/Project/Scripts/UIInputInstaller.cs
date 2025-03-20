using UnityEngine;
using Zenject;
public class UIInputInstaller : MonoInstaller
{
    [SerializeField] Joystick joystick;
    [SerializeField] SwipeZone swipeZone;

    public override void InstallBindings()
    {
        Container.Bind<Joystick>().FromInstance(joystick);
        Container.Bind<SwipeZone>().FromInstance(swipeZone);
    }

}
