using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] CameraController cameraController;
    [SerializeField] RectTransform tapRect;
    Vector3 beginTapPos;
    Vector3 nowTapPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TapAction();	
	}

    void TapAction() {
        switch(AppUtil.GetTouch()) {
            case TouchInfo.Began:
                beginTapPos = AppUtil.GetTouchPosition();
                tapRect.position = beginTapPos;
            break;
            case TouchInfo.Moved:
                nowTapPos = AppUtil.GetTouchPosition();
                var normalizedVec = AppUtil.GetDragDirection(beginTapPos, nowTapPos);
                var translatedVec = new Vector3(normalizedVec.x, normalizedVec.y, 0);
                if (Mathf.Abs(translatedVec.x) > Mathf.Abs(translatedVec.y))
                    translatedVec.y = 0;
                else translatedVec.x = 0;
                //Debug.Log("vec:"+translatedVec);
                cameraController.TranslateOnSphere(translatedVec);
            break;
            case TouchInfo.Ended:
            break;
        }
    }
}
