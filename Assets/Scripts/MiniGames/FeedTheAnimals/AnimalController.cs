using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimalController : MonoBehaviour
{
    public string AnimalName;

    private AnimationClip currentAnimation;

    private Animation animComponent;

    private GameObject pointerArrow;

    private bool pointerActive;

    private GameObject foodSpawn;

    public GameObject targetFood;

    public GameObject poofEffect;

    private bool canLoopAnim;

    private bool canBeFed;

    void Start()
    {
        animComponent = this.GetComponent<Animation>();

        if (animComponent == null)
        {
            Debug.Log("ERROR! Animation component not attached!");
        }
        else {

            currentAnimation = animComponent.clip;
        }

        pointerArrow = this.transform.GetChild(0).gameObject;
        foodSpawn = this.transform.GetChild(1).gameObject;

        pointerActive = false;

        canLoopAnim = true;
    }

    void Update()
    {
        if (!animComponent.isPlaying && canLoopAnim) {

            animComponent.Play();
        }

        if (this.pointerArrow.activeInHierarchy && !pointerActive) {
            pointerActive = true;
            arrowAnimation();
        }
    }

    public IEnumerator setAnimation(string targetAnim, float delay, float fade, bool canLoop) {
        yield return new WaitForSeconds(delay);
        currentAnimation = animComponent.GetClip(targetAnim);
        animComponent.clip = currentAnimation;
        animComponent.CrossFade(targetAnim, fade);
        canLoopAnim = canLoop;
    }

    private void OnMouseOver()
    {
        if(canBeFed)

        pointerArrow.SetActive(true);

        if (Input.GetMouseButtonDown(0)) {

            GameObject _poofEffect = Instantiate(poofEffect, foodSpawn.transform.position, Quaternion.identity);
            GameObject _targetFood = Instantiate(targetFood, foodSpawn.transform.position, Quaternion.identity);
            _targetFood.transform.DORotate(new Vector3(90f, 0f, 0f), 0f);
            StartCoroutine(this.setAnimation("Eating", 1f, 0.45f, true));
            Destroy(_poofEffect, 1f);
            Destroy(_targetFood, 3f);
        }
    }

    private void arrowAnimation() {
        this.pointerArrow.transform.DORotate(new Vector3(0f, 200f, 90f), 1f).OnComplete(() => {
            pointerActive = false;
            this.pointerArrow.transform.DORotate(new Vector3(0f, 0f, 90f), 0f);
        });
    }

    private void OnMouseExit()
    {
        pointerArrow.SetActive(false);
        this.pointerArrow.transform.DORotate(new Vector3(0f, 0f, 90f), 0f);
    }

    public void setCanBeFed(bool canBeFed) {

        this.canBeFed = canBeFed;
    }
}
