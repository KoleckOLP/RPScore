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
    public GameObject Rock;
	public GameObject paper;
	public GameObject Scissors;
	public GameObject DebugLayer;
	public GameObject Cheat;
	public GameObject Lost;
    public string videoname;
    public int rando = 0;
	public string cheat = "cheat";
	public bool win = false;
	public bool lost = false;
	public bool draw = false;
	public int lose = 0;

	// Static variables to make me more lazy
	public string vn(string inp){
		string name = Application.streamingAssetsPath + Path.AltDirectorySeparatorChar + inp;
		return name;
	}

    // Start is called before the first frame update
    void Start()
    {
        video.prepareCompleted += prepareCompleted;
        video.loopPointReached += loopPointReached;
        playvid(vn("1_0_game.mp4"));
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
			GameLayer(!Rock.activeSelf);
		}
    }

	private void GameLayer(bool actv){
		Rock.SetActive(actv);
		paper.SetActive(actv);
		Scissors.SetActive(actv);
	}

    private void prepareCompleted(VideoPlayer v){ //Autoplaying the first clip
		video.Play();
    }

	public void playvid(string vid){
		video.url = vid;
		video.Prepare();
		videoname = Path.GetFileName(vid);
	}

	private void win_lose(){
		if(win){
			playvid(vn("1_5_win.mp4"));
		}
		if(lost){
			if(lose == 1){
				if(draw){
					playvid(vn("1_2_draw.mp4"));
				}
				else{
					playvid(vn("1_1_lose.mp4"));
				}
			}
			else if(lose == 2){
				playvid(vn("1_3_lose.mp4"));
			}
			else{
				playvid(vn("1_4_lose.mp4"));
			}
		}
	}

    private void loopPointReached(VideoPlayer v){ //Code to be ran when video ends.
		if(videoname == "1_0_game.mp4"){ //Stage 1
            Random();
            GameLayer(true); //Activates the GaySlayer (as for Soldat's request)
        }
		else if(videoname == "6_1_rock.mp4" || videoname == "6_2_paper.mp4" || videoname == "6_3_scissors.mp4"){ // in the final game it can be else
			win_lose();
			if(lost){
				Lost.GetComponent<UnityEngine.UI.Text>().text = "Lost: " + lose.ToString();
			}
		}
		else if(videoname == "1_1_lose.mp4" || videoname == "1_1_lose.mp4" || videoname == "1_2_draw.mp4" || videoname == "1_3_lose.mp4" || videoname == "1_4_lose.mp4"){
			playvid(vn("1_0_game.mp4"));
		}
		else if(videoname == "1_5_win.mp4"){
			lose = 0;
			playvid(vn("1_6_undress.mp4"));
		}
		else if(videoname == "1_6_undress.mp4"){
			playvid(vn("2_0_game.mp4"));
		}
		else if(videoname == "2_0_game.mp4"){ // Stage 2
			Random();
			GameLayer(true);
		}
    }

    public int Random(){
        System.Random rd = new System.Random();

        rando = rd.Next(1, 4);

        switch (rando)
        {
            case 1:
				cheat = "She chose: Rock! (" + rando + ")";
                break;
            case 2:
				cheat = "She chose: Paper! (" + rando + ")";
                break;
            case 3:
				cheat = "She chose: Scissors! (" + rando + ")";
                break;
        }
        
		Debug.Log(cheat);
		Cheat.GetComponent<UnityEngine.UI.Text>().text = cheat;
        return rando;
	}

	private void win_s(){
		win = true;
		lost = false;
		draw = false;
	}

	private void lose_s(){
		lose = lose + 1;
		win = false;
		lost = true;
		draw = false;
	}

	private void draw_s(){
		lose = lose + 1;
		win = false;
		lost = true;
		draw = true;
	}

	//==========ROCK==========
	public void Click_rock(){ //1
		if(rando == 1){ 		//draw r r
			draw_s();
			GameLayer(false);
			playvid(vn("6_1_rock.mp4"));
		}
		else if(rando == 2){ 	//lost r p
			lose_s();
			GameLayer(false);
			playvid(vn("6_2_paper.mp4"));
		}
		else{ 					//win r s !!!
			win_s();
			GameLayer(false);
			playvid(vn("6_3_scissors.mp4"));
		}
	}

	//==========PAPER==========
	public void Click_paper(){ //2
		if(rando == 1){ 		//win p r !!!
			win_s();
			GameLayer(false);
			playvid(vn("6_1_rock.mp4"));
		}
		else if(rando == 2){ 	//draw p p
			draw_s();
			GameLayer(false);
			playvid(vn("6_2_paper.mp4"));
		}
		else{ 					//lost p s
			lose_s();
			GameLayer(false);
			playvid(vn("6_3_scissors.mp4"));
		}
	}

	//==========SCISSORS==========
	public void Click_scissors(){ //3
		if(rando == 1){ 		//lose s r
			lose_s();
			GameLayer(false);
			playvid(vn("6_1_rock.mp4"));
		}
		else if(rando == 2){ 	//win s p !!!
			win_s();
			GameLayer(false);
			playvid(vn("6_2_paper.mp4"));
		}
		else{ 					//draw s s 
			draw_s();
			GameLayer(false);
			playvid(vn("6_3_scissors.mp4"));
		}
	}

    //==========DEBUG==========
	public void debug_click(Button button){
		string debug;
		debug = button.name;

		if(debug == "Debug0.9"){        //Reset?
			playvid(vn("1_0_game.mp4"));
		}
		else if(debug == "Debug1.0"){   //Skip time to stage 1 gameplay
			if(videoname == "1_0_game.mp4"){
				video.time = 24;
			}
			else{
				playvid(vn("1_0_game.mp4"));
				video.time = 24;
			}
		}
		else if(debug == "Debug1.1"){
			playvid(vn("1_1_lose.mp4"));
		}
		else if(debug == "Debug1.2"){
			playvid(vn("1_2_draw.mp4"));
		}
		else if(debug == "Debug1.3"){
			playvid(vn("1_3_lose.mp4"));
		}
		else if(debug == "Debug1.4"){
			playvid(vn("1_4_lose.mp4"));
		}
		else if(debug == "Debug1.5"){
			playvid(vn("1_5_win.mp4"));
		}
		else if(debug == "Debug1.6"){
			playvid(vn("1_6_undress.mp4"));
		}
		else if(debug == "Debug1.9"){
			playvid(vn("2_0_game.mp4"));
		}
		else if(debug == "Debug2.0"){
			if(videoname == "2_0_game.mp4"){
				video.time = 19;
			}
			else{
				playvid(vn("2_0_game.mp4"));
				video.time = 19;
			}
		}
		else if(debug == "Debug6.1"){ //rock
			playvid(vn("6_1_rock.mp4"));
		}
		else if(debug == "Debug6.2"){ //paper
			playvid(vn("6_2_paper.mp4"));
		}
		else if(debug == "Debug6.3"){ //scissors
			playvid(vn("6_3_scissors.mp4"));
		}
	}
}

