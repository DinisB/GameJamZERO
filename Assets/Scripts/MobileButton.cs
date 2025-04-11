using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum DogAction { Jump, Bark, Left, Right }

    [SerializeField] private DogAction action;
    [SerializeField] private DogScript dogScript;
    [SerializeField] private Button uiButton;

    private bool isHeld = false;

    void Awake()
    {
        if (action == DogAction.Jump || action == DogAction.Bark)
        {
            uiButton.onClick.AddListener(HandleButtonPress);
        }
    }

    void Update()
    {
        if (isHeld)
        {
            switch (action)
            {
                case DogAction.Left:
                    dogScript.LeftButton();
                    break;
                case DogAction.Right:
                    dogScript.RightButton();
                    break;
            }
        }
    }

    private void HandleButtonPress()
    {
        switch (action)
        {
            case DogAction.Jump:
                dogScript.JumpButton();
                break;
            case DogAction.Bark:
                dogScript.BarkButton();
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (action == DogAction.Left || action == DogAction.Right)
        {
            isHeld = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (action == DogAction.Left || action == DogAction.Right)
        {
            isHeld = false;
        }
    }
}
