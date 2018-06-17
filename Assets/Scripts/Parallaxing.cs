using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;			
	private float[] parallaxScales;			// multipliers for parallax scrolling
	public float smoothing = 1f;			

	public Transform cam;					
	private Vector3 previousCamPos;			

	void Awake () {

	}

	void Start () {
		// new cam pos
		previousCamPos = cam.position;

		// assign scalings
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	

	void Update () {


		for (int i = 0; i < backgrounds.Length; i++) {
			// opposite of camera movement times scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position 
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position 
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// interpolate to new pos
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// prev camera
		previousCamPos = cam.position;
	}
}
