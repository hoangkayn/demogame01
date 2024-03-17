using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mousePosition;
    [SerializeField] protected float onFirting;
    public float OnFirting { get => onFirting; }
     public Vector3 MousePosition { get => mousePosition; }
    [SerializeField] protected Vector4 direction;
    public Vector4 Direction { get => direction; }
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if(instance != null & instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
        GetMouseDown();
        this.GetDirectionByKeyDown();
    }
    private void FixedUpdate()
    {
        GetMousePosition();
     
    }
    void GetMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void GetMouseDown()
    {
        onFirting = Input.GetAxis("Fire1");
    }
    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A)? 1:0;
        if(this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow)? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 0) this.direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 0) this.direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.w == 0) this.direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
        //if (this.direction.x == 1) Debug.Log("Left");
        //if (this.direction.y == 1) Debug.Log("Right");
        //if (this.direction.z == 1) Debug.Log("Up");
        //if (this.direction.w == 1) Debug.Log("Down");
    }

}
