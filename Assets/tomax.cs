using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharSelect : MonoBehaviour
{
    public void ToMax()
    {
        SceneManager.LoadScene(1);
    }
    public void ToTao()
    {
        SceneManager.LoadScene(2);
    }
    public void ToZylo()
    {
        SceneManager.LoadScene(3);
    }
}
