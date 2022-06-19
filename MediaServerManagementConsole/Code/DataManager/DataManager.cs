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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public DataManager()
        {
            string plainText;
            string cypherText;

            #region StorageEngine
            this.storageEngines = new Dictionary<StorageEngine, DataMangerStorageEngine>();
            this.storageEngines.Add(StorageEngine.Text, new DataMangerStorageEngineText());
            this.primaryStorageEngine = StorageEngine.Text;

            plainText = "abc";
            cypherText = plainText.Encrypt();
            try
            {
                plainText = cypherText.Decrypt();
            }
            catch {
                plainText = "";
            }
            #endregion
        }

        #endregion

        #region Properties

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

        #endregion

    }
}
