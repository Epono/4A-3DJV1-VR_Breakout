// script for setting an adaptive frustum to a camera in Unity
// this script needs Osc.cs and UDPPacketIO.cs to work

using UnityEngine;
using System.Collections;


public class OSCReceiveCameraAdaptive : MonoBehaviour {
    public string RemoteIP = "127.0.0.1"; //127.0.0.1 signifies a local host (if testing locally
    public int SendToPort = 0; //the port you will be sending from
    public int ListenerPort = 7000; //the port you will be listening on
    public GameObject paddle; // object that the camera will look at

    private Osc handler;
    private Vector3 Cyclop_eye_pos;

    void Set_Position(float posX, float posY, float posZ) {
        Cyclop_eye_pos.Set(posX, posY, -posZ);
    }

    void AllMessageHandler(OscMessage oscMessage) {
        string msgString = Osc.OscMessageToString(oscMessage); //the message and value combined
        string msgAddress = oscMessage.Address; //the message parameters

        float posX = (float)oscMessage.Values[0];
        float posY = (float)oscMessage.Values[1];
        float posZ = (float)oscMessage.Values[2];

        switch(msgAddress) {
            case "/tracker/head/pos_xyz/cyclope_eye":
                Set_Position(posX, posY, posZ);
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start() {
        // init OSC packet receiver
        UDPPacketIO udp = GetComponent<UDPPacketIO>();
        udp.init(RemoteIP, SendToPort, ListenerPort);
        handler = GetComponent<Osc>();
        handler.init(udp);
        handler.SetAllMessageHandler(AllMessageHandler);
    }

    // Update is called once per frame
    void LateUpdate() {
        if(Cyclop_eye_pos == Vector3.zero)
            PaddleMovementScript.isMoving = false;
        else
            PaddleMovementScript.isMoving = true;
        paddle.transform.position = new Vector3(Cyclop_eye_pos.x + 5, paddle.transform.position.y, paddle.transform.position.z);
    }
}
