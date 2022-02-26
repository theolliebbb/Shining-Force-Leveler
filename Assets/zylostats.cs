using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class zylostats : MonoBehaviour
{
    static System.Random rnd = new System.Random();
    public Text title;
    public GameObject ZyloCanvas1;
    public GameObject ZyloCanvas2;
    
    public GameObject title1;
    public GameObject title2;
    public GameObject agilitygo;
    public Text attack;
    public Text defense;
    public AudioSource hq;
    public AudioSource promotesound;
    public Text level;
    public Text hp;
    public Text mp;
    public Text agility;
    public int atval = 6 ;
    public static int attacks;
    public int levval = 0;
    
    public int mpval = 0;
    public int defval = 6;
    public int hpval = 15;
    public int agval = 12;
    int upattack;
    int updefense;
    int uphp;
    int upmp;
    int upagility;
    public string wfmn = "WFMN Zylo";
    public string wfbn = "WFBN Zylo";
    
    public GameObject promoteButton;
    
    public bool promoted;
   
    public void Start()
    {    
        
       
         attack = GetComponent<Text>();
         attack.text = PlayerPrefs.GetInt("attacks").ToString();
         
         
         attack.text = attacks.ToString();
         
         level.text = levval.ToString();
        
         agility = GetComponent<Text>();
         agility.text = agval.ToString();
         hp = GetComponent<Text>();
         hp.text = hpval.ToString();
         defense = GetComponent<Text>();
         defense.text = defval.ToString();
         promoteButton.SetActive(false);
         promoted = false;
         title.text = wfbn;
         title1.SetActive(true);
          title2.SetActive(false);

    }
    public void classChange()
    {       
            hq.Pause();
              hq.Stop();
            promotesound.Play();
            StartCoroutine(waitMusic());
          
          
           title1.SetActive(false);
           title2.SetActive(true);
           title.text = wfbn;
        
    }
    IEnumerator waitMusic()
    {
        yield return new WaitForSecondsRealtime(13);
    }
  


    public void promote()
       {    promoted = true;
            hq.Pause();
              hq.Pause();
            promotesound.Play();
            StartCoroutine(waitMusic());
          
         
             
           promoteButton.SetActive(false);
            
            levval = 0;
            levelup();
            level = GetComponent<Text>();
             level.text = levval.ToString();
            hq.Pause();
             promotesound.Play();
              hq.Play();

             
            
            
             
             
       } 
    
    public void levelup()
    {
        if (promoted == false)
        {
        upattack = rnd.Next(0, 3);
        updefense = rnd.Next(0, 1);
        uphp = rnd.Next(0, 3);
        upmp = rnd.Next(0, 0);
        upagility = rnd.Next(0, 3);
        }
        else
        {
        upattack = rnd.Next(0, 4);
        updefense = rnd.Next(0, 2);
        uphp = rnd.Next(0, 4);
        upmp = rnd.Next(0, 0);
        upagility = rnd.Next(0, 4);
        }
       attack = GameObject.Find("attack").GetComponent<Text>();
       level = GameObject.Find("level").GetComponent<Text>();
       levval += 1;
       level.text = levval.ToString();
       atval += upattack;
       attack.text = atval.ToString();
       mp = GameObject.Find("mp").GetComponent<Text>();
        mp.text = mpval.ToString();
        agility = GameObject.Find("agility").GetComponent<Text>();
        agility.text = agval.ToString();
        agval += upagility;
         hp = GameObject.Find("hp").GetComponent<Text>();
        hp.text = hpval.ToString();
        hpval += uphp;
        defense = GameObject.Find("defense").GetComponent<Text>();
        defense.text = defval.ToString();
        defval += updefense;
       if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
            
        }
        if (promoted == true)
        {
            title.text = wfbn;
         title1.SetActive(true);
          title2.SetActive(false);
          
            
      
       }
      void StatUpdater(int attacks)
       {
           atval = attacks;
       }
         void Update()
        {
            PlayerPrefs.SetInt("attacks", atval);
        
        }
    
    
    }
    
}
