using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private PlayerController playerController;
    private Slider currentHP;
	private Gun gun;
	private Text currentTimer;
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
		gun = playerController.GetComponentInChildren<Gun>();
        currentHP = GameObject.FindGameObjectWithTag("HUD").GetComponentInChildren<Slider>();
		currentTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        currentHP.value = playerController.maxHP;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			TogglePause();
		
        UpdateHUD();
	}

    private void UpdateHUD() {
		if (currentTimer == null)
			currentTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        currentHP.value = playerController.currentHP < 0 ? 0 : playerController.currentHP;
		currentTimer.text = "Timer: " + Time.timeSinceLevelLoad.ToString("0:00");
    }

    public static void ResetStage() {
		SceneManager.LoadScene("StageTest");
	}

	public static void TogglePause() {
		gm.currentTimeScale = gm.currentTimeScale == 0 ? 1 : 0;
		gm.SetTimeScale();
	}

	private void SetTimeScale() {
		bool enabled = gm.currentTimeScale > 0 ? true : false;

		Time.timeScale = gm.currentTimeScale;
		playerController.enabled = enabled;
		gun.enabled = enabled;
	}
}
