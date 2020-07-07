using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed, leftBound = -1.7f, rightBound = 1.7f;
    public GameObject goAfterBurner;

    private Animator _animAfterburner;
    private Vector3 _leftBoundary, _rightBoundary;

    private void Start()
    {
        if (goAfterBurner == null) goAfterBurner = GameObject.Find("Afterburner");
        _animAfterburner = goAfterBurner.GetComponent<Animator>();
        _leftBoundary = new Vector3(leftBound, -4.0f, 0f);
        _rightBoundary = new Vector3(rightBound, -4.0f, 0f);
    }

    void FixedUpdate()
    {
        #if UNITY_EDITOR
        DebugControls();
        #endif

        #if UNITY_ANDROID
        TouchControls();
        #endif
        Boundary(leftBound, rightBound);
    }

    void DebugControls()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _animAfterburner.SetBool("isMoving", true);
            transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animAfterburner.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _animAfterburner.SetBool("isMoving", true);
            transform.position += Vector3.right * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animAfterburner.SetBool("isMoving", false);
        }
    }

    void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            if (transform.position.x < touchPosition.x) // Move Right
            {
                _animAfterburner.SetBool("isMoving", true);
                transform.position += Vector3.right * Time.deltaTime * playerSpeed;
            }

            if (transform.position.x > touchPosition.x) // Move Left
            {
                _animAfterburner.SetBool("isMoving", true);
                transform.position += Vector3.left * Time.deltaTime * playerSpeed;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _animAfterburner.SetBool("isMoving", false);
            }
        }
    }

    private void Boundary(float left, float right)
    {
        if (transform.position.x <= left) transform.position = _leftBoundary;
        if (transform.position.x >= right) transform.position = _rightBoundary;
    }
}