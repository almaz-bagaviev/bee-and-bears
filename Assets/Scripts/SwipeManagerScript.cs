using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManagerScript : MonoBehaviour
{
    public static SwipeManagerScript instance;

    /*Необходимо при старте игры ключать Свайп Менеджер, при Рестарте  - выключать
    private GameObject SwipeManager;
    
    if GameisStart{
        SwipeManager.enabled = true;
    */
    
    //направление
    public enum Direction {Left, Right, Up, Down};
    bool [] swipebool = new bool[4];

    Vector2 StartTouch, SwipeDelta;
    bool TouchMoved;
    const float SWIPE_constant_value = 50;

    public delegate void MoveDelegate(bool[] swipes);
    public MoveDelegate MoveEvent;

    public delegate void ClickDelegate(Vector2 pos);
    public ClickDelegate ClickEvent;


    Vector2 TouchPosition() { return (Vector2)Input.mousePosition;}
    bool TouchBegin(){ return Input.GetMouseButtonDown(0); }
    bool TouchEnded() { return Input.GetMouseButtonUp(0); }
    bool isTouching() { return Input.GetMouseButton(0); }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; //если производится Клик на объектов UI, то мы выходим из проверки, и не будут обработаны Swipы
        if (TouchBegin())
        {
            StartTouch = TouchPosition();
            TouchMoved = true;
        }

        else if (TouchEnded() && TouchMoved == true)
        {
            Send_to_Swipe();
            TouchMoved = false;
        }

        //Расстяние Swipa
        
        SwipeDelta = Vector2.zero; // расстояние между текущей и стартовой позицией
        if(TouchMoved == true && isTouching() == true)
        {
            SwipeDelta = TouchPosition() - StartTouch;
        }

        //Было ли это Swipпом
        if (SwipeDelta.magnitude > SWIPE_constant_value)
        {
            if(Mathf.Abs(SwipeDelta.x) > Mathf.Abs(SwipeDelta.y))
            {
                //Вправо или влево
                swipebool[(int)Direction.Left] = SwipeDelta.x < 0;
                swipebool[(int)Direction.Right] = SwipeDelta.x > 0;
            }
            else
            {
                //Вверх или Вниз
                swipebool[(int)Direction.Down] = SwipeDelta.y < 0;
                swipebool[(int)Direction.Up] = SwipeDelta.y > 0;
            }
            Send_to_Swipe();
        }



    }

    private void Send_to_Swipe()
    {
        if (swipebool[0] == true || swipebool[1] == true || swipebool[2] == true || swipebool[3] == true)
        {
            Debug.Log(swipebool[0] + "+" + swipebool[1] + "+" + swipebool[2] + "+" + swipebool[3]);
            MoveEvent?.Invoke(swipebool); 
        }

        else
        {
            Debug.Log("Click");
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
            swipebool[i] = false;
        }
    }
}
