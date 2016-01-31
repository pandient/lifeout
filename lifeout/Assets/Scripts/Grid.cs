using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace lifeout.cultist
{

    public class Grid
    {

        // The Grid itself
        public static int w = 8; // this is the width
        public static int h = 8; // this is the height
        public static Dictionary<Vector2 ,Cultist> cultists = new Dictionary<Vector2, Cultist>();
        private static Boolean done = false;

        public static Boolean isFinished() {
            foreach (var item in cultists)
            {
                if (item.Value.isAlive())
                {
                    return false;
                }
            }
            done = true;
            return true;
        }

        public static Boolean GetLevelDone()
        {
            return done;
        }

        public static void SetLevelDone(Boolean value)
        {
            done = value;
        }

        public static void ClearGrid()
        {
            cultists.Clear();
        }
    }

}
