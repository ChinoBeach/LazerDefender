using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //variables
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;


    [SerializeField] float fltMoveSpeed = 5f;
    [SerializeField] float fltPaddingLeft;
    [SerializeField] float fltPaddingRight;
    [SerializeField] float fltPaddingTop;
    [SerializeField] float fltPaddingBottom;

    Shooter shooter;
    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        Vector2 newPos = new Vector2();

        Vector2 delta = rawInput * fltMoveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + fltPaddingLeft, maxBounds.x - fltPaddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + fltPaddingBottom, maxBounds.y - fltPaddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        //Debug.Log(rawInput);
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.bolIsFiring = value.isPressed;
        }
    }
}
