using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource bgSoundManager, diamondSoundManager, jumpSoundManager;

	public Button musicBtn;
	public Sprite music_On_Img, music_Off_Img;
	private bool playMusic;

	void Awake () {
		MakeInstance ();
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	public void MusicControl() {
		if (playMusic) {
			
			playMusic = false;
			musicBtn.image.sprite = music_On_Img;

			bgSoundManager.Stop ();

		} else {

			playMusic = true;
			musicBtn.image.sprite = music_Off_Img;

			bgSoundManager.Play ();

		}
	}

	public void PlayDiamondSound() {
		diamondSoundManager.Play ();
	}

	public void PlayJumpSound() {
		jumpSoundManager.Play ();
	}

} // class






























