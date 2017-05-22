using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour {

    // Current object shall be an InputField
    InputField mainInputField;
    public string inputText;
    public bool textHasChanged;

    void Start()
    {
        textHasChanged = false;
        mainInputField = gameObject.GetComponent<InputField>();
    }
    
    void OnGUI()
    {
        if (mainInputField.isFocused && mainInputField.text != "" && Input.GetKey(KeyCode.Return))
        {
            textHasChanged = true;
            inputText = mainInputField.text;
            mainInputField.text = "";
            textHasChanged = false;
        }
    }
}
