using UnityEngine;
using System.Collections;

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

        SpriteRenderer renderer;

        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseUpAsButton()
        {
            createResurrectionAura();
        }

        void OnTriggerEnter2D() {
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
            renderer.sprite = deadSprite;
        }

        private void resurrect()
        {
            this.state = CultistState.ALIVE;
            renderer.sprite = aliveSprite;
        }

        

        
    }
}


