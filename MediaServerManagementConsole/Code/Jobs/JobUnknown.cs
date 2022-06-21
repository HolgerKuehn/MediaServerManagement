/// <copyright file="DataManager.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    internal class JobUnknown : Job
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobUnknown"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public JobUnknown(DataManager dataManager)
            : base(dataManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// executes Job
        /// writes Message on Console
        /// </summary>
        /// <returns>error code of execution</returns>
        public override int ExecuteJob()
        {
            Console.WriteLine("Command unknown");

            return 1;
        }

        #endregion
    }
}
