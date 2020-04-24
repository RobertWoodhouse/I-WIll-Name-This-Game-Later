using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShipController : MonoBehaviour
{
    public Text nameTxt, descriptionTxt;
    public Image shipImg;

    // Start is called before the first frame update
    void Start()
    {
        // TODO test functions
        nameTxt.text = ChangeName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string ChangeName()
    {
        string[] names = { "", "S.S. BUC NASTY", "BANTON CHRONICLE" };

        // TODO For method to change names when buttons is pressed
        return names[2];
    }
}
