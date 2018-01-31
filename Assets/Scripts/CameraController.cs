using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {
    [SerializeField] Transform targetTrans;
    [SerializeField, Range(1, 20)] float moveSpeed = 1f;
    Camera camera;
    Transform parent;
    bool played = false;
    Vector3 initPos; //初期位置
    float viewingAngle; //視野角 ズームイン/アウトで使用
    Vector3 centerPos;


	// Use this for initialization
	void Start () {
        parent = transform.parent;
        camera = GetComponent<Camera>();
        Debug.Log(camera.transform.position);
	}
	
    public void StartControl() {
        centerPos = GetCenterPos();
        initPos = transform.position;
        viewingAngle = camera.fieldOfView;
    }
    public void FinishControl() {
        parent.position = initPos;
        parent.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = initPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        camera.fieldOfView = viewingAngle;
    }

    //ズーム
    // amount: 量
    public void Zoom(float amount) {
        camera.fieldOfView = amount;
    }

    /// <summary>
    /// 球面上に移動
    /// </summary>
    /// <param name='dragVec'>移動ベクトル</param>
    public void TranslateOnSphere(Vector3 dragVec) {
        var horizontal = Vector3.up * dragVec.x;
        parent.RotateAround(centerPos, horizontal, moveSpeed);
        var vertical = transform.right * dragVec.y;
        transform.RotateAround(centerPos, vertical, moveSpeed);
    }

    public Vector3 GetCenterPos() {
        return targetTrans.position;
    }

    public void ChangeState() {
        played = !played;
        if (played) StartControl();
        else FinishControl();
    }
}
