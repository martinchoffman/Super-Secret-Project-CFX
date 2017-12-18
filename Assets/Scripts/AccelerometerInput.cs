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

    [SerializeField] private bool active;

    void Start () {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update () {
        UpdateAxes();
        if (Mathf.Abs(atf) > deadZone && active) {
            transform.Rotate(atr, atf);
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
