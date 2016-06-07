using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//The three states for the lights
public enum states
{
    off,
    half,
    on
}
public class Lightbulb : MonoBehaviour {

    //Enum for the light's current state -- off is default
    private states currentState = states.off;
    
    //Ints for the grid position of the given light
    public int xPos;
    public int yPos;

    //Bool to determine if the light is active or not
    private bool activated = false;

    //Toggle lights on/off
    public void toggleLight()
    {
        //When starting with a light that's off
        if (currentState == states.off)
        {
            //Change to half-on
            currentState = states.half;
            this.GetComponent<Image>().color = Color.grey;
        }
        //When starting with a light that's half-on
        else if (currentState == states.half)
        {
            //Change to full-on
            currentState = states.on;
            this.GetComponent<Image>().color = Color.white;
        }
        //When starting with a light that's fully on
        else if (currentState == states.on)
        {
            //Change to off
            currentState = states.off;
            this.GetComponent<Image>().color = Color.black;
        }
    }

    //Highlight selected light
    public void highlight()
    {
        //Green just to differentiate it from the other lights
        this.GetComponent<Image>().color = Color.green;
    }
}
