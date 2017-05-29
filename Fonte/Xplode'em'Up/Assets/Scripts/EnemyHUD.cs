using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHUD : MonoBehaviour {
	private EnemyIA enemyScript;

	// Use this for initialization
	void Start () {
		enemyScript = GetComponent<EnemyIA>();
	}

	void OnGUI() {
		float yOffset = 10;
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);

		GUI.Box(new Rect(targetPos.x, targetPos.y + yOffset, 60, 20), enemyScript.currentHP + "/" + enemyScript.maxHP);
	}
}
