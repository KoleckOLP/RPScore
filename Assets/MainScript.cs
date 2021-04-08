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
    public string videoname;
    public int rando;

    // Start is called before the first frame update
    void Start()
    {
        video.prepareCompleted += prepareCompleted;
        video.loopPointReached += loopPointReached;
        video.url = Application.dataPath + "/video/1_0_game.mp4";
        video.Prepare();
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

    private void loopPointReached(VideoPlayer v){ //Code to be ran when video ends.
        videoname = Path.GetFileName(video.url);
        if(videoname == "1_0_game.mp4"){
            Random();
            GameLayer.SetActive(true); //Activates the GaySlayer (as for Soldat's request)
        }
    }

    public int Random(){
        System.Random rd = new System.Random();

        rando = rd.Next(1, 4);

        switch (rando)
        {
            case 1:
                Debug.Log("She chose Rock!");
                break;
            case 2:
                Debug.Log("She chose paper!");
                break;
            case 3:
                Debug.Log("She chose Scissors!");
                break;
        }
        
        return rando;
	}

	//==========ROCK==========
	/*public void Click_rock(){ //1
		if(round == 1.0){
			if(rando == 1){ 		//draw r r

			}
			else if(rando == 2){ 	//lost r p

			}
			else{ 					//win r s !!!

			}
		}
	}

	//==========PAPER==========
	public void Click_paper(){ //2
		if(round == 1.0){
			if(rando == 1){ 		//win p r !!!

			}
			else if(rando == 2){ 	//draw p p

			}
			else{ 					//lost p s

			}
		}
	}

	//==========SCISSORS==========
	public void Click_scissors(){ //3
		if(round == 1.0){
			if(rando == 1){ 		//lose s r

			}
			else if(rando == 2){ 	//win s p !!!

			}
			else{ 					//draw s s 

			}
		}
	}*/

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

