using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private PlayerController playerController;
    private Slider currentHP;
//	private Gun gun;
	public static GameManager gm;
	public float currentTimeScale = 1;

	void Awake() {
		if (gm == null)
			gm = this;
		else if (gm != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentHP = GameObject.FindGameObjectWithTag("HUD").GetComponentInChildren<Slider>();
        currentHP.value = playerController.maxHP;
//		gun = playerController.GetComponentInChildren<Gun>();
    }
	
	// Update is called once per frame
	void Update () {
		SetTimeScale();
        UpdateHUD();
	}

    private void UpdateHUD() {
        currentHP.value = playerController.currentHP < 0 ? 0 : playerController.currentHP;
    }

    public static void ResetStage() {
		SceneManager.LoadScene("StageTest");
	}

	public static void TogglePause() {
		gm.currentTimeScale = gm.currentTimeScale == 0 ? 1 : 0;
		gm.SetTimeScale();
	}

	private void SetTimeScale() {
		Time.timeScale = gm.currentTimeScale;
    
//		gun.enabled = gm.currentTimeScale > 0 ? true : false;
	}
}
