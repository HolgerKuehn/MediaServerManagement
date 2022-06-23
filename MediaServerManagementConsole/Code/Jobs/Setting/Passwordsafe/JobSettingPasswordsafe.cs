/// <copyright file="JobSettingPasswordsafe.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
namespace MediaServerManagement
{
    internal abstract class JobSettingPasswordsafe : JobSetting
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSettingPasswordsafe"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public JobSettingPasswordsafe(DataManager dataManager)
            : base(dataManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// executes Job
        /// </summary>
        /// <returns>error code of execution</returns>
        public override int ExecuteJob()
        {

            return 0;
        }

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
                case "type":
                    job = new JobSettingPasswordsafeType(dataManager, commandLineArgument);
                    break;

                default:
                    job = new JobUnknown(dataManager);
                    ((JobUnknown)job).PossibleCommands = new List<string>();
                    ((JobUnknown)job).PossibleCommands.Add(commandLineArgument);
                    ((JobUnknown)job).PossibleCommands.Add("Setting Passwordsafe");
                    break;
            }

            #endregion

            return job;
        }

        #endregion
        #endregion
    }
}
