using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource bgSoundManager, diamondSoundManager, jumpSoundManager, atkSoundManager, shurikenSoundManager, hitSoundManager,hurtSoundManager,potionSoundManager,teleportSoundManager;

	public Button musicBtn;
	public Sprite music_On_Img, music_Off_Img;
	private bool playMusic;

	void Awake () {
		MakeInstance ();
		bgSoundManager.Play();
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
		if(diamondSoundManager)
		diamondSoundManager.Play ();
	}

	public void PlayPotionSound() {
		if(potionSoundManager)
		potionSoundManager.Play ();
	}

	public void PlayJumpSound() {
		if(jumpSoundManager)
		jumpSoundManager.Play ();
	}

	public void PlayAtkSound(){
		
		if(atkSoundManager.isPlaying == false && atkSoundManager){
			atkSoundManager.Play();

		}

		
	}

	public void PlayShurikenSound(){
		if(shurikenSoundManager)
		shurikenSoundManager.Play();
	}	

	public void PlayHitSound(){
		if(hitSoundManager)
		hitSoundManager.Play();

	}	

	public void PlayHurtSound(){
		if(hurtSoundManager)
		hurtSoundManager.Play();
	}	

	public void PlayTeleportSound(){
		if(teleportSoundManager)
		teleportSoundManager.Play();
	}	


} // class






























