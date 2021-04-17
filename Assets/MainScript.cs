//using System;
using System.IO;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject rock;
    public GameObject paper;
    public GameObject scissors;
    public GameObject debugLayer;
    public GameObject cheat;
    public GameObject lost;
    public string videoname;
    public int rando;
    public string scheat = "cheat";
    public bool win;
    public bool draw;
    public int lose;
    public int stage;

    private enum Pick{
        Rock=1, Paper=2, Scissors=3
    }

    // Static variables to make me more lazy
    private static string Vn(string inp){
        var temp = Application.streamingAssetsPath + Path.AltDirectorySeparatorChar + inp;
        return temp;
    }

    // Start is called before the first frame update
    private void Start(){
        video.prepareCompleted += PrepareCompleted;
        video.loopPointReached += LoopPointReached;
        PlayVid(Vn("1_0_game.mp4"));
    }

    // Update is called once per frame
    private void Update(){
        //Debug play/pause
        if(Input.GetKeyDown(KeyCode.Space)){
            if (!video.isPlaying)
                video.Play();
            else
                video.Pause();
        }

        //Debug DebugLayer
        if(Input.GetKeyDown(KeyCode.D)){
            debugLayer.SetActive(!debugLayer.activeSelf);
        }

        //Debug GameLayer
        if(Input.GetKeyDown(KeyCode.G)){
            GameLayer(!rock.activeSelf);
        }
    }

    private void GameLayer(bool actv){
        rock.SetActive(actv);
        paper.SetActive(actv);
        scissors.SetActive(actv);
    }

    private void PrepareCompleted(VideoPlayer v){ //Autoplaying the first clip
        video.Play();
    }

    private void PlayVid(string vid){
        video.url = vid;
        video.Prepare();
        videoname = Path.GetFileName(vid);
    }

    private void GameResult(int stg)
    {
        if(win){
            PlayVid(Vn($"{stg}_5_win.mp4"));
            return;
        }
        switch (lose){
            case 1 when draw:
                PlayVid(Vn($"{stg}_2_draw.mp4"));
                return;
            case 1:
                PlayVid(Vn($"{stg}_1_lose.mp4"));
                return;
            case 2:
                PlayVid(Vn($"{stg}_3_lose.mp4"));
                break;
            default:
                PlayVid(Vn($"{stg}_4_lose.mp4"));
                break;
        }
    }

    private void Stage(int stg){
        if(videoname == $"{stage}_0_game.mp4"){ //Stage 1 vest
            Random();
            if(stg != 5){
                GameLayer(true); //Activates the GaySlayer (as for Soldat's request)
            }
        }
        else if(videoname == $"{stg}_1_lose.mp4" || videoname == $"{stg}_2_draw.mp4" || videoname == $"{stg}_3_lose.mp4" || videoname == $"{stg}_4_lose.mp4"){
            PlayVid(Vn($"{stg}_0_game.mp4"));
        }
        else if(videoname == $"{stg}_5_win.mp4"){
            lose = 0;
            PlayVid(Vn($"{stg}_6_undress.mp4"));
        }
        else if(videoname == $"{stg}_6_undress.mp4"){
            stage = stg + 1; //kinda ugly I hate it.
            PlayVid(Vn($"{stage}_0_game.mp4"));
        }
    }

    private void LoopPointReached(VideoPlayer v){ //Code to be ran when video ends.
        if(videoname == "6_1_rock.mp4" || videoname == "6_2_paper.mp4" || videoname == "6_3_scissors.mp4"){ // in the final game it can be else
            GameResult(stage);
            if(lose != 0){
                lost.GetComponent<Text>().text = "Lost: " + lose.ToString();
            }
        }
        else{
            Stage(stage);
        }
    }

    private void Random(){
        var rd = new System.Random();

        rando = rd.Next(1, 4);

        scheat = rando switch{
            1 => $"She chose: Rock! ({rando})",
            2 => $"She chose: Paper! ({rando})",
            3 => $"She chose: Scissors! ({rando})",
            _ => scheat
        };

        Debug.Log(scheat);
        cheat.GetComponent<Text>().text = scheat;
    }

    private void Win_s(){
        win = true;
        draw = false;
    }

    private void Lose_s(){
        lose += 1;
        win = false;
        draw = false;
    }

    private void Draw_s(){
        lose += 1;
        win = false;
        draw = true;
    }

    //==========ROCK==========
    public void Click_rock(){ //1
        GameLayer(false);
        switch(rando){
            case (int)Pick.Rock:
                Draw_s();
                PlayVid(Vn("6_1_rock.mp4"));
                break;
            case (int)Pick.Paper:
                Lose_s();
                PlayVid(Vn("6_2_paper.mp4"));
                break;
            case (int)Pick.Scissors:
                Win_s();
                PlayVid(Vn("6_3_scissors.mp4"));
                break;
        }
    }

    //==========PAPER==========
    public void Click_paper(){ //2
        GameLayer(false);
        switch(rando){
            case (int)Pick.Rock:
                Win_s();
                PlayVid(Vn("6_1_rock.mp4"));
                break;
            case (int)Pick.Paper:
                Draw_s();
                PlayVid(Vn("6_2_paper.mp4"));
                break;
            case (int)Pick.Scissors:
                Lose_s();
                PlayVid(Vn("6_3_scissors.mp4"));
                break;
        }
    }

    //==========SCISSORS==========
    public void Click_scissors(){ //3
        GameLayer(false);
        switch(rando){
            case (int)Pick.Rock:
                Lose_s();
                PlayVid(Vn("6_1_rock.mp4"));
                break;
            case (int)Pick.Paper:
                Win_s();
                PlayVid(Vn("6_2_paper.mp4"));
                break;
            case (int)Pick.Scissors: // to test if it needs to be pick.type
                Draw_s();
                PlayVid(Vn("6_3_scissors.mp4"));
                break;
        }
    }

    //==========DEBUG==========
    public void debug_click(Button button)
    {
        var debug = button.name;

        if(debug == "Debug0.9"){        //Reset?
            stage = 1;
            PlayVid(Vn("1_0_game.mp4"));
        }
        else if(debug == "Debug1.0"){   //Skip time to stage 1 gameplay
            if(videoname == "1_0_game.mp4"){
                video.time = 24;
            }
            else{
                stage = 1;
                PlayVid(Vn("1_0_game.mp4"));
                video.time = 24;
            }
        }
        else if(debug == "Debug1.1"){
            PlayVid(Vn("1_1_lose.mp4"));
        }
        else if(debug == "Debug1.2"){
            PlayVid(Vn("1_2_draw.mp4"));
        }
        else if(debug == "Debug1.3"){
            PlayVid(Vn("1_3_lose.mp4"));
        }
        else if(debug == "Debug1.4"){
            PlayVid(Vn("1_4_lose.mp4"));
        }
        else if(debug == "Debug1.5"){
            PlayVid(Vn("1_5_win.mp4"));
        }
        else if(debug == "Debug1.6"){
            PlayVid(Vn("1_6_undress.mp4"));
        }
        else if(debug == "Debug1.9"){
            stage = 2;
            PlayVid(Vn("2_0_game.mp4"));
        }
        else if(debug == "Debug2.0"){ //Stage 2
            if(videoname == "2_0_game.mp4"){
                video.time = 19.2;
            }
            else{
                stage = 2;
                PlayVid(Vn("2_0_game.mp4"));
                video.time = 19.2;
            }
        }
        else if(debug == "Debug2.1"){
            PlayVid(Vn("2_1_lose.mp4"));
        }
        else if(debug == "Debug2.2"){
            PlayVid(Vn("2_2_draw.mp4"));
        }
        else if(debug == "Debug2.3"){
            PlayVid(Vn("2_3_lose.mp4"));
        }
        else if(debug == "Debug2.4"){
            PlayVid(Vn("2_4_lose.mp4"));
        }
        else if(debug == "Debug2.5"){
            PlayVid(Vn("2_5_win.mp4"));
        }
        else if(debug == "Debug2.6"){
            PlayVid(Vn("2_6_undress.mp4"));
        }
        else if(debug == "Debug2.9"){
            stage = 3;
            PlayVid(Vn("3_0_game.mp4"));
        }
        else if(debug == "Debug3.0"){ //Stage 3
            if(videoname == "3_0_game.mp4"){
                video.time = 16.8;
            }
            else{
                stage = 3;
                PlayVid(Vn("3_0_game.mp4"));
                video.time = 16.8;
            }
        }
        else if(debug == "Debug3.1"){
            PlayVid(Vn("3_1_lose.mp4"));
        }
        else if(debug == "Debug3.2"){
            PlayVid(Vn("3_2_draw.mp4"));
        }
        else if(debug == "Debug3.3"){
            PlayVid(Vn("3_3_lose.mp4"));
        }
        else if(debug == "Debug3.4"){
            PlayVid(Vn("3_4_lose.mp4"));
        }
        else if(debug == "Debug3.5"){
            PlayVid(Vn("3_5_win.mp4"));
        }
        else if(debug == "Debug3.6"){
            PlayVid(Vn("3_6_undress.mp4"));
        }
        else if(debug == "Debug3.9"){
            stage = 4;
            PlayVid(Vn("4_0_game.mp4"));
        }
        else if(debug == "Debug4.0"){ //Stage 4
            if(videoname == "4_0_game.mp4"){
                video.time = 19.4;
            }
            else{
                stage = 4;
                PlayVid(Vn("4_0_game.mp4"));
                video.time = 19.4;
            }
        }
        else if(debug == "Debug4.1"){
            PlayVid(Vn("4_1_lose.mp4"));
        }
        else if(debug == "Debug4.2"){
            PlayVid(Vn("4_2_draw.mp4"));
        }
        else if(debug == "Debug4.3"){
            PlayVid(Vn("4_3_lose.mp4"));
        }
        else if(debug == "Debug4.4"){
            PlayVid(Vn("4_4_lose.mp4"));
        }
        else if(debug == "Debug4.5"){
            PlayVid(Vn("4_5_win.mp4"));
        }
        else if(debug == "Debug4.6"){
            PlayVid(Vn("4_6_undress.mp4"));
        }
        else if(debug == "Debug4.9"){
            stage = 5;
            PlayVid(Vn("5_0_game.mp4"));
        }
        else if(debug == "Debug5.0"){ //Stage 4
            if(videoname == "5_0_game.mp4"){
                video.time = 20.8;
            }
            else{
                stage = 5;
                PlayVid(Vn("5_0_game.mp4"));
                video.time = 20.8;
            }
        }
        else if(debug == "Debug5.1"){
            PlayVid(Vn("5_1_lose.mp4"));
        }
        else if(debug == "Debug5.2"){
            PlayVid(Vn("5_2_draw.mp4"));
        }
        else if(debug == "Debug5.3"){
            PlayVid(Vn("5_3_lose.mp4"));
        }
        else if(debug == "Debug5.4"){
            PlayVid(Vn("5_4_lose.mp4"));
        }
        else if(debug == "Debug5.5"){
            PlayVid(Vn("5_5_win.mp4"));
        }
        else if(debug == "Debug5.6"){
            if(videoname == "5_6_undress.mp4"){
                video.time = 190;
            }
            else{
                PlayVid(Vn("5_6_undress.mp4"));
            }
        }	
        else if(debug == "Debug6.1"){ //rock
            PlayVid(Vn("6_1_rock.mp4"));
        }
        else if(debug == "Debug6.2"){ //paper
            PlayVid(Vn("6_2_paper.mp4"));
        }
        else if(debug == "Debug6.3"){ //scissors
            PlayVid(Vn("6_3_scissors.mp4"));
        }
    }
}

