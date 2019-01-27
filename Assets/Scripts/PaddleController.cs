using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

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

        currentYPos = transform.localPosition.y;

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
            transform.localPosition = new Vector2(transform.position.x, currentYPos - movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(upKey))
        {
            transform.localPosition = new Vector2(transform.position.x, currentYPos + movementSpeed * Time.deltaTime);
        }
	}
}
