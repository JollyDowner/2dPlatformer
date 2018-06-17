using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour {

    private Animator anim;
    private bool shouldOpen = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleOpen()
    {
        anim.SetBool("isTouched", true);
    }

}



