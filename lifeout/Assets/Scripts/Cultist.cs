using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lifeout.cultist 
{

    enum CultistState { DEAD, ALIVE }
    
    public class Cultist : MonoBehaviour 
    {
        [SerializeField]
        CultistState State = CultistState.DEAD;

        [SerializeField]
        Sprite DeadSprite;

        [SerializeField]
        Sprite AliveSprite;

        [SerializeField]
        GameObject Aura;

        // Use this for initialization

        SpriteRenderer _renderer;

        void Start()
        {
            try
            {
                // Register in Grid
                var x = (int)transform.position.x;
                var y = (int)transform.position.y;
                Debug.Log("" + x + " " + y);
                Grid.cultists.Add(new Vector2(x, y), this);
                _renderer = GetComponent<SpriteRenderer>();
                _renderer.sprite = State  == CultistState.ALIVE ? AliveSprite : DeadSprite;

            }
            catch (Exception) {
                // ignored
            }
        }

        void OnMouseUpAsButton()
        {
            CreateAura();
            Flip();
            var currentx = (int)transform.position.x;
            var currenty = (int)transform.position.y;
            FlipSurrounding(currentx, currenty);
            
        }

        static void FlipSurrounding(int currentx, int currenty)
        {
            var cultlist = new List<Vector2> {
                new Vector2(currentx - 1, currenty + 0),
                new Vector2(currentx + 0, currenty - 1),
                new Vector2(currentx - 0, currenty + 1),
                new Vector2(currentx + 1, currenty + 0)
            };
            //cultlist.Add(Grid.cultists[new Vector2(currentx + 1, currenty + 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx - 1, currenty + 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx + 1, currenty - 1)]);
            //cultlist.Add(Grid.cultists[new Vector2(currentx - 1, currenty - 1)]);


            var checkWin = true;
            foreach (var v in cultlist.Where(v => Grid.cultists.ContainsKey(v))) {
                Grid.cultists[v].Flip();
                if (Grid.cultists[v].IsAlive()) {
                    checkWin = false;
                }
            }
            if (checkWin)
            {
                Grid.isFinished();
            }

        }


        public void Flip()
        {
            if (State == CultistState.ALIVE)
            {
                Die();
            }
            else
            {
                Resurrect();
            }
        }
        

        void CreateAura() {
            var aura = Instantiate(Aura, transform.position, transform.rotation) as GameObject;
            GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyAura(aura));
        }

        static IEnumerator DestroyAura(GameObject aura) {
            var animator = aura.GetComponent<Animator>();
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Destroy(aura);
        }

        void Die()
        {
            State = CultistState.DEAD;
            _renderer.sprite = DeadSprite;
        }

        void Resurrect()
        {
            State = CultistState.ALIVE;
            _renderer.sprite = AliveSprite;
        }

        public bool IsAlive()
        {
            return State.Equals(CultistState.ALIVE);
        }

        
    }
}


