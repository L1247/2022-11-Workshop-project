#region

using UnityEngine;

#endregion

namespace GameJam.Core
{
    public interface IUnityComponent
    {
    #region Public Methods

        void PlayAnimation(string animationName);

    #endregion
    }

    public class UnityComponent : IUnityComponent
    {
    #region Private Variables

        private readonly Animator animator;

    #endregion

    #region Constructor

        public UnityComponent(Animator animator)
        {
            this.animator = animator;
        }

    #endregion

    #region Public Methods

        public void PlayAnimation(string animationName)
        {
            animator.Play(animationName);
        }

    #endregion
    }
}