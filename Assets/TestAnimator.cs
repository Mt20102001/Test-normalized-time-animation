using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
	[SerializeField] private Animator _animator;

	[SerializeField]private float testNormalizeTime;

	[SerializeField] private float currentStateTime = 2f;
	[SerializeField] private float currentAnimtime;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		SetAnimation(currentStateTime, currentAnimtime);
		PlayAnim("Idle", 0, 0);
	}


	private void Update()
	{
		if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			testNormalizeTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			if(testNormalizeTime > 0.95f)
			{
				_animator.Play("Idle", 0, 0f);
			}
		}

		if(Input.GetKeyUp(KeyCode.Space))
		{
			PlayAnim("Idle", 0.5f, 0);
		}
	}

	//snippet
	//actual time for that interaction: x
	//anim time for that interaction: y
	// motion speed animation
	//if actual time is set at alpha -> current start normalize time of animator 



	private void SetAnimation(float actualTime, float actualAniamtionTime)
	{
		var animationSpeed = actualAniamtionTime/ actualTime;
		//setup anim speed to state 
		_animator.SetFloat("multiplier", animationSpeed);
	}


	private void PlayAnim(string state, float normalizeTime, int layer )
	{
		_animator.Play(state, layer, normalizeTime);
	}
	




	
}
