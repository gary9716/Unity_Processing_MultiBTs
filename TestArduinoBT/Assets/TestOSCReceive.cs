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
			string msg = oscMsg.Values [0].ToString().TrimEnd();
			Debug.Log("Event data:" + msg);
			if(msg.Equals("I'm bt1")) {
				Debug.Log ("Yes, bt1");
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
