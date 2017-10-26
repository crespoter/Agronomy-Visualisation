using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class landcontroller : MonoBehaviour {
    public GameObject camera;
    public string requestURL;
    public Text uiDisplay;
    public Text ButtonDisplay;
    private string area1;
    private string area2;
    private string depth;
    private string cropname1;
    private string cropname2;
    public void Start()
    {
        requestURL = Application.absoluteURL;
        area1 = requestURL.Split('?')[1].Split('&')[0].Split('=')[1];
        cropname1 = requestURL.Split('?')[1].Split('&')[1].Split('=')[1];
        area2 = requestURL.Split('?')[1].Split('&')[2].Split('=')[1];
        cropname2 = requestURL.Split('?')[1].Split('&')[3].Split('=')[1];
        uiDisplay.text = cropname1 + " \n\n Distribution:\n" + (int.Parse(area1)*100.0 / (int.Parse(area1) + int.Parse(area2))) + " %\n\n" +
            "Area : " + area1 + " Acres";
        ButtonDisplay.text = "Show " + cropname2;
    }
	public void goto2()
    {
        if (camera.GetComponent<Animator>().GetBool("goto2") == false)
        {
            camera.GetComponent<Animator>().SetBool("goto2", true);
            uiDisplay.text = cropname2 + " \n\n Distribution:\n" + (int.Parse(area2) * 100.0 / (int.Parse(area1) + int.Parse(area2))) + " %\n\n" +
                "Area : " + area2 + " Acres";
            ButtonDisplay.text = "Show " + cropname1;
        }
        else
        {
            goto1();
        }
    }
    public void goto1()
    {
        camera.GetComponent<Animator>().SetBool("goto2", false);
        uiDisplay.text = cropname1 + " \n\n Distribution:\n" + (int.Parse(area1)*100 / (int.Parse(area1) + int.Parse(area2))) + " %\n\n" +
            "Area : " + area1 + " Acres";
        ButtonDisplay.text = "Show " + cropname2;
    }
}
