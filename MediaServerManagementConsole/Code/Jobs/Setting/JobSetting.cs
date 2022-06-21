/// <copyright file="JobSetting.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    internal class JobSetting : Job
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSetting"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public JobSetting(DataManager dataManager)
            : base(dataManager)
        {
        }

        #endregion

        #region Methods

        #region static Factories

        static new public Job JobFactory(DataManager dataManager, List<string> commandLineArguments)
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
