using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private void OnGUI() //=Canvas things need to be attachd to this to render on screen or be seen on screen
    {

        //GUI.Box(new Rect(0,0,500,500),"Hello World");
        //GUI.Box(new Rect(0*Screen.width/16,3*Screen.height/9,3*Screen.width/16,0.5f*Screen.height/9), "Hello World");
        //GUI.Box(new Rect(ScreenPlacement(1.5f, 6, 8, 1)), "Hello World!");
        LessonGrid();

        GUI.Box(new Rect(ScreenPlacement(5.5f, 1, 5, 1)), "Mush & Rush");
        //GUI.Label(new Rect(ScreenPlacement(5.5f, 1, 5, 1)), "");
        if (GUI.Button(new Rect(ScreenPlacement(6.5f, 3.75f, 3, 1)), "Play"))
        {

        }

        if (GUI.Button(new Rect(ScreenPlacement(6.5f, 4.9f, 3, 1)), "Options"))
        {

        }

        if (GUI.Button(new Rect(ScreenPlacement(6.5f, 6.10f, 3, 1)), "Exit"))
        {

        }

    }

    //GUI element that is a type of box - box is = to Canvas Image
    //New Rect = Canvas Rect Transform
    //new Rect (StartPositionX, StartPositionY, SizeX, SizeY), "Content" ie an image or a sprite or text ect.)

    //method - Does not have a return type (runs code)
    void LessonGrid()
    {
        // Loops - There are 4 types of loop:

        // for - Loops for a set amount
        // foreach - for every thing of a specific type in a chosen group 
        // while - while a situation is true the code will run (while the door is open you ust do jumping jacks)
        // Dowhile - Do the action once and then checks if its needs to be repeated (jumps once and then checks if door is open) 

        for(int x = 0; x < 16; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(ScreenPlacement(x,y,1,1)),"");
                GUI.Label(new Rect(ScreenPlacement(x, y, 1, 1)), x+ ":" + y);
            }
        }
    }

    //Function - has a return type (kinda like a calculator? It has to give you an answer based on input you give it.)
    public static Rect ScreenPlacement(float startPositionX, float startPositionY, float sizeX, float sizeY)
    {
        Rect placement = new Rect(startPositionX*Screen.width / 16, startPositionY * Screen.height/9, sizeX * Screen.width / 16, sizeY * Screen.height/9);
        return placement;
    }
}