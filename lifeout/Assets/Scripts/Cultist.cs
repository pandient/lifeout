using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace lifeout.cultist 
{

    enum CultistState { DEAD, ALIVE }
    
    public class Cultist : MonoBehaviour 
    {
        [SerializeField]
        CultistState state = CultistState.DEAD;

        [SerializeField]
        Sprite deadSprite;

        [SerializeField]
        Sprite aliveSprite;

        public ResurrectionAura aura;

        // Use this for initialization

        SpriteRenderer rend;

        void Start()
        {
            try
            {
                // Register in Grid
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                Debug.Log("" + x + " " + y);
                Grid.cultists.Add(new Vector2(x, y), this);
                rend = GetComponent<SpriteRenderer>();

                if(state  == CultistState.ALIVE)
                {
                    rend.sprite = aliveSprite;
                }else
                {
                    rend.sprite = deadSprite;
                }

            }
            catch (System.Exception e )
            {

                throw e;
            }
          
            
        }

        void OnMouseUpAsButton()
        {
           
                flip();
                int currentx = (int)transform.position.x;
                int currenty = (int)transform.position.y;
                flipSurrounding(currentx, currenty);
            
        }

        private void flipSurrounding(int currentx, int currenty)
        {
            List<Vector2> cultlist = new List<Vector2>();
            //cultlist.Add(Grid.cultists[new Vector2(currentx + 1, currenty + 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx - 1, currenty + 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx + 1, currenty - 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx - 1, currenty - 1)]);

            cultlist.Add(new Vector2(currentx - 1, currenty + 0));
            cultlist.Add(new Vector2(currentx + 0, currenty - 1));
            cultlist.Add(new Vector2(currentx - 0, currenty + 1));
            cultlist.Add(new Vector2(currentx + 1, currenty + 0));

            foreach (var v in cultlist)
            {
                if (Grid.cultists.ContainsKey(v)) {
                    Grid.cultists[v].flip();  
                }
            }

        }

        public void flip()
        {
            if (state == CultistState.ALIVE)
            {
                die();
            }
            else
            {
                resurrect();
            }
        }
        

        void createResurrectionAura() {
            Instantiate(aura, transform.position, transform.rotation);
           
        }

        private void die()
        {
            this.state = CultistState.DEAD;
            rend.sprite = deadSprite;
        }

        private void resurrect()
        {
            this.state = CultistState.ALIVE;
            rend.sprite = aliveSprite;
        }

        

        
    }
}


