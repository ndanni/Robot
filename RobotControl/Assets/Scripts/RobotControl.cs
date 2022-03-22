using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class RobotControl : MonoBehaviour
{
    // Draws a horizontal slider control that goes from -10 to 10.
    float robotBaseSliderValue = 0.0f;

    // Draws a horizontal slider control that goes from -10 to 10.
    float robotUpperArmSliderValue = 0.0f;

    // Draws a horizontal slider control that goes from -10 to 10.
    float robotLowerArmSliderValue = 0.0f;

    // Draws a horizontal slider control that goes from -10 to 10.
    float robotEndNozzleSliderValue = 0.0f;

    //These allow us to have numbers to adjust in the inspector for the speed of each part's rotation.
    float baseTurnRate = 5f;
    float upperArmTurnRate = 5f;
    float lowerArmTurnRate = 3f;
    float nozzleTurnRate = 5f;

    private float robotBaseYRot;
    public float robotBaseYRotMin = -25f;
    public float robotBaseYRotMax = 25f;

    private float robotUpperArmXRot;
    public float robotUpperArmXRotMin = -50f;
    public float robotUpperArmXRotMax = 60f;

    private float robotLowerArmXRot;
    public float robotLowerArmXRotMin = -10f;
    public float robotLowerArmXRotMax = 20f;

    private float robotEndNozzleXRot;
    public float robotEndNozzleXRotMin = -45f;
    public float robotEndNozzleXRotMax = 45f;


    //These slots are where you will plug in the appropriate robot parts into the inspector.
    public Transform RobotBase;
    public Transform RobotUpperArm;
    public Transform RobotLowerArm;
    public Transform RobotEndNozzle;

   
    // Start is called before the first frame update
    void Start()

    {
    }
    // Update is called once per frame
    void Update()
    {
        //rotating our base of the robot here around the Y axis and multiplying
        //the rotation by the slider's value and the turn rate for the base.
        // RobotBase.Rotate(0, robotBaseSliderValue * baseTurnRate, 0);

        robotBaseYRot += robotBaseSliderValue * baseTurnRate;

        robotBaseYRot = Mathf.Clamp(robotBaseYRot, robotBaseYRotMin, robotBaseYRotMax);

        RobotBase.eulerAngles = new Vector3(RobotBase.eulerAngles.x, robotBaseYRot, RobotBase.eulerAngles.z);

        //rotating our upper arm of the robot here around the X axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        //RobotUpperArm.Rotate(robotUpperArmSliderValue * upperArmTurnRate, 0, 0);

        robotUpperArmXRot += robotUpperArmSliderValue * upperArmTurnRate;

        robotUpperArmXRot = Mathf.Clamp(robotUpperArmXRot, robotUpperArmXRotMin, robotUpperArmXRotMax);

        RobotUpperArm.eulerAngles = new Vector3(RobotUpperArm.eulerAngles.y, robotUpperArmXRot, RobotUpperArm.eulerAngles.z);

        //rotating our upper  arm of the robot here around the X axis and multiplying
        //the rotation by the slider's value and the turn rate for the upper arm.
        //RobotUpperArm.Rotate(robotUpperArmSliderValue * upperArmTurnRate, 0, 0);

        robotLowerArmXRot += robotLowerArmSliderValue * lowerArmTurnRate;

        robotLowerArmXRot = Mathf.Clamp(robotLowerArmXRot, robotLowerArmXRotMin, robotLowerArmXRotMax);

        RobotLowerArm.eulerAngles = new Vector3(RobotLowerArm.eulerAngles.y, robotLowerArmXRot, RobotLowerArm.eulerAngles.z);

        // rotating our end nozzle of the robot here around the X axis and multiplying
        //the rotation by the slider's value and the turn rate for the end Nozzle.
        // RobotEndNozzle.Rotate(robotEndNozzleSliderValue * nozzleTurnRate, 0, 0);

        robotEndNozzleXRot += robotEndNozzleSliderValue * nozzleTurnRate;

        robotEndNozzleXRot = Mathf.Clamp(robotEndNozzleXRot, robotEndNozzleXRotMin, robotEndNozzleXRotMax);

        RobotEndNozzle.eulerAngles = new Vector3(RobotEndNozzle.eulerAngles.x, robotEndNozzleXRot, RobotEndNozzle.eulerAngles.y);

        if (Input.GetMouseButtonUp(0))
        {

            //resets the sliders back to 0 when you lift up on the mouse click down.
            robotBaseSliderValue = 0;
            robotUpperArmSliderValue = 0;
            robotEndNozzleSliderValue = 0;
        }
    }
    void OnGUI()
    {
        //creates the slider and sets it 25 pixels in x, 25 in y, 100 wide and 30 tall.
        robotBaseSliderValue = GUI.HorizontalSlider(new Rect(25, 10, 100, 30),
                                                    robotBaseSliderValue,
                                                    -10.0f,
                                                    10.0f);

        //creates the slider and sets it 25 pixels in x, 80 in y, 100 wide and 30 tall.
        robotUpperArmSliderValue = GUI.HorizontalSlider(new Rect(25, 60, 100, 30),
                                                        robotUpperArmSliderValue,
                                                        -10.0f,
                                                        10.0f);

        //creates the slider and sets it 25 pixels in x, 80 in y, 100 wide and 30 tall.
        robotLowerArmSliderValue = GUI.HorizontalSlider(new Rect(25, 110, 100, 30),
                                                        robotLowerArmSliderValue,
                                                        -10.0f,
                                                        10.0f);

        // creates the slider and sets it 25 pixels in x, 80 in y, 100 wide and 30 tall.
        robotEndNozzleSliderValue = GUI.HorizontalSlider(new Rect(25, 150, 100, 30),
                                                         robotEndNozzleSliderValue,
                                                         -10.0f,
                                                         10.0f);
    }
}