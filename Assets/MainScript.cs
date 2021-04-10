using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject GameLayer;
	public GameObject DebugLayer;
	public GameObject Cheat;
    public string videoname;
    public int rando = 0;
	public string cheat = "cheat";
	public bool win = false;
	public bool lost = false;
	public bool draw = false;
	public int lose = 0;

	// Static variables to make me more lazy
	public string vn(string inp){
		string vpath = "/video/";
		string name = vpath + inp + ".mp4";
		return name;
	}

    // Start is called before the first frame update
    void Start()
    {
        video.prepareCompleted += prepareCompleted;
        video.loopPointReached += loopPointReached;
        playvid(vn("1_0_game"));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug play/pause
        if(Input.GetKeyDown(KeyCode.Space)){
			if (!video.isPlaying)
				video.Play();
			else
				video.Pause();
		}

        //Debug DebugLayer
        if(Input.GetKeyDown(KeyCode.D)){
			DebugLayer.SetActive(!DebugLayer.activeSelf);
		}

        //Debug GameLayer
		if(Input.GetKeyDown(KeyCode.G)){
			GameLayer.SetActive(!GameLayer.activeSelf);
		}
    }

    private void prepareCompleted(VideoPlayer v){ //Autoplaying the first clip
		video.Play();
    }

	public void playvid(string vid){
		video.url = Application.dataPath + vid;
		video.Prepare();
		videoname = Path.GetFileName(video.url);
		Debug.Log("playvid " + videoname);
	}

	private void win_lose(){
		Debug.Log("hit");
		if(win){
			playvid(vn("1_5_win"));
		}
		if(lost){
			if(lose == 1){
				if(draw){
					playvid(vn("1_2_draw"));
				}
				else{
					playvid(vn("1_1_lose"));
				}
			}
			else if(lose == 2){
				playvid(vn("1_3_lose"));
			}
			else{
				playvid(vn("1_4_lose"));
			}
		}
	}

    private void loopPointReached(VideoPlayer v){ //Code to be ran when video ends.
		Debug.Log("hit_main");
		
		if(videoname == "1_0_game.mp4"){
            Random();
            GameLayer.SetActive(true); //Activates the GaySlayer (as for Soldat's request)
        }

		if(videoname == "6_1_rock"){
			win_lose();
		}
		
		if(videoname == "6_2_paper"){
			win_lose();
		}
		
		if(videoname == "6_3_scissors"){
			win_lose();
		}
    }

    public int Random(){
        System.Random rd = new System.Random();

        rando = rd.Next(1, 4);

        switch (rando)
        {
            case 1:
				cheat = "She chose Rock!";
                break;
            case 2:
				cheat = "She chose Scissors!";
                break;
            case 3:
				cheat = "She chose Scissors!";
                break;
        }
        
		Debug.Log(cheat);
		Cheat.GetComponent<UnityEngine.UI.Text>().text = cheat;
        return rando;
	}

	//==========ROCK==========
	public void Click_rock(){ //1
		if(videoname == "1_0_game.mp4"){
			if(rando == 1){ 		//draw r r
				lose += lose;
				win = false;
				lost = true;
				draw = true;
				playvid(vn("6_1_rock"));
			}
			else if(rando == 2){ 	//lost r p
				lose += lose;
				win = false;
				lost = true;
				draw = false;
				playvid(vn("6_2_paper"));
			}
			else{ 					//win r s !!!
				win = true;
				lost = false;
				draw = false;
				playvid(vn("6_3_scissors"));
			}
		}
	}

	//==========PAPER==========
	public void Click_paper(){ //2
		if(videoname == "1_0_game.mp4"){
			if(rando == 1){ 		//win p r !!!
				win = true;
				lost = false;
				draw = false;
				playvid(vn("6_1_rock"));
			}
			else if(rando == 2){ 	//draw p p
				lose += lose;
				win = false;
				lost = true;
				draw = true;
				playvid(vn("6_2_paper"));
			}
			else{ 					//lost p s
				lose += lose;
				win = false;
				lost = true;
				draw = false;
				playvid(vn("6_3_scissors"));
			}
		}
	}

	//==========SCISSORS==========
	public void Click_scissors(){ //3
		if(videoname == "1_0_game.mp4"){
			if(rando == 1){ 		//lose s r
				lose += lose;
				win = false;
				lost = true;
				draw = false;
				playvid(vn("6_1_rock"));
			}
			else if(rando == 2){ 	//win s p !!!
				win = true;
				lost = false;
				draw = false;
				playvid(vn("6_2_paper"));
			}
			else{ 					//draw s s 
				lose += lose;
				win = false;
				lost = true;
				draw = true;
				playvid(vn("6_3_scissors"));
			}
		}
	}

    //==========DEBUG==========
	public void debug_click(Button button){
		string debug;
		debug = button.name;

		if(debug == "Debug0.9"){        //Reset?
			video.time = 0;
		}
		else if(debug == "Debug1.0"){   //Skip
			video.time = 24;
		}
		/*else if(debug == "Debug1.5"){
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
		}*/
	}
}

