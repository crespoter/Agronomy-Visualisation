using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wellcontroller : MonoBehaviour {
    public GameObject camera;
    public GameObject depthcanvas;
    public GameObject well;
    public GameObject wateryieldObject;
    public string requestURL;
    public Text wateryeildText;
    public Text Depth;
    private string wateryield;
    private string depth;
    private Vector3 origPosition;
    private void Start()
    {
        requestURL = Application.absoluteURL;
        wateryield = requestURL.Split('?')[1].Split('&')[0].Split('=')[1];
        depth = requestURL.Split('?')[1].Split('&')[1].Split('=')[1];
        wateryeildText.text = "Water Yield \n" + wateryield + " L" ;
        origPosition = well.transform.position;
    }
    public void changeToVerticalView()
    {
        camera.GetComponent<Animator>().SetBool("changeToVertical", true);
        depthcanvas.SetActive(true);
        wateryieldObject.SetActive(true);
        wateryieldObject.transform.localScale = new Vector3(wateryieldObject.transform.localScale.x, wateryieldObject.transform.localScale.y * int.Parse(wateryield) / 100.0f, well.transform.localScale.z);
        wateryieldObject.transform.Translate(new Vector3(0, wateryieldObject.transform.localPosition.y * (well.transform.localScale.y - 1), 0));
        Depth.text = "Depth : \n " + depth + " m";
        well.transform.localScale = new Vector3(well.transform.localScale.x, well.transform.localScale.y * int.Parse(depth) / 100.0f, well.transform.localScale.z);
        well.transform.Translate(new Vector3(0, well.transform.localPosition.y * (well.transform.localScale.y-1) , 0));
        wateryieldObject.GetComponent<Renderer>().material.color = new Color(0.0f,0.0f,int.Parse(wateryield)/100.0f);
    }
    public void changeToHorizontalView()
    {
        wateryieldObject.SetActive(false);
        camera.GetComponent<Animator>().SetBool("changeToVertical", false);
        depthcanvas.SetActive(false);
        well.transform.localScale = new Vector3(1, 1, 1);
        well.transform.position = origPosition;

    }
}
