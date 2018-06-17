using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UIManager : MonoBehaviour {
    public Text objectiveText;
    public Image inventoryWidget;
    public Text victoryText;

    public GameObject player;
    // Use this for initialization
    void Start () {
        victoryText.text = "";
        objectiveText.text = "The key to the chest\nis this way------------ > ";
        inventoryWidget.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlatformerCharacter2D>().getHaskey())
        {
            objectiveText.text = "alright dude, nice\nnow get back to the chest";
            inventoryWidget.gameObject.SetActive(true);
        }

        if (player.GetComponent<PlatformerCharacter2D>().getHasTurnedIn())
        {
            objectiveText.text = "";
            inventoryWidget.gameObject.SetActive(false);
            victoryText.text = "wow\ngood job";
        }


	}
}
