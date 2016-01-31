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

        [SerializeField]
        ResurrectionAura aura;

        Object bob;

        // Use this for initialization

        SpriteRenderer renderer;
        Collider2D collider;

        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseUpAsButton()
        {
            //flip();
            createResurrectionAura();

        }

        void OnCollisionStay2D(Collision2D coll)
        {
            Debug.Log("asdfasd");
            flip();
            Destroy(bob);
        }

        void flip() {
            if (state == CultistState.ALIVE) {
                die();
            }
            else
            {
                resurrect();
            }
        }

        void createResurrectionAura() {
            bob = Instantiate(aura, transform.position, transform.rotation);
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


