# BreakWithYourPhone
BreakWithYourPhone is network course project of POSTECH (CSED353)

## Development Environment

Language: C#, HTML, Javacript

Unity 5.6.0f3

## Introduction

This game is made for POSTECH network course (CSED353) term project.

Goal of the project is making an application using socket programming.

Our team used web socket sharp and http to communicate between client and server.

Our team made simple game whose goal is breaking coming obstacles.

The main feature of the game is that user use their smartphones to controll in-game weapon.

This feature immitates VR-controller's feature, but not perfect as our team has no professional knowledge

about controlling stuffs using sensor information.

Thus our immitation has strict limitation, but it applied well at least giving feeling of control using smartphone.

## Game

### Main Scene

before start game, you should connect your smartphone to game server.

##### Check List
* Enroll exception on firewall
* If you are using router (If you are on restricted cone NAT), use DMZ service / port forwarding etc.

![Image of main scene](https://github.com/MoonCall/BreakWithYourPhone/blob/master/readme_image/main.png?raw=true)


### Connection Guide

If you click open server button at bottom, instruction will lead you to connect a webpage.

After you connect to webpage using your smartphone, you will see page like this:

##### Guide
* First, click connect button.
* Second, follow the guide shown on the game screen and click calibrate button.
* Finally game start button will show up and press the button.

![Image of main scene](https://github.com/MoonCall/BreakWithYourPhone/blob/master/readme_image/webpage.png?raw=true)

### Game Scene

You can move stick using your smartphone.

Move your stick to break obstacle, and get score for each destructed obstacle.



![Image of game play scene](https://github.com/MoonCall/BreakWithYourPhone/blob/master/readme_image/move.png?raw=true)


### DEMO

[![BreakWithYourPhone](https://img.youtube.com/vi/XWoY7LevwKg/0.jpg)](https://www.youtube.com/watch?v=XWoY7LevwKg)
