using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 1;
    [SerializeField] int currentEXP = 0;
    [SerializeField] int nextLevelEXP = 10;
    [SerializeField] int currentLevel = 1;
    
    public int levelToReachForQuest = 3;


    public static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                _instance = playerObject.GetComponent<Player>();
            }

            return _instance;
        }

    }

    public int EXP
    {
        get => currentEXP;
        set
        {
            currentEXP = value;
            OnEXPChanged.Invoke(currentEXP);
        }

    }

    public int Lvl
    {
        get => currentLevel;
        set
        {
            currentLevel = value;
            OnLevelChanged.Invoke(currentLevel);
        }

    }

    public int NextLvlEXPRequired
    {
        get => nextLevelEXP;
        set
        {
            nextLevelEXP = value;
        }

    }

    public delegate void OnLevelChangedFuntion(int newLevel);
    public event OnLevelChangedFuntion OnLevelChanged;

    public delegate void OnEXPChangedFuntion(int newEXP);
    public event OnEXPChangedFuntion OnEXPChanged;


    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;

        transform.Translate(horizontal, 0, vertical);

        
    }
}
