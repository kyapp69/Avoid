﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 touchPosition;
    public Vector3 pixelTouchPosition;
    public Camera camera;
    public GameManager gm;
    public GameObject gemEffect;
    public GameObject[] skins;
    public int gemsCollected;


    // Use this for initialization
    void Start () {
        Instantiate(skins[PlayerPrefs.GetInt("skin")],GetComponent<Transform>());
	}
	
	// Update is called once per frame
	void Update () {
        if (gm.isStarted)
        {
            brackeysMove();
        }
        }

    public void brackeysMove(){
        if(Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            touchPosition = camera.ScreenToWorldPoint(touch.position);
            pixelTouchPosition = touch.position;
            touchPosition.z = 0f;
            transform.position = Vector3.Slerp(transform.position, touchPosition, 0.5f); ;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("found collision");
        if(collision.gameObject.CompareTag("block")){
            //Debug.Log("collision is a block");
            gm.endGame();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            //Debug.Log("collision is a block");
            Destroy(collision.gameObject);
            gemsCollected++;
            Instantiate(gemEffect, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.CompareTag("block"))
        {
            //Debug.Log("collision is a block");
            gm.endGame();
        }
    }


}