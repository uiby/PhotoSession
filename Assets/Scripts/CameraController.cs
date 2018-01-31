using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {
    Vector3 initPos; //初期位置
    float viewingAngle; //視野角 ズームイン/アウトで使用
    Camera camera;
    bool played = false;
    [SerializeField] Transform targetTrans;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        Debug.Log(camera.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartControl() {
        initPos = transform.position;
        viewingAngle = camera.fieldOfView;
    }
    public void FinishControl() {
        transform.position = initPos;
        camera.fieldOfView = viewingAngle;
    }

    //ズーム
    // amount: 量
    public void Zoom(float amount) {
        camera.fieldOfView = amount;
    }

    //移動
    //移動量
    public void TranslateBySphere(Vector2 movement) {
        ;
    }

    public Vector3 GetCenterPos() {
        return Vector3.zero;
    }

    public void ChangeState() {
        played = !played;
        if (played) StartControl();
        else FinishControl();
    }
}
