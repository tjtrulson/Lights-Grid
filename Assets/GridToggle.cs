using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GridToggle : MonoBehaviour {
    //2D Array of buttons for the grid
    private GameObject[,] grid = new GameObject[10,10];
    //Temp array for setting the grid by finding the buttons in a row
    private GameObject[] temp;
    //2D List for the rectangle to be lit up
    public List<GameObject> rectangle;

    //First and last positions of the rectangle
    private Lightbulb firstPos;
    private Lightbulb lastPos;
    
    //Bool for if the first position of the rectangle has been set
    private bool firstPosSet = false;

    //Reset the rectangle to avoid incorrect changes
    private void resetRect()
    {
        rectangle.Clear();
    }

    //This will be used to set either the starting position or ending position of the rectangle
    public void SetPos()
    {
        //Set the currently selected light's Lightbulb script to the temp variable
        Lightbulb tempLight = EventSystem.current.currentSelectedGameObject.GetComponent<Lightbulb>();
        //If this click is to set the first position
        if (!firstPosSet)
        {
            //Reset the previous rectangle for insurance
            resetRect();
            //Set firstPos to the temp variable
            firstPos = tempLight;
            //Highlight the selected light in green
            firstPos.highlight();
            //Update the bool for the second click
            firstPosSet = true;
        }
        //If this click is to set the second position
        else
        {
            //Set lastPos to the temp variable
            lastPos = tempLight;
            //Form the rectangle from the points between first and last pos
            formRectangle(firstPos, lastPos);
            //Update the bool for the first click
            firstPosSet = false;
        }
    }

    //This function forms the rectangle between the selected points
    private void formRectangle(Lightbulb firstPos, Lightbulb lastPos)
    {
        //For sake of ease, swap the first/last positions when going to the left
        if (lastPos.xPos < firstPos.xPos)
        {
            Lightbulb temp = firstPos;
            firstPos = lastPos;
            lastPos = temp;
        }
        //This loop only accounts for if lastPos.yPos >= firstPos.yPos (so down and to the right from starting pos)
        if (lastPos.yPos >= firstPos.yPos)
        {
            for (int i = firstPos.yPos; i <= lastPos.yPos; i++)
            {
                for (int j = firstPos.xPos; j <= lastPos.xPos; j++)
                {
                    //Loop through the grid array, and add the lights between the first and last positions to the rectangle List
                    rectangle.Add(grid[i, j]);
                }
            }
        }
        //This loop accounts for if lastPos.yPos < firstPos.yPos (so up and to the right from starting pos)
        else if(lastPos.yPos < firstPos.yPos)
        {
            for (int i = firstPos.yPos; i >= lastPos.yPos; i--)
            {
                for (int j = firstPos.xPos; j <= lastPos.xPos; j++)
                {
                    //Loop through the grid array, and add the lights between the first and last positions to the rectangle List
                    rectangle.Add(grid[i, j]);
                }
            }
        }
        //For the selected list, toggle the lights between the states
        toggleLights();
    }

    //This function loops through the list and toggles the lights to the varying states
    private void toggleLights()
    {
        foreach (GameObject button in rectangle)
        {
            //Call each button's toggle function
            button.GetComponent<Lightbulb>().toggleLight();
        }
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            //Find the buttons in the given row -- Sorted alphabetically (since FindGameObjectsWithTag adds them randomly)
            temp = GameObject.FindGameObjectsWithTag("Row " + (i + 1)).OrderBy(go =>go.name).ToArray();
            for (int j = 0; j < 10; j++)
            {
                //Add them to the grid
                grid[i,j] = temp[j];
            }
        }
	}
}
