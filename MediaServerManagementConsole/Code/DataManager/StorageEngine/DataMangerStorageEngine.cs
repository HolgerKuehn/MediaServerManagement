/// <copyright file="DataMangerStorageEngine.cs" company="dachs.blog">
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
    abstract internal class DataMangerStorageEngine
    {
        #region Methods

        /// <summary>
        /// reads data from storage
        /// </summary>
        /// <param name="dataName">name of object to be read</param>
        /// <returns>value of object</returns>
        public abstract string ReadData(string dataName);

        /// <summary>
        /// write data from storage
        /// </summary>
        /// <param name="dataName">name of object to be written</param>
        /// <param name="dataValue">value of object to be written</param>
        public abstract void WriteData(string dataName, string dataValue);

        #endregion
    }
}
