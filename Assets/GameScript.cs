using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		video.seekCompleted += seekCompleted;
	}

	public VideoPlayer video;

	public GameObject GameLayer;
	public GameObject DebugLayer;

	public double round = 0.9;
	public int rando;
	public bool isDone;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			video.Prepare();
			if (!video.isPlaying)
				video.Play();
			else
				video.Pause();
		}

		if(Input.GetKeyDown(KeyCode.Keypad1)){
			video.time = 300;
		}

		if(Input.GetKeyDown(KeyCode.D)){
			DebugLayer.SetActive(!DebugLayer.activeSelf);
		}

		if(Input.GetKeyDown(KeyCode.G)){
			GameLayer.SetActive(!GameLayer.activeSelf);
		}

		if(round == 0.9 && video.time >= 23.99){
			video.Pause();
			round = 1.0;
			GameLayer.SetActive(true);
			rando = Random();
		}
		if(round == 1.5){
			if(rando == 1){ //rock
				if(video.time >= 600.777){
					round = 1.6;
				}
			}
			else if (rando == 2){ //paper
				if(video.time >= 612.0){ // if you get close to the end of the video Unity can't seek fast enough.
					round = 1.6;
				}
			}
			else{ //scissors
				if(video.time >= 607.287){
					round = 1.6;
				}
			}
		}
		if(round == 1.6){
			video.time = 24.5;
		}
		if(round == 1.9){
			if(video.time >= 30.172){
				Debug.Log("oof: "+video.time);
				video.time = 58;
			}
		}
		if(round == 2.0){
			if(video.time >= 93.118){
				video.Pause();
				GameLayer.SetActive(true);
				rando = Random();
			}
		}

		Debug.Log(video.time);
	}

	public void seekCompleted(VideoPlayer v){
		if(round == 1.6){
			round = 1.9;
		}
		if(round == 1.9 &&  video.time >= 29){
			round = 2.0;
		}
	}


	public int Random(){
		if(round == 1.0){
			System.Random rd = new System.Random();

      		rando = rd.Next(1, 4);

			Debug.Log("1 rock, 2 paper, 3 scisors: "+rando);
			return rando;
		}
		else{
			return 0;
		}
	}

	public void Click_rock(){ //1
		if(round == 1.0){
			if(rando == 1){ //draw r r
				video.time = 594.954; //play rock
				
				video.Play();
				Debug.Log("Draw");
			}
			else if(rando == 2){ //lost r p
				video.time = 604.288; //play paper
				video.Play();
				Debug.Log("You Lost");
			}
			else{ //win r s
				video.time = 601.0; //play scisors
				round = 1.5;
				if(video.isPrepared){
					video.Play();
					Debug.Log("You Won");
				}
				GameLayer.SetActive(false);
			}
		}
	}

	public void Click_paper(){ //2
		if(round == 1.0){
			if(rando == 1){ //win p r
				video.time = 595.5; //play rock
				round = 1.5;
				if(video.isPrepared){
					video.Play();
					Debug.Log("You Won");
				}
				GameLayer.SetActive(false);
			}
			else if(rando == 2){ //draw p p
				video.time = 604.288; //play paper
				video.Play();
				Debug.Log("Draw");
			}
			else{ //lost p s
				video.time = 600.778; //play scisors
				video.Play();
				Debug.Log("You Lost");
			}
		}
	}

	public void Click_scissors(){ //3
		if(round == 1.0){
			if(rando == 1){ //lose s r
				video.time = 594.954; //play rock
				video.Play();
				Debug.Log("You Lost");
			}
			else if(rando == 2){ //win s p
				video.time = 607.5; //play paper
				round = 1.5;
				if(video.isPrepared){
					video.Play();
					Debug.Log("You Won");
				}
				GameLayer.SetActive(false);
			}
			else{ //draw s s 
				video.time = 600.778; //play scisors
				video.Play();
				Debug.Log("Draw");
			}
		}
	}

	public void debug_click(Button button){
		string debug;
		debug = button.name;

		if(debug == "Debug0.9"){
			round = 0.9;
			video.time = 0;
		}
		else if(debug == "Debug1.0"){
			round = 0.9;
			video.time = 23.99;
		}
		else if(debug == "Debug1.5"){
			round = 1.6;
			video.time = 25.0;
			rando = 1;
		}
		else if(debug == "Debug1.6"){
			round = 1.9;
			video.time = 58;
			rando = 1;
		}
		else if(debug == "Debug1.9"){
			round = 2.0;
			video.time = 74;
			rando = 1;
		}
		else if(debug == "Debug2.0"){
			round = 2.0;
			video.time = 93.1;
			rando = 1;
		}
		else if(debug == "Debug9.1"){ //rock
			round = 1.5;
			video.time = 595.5;
			rando = 1;
		}
		else if(debug == "Debug9.2"){ //paper
			round = 1.5;
			video.time = 607.5;
			rando = 2;
		}
		else if(debug == "Debug9.3"){ //scissors
			round = 1.5;
			video.time = 601.0;
			rando = 3;
		}
	}
}
