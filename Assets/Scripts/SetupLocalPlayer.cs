using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/**
 * Client erkennt durch diese Klasse, seinen Player zu identifizieren
 * */
public class SetupLocalPlayer : NetworkBehaviour {

    public Text namePrefab;
    public Text nameLabel;
    public Transform namePos;
    string textboxname = "";


    [SyncVar(hook = "OnChangeName")]
    public string pName = "player";

    void OnChangeName(string n)
    {
        pName = n;
        nameLabel.text = pName;
    }

    [Command]
    public void CmdChangeName(string newName)
    {
        pName = newName;
        nameLabel.text = pName;
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            textboxname = GUI.TextField(new Rect(25, 15, 100, 25), textboxname);
            if (GUI.Button(new Rect(130, 15, 35, 25), "Set"))
                CmdChangeName(textboxname);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<GoblinMovement>().enabled = true;
        }
        else
        {
            GetComponent<GoblinMovement>().enabled = false;
        }

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePrefab, Vector3.zero, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);
    }

    public void OnDestroy()
    {
        if (nameLabel != null)
            Destroy(nameLabel.gameObject);
    }

    void Update()
    {
        //determine if the object is inside the camera's viewing volume
        if (nameLabel != null)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 &&
                            screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            //if it is on screen draw its label attached to is name position
            if (onScreen)
            {
                Vector3 nameLabelPos = Camera.main.WorldToScreenPoint(namePos.position);
                nameLabel.transform.position = nameLabelPos;
            }
            else //otherwise draw it WAY off the screen 
                nameLabel.transform.position = new Vector3(-1000, -1000, 0);
        }
    }
}
