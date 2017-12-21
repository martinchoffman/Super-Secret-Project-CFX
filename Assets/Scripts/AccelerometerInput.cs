using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

    [SerializeField] private Axis axisToFollow;
    private float atf;
    [SerializeField] private Axis axisToRotate;
    private Vector3 atr;

    [SerializeField] private float deadZone;        // .05
    [SerializeField] private float speed;           // 200
    [SerializeField] private float airFriction;

    [SerializeField] private bool active;
    [SerializeField] private bool slide;

    private float momentum = -1;

    void Start () {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update () {
        UpdateAxes();
        if (active) {
            transform.Rotate(atr, atf);
            momentum = -1;
        } else if (!active && slide) {
            if (momentum == -1) {
                momentum = atf;
            } else if (momentum < 0.001f) {
                momentum = 0;
            }

            print(momentum);

            momentum *= airFriction;
            transform.Rotate(atr, momentum * Time.deltaTime);
        }
	}

    public void SetActive(bool b) {
        active = b;
    }
    
    private void UpdateAxes () {
        switch (axisToFollow) {
            case Axis.x:
                atf = Input.acceleration.x;
                break;
            case Axis.y:
                atf = Input.acceleration.y;
                break;
            case Axis.z:
                atf = Input.acceleration.z;
                break;
            default:
                Debug.LogError("Unexpected value for axisToFollow: " + axisToFollow);
                break;
        }

        if (Mathf.Abs(atf) > deadZone) {
            if (atf > 0) {
                atf -= deadZone;
            } else if (atf < 0) {
                atf += deadZone;
            }
        } else {
            atf = 0;
        }
        atf = -atf * Time.deltaTime * speed;

        switch (axisToRotate) {
            case Axis.x:
                atr = Vector3.right;
                break;
            case Axis.y:
                atr = Vector3.up;
                break;
            case Axis.z:
                atr = Vector3.forward;
                break;
            default:
                Debug.LogError("Unexpected value for axisToRotate: " + axisToRotate);
                break;
        }
    }

    private enum Axis {
        x, y, z
    }
}
