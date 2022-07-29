using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManagerScript : MonoBehaviour
{
    public static SwipeManagerScript instance;
    bool[] swipeBool = new bool[4];

    Vector2 StartTouch, SwipeDelta;
    bool TouchMoved;
    const float swipeConstValue = 50;

    public delegate void MoveDelegate(bool[] swipes);
    public MoveDelegate MoveEvent;

    public delegate void ClickDelegate(Vector2 pos);
    public ClickDelegate ClickEvent;

    Vector2 TouchPosition() => (Vector2)Input.mousePosition;
    bool TouchBegin() => Input.GetMouseButtonDown(0);
    bool TouchEnded() => Input.GetMouseButtonUp(0);
    bool isTouching() => Input.GetMouseButton(0);

    private void Awake() => instance = this;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (TouchBegin())
        {
            StartTouch = TouchPosition();
            TouchMoved = true;
        }
        else if (TouchEnded() && TouchMoved == true)
        {
            Send2Swipe();
            TouchMoved = false;
        }

        //Swipe distance

        SwipeDelta = Vector2.zero;
        if (TouchMoved == true && isTouching() == true) SwipeDelta = TouchPosition() - StartTouch;

        if (SwipeDelta.magnitude > swipeConstValue)
        {
            if (Mathf.Abs(SwipeDelta.x) > Mathf.Abs(SwipeDelta.y))
            {
                swipeBool[(int)Direction.Left] = SwipeDelta.x < 0;
                swipeBool[(int)Direction.Right] = SwipeDelta.x > 0;
            }
            else
            {
                swipeBool[(int)Direction.Down] = SwipeDelta.y < 0;
                swipeBool[(int)Direction.Up] = SwipeDelta.y > 0;
            }

            Send2Swipe();
        }
    }

    private void Send2Swipe()
    {
        if (swipeBool[0] == true || swipeBool[1] == true || swipeBool[2] == true || swipeBool[3] == true)
        {
            print($"{swipeBool[0]} + {swipeBool[1]} + {swipeBool[2]} + {swipeBool[3]}");

            MoveEvent?.Invoke(swipeBool);
        }
        else
        {
            print("Click");
            ClickEvent?.Invoke(TouchPosition());
        }

        Reset();
    }

    private void Reset()
    {
        StartTouch = SwipeDelta = Vector2.zero;
        TouchMoved = false;
        for (int i = 0; i < 4; i++)
        {
            swipeBool[i] = false;
        }
    }
}
