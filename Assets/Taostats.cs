using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Taostats : MonoBehaviour
{
    static System.Random rnd = new System.Random();
    int upattack;
    int updefense;
    int uphp;
    int upmp;
    int upagility;
    
    public Text title;
    
    public GameObject title1;
    public GameObject title2;
    public Text attack;
    public Text defense;
    public AudioSource hq;
    public AudioSource promotesound;
    public Text level;
    public Text hp;
    public Text mp;
    public Text agility;
    public int atval = 7;
    public int levval = 1;
    public int levval2;
    public int mpval = 8;
    public int defval =7;
    public int hpval = 14;
    public int agval = 6;
    public string mage = "MAGE Tao";
    public string wiz = "WIZD Tao";
    
    public GameObject promoteButton;
    public GameObject sleepImage;
    public GameObject sleepPill2;
     public GameObject blazePill2;
     public GameObject blazePill3;
     public GameObject blazePill4;
     public GameObject desoulImage;
     public GameObject desoulPill2;
    public bool promoted;
    public int promotedVal;
    public int blaze4Val;
    public int sleep2Val;
    public int desoul1Val;
    public int desoul2Val;
    public void Start()
    {    
       
        hq.Play();
        attack = GetComponent<Text>();
        if (PlayerPrefs.HasKey("TaosavedAttack"))
        {
        atval = PlayerPrefs.GetInt("TaosavedAttack");
        }
        else
        {
        atval = 5;

        }
        if (PlayerPrefs.HasKey("TaosavedLevel"))
        {
        levval = PlayerPrefs.GetInt("TaosavedLevel");
        levval2 = levval;
        }
        else
        {
        levval2 = 1;
        levval = levval2;
        }

        if (PlayerPrefs.HasKey("TaosavedHP"))
        {
        hpval = PlayerPrefs.GetInt("TaosavedHP");
        }
        else
        {
        hpval = 12;
        }

        if (PlayerPrefs.HasKey("TaosavedDefense"))
        {
        defval = PlayerPrefs.GetInt("TaosavedDefense");
        }
        else
        {
        defval = 5;
        }
        
        if (PlayerPrefs.HasKey("TaosavedMP"))
        {
        mpval = PlayerPrefs.GetInt("TaosavedMP");
        }
        else
        {
        mpval = 11;
        }

        if (PlayerPrefs.HasKey("TaosavedAgility"))
        {
        agval = PlayerPrefs.GetInt("TaosavedAgility");
        }
        else
        {
        agval = 10;
        }
        
         if (PlayerPrefs.HasKey("TaopromotedVal"))
        {
        promotedVal = PlayerPrefs.GetInt("TaopromotedVal");
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
        //spellllll//
        if (PlayerPrefs.HasKey("Taoblaze4Val"))
        {
        blaze4Val = PlayerPrefs.GetInt("Taoblaze4Val");
        }
        else
        {
        blaze4Val = 0;
        }

        if (PlayerPrefs.HasKey("Taosleep2Val"))
        {
        sleep2Val = PlayerPrefs.GetInt("Taosleep2Val");
        }
        else
        {
        sleep2Val = 0;
        }

        if (PlayerPrefs.HasKey("Taoblaze4Val"))
        {
        blaze4Val = PlayerPrefs.GetInt("Taoblaze4Val");
        }
        else
        {
        blaze4Val = 0;
        }

        if (PlayerPrefs.HasKey("Taodesoul1Val"))
        {
        desoul1Val = PlayerPrefs.GetInt("Taodesoul1Val");
        }
        else
        {
        desoul1Val = 0;
        }

        if (PlayerPrefs.HasKey("Taodesoul2Val"))
        {
        desoul2Val = PlayerPrefs.GetInt("Taodesoul2Val");
        }
        else
        {
        desoul2Val = 0;
        }

        if (blaze4Val == 0)
        {
            blazePill4.SetActive(false);
        }
        else
        {
            blazePill4.SetActive(true);
        }

        if (sleep2Val == 0)
        {
            sleepPill2.SetActive(false);
        }
        else
        {
            sleepPill2.SetActive(true);
        }

        if (desoul1Val == 0)
        {
            desoulImage.SetActive(false);
        }
        else
        {
            desoulImage.SetActive(true);
        }

        if (desoul2Val == 0)
        {
            desoulPill2.SetActive(false);
        }
        else
        {
            desoulPill2.SetActive(true);
        }
        //spell//
        if (promotedVal == 0)
        {
            promoted = false;
        }
        else
        {
            promoted = true;
        }
        if ((promoted == false) & (levval >= 5))
        {
            blazePill2.SetActive(true);
        }
     
        if (promoted == true)
        {
            blazePill3.SetActive(true);
            sleepImage.SetActive(true);
            desoulImage.SetActive(true);
            blazePill2.SetActive(true);
        }
        if ((promoted == false) & (levval >= 8))
        {
            blazePill3.SetActive(true);
        }
        if ((promoted == true) & (levval >= 6) || (promoted == false) & (levval >= 16))
       {
           blazePill4.SetActive(true);
           blaze4Val = 1;
           PlayerPrefs.SetInt("Taoblaze4Val", blaze4Val);
       }
       
       if ((promoted == false) & (levval >= 6))
       {
           sleepImage.SetActive(true);
       }
        if ((promoted == true) & (levval >= 8)|| (promoted == false) & (levval >= 18)) 
        {
           sleepPill2.SetActive(true);
           sleep2Val = 1;
           PlayerPrefs.SetInt("Taosleep2Val", sleep2Val);
       }
       if ((promoted == false) & (levval >= 10))
        {
            desoulImage.SetActive(true);
            desoul1Val = 1;
            PlayerPrefs.SetInt("Taodesoul1Val", desoul1Val);
        }
        if ((promoted == true) & (levval >= 12)|| (promoted == false) & (levval >= 22)) 
        {
           desoulPill2.SetActive(true);
           desoul2Val = 1;
           PlayerPrefs.SetInt("Taodesoul2Val", desoul2Val);
       }

        attack.text = atval.ToString();
        level.text = levval.ToString();
        mp.text = mpval.ToString();
        agility.text = agval.ToString();
        hp.text = hpval.ToString();
        defense.text = defval.ToString();
       
         if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
        }
        if (promoted = true);
        {
             title1.SetActive(false);
        title2.SetActive(true);
        title.text = mage;
        }
        promoted = false;
        title.text = wiz;
        title1.SetActive(true);
        title2.SetActive(false);

    }
    public void classChange()
    {       
       
           title1.SetActive(false);
           title2.SetActive(true);
           title.text = wiz;
        
    }

    public void promote()
       {   
        promoted = true;
        promotedVal = 1;
        PlayerPrefs.SetInt("TaopromotedVal", promotedVal);
        hq.Pause();
        promotesound.Play();     
        promoteButton.SetActive(false);
        levval = 0;
        levval2 = 0;
        PlayerPrefs.SetInt("TaosavedLevel", levval2);
        levelup();
        level = GetComponent<Text>();
        level.text = levval.ToString();
       } 
    
    public void levelup()
    {

       if (promoted == false)
        {
        upattack = rnd.Next(0, 2);
        updefense = rnd.Next(0, 2);
        uphp = rnd.Next(0, 3);
        upmp = rnd.Next(0, 3);
        upagility = rnd.Next(0, 3);
        }
        else
        {
        upattack = rnd.Next(0, 3);
        updefense = rnd.Next(0, 3);
        uphp = rnd.Next(0, 4);
        upmp = rnd.Next(0, 4);
        upagility = rnd.Next(0, 4);
        }
        levval = PlayerPrefs.GetInt("TaosavedLevel");
        levval = levval2;
        level = GameObject.Find("level").GetComponent<Text>();
        levval += 1;
        
        levval2 = levval;
        level.text = levval.ToString();
        PlayerPrefs.SetInt("TaosavedLevel", levval2);
	    PlayerPrefs.Save();
   
        attack = GameObject.Find("attack").GetComponent<Text>();
        atval += upattack;
        attack.text = atval.ToString();
        PlayerPrefs.SetInt("TaosavedAttack", atval);
	    PlayerPrefs.Save();

        mp = GameObject.Find("mp").GetComponent<Text>();
        mp.text = mpval.ToString();
        mpval += upmp;
        PlayerPrefs.SetInt("savedMP", mpval);
	    PlayerPrefs.Save();

        agility = GameObject.Find("agility").GetComponent<Text>();
        agility.text = agval.ToString();
        agval += upagility;
        PlayerPrefs.SetInt("TaosavedAgility", agval);
	    PlayerPrefs.Save();

        hp = GameObject.Find("hp").GetComponent<Text>();
        hp.text = hpval.ToString();
        hpval += uphp;
        PlayerPrefs.SetInt("TaosavedHP", hpval);
	    PlayerPrefs.Save();

        defense = GameObject.Find("defense").GetComponent<Text>();
        defense.text = defval.ToString();
        defval += updefense;
        PlayerPrefs.SetInt("TaosavedDefense", defval);
	    PlayerPrefs.Save();

        if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
        }
        if (promoted == true)
        {
        title.text = wiz;
        title1.SetActive(true);
        title2.SetActive(false);

            
        }
         if ((promoted == false) & (levval >= 5))
        {
            blazePill2.SetActive(true);
        }
     
        if ((promoted == false) & (levval >= 8))
        {
            blazePill3.SetActive(true);
        }
         if ((promoted == true) & (levval >= 6) || (promoted == false) & (levval >= 16))
       {
           blazePill4.SetActive(true);
           blaze4Val = 1;
           PlayerPrefs.SetInt("Taoblaze4Val", blaze4Val);
       }
       
       if ((promoted == false) & (levval >= 6))
       {
           sleepImage.SetActive(true);
       }
        if ((promoted == true) & (levval >= 8)|| (promoted == false) & (levval >= 18)) 
        {
           sleepPill2.SetActive(true);
           sleep2Val = 1;
           PlayerPrefs.SetInt("Taosleep2Val", sleep2Val);
       }
       if ((promoted == false) & (levval >= 10))
        {
            desoulImage.SetActive(true);
            desoul1Val = 1;
            PlayerPrefs.SetInt("Taodesoul1Val", desoul1Val);
        }
        if ((promoted == true) & (levval >= 12)|| (promoted == false) & (levval >= 22)) 
        {
           desoulPill2.SetActive(true);
           desoul2Val = 1;
           PlayerPrefs.SetInt("Taodesoul2Val", desoul2Val);
       }
    }  
       public void resetStats()
        {
              PlayerPrefs.DeleteAll();
              levval = 1;
              levval2 = 1;
              atval = 5;
              defval = 5;
              agval = 10;
              hpval = 12;
              mpval = 11;
              PlayerPrefs.SetInt("TaosavedMP", mpval);
               promoted = false;
               sleepImage.SetActive(false);
               sleepPill2.SetActive(false);
               desoulImage.SetActive(false);
               desoulPill2.SetActive(false);
               blazePill2.SetActive(false);
               blazePill3.SetActive(false);
               blazePill4.SetActive(false);
        promotedVal = 0;
        title1.SetActive(true);
        title2.SetActive(false);
        title.text = mage;
        PlayerPrefs.SetInt("TaopromotedVal", promotedVal);
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
            title.text = wiz;
            
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
