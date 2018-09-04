using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {


	public float speed;
	public bool canScale;

	float parameter = 1;

	RectTransform trans;

	void Start () {
		trans = GetComponent<RectTransform> ();
	}
	

	void Update () {
		if (canScale) {
			parameter += 0.01f * Time.deltaTime * speed;
			trans.localScale = new Vector3 (parameter, parameter, parameter);
			if (trans.localScale.x >= 1.3f) {
				canScale = false;
			}
		} else {
			if (trans.localScale.x > 1.0f) {
				parameter -= 0.01f * Time.deltaTime * speed;
				trans.localScale = new Vector3 (parameter, parameter, parameter);
			} else {
				trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			}
		}
	}
}
