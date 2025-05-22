# Overview
Nature Quest is an educational mobile game which aim delivery lessons content through interactive mini-games for UCI Ecological Preserve. The game is geolocation based 

## Features
- Geolocation-based exploration tied to the UCI Ecological Preserve
- Educational mini-games designed to teach ecological concepts
- Interactive UI with AR-style map navigation (via Mapbox)
- Progress tracking for completed activities and learning modules

## Target Plateforms 
- Android mobile
  - Minimum API Level: Android 7.0 'Nougat' (API level 24)
  - Target API Level: Android 14.0 (API level 34)   

# Project Setup

## Development Environment
- Unity Editor 2022.2.55f1
- Mapbox Unity SDK (v2.1.1 or newer)
- Android Build Support (via Unity Hub)
  
## Installing Software Dependencies 
### Cloning Project
To clone the project simply select "Code" drop down on the github repository page and then clone the project using HTTPS, SSH, or GitHub CLI.
### Downloading Unity
Use the following [download Link](https://unity.com/download). Select your operating system. 
Once UnityHubSetup executable is downloaded, double click to open and follow installation instructions. 
Unity Hub is a manager application that organizes multiple Unity installations and keeps packages a project associated with the proper Unity version. 
In Unity Hub browse to "Installs" tab, locate and click the "Install Editor" button, and select "install on Unity(2022.2.55). Installing the editor can take several minutes to an hour. 
Once the Unity editor is installed select "Add" and browse to project root directory include the project on Unity Hub's "Projects" page. 
### Mapbox Account Set up
A Mapbox API key is required to work with this project. To generate a key an Mapbox user acount is required. Go to the [Mapbox homepage](https://www.mapbox.com/) and select "Sign Up" and complete the sign up process. 
Once complete go the account console, find the "Tokens" tab under "Admin". On the page select "Create a token", add a name, and leave all the settings to default. Select "Create token". Finally, copy the created token
### Adding Mapbox API key to Unity Project
Launch the project in the Unity Editor. In the top option bar select "Mabox" -> "Setup". In the "Mapbox Setup" window paste your token in "Access Token" field and select "Submit". If all works correctly a "valid" message will appear next to your token.

## Building and Running
1. Connect an Android device with Developer Mode enabled.
2. In Unity, go to `File > Build Settings`.
3. Select `Android` and click `Switch Platform`.
4. Click `Build and Run`.

## Known Issues
- Camera does not always stay centered on player (Mapbox sync issue)

## TODO
- Add Sprout Village AR mini-game
- Store user generated data for later analysis
- Staff dashboard to allow Ecological Preserve staff to set the location of mini-games themself

## Security Note
Do **not** commit API keys or sensitive data directly in the project files.
Use environment variables or Unity's `Resources` folder with `.gitignore` in place to prevent exposure.

# Project Sponsors
- UCI Nature
  - Megan Lulow, Ph.D
  - Julie Cofffey, M.sc
  - Thanh Le
  - Moises Perea-Vega
- Matthew Bietz Ph.D     
