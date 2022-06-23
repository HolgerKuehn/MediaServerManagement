/// <copyright file="DataMangerStorageEngineText.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>

/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    /// <summary>
    /// abstract class for storage Engines
    /// </summary>
    internal class DataMangerStorageEngineText : DataMangerStorageEngine
    {
        #region Attributes

        /// <summary>
        /// base path to Programdata-directory used to store data
        /// </summary>
        private readonly string baseProgramDataPath;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// initializes configuration with settings-files
        /// </summary>
        public DataMangerStorageEngineText()
        {
            #region Paths

            this.baseProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\blog.dachs\\MediaServerManagement\\";

            #endregion
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets base path for storage in text files<br/>
        /// </summary>
        /// <returns>path to store text files</returns>
        public string BaseProgramDataPath
        {
            get
            {
                return this.baseProgramDataPath;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// reads data from storage
        /// </summary>
        /// <param name="dataName">name of object to be read</param>
        /// <returns>value of object</returns>
        public override string ReadData(string dataName)
        {
            return this.baseProgramDataPath;
        }

        /// <summary>
        /// write data from storage
        /// </summary>
        /// <param name="dataName">name of object to be written</param>
        /// <param name="dataValue">value of object to be written</param>
        public override void WriteData(string dataName, string dataValue)
        {
            return;
        }

        #endregion
    }
}
