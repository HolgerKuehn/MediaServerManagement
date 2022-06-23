/// <copyright file="JobSettingPasswordsafeType.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
namespace MediaServerManagement
{
    internal class JobSettingPasswordsafeType : JobSettingPasswordsafe
    {
        #region Attributes

        /// <summary>
        /// Type of Passwordsafe used
        /// </summary>
        private readonly string type;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSettingPasswordsafeType"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public JobSettingPasswordsafeType(DataManager dataManager, string type)
            : base(dataManager)
        {
            this.type = type;
        }

        #endregion

        #region Properties

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// executes Job
        /// </summary>
        /// <returns>error code of execution</returns>
        public override int ExecuteJob()
        {
            this.DataManager.PasswordsafeType = this.type;
            return 0;
        }

        #endregion
    }
}
