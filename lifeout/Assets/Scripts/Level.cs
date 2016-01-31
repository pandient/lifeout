using UnityEngine;
using System.Collections;

namespace lifeout.cultist {
    public class Level : MonoBehaviour {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Grid.GetLevelDone())
            {
                //LevelManager.LoadNextLevel();
                LevelManager.LoadLevel("Win");
                Grid.SetLevelDone(false);
                Grid.ClearGrid();
            }
        }
    }
}
