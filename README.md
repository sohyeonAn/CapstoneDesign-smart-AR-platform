# CapstoneDesign-smart-AR-platform



# Quick start
This is a quick start guide for running this program.

※ To start this program, [Unity](https://unity3d.com/kr/get-unity/download) and [Nodejs](https://nodejs.org/en/download/) should be installed first .

### Step1. Open Unity Project
Clone this program and open a folder named Unity in Unity.

### Step2. Check Target Marker
SampleScene is added automatically when you run the program. <br/>
The objects added by ImageTarget in SampleScene
When it recognizes it as a camera, AR content appears above it. <br/>
**That is, ImageTarget becomes marker**
*Image of ImageTarget can be found in Asset \ Editor \ Vufoia \ ImageTargetTextures \ Test. <br/> <br/>
*If you want to change the Target Marker to the object you want, please join [Vuforia](https://www.vuforia.com/)
Create a license key and create a target database to import into your Unity project. For more information, please visit [here](https://library.vuforia.com/articles/Training/getting-started-with-vuforia-in-unity.html).
### Step3. Execute Nodejs server
Run cmd to move the cloned program to the folder and run **main.js** in a folder named Nodejs.

### Step4.  Specifying a server 
Open the Asset \ MyScripts \ SelectContentType.cs file in the Unity project. <br/>
`private string url =" http: // MYSERVERIP: 3000 / ";` <br/>
Replace the MYSERVERIP part with your own server address.

### Step 5. Build the Android APK
Connect your Android device to your PC and run  **File - Build & Run**  from the Unity project.

## Demo
<img src="https://raw.githubusercontent.com/sohyeonAn/CapstoneDesign-smart-AR-platform/master/demo.gif" >
