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
    internal class DataManager
    {
        #region Enums

        /// <summary>
        /// List of StorageEngines supported.
        /// </summary>
        public enum StorageEngine
        {
            /// <summary>
            /// uses text-files to store the data
            /// </summary>
            Text
        }

        #endregion

        #region Attributes

        /// <summary>
        /// stores configured passwordsafe type
        /// </summary>
        private string passwordsafeType;

        /// <summary>
        /// defines, what storage engine is used
        /// </summary>
        /// <remarks>
        /// supported storage engines
        /// - Text
        /// </remarks>
        private StorageEngine primaryStorageEngine;

        /// <summary>
        /// provides access to all configured storage engines
        /// </summary>
        private Dictionary<StorageEngine, DataMangerStorageEngine> storageEngines;

        /// <summary>
        /// list of jobs to be executed
        /// </summary>
        private readonly List<Job> jobs;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public DataManager()
        {
            #region StorageEngine

            this.storageEngines = new Dictionary<StorageEngine, DataMangerStorageEngine>();
            this.storageEngines.Add(StorageEngine.Text, new DataMangerStorageEngineText());
            this.primaryStorageEngine = StorageEngine.Text;

            #endregion

            # region Jobs

            this.jobs = new List<Job>();

            #endregion
        }

        #endregion

        #region Properties

        public string PasswordsafeType
        {
            get
            {
                return this.passwordsafeType;
            }

            set
            {
                this.passwordsafeType = value;
            }
        }



        /// <summary>
        /// Gets and sets type of storage engine used<br/>
        /// </summary>
        /// <returns>type of storage engine used</returns>
        public StorageEngine PrimaryStorageEngine
        {
            get {
                return this.primaryStorageEngine;
            }

            set
            {
                this.primaryStorageEngine = value;
            }
        }


        /// <summary>
        /// Gets list of jobs to be executed<br/>
        /// </summary>
        /// <returns>list of jobs</returns>
        public List<Job> Jobs
        {
            get
            {
                return this.jobs;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// executes Job
        /// writes Message on Console
        /// </summary>
        /// <returns>error code of execution</returns>
        public int ExecuteJobs()
        {
            // declare local variables
            int errorcode;

            // initialize value
            errorcode = 0;

            // execute jobs
            foreach (Job job in this.Jobs)
            {
                errorcode = job.ExecuteJob();

                if (errorcode != 0)
                    break;
            }

            return errorcode;
        }

        #endregion
    }
}
