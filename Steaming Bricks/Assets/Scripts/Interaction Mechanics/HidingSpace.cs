﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpace : MonoBehaviour {
    [SerializeField] private LayerMask hiddenLayer;
    [SerializeField] private float interactDistance;
    private bool hidding;

	// Use this for initialization
	void Start () {
        hidding = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hide()
    {
        //check if the player is clsoe enough to hide
        float difference = Vector3.Distance(GameManager.Instance.player.transform.position, this.gameObject.transform.position); //dista between player and this hiding spot
        if(difference <= interactDistance)
        {
            //set hidden variable to true
            hidding = true;

            //change tiny terry layer mask so he wont be picked up by guards
            GameManager.Instance.player.layer = hiddenLayer;

            //stop tiny from moving
            GameManager.Instance.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            //turn tiny terry object invisible - coroutine?
            StartCoroutine(Fade(0, -1, GameManager.Instance.player));
        }
    }

    public void StopHidding()
    {
        //set hidden variable to false
        hidding = false;

        //chnage tiny terry mask back to default
        GameManager.Instance.player.layer = 0; //0 is Default layer

        //stop tiny from moving
        GameManager.Instance.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //clear freeze
        GameManager.Instance.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; //refreeze rotation

        //make tiny terry visible again
        StartCoroutine(Fade(255, 1, GameManager.Instance.player));
    }

    /// <summary>
    /// Fade the specified object
    /// </summary>
    /// <param name="endAlpha">the desired alpha at the end of the fade</param>
    /// <param name="direction">Direction of fade -1 for fade out +1 for fade in</param>
    /// <param name="affectedObj">Affected object by fade</param>
    IEnumerator Fade(float endAlpha, float direction, GameObject affectedObj)
    {
        //get objs rednerer colour
        Color c = affectedObj.GetComponent<Renderer>().material.color;

        //loop and edit colour
        for (float f = 1f; f == endAlpha; f += direction)
        {
            //update alpha
            c.a = f;

            //give new colour to obj
            affectedObj.GetComponent<Renderer>().material.color = c;

            //idk man it was in the example
            yield return null;
        }
    }
}
