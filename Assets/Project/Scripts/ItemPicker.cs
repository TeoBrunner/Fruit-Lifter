using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] float pickDistance = 1;
    [SerializeField] float throwForce = 10;

    private SwipeZone swipeZone;
    Button throwButton;
    private Camera camera;
    private Transform hand;

    private Item itemInHand;
    [Inject]
    private void Construct(SwipeZone swipeZone,
                           [Inject(Id = "ThrowButton")] Button throwButton,
                           Camera camera, 
                           [Inject(Id = "Hand")] Transform hand)
    {
        this.swipeZone = swipeZone;
        this.throwButton = throwButton;
        this.camera = camera;
        this.hand = hand;
    }
    private void OnEnable()
    {
        swipeZone.Touched += TryPick;
        throwButton.onClick.AddListener(ThrowItem);
    }
    private void OnDisable()
    {
        swipeZone.Touched -= TryPick;
        throwButton.onClick.RemoveListener(ThrowItem);
    }
    private void TryPick(Vector2 touchPos)
    {
        if (itemInHand)
        {
            return;
        }

        Ray ray = camera.ScreenPointToRay(touchPos);

        if(Physics.Raycast(ray, out var hit, pickDistance) )
        {
            if(hit.transform.TryGetComponent<Item>(out var item))
            {
                PickItem(item);
            }
        }
    }


    private void PickItem(Item item)
    {
        itemInHand = item;
        item.SetInvisible(true);
        item.transform.SetParent(hand, true);
        item.transform.position = hand.position;
        throwButton.gameObject.SetActive(true);
    }
    private void ThrowItem()
    {
        if (!itemInHand)
        {
            return;
        }

        itemInHand.SetInvisible(false);
        itemInHand.transform.SetParent(null, true);
        itemInHand.Throw(camera.transform.forward * throwForce);
        itemInHand = null;
        throwButton.gameObject.SetActive(false);
    }

}
