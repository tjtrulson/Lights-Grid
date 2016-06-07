# Lights-Grid
Problem:
- You have an grid of light bulbs that is 10 x 10. Represent this visually in Unity and in code via a model(s) (in other words, keep the view and model(s) separate).

Bonus:
- Upon selecting the first light for making a grid, highlight the selected light.
- Instead of just binary states, Off and On, represent multiple states for each light. As an example, Off, 1/2 Brightness, Full On. The first time a light is lit, it goes to 1/2 Brightness, the next time, Full On, and the 3rd time, Off.

The Unity project offers the "player" a view of the 10x10 grid, with some text to help determine which light is being pressed. Each light is represented by a Canvas button. 

Upon selection of the first button, it is highlighted in green to show that it was selected and differentiate it from the other lights (as per the first bonus). 

When a second button is selected, a rectangle is built based on the two coordinates. This rectangle encompasses all other lights that fall into it. For example, if the selected lights were (1,3) and (3,5), then the rectangle formed would be a 3x3 that also includes: (1,4), (1,5), (2,3), (2,4), (2,5), (3,3), and (3,4).

As per the second bonus, each light has three states. Upon first inclusion in a rectangle, the light becomes grey (representing a half-on light). When it is included in a rectangle for a second time, it will turn to white (to represent fully on), and a third inclusion will revert it to black (for a light that is off).
