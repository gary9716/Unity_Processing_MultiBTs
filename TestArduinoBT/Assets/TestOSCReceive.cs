using UnityEngine;
using System.Collections;

public class TestOSCReceive : MonoBehaviour {

	private string OSCHost = "127.0.0.1"; 
	public int oscP5_Port; 
	public int netAddr_Port;

	public UDPPacketIO udpManager;
	public Osc oscHandler;


	// Use this for initialization
	void Start () {
		udpManager.init (OSCHost, oscP5_Port, netAddr_Port);
		oscHandler.init (udpManager);
		oscHandler.SetAddressHandler ("/btTest", oscReceiver);
	}

	public void oscReceiver(OscMessage oscMsg) {
		//Debug.Log("Event name: " + Osc.OscMessageToString(oscMsg));
		if (oscMsg.Values != null && oscMsg.Values.Count > 0) {
			Debug.Log ("Event data: " + oscMsg.Values [0]);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
