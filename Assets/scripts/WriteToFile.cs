using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using System;
using UnityEngine.SocialPlatforms.Impl;


/*
!! AXEVALLA ARKAD SCORE SCRIPT - Step by Step guide to impliment !! 

This script creates a directory location called StreamingAsset in your game, then further creates a map called Score_Log with a single txt file called Score.txt
After being created, it is then used to write !!YOUR!! games score into the file itself so Axevalla Arkad can read the score. Each time the script is run,
It checks if the file exists and then overrides it. You can change the script but the final result should always contain the previous mentioned locations and files.

NOTE: IF YOUR GAME DOES NOT HAVE A SCORE, OR INTENDS TO HAVE A SCORE, CREATE SOMETHING TO RETURN AS A INT. THIS CAN BE A TIMER OR WHATEVER! Remember that the returned
score will be used as currency for the Arkad and should have some formula to return a reasonable number. Example: for every 1 min, give 1 score.

STEP BY STEP PROCESS!

1. Attatch the script

Depending on where you svae your score, you want to attatch this script to the same object that handles your score or the object that handles displaying it,
such as a final score at the end of the game. If your game DOES an object that does this, see the notes below. But otherwise, you just drag and attatch the script.

Notes: The current flow is that it saves the score when the object / script is attatched to is destoryed under the Private void OnDestroy. If your object keeping track of your score presists
for a long time, I.E until the game is closed, you can change Private void OnDestroy to OnApplicationExit.


2. Expose your score / Create a method / Save your score.

In this step you need to make sure you have your score saved and accessable by another script. Easiest way to do this, without making anything that will interfere
is creating a method to expose your score.

public int ReturnScore() {

    return YOUR_SCORE_VARIABLE;

}

Note: this is not required, you can simply just have an exposed int for your score, but this make sure you just send the ifno and doesn't run the chance of editing the score


3. Asgin the variable

Where you have saved the script, you need to type the following where the score is displayed and or shown at the end of the game. The best practice is when you die, loose, or win
as you DO NOT want to constantly send the score inside of Update if can be avoid.

These are the flow / steps you want to think about where your score is saved and where you want to input this code:
1. Score gained / saved = During the game
2. Score displayed = During the game
3. Final Score Displayed = End of the game < You want to have the code fire in this area

After finding the best location to send the score, you want to write the following:

WriteToFile.AccessPoint.WriteScoreToFile("YOUR SCORE INT OR METHOD");

Where "YOUR SCORE INT OR METHOD" is what you use as score, using either the variable or method to give it. It can and should only be an int. 
If done correct, the score should be written to the WriteToFile Script.


4. Checking if it's correct.

If everything is correct, check the following after launching and testing the game for errors:
1. Inside of your "your name"_data (example: my project_data) should be a folder called StreamingAsset
2. A folder called Score_Log should exist
3. Inside of the folder should exist a txt file called Score.txt
4. Opening the txt file should give you the socre you returned.

If you are not getting the correct score, try and debug to see if you are sendig the right information to the right place using Debug.Log. 
The final project should simply have your correct score being sent to the txt file.

Made by Christofer Persson 2024, Discord: .remina, mail: Christoferpworkmail@gmail.com
*/
public class WriteToFile : MonoBehaviour
{

    public static WriteToFile AccessPoint { get; set; }

    int gameScore;
    string txtDocumentName = Application.streamingAssetsPath + "/Score_Log/" + "Score" + ".txt";


    //Creates a directory called "streamingAssetsPath" in the appropriate directory of the game
    void Awake()
    {
        AccessPoint = this;
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Score_Log/");

    }

    private void Start() {

        CreateTextFile();
        
    }

   
    private void OnApplicationQuit() {
        
        WriteToTxtFile();
    }

    //Creates a .txt file to save the variables we want returned, such as score. This is where you'd return an int using
    //a method to get a score that the acrade-hall can read and save.
    public void CreateTextFile() {

        

        if (File.Exists(txtDocumentName)) {

            File.Delete(txtDocumentName);
        
        }
        File.WriteAllText(txtDocumentName, "");
    }

    public void WriteToTxtFile() {

        File.WriteAllText(txtDocumentName, gameScore.ToString());
    }

    public void WriteScoreToFile(int Score) { 
    
        gameScore += Score;

    }
}
