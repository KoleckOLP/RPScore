using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	void Start () {
		video.seekCompleted += seekCompleted;
	}

	/* #region Declaration */
	public VideoPlayer video;
	public GameObject GameLayer;
	public GameObject DebugLayer;
	public double round = 0.9;
	public int rando;
	public int lost = 0;
	public bool win = false;
	public bool draw = false;
	/* #endregion */
	
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

		if(round == 0){
			video.time = 0;
			video.Play();
			GameLayer.SetActive(false);
		}
		else if(round == 0.9 && video.time >= 23.99){ //start
			video.Pause();
			win =  false;
			draw = false;
			round = 1.0;
			GameLayer.SetActive(true);
			rando = Random();
		}
		else if(round == 1.1){ //lost
			video.time = 30.5;
		}
		else if(round == 1.2){ //draw
			video.time = 36.0;
		}
		else if(round == 1.3){ //lost_draw 2
			video.time = 43.0;
		}
		else if(round == 1.4){ //lost_draw 3 or more
			video.time = 49.0;
		}
		else if(round == 1.5){
			if(rando == 1){ //rock
				if(video.time >= 600.777){
					if(win){
						round = 1.6;
					}
					else{
						if(lost == 1){
							if(draw){
								round = 1.2;
							}
							else{
								round = 1.1;
							}
						}
						else if(lost == 2){
							round = 1.3;
						}
						else{
							round = 1.4;
						}
					}
				}
			}
			else if (rando == 2){ //paper
				if(video.time >= 612.0){ // if you get close to the end of the video Unity can't seek fast enough.
					if(win){
						round = 1.6;
					}
					else{
						if(lost == 1){
							if(draw){
								round = 1.2;
							}
							else{
								round = 1.1;
							}
						}
						else if(lost == 2){
							round = 1.3;
						}
						else{
							round = 1.4;
						}
					}
				}
			}
			else{ //scissors
				if(video.time >= 607.287){
					if(win){
						round = 1.6;
					}
					else{
						if(lost == 1){
							if(draw){
								round = 1.2;
							}
							else{
								round = 1.1;
							}
						}
						else if(lost == 2){
							round = 1.3;
						}
						else{
							round = 1.4;
						}
					}
				}
			}
		}
		else if(round == 1.6){
			video.time = 24.5;
		}
		else if(round == 1.9){
			if(video.time >= 30.172){
				Debug.Log("oof: "+video.time);
				video.time = 58;
			}
		}
		else if(round == 2.0){
			if(video.time >= 93.118){
				video.Pause();
				GameLayer.SetActive(true);
				rando = Random();
			}
		}
		else if(round == 10.1 && video.time >= 35.927){
			round = 0;
		}
		else if(round == 10.2 && video.time >= 42.810){
			round = 0;
		}
		else if(round == 10.3 && video.time >= 48.564){
			round = 0;
		}
		else if(round == 10.4 && video.time >= 57.682){
			round = 0;
		}
	}

	public void seekCompleted(VideoPlayer v){
		if(round == 0){
			round = 0.9;
		}
		else if(round == 1.1){
			round = 10.1;
		}
		else if(round == 1.2){
			round = 10.2;
		}
		else if(round == 1.3){
			round = 10.3;
		}
		else if(round == 1.4){
			round = 10.4;
		}
		else if(round == 1.3){

		}
		else if(round == 1.4){

		}
		else if(round == 1.6){
			round = 1.9;
		}
		else if(round == 1.9 &&  video.time >= 29){
			round = 2.0;
		}
	}

	//=====RANDOM=====
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

	//==========ROCK==========
	public void Click_rock(){ //1
		if(round == 1.0){
			if(rando == 1){ 		//draw r r
				video.time = 595.5; //play rock
				round = 1.5;
				lost = lost + 1;
				win = false;
				draw = true;
				video.Play();
				Debug.Log("Draw");
				GameLayer.SetActive(false);
			}
			else if(rando == 2){ 	//lost r p
				video.time = 607.5; //play paper
				round = 1.5;
				lost = lost + 1;
				win = false;
				video.Play();
				Debug.Log("You Lost");
				GameLayer.SetActive(false);
			}
			else{ 					//win r s !!!
				video.time = 601.0; //play scisors
				round = 1.5;
				win = true;
				video.Play();
				Debug.Log("You Won");
				GameLayer.SetActive(false);
			}
		}
	}

	//==========PAPER==========
	public void Click_paper(){ //2
		if(round == 1.0){
			if(rando == 1){ 		//win p r !!!
				video.time = 595.5; //play rock
				round = 1.5;
				win = true;
				video.Play();
				Debug.Log("You Won");
				GameLayer.SetActive(false);
			}
			else if(rando == 2){ 	//draw p p
				video.time = 607.5; //play paper
				round = 1.5;
				lost = lost + 1;
				win = false;
				draw = true;
				video.Play();
				Debug.Log("Draw");
				GameLayer.SetActive(false);
			}
			else{ 					//lost p s
				video.time = 601.0; //play scisors
				round = 1.5;
				lost = lost + 1;
				win = false;
				video.Play();
				Debug.Log("Draw");
				GameLayer.SetActive(false);
			}
		}
	}

	//==========SCISSORS==========
	public void Click_scissors(){ //3
		if(round == 1.0){
			if(rando == 1){ 		//lose s r
				video.time = 595.5; //play rock
				round = 1.5;
				lost = lost + 1;
				win = false;
				video.Play();
				Debug.Log("Draw");
				GameLayer.SetActive(false);
			}
			else if(rando == 2){ 	//win s p !!!
				video.time = 607.5; //play paper
				round = 1.5;
				win = true;
				video.Play();
				Debug.Log("You Won");
				GameLayer.SetActive(false);
			}
			else{ 					//draw s s 
				video.time = 601.0; //play scisors
				round = 1.5;
				lost = lost + 1;
				win = false;
				draw = true;
				video.Play();
				Debug.Log("Draw");
				GameLayer.SetActive(false);
			}
		}
	}

	//==========DEBUG==========
	public void debug_click(Button button){
		string debug;
		debug = button.name;

		if(debug == "Debug0"){
			round = 0.9;
			video.time = 0;
			video.Play();
			GameLayer.SetActive(false);
		}
		else if(debug == "Debug0.9"){
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
		else if(debug == "Debug1.1"){
			round = 1.1;
			video.time = 30.5;
			rando = 1;
		}
		else if(debug == "Debug1.2"){
			round = 1.2;
			video.time = 36.0;
			rando = 1;
		}
		else if(debug == "Debug1.3"){
			round = 1.3;
			video.time = 43.0;
			rando = 1;
		}
		else if(debug == "Debug1.4"){
			round = 1.4;
			video.time = 49.0;
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
