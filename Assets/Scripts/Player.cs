using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] CameraController cameraController;
    [SerializeField] RectTransform tapRect;
    Vector3 tapPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMouseState();
    }

    void UpdateMouseState() {
        if (Input.GetMouseButtonDown(2)) {
            tapPos = Input.mousePosition;
        }

        MouseDrag(Input.mousePosition);
    }

    void MouseDrag(Vector3 mousePos) {
        Vector3 diff = mousePos - tapPos;

        if (Input.GetMouseButton(2))
            cameraController.Translate(-diff);
        else if (Input.GetMouseButton(1))
            cameraController.Rotate(new Vector2(-diff.y, diff.x));

        tapPos = mousePos;
    }
}
