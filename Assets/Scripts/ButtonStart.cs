using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    
    public TMP_InputField textName;
    
    // Start is called before the first frame update
   public void StartGame()
    {
        NameManager.Instance.Name = textName.text;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
