/// <copyright file="DataManager.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    /// <summary>
    /// provides management of program data
    /// </summary>
    internal abstract class Job
    {
        #region Attributes

        /// <summary>
        /// provides access to stored data
        /// </summary>
        private readonly DataManager dataManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public Job(DataManager dataManager)
        {
            #region DataManager

            this.dataManager = dataManager;

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the dataManager to access stored data<br/>
        /// </summary>
        /// <returns>current DataManager</returns>
        public DataManager DataManager
        {
            get
            {
                return this.dataManager;
            }
        }

        #endregion

        #region Methods

        #region

        /// <summary>
        /// executes Job
        /// </summary>
        /// <returns>error code of execution</returns>
        public abstract int ExecuteJob();

        #endregion
        #region static Factories

        static public Job JobFactory(DataManager dataManager, List<string> commandLineArguments)
        {
            #region declare variables

            Job job;
            string commandLineArgument;

            // extract first part of command
            if (commandLineArguments.Count >= 1)
            {
                commandLineArgument = commandLineArguments.First().ToLower();
            }
            else
            {
                commandLineArgument = "";
            }

            // prepare commandLineArguments for new factory
            if (commandLineArguments.Count > 0)
            {
                commandLineArguments.RemoveAt(0);
            }
            else
            {
                commandLineArguments = new List<string>();
            }

            #endregion

            #region create Jobs

            // send command to appropriate factory
            switch (commandLineArgument)
            {
                case "setting":
                    job = JobSetting.JobFactory(dataManager, commandLineArguments);
                    break;

                default:
                    job = new JobUnknown(dataManager);
                    break;
            }

            #endregion

            return job;
        }

        #endregion

        #endregion
    }
}
