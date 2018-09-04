using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {

	public List<GameObject> colorsObj = new List<GameObject> ();
	public GameObject panelGame, panelLevel;
	public Text aciertosText, etapaText, result, messagesText;

	List<string> numbers = new List<string>();

	string[] colors = new string[]
	{
		"Red","Green","Blue","Yellow"
	};

	string[] messages = new string[]
	{
		"Sigueme El Paso", "No Falles", "Eres Bueno", "Te Voy Hacer Fallar", "Perderas", "Mmmm", "No Perdere"
	};

	int count, i, etapa,aciertos;

	float level;

	bool canTouch;

	void Start(){
		
	}

	void Update(){
		etapaText.text = "Etapa: " + etapa.ToString ();
		aciertosText.text = "Aciertos: " + aciertos.ToString ();
	}

	public void StartGame(float l){
		panelGame.SetActive (true);
		panelLevel.SetActive (false);
		level = l;
		Invoke ("SelectColor", level);
	}

	void SelectColor(){
		CancelInvoke ("SelectColor");
		etapa++;
		result.text = "Etapa " + etapa.ToString();
		messagesText.text = string.Empty;
		canTouch = false;
		i = Random.Range (0, colors.Length);
		numbers.Add (colors[i]);
		InvokeRepeating("AnimationColor", 0.0f, level);
	}

	void AnimationColor(){
		if (count < numbers.Count) {
			foreach (GameObject c in colorsObj) {
				if (c.name == numbers [count]) {
					c.GetComponent<ColorManager> ().canScale = true;
				}
			}
			count++;
		} else {
			CancelInvoke ("AnimationColor");
			count = 0;
			canTouch = true;
			result.text = "Tu Turno !!!";
		}
	}
	

	public void TouchColorCompare(string nameColor){
		if(!canTouch)return;
		if (nameColor != numbers [count]) {
			result.text = "Perdiste";
			Invoke ("RestartGame", 2.1f);
		} else {
			result.text = "Correcto !!!";
			count++;
			aciertos = count + aciertos;
			if (count >= numbers.Count) {
				count = 0;
				messagesText.text = messages[Random.Range (0, messages.Length)];
				Invoke ("SelectColor", level);
			}
		}
	}

	void RestartGame(){
		CancelInvoke ("RestartGame");
		count = 0;
		aciertos = 0;
		etapa = 0;
		numbers.Clear ();
		SelectColor ();
	}
}
