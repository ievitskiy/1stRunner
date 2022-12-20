using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class DeathCheck : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos =_rigidbody.position ;
        if (pos.y<-10){
            _rigidbody.transform.position = new Vector3(0, 1, 2);
            DeathScreen();
        }
    }
    void DeathScreen()
    {
        // GameObject myGO;
        // GameObject myText;
        // Canvas myCanvas;
        // Text text;
        // RectTransform rectTransform;

        // // Canvas
        // myGO = new GameObject();
        // myGO.name = "TestCanvas";
        // myGO.AddComponent<Canvas>();

        // myCanvas = myGO.GetComponent<Canvas>();
        // myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        // myGO.AddComponent<CanvasScaler>();
        // myGO.AddComponent<GraphicRaycaster>();
        // myCanvas.planeDistance = 1;
        // myCanvas.worldCamera = cam;

        // // Text
        // myText = new GameObject();
        // myText.transform.parent = myGO.transform;
        // myText.name = "wibble";

        // text = myText.AddComponent<Text>();
        // text.font = (Font)Resources.Load("MyFont");
        // text.text = "wobble";
        // text.fontSize = 100;

        // // Text position
        // rectTransform = text.GetComponent<RectTransform>();
        // rectTransform.localPosition = new Vector3(0, 0, 0);
        // rectTransform.sizeDelta = new Vector2(400, 200);

    }
}

