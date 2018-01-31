using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {
    [SerializeField] Transform targetTrans;
    [SerializeField, Range(0.5f, 5)] float moveSpeed = 1;
    [SerializeField, Range(0.5f, 5)] float rotateSpeed = 1;
    Camera camera;
    bool played = false;
    Vector3 initPos; //初期位置
    float initViewingAngle; //視野角 ズームイン/アウトで使用
    Vector3 centerPos;

	// Use this for initialization
	void Start () {
        initPos = transform.position;
        initViewingAngle = camera.fieldOfView;
        camera = GetComponent<Camera>();
        Debug.Log(camera.transform.position);
	}

    public void Rotate(Vector2 angle) {
        transform.RotateAround(transform.position, transform.right, angle.x * rotateSpeed);
        transform.RotateAround(transform.position, Vector3.up, angle.y * rotateSpeed);
    }

    public void RotateOnZAxis(float angle) {
        transform.RotateAround(transform.position, transform.forward, angle);
    }

    public void Translate(Vector3 movement) {
        transform.Translate(movement * Time.unscaledDeltaTime * moveSpeed);
    }

    public void Zoom(float amount) {
        camera.fieldOfView = amount;
    }

    public void Reset() {
        transform.position = initPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        camera.fieldOfView = initViewingAngle;
    }
}
