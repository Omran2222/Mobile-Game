using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    //reference to the Ball we have in the scene
    [SerializeField] private Rigidbody2D theBall;

    //refernce we'll use for the Main Camera in the scene
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Camera.main is the camera in the scene with the Main Camera tag
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    UpdateBallPosition();
                    break;
                case TouchPhase.Moved:
                    UpdateBallPosition();
                    break;
                case TouchPhase.Stationary:
                    UpdateBallPosition();
                    break;
                case TouchPhase.Ended:
                    ReleaseFinger();
                    break;
                case TouchPhase.Canceled:
                    ReleaseFinger();
                    break;
            }
        }
    }
    private void UpdateBallPosition()
    {
        //get the Vector2 position of the first finger on the screen (touch 0)
        Vector2 screenTouchPosition = Input.GetTouch(0).position;
        //translate the screen position to a world position
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenTouchPosition);
        //put the ball at the WorldPosition location
        theBall.transform.position = worldPosition;
        //make the ball kinematic
        theBall.bodyType = RigidbodyType2D.Kinematic;
    }
    private void ReleaseFinger()
    {
        //make the ball dynamic
        theBall.bodyType = RigidbodyType2D.Dynamic;
    }
}
