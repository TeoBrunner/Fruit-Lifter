using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UIInputInstaller : MonoInstaller
{
    [SerializeField] Joystick joystick;
    [SerializeField] Button throwButton;
    [SerializeField] SwipeZone swipeZone;

    public override void InstallBindings()
    {
        Container.BindInstance(joystick);
        Container.BindInstance(throwButton).WithId("ThrowButton");
        Container.BindInstance(swipeZone);

    }

}
