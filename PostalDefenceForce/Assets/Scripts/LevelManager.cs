using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager instance {
        get {
            if(_instance == null){
                // Set instance (not monobehaviour)
                // _instance = new LevelManager();
                
                // If I don't exist, make a new one
                // Loads a prefab called "LevelManager" out of the resources folder 
                // (checks all folders called "Resources" in the assets folder)
                // I think this might break if you try to instantiate something on the first frame?
                _instance = Instantiate(
                    Resources.Load<GameObject>("LevelManager")
                ).GetComponent<LevelManager>();

                // Finds a game object in the scene called "LevelManager"
                // I think this might break if you try to instantiate something on the first frame?
                _instance = GameObject.Find("LevelManager").GetComponent<LevelManager>();

                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    

    private void Awake(){
        if(_instance != null){
            Destroy(this); // There is already an instance of LevelManager, and there should only ever be 1
        }

        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    public int enemyCount = 0;

    // public List<PlayerController> playerControllerListWeeew = new List<PlayerController>();
}
