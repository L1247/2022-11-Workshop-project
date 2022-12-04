#region

using System;

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
    #region Public Methods

        public void PlayAnimation(string animationName)
        {
            throw new NotImplementedException();
        }

    #endregion
    }
}