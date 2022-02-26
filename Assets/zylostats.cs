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
    public int levval;
    public int levval2;
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
    public int promotedVal;
    public void Start()
    {    
        
       
         hq.Play();
        attack = GetComponent<Text>();
        if (PlayerPrefs.HasKey("savedAttack"))
        {
        atval = PlayerPrefs.GetInt("savedAttack");
        }
        else
        {
        atval = 6;

        }
        if (PlayerPrefs.HasKey("savedLevel"))
        {
        levval = PlayerPrefs.GetInt("savedLevel");
        levval2 = levval;
        }
        else
        {
        levval2 = 1;
        levval = levval2;
        }

        if (PlayerPrefs.HasKey("savedHP"))
        {
        hpval = PlayerPrefs.GetInt("savedHP");
        }
        else
        {
        hpval = 15;
        }

        if (PlayerPrefs.HasKey("savedDefense"))
        {
        defval = PlayerPrefs.GetInt("savedDefense");
        }
        else
        {
        defval = 6;
        }
        
        if (PlayerPrefs.HasKey("savedMP"))
        {
        mpval = PlayerPrefs.GetInt("savedMP");
        }
        else
        {
        mpval = 0;
        }

        if (PlayerPrefs.HasKey("savedAgility"))
        {
        agval = PlayerPrefs.GetInt("savedAgility");
        }
        else
        {
        agval = 12;
        }
        
         if (PlayerPrefs.HasKey("promotedVal"))
        {
        promotedVal = PlayerPrefs.GetInt("promotedVal");
        }
        else
        {
        promotedVal = 0;
        }
        
        if (promotedVal == 0)
        {
            promoted = false;
        }
        else
        {
            promoted = true;
        }
        attack.text = atval.ToString();
        level.text = levval.ToString();
        mp.text = mpval.ToString();
        agility.text = agval.ToString();
        hp.text = hpval.ToString();
        defense.text = defval.ToString();
        if (promoted = true);
        {
        title1.SetActive(false);
        title2.SetActive(true);
        title.text = wfbn;
        }
        promoted = false;
        title.text = wfbn;
        title1.SetActive(true);
        title2.SetActive(false);

    }

    public void classChange()
    {       
            title1.SetActive(false);
        title2.SetActive(true);
        title.text = wfbn;
        
    }

    public void promote()
       {   
        promoted = true;
        promotedVal = 1;
        PlayerPrefs.SetInt("promotedVal", promotedVal);
        hq.Pause();
        promotesound.Play();     
        promoteButton.SetActive(false);
        levval = 0;
        levval2 = 0;
        PlayerPrefs.SetInt("savedLevel", levval2);
        levelup();
        level = GetComponent<Text>();
        level.text = levval.ToString();             
       } 
    
    public void levelup()
    {
        if (promoted == false)
        {
        upattack = rnd.Next(0, 3);
        updefense = rnd.Next(0, 2);
        uphp = rnd.Next(0, 3);
        upmp = rnd.Next(0, 0);
        upagility = rnd.Next(0, 3);
        }
        else
        {
        upattack = rnd.Next(0, 4);
        updefense = rnd.Next(0, 3);
        uphp = rnd.Next(0, 4);
        upmp = rnd.Next(0, 0);
        upagility = rnd.Next(0, 4);
        }

      levval = PlayerPrefs.GetInt("savedLevel");
        levval = levval2;
        level = GameObject.Find("level").GetComponent<Text>();
        levval += 1;
        
        levval2 = levval;
        level.text = levval.ToString();
        PlayerPrefs.SetInt("savedLevel", levval2);
	    PlayerPrefs.Save();
   
        attack = GameObject.Find("attack").GetComponent<Text>();
        atval += upattack;
        attack.text = atval.ToString();
        PlayerPrefs.SetInt("savedAttack", atval);
	    PlayerPrefs.Save();

        mp = GameObject.Find("mp").GetComponent<Text>();
        mp.text = mpval.ToString();

        agility = GameObject.Find("agility").GetComponent<Text>();
        agility.text = agval.ToString();
        agval += upagility;
        PlayerPrefs.SetInt("savedAgility", agval);
	    PlayerPrefs.Save();

        hp = GameObject.Find("hp").GetComponent<Text>();
        hp.text = hpval.ToString();
        hpval += uphp;
        PlayerPrefs.SetInt("savedHP", hpval);
	    PlayerPrefs.Save();

        defense = GameObject.Find("defense").GetComponent<Text>();
        defense.text = defval.ToString();
        defval += updefense;
        PlayerPrefs.SetInt("savedDefense", defval);
	    PlayerPrefs.Save();

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
    }
         public void resetStats()
        {
              PlayerPrefs.DeleteAll();
              levval = 1;
              levval2 = 1;
              atval = 6;
              defval = 6;
              agval = 12;
              hpval = 15;
              mpval = 0;
              PlayerPrefs.SetInt("savedMP", mpval);
               promoted = false;
        promotedVal = 0;
        title1.SetActive(true);
        title2.SetActive(false);
        title.text = wfmn;
        PlayerPrefs.SetInt("promotedVal", promotedVal);
              level = GameObject.Find("level").GetComponent<Text>();
        levval += 0;
        level.text = levval.ToString();
        attack = GameObject.Find("attack").GetComponent<Text>();
        atval += 0;
        attack.text = atval.ToString();
        defense = GameObject.Find("defense").GetComponent<Text>();
        defval += 0;
        defense.text = defval.ToString();
        hp = GameObject.Find("hp").GetComponent<Text>();
        hpval += 0;
        hp.text = hpval.ToString();
        mp = GameObject.Find("mp").GetComponent<Text>();
        mpval += 0;
        mp.text = mpval.ToString();
        agility = GameObject.Find("agility").GetComponent<Text>();
        agval += 0;
        agility.text = agval.ToString();
        }

         void Update()
        {
            attack = GameObject.Find("attack").GetComponent<Text>();
        if (promotedVal == 0)
        {
            promoted = false;
        }
        else
        {
            promoted = true;
            title1.SetActive(false);
             title2.SetActive(true);
            title.text = wfbn;
        }
        attack.text = atval.ToString();
        defense.text = defval.ToString();
        agility.text = agval.ToString();
        hp.text = hpval.ToString();
        mp.text = mpval.ToString();
        level.text = levval.ToString();
        if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
        }
        
        
    
    
    }
    
}
