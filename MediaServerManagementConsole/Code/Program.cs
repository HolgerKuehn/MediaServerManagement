/// <copyright file="Program.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>

/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    /// <summary>
    /// Main Program
    /// manages the command line arguments and directs program work flow
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Program
        /// manages the command line arguments and directs program work flow
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            DataManager DataManager = new DataManager();
        }
    }
}