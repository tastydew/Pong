using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    private float currentXPos;
    private float currentYPos;
    public float movementSpeed;

    public KeyCode upKey;
    public KeyCode downKey;

    private Renderer renderer;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        Debug.Log(renderer.bounds.size.y);
    }
	
	// Update is called once per frame
	void Update () {


        // Script for mouse movement.
        //if (gameObject.name == "PlayerOne")
        //{
        //    float mousePositionOnScreen = (Input.mousePosition.y / Screen.height) * 9;
        //    gameObject.transform.position = new Vector2(currentXPos, mousePositionOnScreen);
        //    currentYPos.y = Mathf.Clamp(mousePositionOnScreen, -4.15f, 4.15f);
        //    this.transform.position = currentYPos;
        //}

        currentYPos = gameObject.transform.localPosition.y;
        currentXPos = gameObject.transform.localPosition.x;

        if ((currentYPos + (renderer.bounds.size.y / 2)) > 5f)
        {
            currentYPos = 5f - (renderer.bounds.size.y / 2);
        }

        if ((currentYPos - (renderer.bounds.size.y / 2)) < -5f)
        {
            currentYPos = -5f + (renderer.bounds.size.y / 2);
        }

        if (Input.GetKey(downKey))
        {
            gameObject.transform.localPosition = new Vector2(currentXPos, currentYPos - movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(upKey))
        {
            gameObject.transform.localPosition = new Vector2(currentXPos, currentYPos + movementSpeed * Time.deltaTime);
        }
	}
}
