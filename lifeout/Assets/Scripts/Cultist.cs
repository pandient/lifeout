using UnityEngine;
using System.Collections;
using Debug = System.Diagnostics.Debug;

namespace lifeout.cultist 
{
    internal enum CultistState { DEAD, ALIVE }
    
    public class Cultist : MonoBehaviour
    {

        [SerializeField]
        CultistState State = CultistState.DEAD;

        [SerializeField]
        Sprite DeadSprite = null;

        [SerializeField]
        Sprite AliveSprite = null;

        [SerializeField]
        GameObject Aura = null;

        SpriteRenderer _renderer;

        void Start() {
            _renderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseUpAsButton() {
            if (State == CultistState.DEAD) {
                CreateResurrectionAura();
            }
            else {
                CreateDeathAura();
            }
        }

        void CreateResurrectionAura() {
            var aura = Instantiate(Aura, transform.position, transform.rotation) as GameObject;
            Debug.Assert(aura != null, "aura != null");
            //aura.transform.parent = transform;
            StartCoroutine(DestroyAura(aura));
        }

        void CreateDeathAura() {
            var aura = Instantiate(Aura, transform.position, transform.rotation) as GameObject;
            Debug.Assert(aura != null, "aura != null");
            aura.transform.parent = transform;
            StartCoroutine(DestroyAura(aura));
        }

        static IEnumerator DestroyAura (GameObject aura) {
            var animator = aura.GetComponent<Animator>();
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            Destroy(aura);
        }

        void OnTriggerEnter2D () {
            if (State == CultistState.DEAD) {
                State = CultistState.ALIVE;
                _renderer.sprite = AliveSprite;
            }
            else {
                State = CultistState.DEAD;
                _renderer.sprite = DeadSprite;
            }

        }

    }

}


