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
    }

}
